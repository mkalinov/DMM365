using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DMM365.Helper;
using DMM365.DataContainers;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.CrmConnectControl;
using LoginCustom;
using Microsoft.Crm.Sdk.Messages;


//using System.Windows;
//using System.Windows.Forms.Integration;
//using System.Windows.Media;

namespace DMM365
{

    public partial class MainForm : Form
    {

        #region Declarations

        AllSettings allSettings;
        //IEnumerable<KeyValuePair<int, string>> listOperators_DS;
        IEnumerable<KeyValuePair<int, string>> listAuthType_DS;
        CrmServiceClient crmServiceClientSource;
        DataEntities listOfData_DS;
        SchemaEntities listOfEntities_DS;
        bool isCreate;
        BindingSource bindings_Settings;
        //a compilation of OOB fields common in all entities in the schema
        List<SchemaField> FieldFilterList = new List<SchemaField>();
        //for drag and drop source
        List<SchemaField> SelectedFieldsAdvanced = new List<SchemaField>();
        Dictionary<Guid, queryContainer> viewsContainers = new Dictionary<Guid, queryContainer>();

        string[] buttons = new string[] { "btnProject", "btnProjectLoad", "btnLoadSchema", "btnProjectSaveAndNext", "btnTestConnSource", "btnCopyToolBack", "btnCopyToolFromSource", "btnCopyToolFromModified", "btnViewsBack", "btnSaveModifyViewsFile", "btnViewNext" };

        #region Attachments

        CrmServiceClient crmTarget;
        List<CrmEntityContainer> sourcePortals;
        List<CrmEntityContainer> targetPortals;

        #endregion Attachments


        #region Saved Views

        BindingSource bindings_DefaultViewsSchema;
        BindingSource bindings_SelectedEntitiesViews;
        BindingSource bindings_SavedUserViews;
        BindingSource bindings_SelectedSavedUserViews_DS;

        List<SchemaEntity> DefaultViewsSchema_DS;
        List<SchemaEntity> SelectedEntitiesViews_DS = new List<SchemaEntity>();
        List<CrmEntityContainer> SavedUserViews_DS = new List<CrmEntityContainer>();
        List<CrmEntityContainer> SelectedSavedUserViews_DS = new List<CrmEntityContainer>();

        #endregion Saved Views


        #endregion Declarations


        #region Form Global

        public MainForm()
        {
            InitializeComponent();

            allSettings = new AllSettings();
            bindings_Settings = new BindingSource();
            bindings_Settings.DataSource = allSettings;

            //listOperators_DS = enumToList.Of<listSelectionOperators>(true);
            listAuthType_DS = enumToList.Of<Microsoft.Xrm.Tooling.Connector.AuthenticationType>(true);
            //set select oprators drop down. Simplify, not need the operators fo visualized selection
            //setOperatorsDropDown(ddlAuthType, listAuthType_DS);


            #region Bindings

            tbxProject.DataBindings.Add("Text", bindings_Settings, "ProjectPath", false, DataSourceUpdateMode.OnPropertyChanged);
            //tbxOrgNameSource.DataBindings.Add("Text", bindings_Settings, "OrgUniqueNameSource", false, DataSourceUpdateMode.OnPropertyChanged);
            //tbxServerUrlSource.DataBindings.Add("Text", bindings_Settings, "ServerUrlSource", false, DataSourceUpdateMode.OnPropertyChanged);
            //tbxUsernameSource.DataBindings.Add("Text", bindings_Settings, "UsernameSource", false, DataSourceUpdateMode.OnPropertyChanged);
            //tbxPasswordSource.DataBindings.Add("Text", bindings_Settings, "PasswordSource", false, DataSourceUpdateMode.OnPropertyChanged);

            #endregion Bindings

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //property changed notification
            allSettings.PropertyChanged += AllSettings_PropertyChanged;
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            //save tab
            SettingsHelper.saveProject(allSettings);

            moveNextTab(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //save tab
            SettingsHelper.saveProject(allSettings);

            moveNextTab(1);
        }

        private void loadProject()
        {
            //deserialize source schema
            listOfEntities_DS = IOHelper.DeserializeXmlFromFile<SchemaEntities>(IOHelper.getProjectSubfolderPath(allSettings, subFolders.SchemaFileSource, fileName.dataSchemaXml));
            //deserialise source data file
            listOfData_DS = IOHelper.DeserializeXmlFromFile<DataEntities>(IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileSource, fileName.dataFileXml));

            loadViewsConfiguration();

        }



        private void linkSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ReferenceEquals(crmServiceClientSource, null) && crmServiceClientSource.IsReady)
                System.Diagnostics.Process.Start(crmServiceClientSource.CrmConnectOrgUriActual.Scheme + "://" + crmServiceClientSource.CrmConnectOrgUriActual.DnsSafeHost);
        }

        private void linkTarget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ReferenceEquals(crmTarget, null) && crmTarget.IsReady)
                System.Diagnostics.Process.Start(crmTarget.CrmConnectOrgUriActual.Scheme + "://" + crmTarget.CrmConnectOrgUriActual.DnsSafeHost);
        }


        #endregion Form Global


        private void AllSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                switch (e.PropertyName)
                {
                    case "ProjectPath":
                        {
                            try
                            {
                                SettingsHelper.projectFileLoad(allSettings);
                                bindings_Settings.ResetBindings(false);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                tbxProject.Text = string.Empty;
                                return;
                            }
                            //set directories if not there
                            IOHelper.setInnerProjectStructure(allSettings);
                            //
                            updateProjectTree();

                            //check project mode
                            if (!isCreate) loadProject();
                        }
                        break;

                    case "IsDirty":
                        // btnConnectionsSaveNext.Enabled = allSettings.IsDirty;
                        break;

                    default: break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region Project Tab


        private void cbxCreateProject_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;
            //show/enable groups
            groupViewDataFilter.Enabled = groupCopyToolContent.Enabled = groupProjectSchema.Visible = cb.Checked;

            cbxLoadProject.Enabled = cbxAttachmentsMigration.Enabled = !cb.Checked;

            if (!cb.Checked) return;


            //create project
            if (folderBrowserDialogLoadProject.ShowDialog() == DialogResult.OK)
            {
                //project mode
                isCreate = true;

                tbxProject.Text = folderBrowserDialogLoadProject.SelectedPath;
            }


            //get crm connection
            crmServiceClientSource = getCrmConnectionOOB();
            //update header
            if (crmServiceClientSource.IsReady)
            {
                linkSource.Text = string.Format(linkSource.Text, crmServiceClientSource.ConnectedOrgFriendlyName, crmServiceClientSource.CrmConnectOrgUriActual.Scheme + "://" + crmServiceClientSource.CrmConnectOrgUriActual.DnsSafeHost);
                groupConnectedTo.Visible = linkSource.Visible = crmServiceClientSource.IsReady;
            }

            //load configuration migration tool package
            if (openFileDialogLoadSchema.ShowDialog() == DialogResult.OK)
            {
                //check if loaded file is zip
                if (Path.GetExtension(openFileDialogLoadSchema.FileName) != ".zip")
                {
                    MessageBox.Show("The file is not a Zip archive");
                    return;
                }
                if (!ArchiveHelper.isFileInZipArchive(openFileDialogLoadSchema.FileName, "data_schema.xml")
                    || !ArchiveHelper.isFileInZipArchive(openFileDialogLoadSchema.FileName, "data.xml")
                    || !ArchiveHelper.isFileInZipArchive(openFileDialogLoadSchema.FileName, @"[Content_Types].xml"))
                {
                    MessageBox.Show("The file is not a valid MS SDK Configuration Manager package");
                    return;
                }
                //copy package to ExportPackageZip folder
                IOHelper.copyFile(openFileDialogLoadSchema.FileName, IOHelper.getProjectSubfolderPath(allSettings, subFolders.ExportPackageZip, fileName.appendFolderNameDotZip), true);

                //unzip schema and data
                ArchiveHelper.ExtractZipContentByFileName(IOHelper.getProjectSubfolderPath(allSettings, subFolders.ExportPackageZip, fileName.appendFolderNameDotZip)
                    , "data_schema.xml", IOHelper.getProjectSubfolderPath(allSettings, subFolders.SchemaFileSource, fileName.dataSchemaXml));

                ArchiveHelper.ExtractZipContentByFileName(IOHelper.getProjectSubfolderPath(allSettings, subFolders.ExportPackageZip, fileName.appendFolderNameDotZip)
                    , "data.xml", IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileSource, fileName.dataFileXml));

                ArchiveHelper.ExtractZipContentByFileName(IOHelper.getProjectSubfolderPath(allSettings, subFolders.ExportPackageZip, fileName.appendFolderNameDotZip)
                    , @"[Content_Types].xml", IOHelper.getProjectSubfolderPath(allSettings, subFolders.ContentTypeSource, fileName.contentTypesXml));



                updateProjectTree();


                loadProject();
            }


            //move to views tab
            moveNextTab(1);

        }

        private void cbxLoadProject_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;
            //show/enable groups
            groupViewDataFilter.Enabled = groupCopyToolContent.Enabled = groupProjectSchema.Visible = cb.Checked;

            cbxCreateProject.Enabled = cbxAttachmentsMigration.Enabled = !cb.Checked;


            if (!cb.Checked) return;


            //get crm connection
            crmServiceClientSource = getCrmConnectionOOB();
            //update header
            if (crmServiceClientSource.IsReady)
            {
                linkSource.Text = string.Format(linkSource.Text, crmServiceClientSource.ConnectedOrgFriendlyName, crmServiceClientSource.CrmConnectOrgUriActual.Scheme + "://" + crmServiceClientSource.CrmConnectOrgUriActual.DnsSafeHost);
                groupConnectedTo.Visible = linkSource.Visible = crmServiceClientSource.IsReady;
            }

            //load project
            if (openFileLoadProject.ShowDialog() == DialogResult.OK)
            {
                //project mode
                isCreate = false;

                tbxProject.Text = Path.GetDirectoryName(openFileLoadProject.FileName);
            }

            //move to views tab
            moveNextTab(1);
        }

        private void cbxAttachmentsMigration_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            cbxCreateProject.Enabled = cbxLoadProject.Enabled = !cb.Checked;

            if (!cb.Checked) return;


            //get crm connection
            crmServiceClientSource = getCrmConnectionOOB();
            //update header
            if (crmServiceClientSource.IsReady)
            {
                linkSource.Text = string.Format(linkSource.Text, crmServiceClientSource.ConnectedOrgFriendlyName, crmServiceClientSource.CrmConnectOrgUriActual.Scheme + "://" + crmServiceClientSource.CrmConnectOrgUriActual.DnsSafeHost);
                linkSource.Visible = crmServiceClientSource.IsReady;

            }
            crmTarget = getCrmConnectionOOB();
            //update header
            if (crmTarget.IsReady)
            {
                string.Format(linkTarget.Text, crmTarget.ConnectedOrgFriendlyName, crmTarget.CrmConnectOrgUriActual.Scheme + "://" + crmTarget.CrmConnectOrgUriActual.DnsSafeHost);
                linkTarget.Visible = crmTarget.IsReady;
            }
            groupConnectedTo.Visible = crmServiceClientSource.IsReady && crmTarget.IsReady;



            cbxBasedOnFiles.Enabled = cbxFromPortalToPortal.Enabled = cbxAttachmentsRollback.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxAttachmentsKeepIDs.Checked = cbxIncludeTextNotes.Checked = cbxAttachmentsRollback.Checked =  cbxFromPortalToPortal.Checked = cbxBasedOnFiles.Checked = cb.Checked;
            }

        }

        private void updateProjectTree()
        {
            if (!Directory.Exists(allSettings.ProjectPath)) return;
            DirectoryInfo inf = new DirectoryInfo(allSettings.ProjectPath);
            treeProject.Nodes.Clear();
            treeProject.Nodes.Add(treeHelper.CreateDirectoryNode(inf));
            treeProject.Nodes[0].Expand();
        }


        #region Connection 


        private CrmServiceClient getCrmConnectionOOB()
        {

            CrmServiceClient current = null;
            //window to back
            this.TopMost = false;

            CRMLogin login = new CRMLogin();
            login.ShowDialog();
            //lgin.ConnectionToCrmCompleted += Lgin_ConnectionToCrmCompleted;

            if (login.CrmConnectionMgr != null && login.CrmConnectionMgr.CrmSvc != null && login.CrmConnectionMgr.CrmSvc.IsReady)
            {
                try
                {
                    WhoAmIResponse wai = (WhoAmIResponse)login.CrmConnectionMgr.CrmSvc.Execute(new WhoAmIRequest());
                    current = login.CrmConnectionMgr.CrmSvc;
                }
                catch (Exception)
                {
                    //TO DO: logs
                }

            }

            //window to front
            this.TopMost = true;

            return current;
        }


        #endregion Connection 


        #endregion Project Tab


        #region Saved Views Tab 


        #region buttons

        private void btnSaveModifyViewsFile_Click(object sender, EventArgs e)
        {
            if (lstListOfViewsFilters.Items.Count == 0)
            {
                allSettings.SelectedUserQueries = null;
                SettingsHelper.saveProject(allSettings);
                return;
            }


            try
            {
                allSettings.SelectedUserQueries = new List<selectedQuery>();
                //get selected queries


                foreach (CrmEntityContainer item in lstListOfViewsFilters.Items)
                {
                    queryContainer current = viewsContainers[item.id];
                    if (ReferenceEquals(current, null))
                    {
                        MessageBox.Show("Cannot find '" + item.name + "' view");
                        return;
                    }

                    saveViewToSettings(current, item.id);
                }

                //save tab
                SettingsHelper.saveProject(allSettings);



                //execute views, get and merge all guids, exclude results based on ExcludeFromResults property of container
                List<Guid> ids = CrmHelper.getIdsFromViewsExecution(crmServiceClientSource, viewsContainers);

                //file create an object for transformation
                DataEntities raw = IOHelper.DeserializeXmlFromFile<DataEntities>(IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileSource, fileName.dataFileXml));


                foreach (DataEntity comparer in listOfData_DS.entities)
                {

                    //switch (ddlViewsActionOperator.Text)
                    //{
                    //    case "Selected Only":

                    if (comparer.RecordsCollection.All(r => !ids.Contains(new Guid(r.id), new GuidEqualityComparer())))
                        raw.entities.RemoveAll(d => d.name == comparer.name);
                    else
                        raw.entities.SingleOrDefault(d => d.name == comparer.name).RecordsCollection.RemoveAll(r => !ids.Contains(new Guid(r.id), new GuidEqualityComparer()));

                    //    break;
                    //case "All Except Selected":

                    //if (comparer.RecordsCollection.All(r => ids.Contains(new Guid(r.id), new GuidEqualityComparer())))
                    //    raw.entities.RemoveAll(d => d.name == comparer.name);
                    //else
                    //    raw.entities.SingleOrDefault(d => d.name == comparer.name).RecordsCollection.RemoveAll(r => ids.Contains(new Guid(r.id), new GuidEqualityComparer()));

                    //        break;

                    //    default: break;
                    //}
                }

                //clear DataFileByViews folder
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileByViews, fileName.pathToFolderFromProjectRoot));

                //save file
                IOHelper.SerializeObjectToXmlFile<DataEntities>(raw, IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileByViews, fileName.dataFileXml));

                //create import package
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.ImportPackageZipByViews, fileName.pathToFolderFromProjectRoot));
                //clear temp folder
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot));

                //copy to temp folder
                copyFilesToImportZipPackage(subFolders.DataFileByViews, subFolders.TempFolder);
                //create package
                ArchiveHelper.CreateZipFromDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot), IOHelper.getProjectSubfolderPath(allSettings, subFolders.ImportPackageZipByViews, fileName.appendFolderNameDotZip));

                //clear temp folder
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot));

                updateModifiedDataMonitorViewsTab();

                MessageBox.Show("Package is ready for import");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }

        }
        

        private void btnbtnViews_FromDefaultToSelected_Click(object sender, EventArgs e)
        {
            moveListBoxItems(lstDefaultSchemaDataByViews, DefaultViewsSchema_DS, bindings_DefaultViewsSchema, SelectedEntitiesViews_DS, bindings_SelectedEntitiesViews);
            updateViewsTabDependencies();
        }

        private void btnViews_ReturnToDefaultFromSelected_Click(object sender, EventArgs e)
        {
            moveListBoxItems(lstSelectedSchemaDataByViews, SelectedEntitiesViews_DS, bindings_SelectedEntitiesViews, DefaultViewsSchema_DS, bindings_DefaultViewsSchema);
            updateViewsTabDependencies();
        }

        #endregion buttons


        #region ListBoxes


        private void lstSelectedSchemaDataByViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox ents = sender as ListBox;
            if (ReferenceEquals(ents, null)) return;

            SchemaEntity ent = ents.SelectedItem as SchemaEntity;
            if (ReferenceEquals(ent, null)) return;

            bindings_SavedUserViews = new BindingSource();
            bindings_SavedUserViews.DataSource = CrmHelper.getUserQueryListWraped(crmServiceClientSource, ent.etc);
            lstViewsPerEntity.DataSource = bindings_SavedUserViews;
            lstViewsPerEntity.DisplayMember = "name";

            bindings_SavedUserViews.ResetBindings(false);
        }

        private void lstViewsPerEntity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox lst = sender as ListBox;
            if (ReferenceEquals(lst, null)) return;

            int index = lst.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                CrmEntityContainer selected = lst.Items[index] as CrmEntityContainer;
                if (ReferenceEquals(selected, null)) return;
                else
                {
                    if (!SelectedSavedUserViews_DS.Contains(selected, new CrmEntityContainerEqualityComparers()))
                    {
                        SelectedSavedUserViews_DS.Add(selected);
                        bindings_SelectedSavedUserViews_DS.DataSource = SelectedSavedUserViews_DS;
                        lstListOfViewsFilters.DataSource = bindings_SelectedSavedUserViews_DS;
                        bindings_SelectedSavedUserViews_DS.ResetBindings(false);

                        addView(selected);
                        loadView(selected);
                    }
                }
            }
        }

        private void lstListOfViewsFilters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (ReferenceEquals(lb, null)) return;

            int index = lb.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                CrmEntityContainer selected = lb.Items[index] as CrmEntityContainer;
                if (ReferenceEquals(selected, null)) return;
                else
                {
                    SelectedSavedUserViews_DS.Remove(selected);
                    bindings_SelectedSavedUserViews_DS.DataSource = SelectedSavedUserViews_DS;
                    lstListOfViewsFilters.DataSource = bindings_SelectedSavedUserViews_DS;
                    bindings_SelectedSavedUserViews_DS.ResetBindings(false);
                }
            }
        }

        private void lstListOfViewsFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox current = sender as ListBox;
            if (ReferenceEquals(current, null)) return;

            CrmEntityContainer view = current.SelectedItem as CrmEntityContainer;
            if (ReferenceEquals(view, null)) return;

            loadView(view);
        }


        #endregion ListBoxes


        #region Transformation Settings Changed


        private void transformationSettings_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            CrmEntityContainer view = lstListOfViewsFilters.SelectedItem as CrmEntityContainer;
            if (!ReferenceEquals(view, null))
            {
                queryContainer qc = getView(view.id);
                if (!ReferenceEquals(qc, null)) saveAndReloadView();
            }
        }



        #endregion Transformation Settings Changed


        #endregion Saved Views Tab 


        #region Copy Tool


        private void btnCopyToolFromSource_Click(object sender, EventArgs e)
        {
            try
            {
                ReplaceIDHelper.replaceGuids(IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileSource, fileName.dataFileXml), IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileByCopyTool, fileName.dataFileXml));

                //create import package
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.ImportPackageZipByCopyToolFromOrigin, fileName.pathToFolderFromProjectRoot));
                //clear temp folder
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot));

                //copy to temp folder
                copyFilesToImportZipPackage(subFolders.DataFileSource, subFolders.TempFolder);
                //create import package
                ArchiveHelper.CreateZipFromDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot), IOHelper.getProjectSubfolderPath(allSettings, subFolders.ImportPackageZipByCopyToolFromOrigin, fileName.appendFolderNameDotZip));

                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot));


                MessageBox.Show("Package is ready for import");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        private void btnCopyToolFromModified_Click(object sender, EventArgs e)
        {
            try
            {
                ReplaceIDHelper.replaceGuids(IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileByViews, fileName.dataFileXml), IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileByCopyTool, fileName.dataFileXml));

                //create import package
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.ImportPackageZipByCopyToolFromViews, fileName.pathToFolderFromProjectRoot));
                //clear temp folder
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot));

                //copy to temp folder
                copyFilesToImportZipPackage(subFolders.DataFileByViews, subFolders.TempFolder);
                //create import package
                ArchiveHelper.CreateZipFromDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot), IOHelper.getProjectSubfolderPath(allSettings, subFolders.ImportPackageZipByCopyToolFromViews, fileName.appendFolderNameDotZip));


                //clear temp folder
                IOHelper.clearDirectory(IOHelper.getProjectSubfolderPath(allSettings, subFolders.TempFolder, fileName.pathToFolderFromProjectRoot));


                MessageBox.Show("Package is ready for import");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }



        #endregion Copy Tool


        #region Helpers


        #region Private methods

        private void cleanAttachmentsSetting(bool _checked)
        {
            foreach (Control item in groupAttachmentsCopySettings.Controls)
            {
                if (item is CheckBox) ((CheckBox)item).Checked = _checked;
            }
        }

        private void btnStartAttachmentsCopyText()
        {
            btnStartAttachmentsCopy.Text = cbxAttachmentsRollback.Checked ? "ROLL BACK" : "COPY";
        }

        private void enableAllButtons(bool isEnabled)
        {
            for (int i = 0; i < buttons.Length; i++)
            {   
                Button current = Controls.Find(buttons[i], true).SingleOrDefault() as Button;
                if (!ReferenceEquals(current, null)) current.Enabled = isEnabled;
            }
        }

        private void copyFilesToImportZipPackage(subFolders dataFileToImportPath, subFolders tempFolder)
        {

            // Content type xml
            IOHelper.copyFile(IOHelper.getProjectSubfolderPath(allSettings, subFolders.ContentTypeSource, fileName.contentTypesXml)
                , IOHelper.getProjectSubfolderPath(allSettings, tempFolder, fileName.contentTypesXml), true);
            //schema xml
            IOHelper.copyFile(IOHelper.getProjectSubfolderPath(allSettings, subFolders.SchemaFileSource, fileName.dataSchemaXml), IOHelper.getProjectSubfolderPath(allSettings, tempFolder, fileName.dataSchemaXml), true);
            //data xml
            IOHelper.copyFile(IOHelper.getProjectSubfolderPath(allSettings, dataFileToImportPath, fileName.dataFileXml), IOHelper.getProjectSubfolderPath(allSettings, tempFolder, fileName.dataFileXml), true);

        }

        private void moveNextTab(int direction)
        {
            tabs.SelectTab(tabs.TabPages.IndexOf(tabs.SelectedTab) + direction);
        }

        private void populateDropDown(ComboBox cb, IEnumerable<KeyValuePair<object, string>> ds)
        {
            cb.DataSource = ds;
            cb.DisplayMember = "Value";
            cb.ValueMember = "Key";
        }

        private void moveListBoxItems(ListBox source, List<SchemaEntity> dataSource, BindingSource bs, List<SchemaEntity> dataSourceTarget, BindingSource bd)
        {
            if (source.SelectedItems.Count > 0)
            {
                //copy selected items to a new collection
                List<SchemaEntity> selected = source.SelectedItems.Cast<SchemaEntity>().ToList();
                //remove from source ds
                selected.ForEach(a =>
                {
                    dataSource.Remove(a);
                });
                //merge to selected ds
                dataSourceTarget.AddRange(selected.Where(d1 => dataSourceTarget.All(d2 => d1.name != d2.name)));

                //reset data bindings
                bs.ResetBindings(false);
                bd.ResetBindings(false);
            }

        }


        #endregion Private methods


        #region Views

        private void deleteView(Guid viewId)
        {
            if (viewsContainers.Keys.Contains(viewId)) viewsContainers.Remove(viewId);
        }

        private queryContainer getView(Guid viewId)
        {
            if (!viewsContainers.Keys.Contains(viewId)) return null;

            return viewsContainers[viewId];
        }

        private void addView(CrmEntityContainer view)
        {

            if (!view.crmEntity.Contains("fetchxml")) return;

            string fetch = view.crmEntity.GetAttributeValue<string>("fetchxml");
            //yet saved
            if (!ReferenceEquals(getView(view.id), null)) deleteView(view.id);

            if (ReferenceEquals(allSettings.SelectedUserQueries.FirstOrDefault(x => x.id == view.id), null))
                viewsContainers.Add(view.id, queryTransformationHelper.transformFetch(crmServiceClientSource, listOfEntities_DS, fetch, cbxExecuteAsListOfLinkedQueries.Checked, cbxCollectAllReferences.Checked, cbxExcludeFromResult.Checked));

            else {

                selectedQuery current = allSettings.SelectedUserQueries.FirstOrDefault(x => x.id == view.id);
                viewsContainers.Add(view.id, queryTransformationHelper.transformFetch(crmServiceClientSource, listOfEntities_DS, fetch, current.ExecuteAsListOfLinkedQueries, current.CollectAllReferences, current.ExcludeFromResults));
            }

        }

        private void loadView(CrmEntityContainer view)
        {

            queryContainer current = getView(view.id);
            if (ReferenceEquals(current, null))
            {
                if (ReferenceEquals(allSettings.SelectedUserQueries.FirstOrDefault(x => x.id == view.id), null))
                {
                    //?? add on fly??
                    return;
                }
                //MessageBox.Show("Cannot load selected view");
                return;
            }
            string fetch = view.crmEntity.GetAttributeValue<string>("fetchxml");
            //load Load Query Monitor
            treeTransformedQueryDisplay.Nodes.Clear();
            if (current.ExequteAsSeparateLinkedQueries)
                treeTransformedQueryDisplay.Nodes.AddRange(treeHelper.fromQuery(crmServiceClientSource, getView(view.id), CrmHelper.queryToFetch(crmServiceClientSource, current.expression)).ToArray());
            else treeTransformedQueryDisplay.Nodes.Add(treeHelper.nodeBasedOnFetch(fetch));
            //treeTransformedQueryDisplay.ExpandAll();
            //load transformation settings
            //remove oncheked event
            //transformationSettings_CheckedChanged
            cbxExcludeFromResult.CheckedChanged -= transformationSettings_CheckedChanged;
            cbxCollectAllReferences.CheckedChanged -= transformationSettings_CheckedChanged;
            cbxExecuteAsListOfLinkedQueries.CheckedChanged -= transformationSettings_CheckedChanged;
            cbxExcludeFromResult.Checked = current.ExcludeFromResults;
            cbxCollectAllReferences.Checked = current.CollectAllReferences;
            cbxExecuteAsListOfLinkedQueries.Checked = current.ExequteAsSeparateLinkedQueries;
            cbxExcludeFromResult.CheckedChanged += transformationSettings_CheckedChanged;
            cbxCollectAllReferences.CheckedChanged += transformationSettings_CheckedChanged;
            cbxExecuteAsListOfLinkedQueries.CheckedChanged += transformationSettings_CheckedChanged;


        }

        private void saveAndReloadView()
        {

            if (ReferenceEquals(lstListOfViewsFilters.SelectedItem, null)) return;
            CrmEntityContainer view = lstListOfViewsFilters.SelectedItem as CrmEntityContainer;
            queryContainer current = getView(view.id);
            current.CollectAllReferences = cbxCollectAllReferences.Checked;
            current.ExcludeFromResults = cbxExcludeFromResult.Checked;
            current.ExequteAsSeparateLinkedQueries = cbxExecuteAsListOfLinkedQueries.Checked;
            saveViewToSettings(current, view.id);
            loadView(view);

        }

        private void saveViewToSettings(queryContainer query, Guid viewid)
        {

            selectedQuery userQuery = SelectedSavedUserViews_DS.Select(s => new selectedQuery
            {
                id = s.id,
                CollectAllReferences = query.CollectAllReferences,
                ExecuteAsListOfLinkedQueries = query.ExequteAsSeparateLinkedQueries,
                ExcludeFromResults = query.ExcludeFromResults
            }).FirstOrDefault(s => s.id == viewid);

            if (allSettings.SelectedUserQueries.Contains(userQuery, new selectedQueryEqualityComparer()))
                allSettings.SelectedUserQueries.RemoveAll(q => q.id == userQuery.id);

            allSettings.SelectedUserQueries.Add(userQuery);
        }

        #endregion Views


        #region Saved Views Tab Management


        private void updateModifiedDataMonitorViewsTab()
        {
            //update Processed records monitor:
            string modifiedDataFilePath = IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileByViews, fileName.dataFileXml);
            if (File.Exists(modifiedDataFilePath))
            {
                treeResultDataFile.Nodes.Clear();
                treeResultDataFile.Nodes.Add(treeHelper.createEntityNodes(IOHelper.DeserializeXmlFromFile<DataEntities>(modifiedDataFilePath).entities));
                treeResultDataFile.Nodes[0].Expand();
            }

        }


        private void loadViewsConfiguration()
        {

            reinitViewsData();

            lstDefaultSchemaDataByViews.ClearSelected();
            List<SchemaEntity> d = lstDefaultSchemaDataByViews.Items.Cast<SchemaEntity>().ToList();

            //if(!ReferenceEquals(allSettings.SelectedUserQueries, null) && allSettings.SelectedUserQueries.Count > 0)

            bindings_SelectedSavedUserViews_DS.DataSource = SelectedSavedUserViews_DS
= CrmHelper.convertEntityToEntityContainer(CrmHelper.getUserQueryListByIds(crmServiceClientSource, allSettings.SelectedUserQueries));
            lstListOfViewsFilters.DataSource = bindings_SelectedSavedUserViews_DS;
            bindings_SelectedSavedUserViews_DS.ResetBindings(false);

            //load selected seting collection
            if (SelectedSavedUserViews_DS.Count > 0)
            {
                foreach (CrmEntityContainer cec in SelectedSavedUserViews_DS) addView(cec);
                //load selected
                loadView(lstListOfViewsFilters.SelectedItem as CrmEntityContainer);
            }

            //set selected in default source
            if (!ReferenceEquals(SelectedSavedUserViews_DS, null) && SelectedSavedUserViews_DS.Count > 0)
            {
                foreach (CrmEntityContainer s in SelectedSavedUserViews_DS)
                {
                    string fetch = s.crmEntity.GetAttributeValue<string>("fetchxml");
                    if (!GlobalHelper.isValidString(fetch)) continue;
                    QueryExpression query = CrmHelper.fetchToQuery(crmServiceClientSource, fetch);
                    int index = d.FindIndex(c => c.name == query.EntityName);
                    if (index != -1)
                        lstDefaultSchemaDataByViews.SetSelected(index, true);
                }
            }


            //remove selected entities from defaults to selected
            moveListBoxItems(lstDefaultSchemaDataByViews, DefaultViewsSchema_DS, bindings_DefaultViewsSchema, SelectedEntitiesViews_DS, bindings_SelectedEntitiesViews);
            //mimic lstSelectedSchemaDataByViews.SelectedIndexChanged
            if (lstSelectedSchemaDataByViews.SelectedItems.Count > 0)
            {
                SchemaEntity ent = lstSelectedSchemaDataByViews.SelectedItem as SchemaEntity;
                if (ReferenceEquals(ent, null)) return;

                bindings_SavedUserViews = new BindingSource();
                bindings_SavedUserViews.DataSource = CrmHelper.getUserQueryListWraped(crmServiceClientSource, ent.etc);
                lstViewsPerEntity.DataSource = bindings_SavedUserViews;
                lstViewsPerEntity.DisplayMember = "name";
                bindings_SavedUserViews.ResetBindings(false);
            }

            //
            updateViewsTabDependencies();
        }

        private void updateViewsTabDependencies()
        {

            //fill fields collection with selected entity fields

            //clear Fields list in advaced filters to if selected entities is empty
            if (SelectedEntitiesViews_DS.Count == 0)
            {
                bindings_SavedUserViews.DataSource = SavedUserViews_DS;
                lstViewsPerEntity.DataSource = bindings_SavedUserViews;
                bindings_SavedUserViews.ResetBindings(false);

                bindings_SelectedSavedUserViews_DS.DataSource = SelectedSavedUserViews_DS = new List<CrmEntityContainer>();
                lstListOfViewsFilters.DataSource = bindings_SelectedSavedUserViews_DS;
                bindings_SelectedSavedUserViews_DS.ResetBindings(false);
            }

        }

        private void reinitViewsData()
        {

            //douplicate schema source to keep default unchanged
            DefaultViewsSchema_DS = GlobalHelper.copyCollection<SchemaEntity>(listOfEntities_DS.entities).Where(x => listOfData_DS.entities.Exists(d => d.name == x.name)).ToList();


            //set binded source
            bindings_DefaultViewsSchema = new BindingSource();
            bindings_DefaultViewsSchema.DataSource = DefaultViewsSchema_DS;
            lstDefaultSchemaDataByViews.DataSource = bindings_DefaultViewsSchema;
            lstDefaultSchemaDataByViews.DisplayMember = "name";


            //set binded source
            bindings_SelectedEntitiesViews = new BindingSource();
            bindings_SelectedEntitiesViews.DataSource = SelectedEntitiesViews_DS;
            lstSelectedSchemaDataByViews.DataSource = bindings_SelectedEntitiesViews;
            lstSelectedSchemaDataByViews.DisplayMember = "name";

            //selected fields
            bindings_SavedUserViews = new BindingSource();
            bindings_SavedUserViews.DataSource = SavedUserViews_DS;
            lstViewsPerEntity.DataSource = bindings_SavedUserViews;
            lstViewsPerEntity.DisplayMember = "name";

            bindings_SelectedSavedUserViews_DS = new BindingSource();
            bindings_SelectedSavedUserViews_DS.DataSource = SelectedSavedUserViews_DS;
            lstListOfViewsFilters.DataSource = bindings_SelectedSavedUserViews_DS;
            lstListOfViewsFilters.DisplayMember = "name";

            //fill original data tree
            treeSorceDataFile.Nodes.Clear();
            treeSorceDataFile.Nodes.Add(treeHelper.createEntityNodes(listOfData_DS.entities));
            treeSorceDataFile.Nodes[0].Expand();

            updateModifiedDataMonitorViewsTab();
        }





        #endregion Saved Views Tab Management





        #endregion Helpers


        #region Attachments

        private void cbxBasedOnFiles_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            groupAttachmentsCopySettings.Enabled = txtxAttachmentsDataFile.Visible = btnSelectAttachmentsDataFile.Visible = cb.Checked;
            cbxAttachmentsRollback.Enabled = cbxFromPortalToPortal.Enabled = !cb.Checked;
            btnStartAttachmentsCopyText();
            if(!cb.Checked) cleanAttachmentsSetting(cb.Checked);
        }

        private void cbxFromPortalToPortal_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            //fill portals drop downs
            //source 
            sourcePortals = CrmHelper.getListOfPortals(crmServiceClientSource);
            populateDropDown(ddlSourcePortal, CrmHelper.convertEntityContainerToKVP(sourcePortals));
            //target
            targetPortals = CrmHelper.getListOfPortals(crmTarget);
            populateDropDown(ddlTargetPortal, CrmHelper.convertEntityContainerToKVP(targetPortals));


            groupAttachmentsCopySettings.Enabled = groupPortalsSources.Visible = cb.Checked;
            cbxAttachmentsRollback.Enabled = cbxBasedOnFiles.Enabled = !cb.Checked;
            btnStartAttachmentsCopyText();
            if (!cb.Checked) cleanAttachmentsSetting(cb.Checked);

        }

        private void cbxAttachmentsRollback_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            cbxAttachmentsKeepIDs.Checked = false;
            groupAttachmentsCopySettings.Visible = cbxFromPortalToPortal.Enabled = cbxBasedOnFiles.Enabled = !cb.Checked;
            txtAttachmentsIDsBackUpFile.Visible = btnSelectIDsBackup.Visible = cb.Checked;

            btnStartAttachmentsCopyText();
        }

        private void cbxAttachmentsKeepIDs_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            txtAttachmentsIDsBackUpFile.Visible = btnSelectIDsBackup.Visible = cb.Checked;

        }

        private void btnSelectAttachmentsDataFile_Click(object sender, EventArgs e)
        {
            //get 
        }

        private void btnSelectIDsBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnStartAttachmentsCopy_Click(object sender, EventArgs e)
        {

        }
        #endregion Attachments
    }
}
