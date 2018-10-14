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
using Microsoft.Xrm.Sdk;
using Portal365_Deployment_Manager.Properties;
using System.Threading;


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

        //protected override bool ShowWithoutActivation
        //{
        //    get { return true; }
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
            //load wpf control - mutulates the form 
            CRMLogin login = new CRMLogin();

            //fix sizes
            fixWPF_caused_resizing();

            //property changed notification
            allSettings.PropertyChanged += AllSettings_PropertyChanged;

        }

        private void fixWPF_caused_resizing()
        {

            this.WindowState = Settings.Default.F1State;
            this.Location = Settings.Default.F1Location;
            this.Size = Settings.Default.F1Size;
            this.Font = Settings.Default.F1Font;
            this.StartPosition = Settings.Default.F1Position;

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

            cbxLoadProject.Enabled = cbxAttachmentsMigration.Enabled = !cb.Checked;

            if (!cb.Checked) return;

            MessageBox.Show("Select or create a directory for a new project. \r\n Directory name becomes the poject name", "New Project");

            //create project
            if (folderBrowserDialogLoadProject.ShowDialog() == DialogResult.OK)
            {
                //project mode
                isCreate = true;

                tbxProject.Text = folderBrowserDialogLoadProject.SelectedPath;
            }
            else
            {
                cb.Checked = false;
                return;
            }


            //get crm connection
            getConnectionsTargetPlusSource();
            if (ReferenceEquals(crmServiceClientSource, null))
            {
                cb.Checked = false;
                return;
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
            else
            {
                cb.Checked = false;
                return;
            }


            //move to views tab
            moveNextTab(1);

        }

        private void cbxLoadProject_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;
            //show/enable groups
            //
            cbxCreateProject.Enabled = cbxAttachmentsMigration.Enabled = !cb.Checked;


            if (!cb.Checked) return;

            //get crm connection
            getConnectionsTargetPlusSource();
            if (ReferenceEquals(crmServiceClientSource, null))
            {
                cb.Checked = false;
                return;
            }


            MessageBox.Show("Select < project name >.xml file to load", "Load Project");

            //load project
            if (openFileLoadProject.ShowDialog() == DialogResult.OK)
            {
                //project mode
                isCreate = false;

                tbxProject.Text = Path.GetDirectoryName(openFileLoadProject.FileName);
            }
            else
            {
                cb.Checked = false;
                return;
            }

            //move to views tab
            moveNextTab(1);
        }

        private void cbxAttachmentsMigration_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            cbxCreateProject.Enabled = cbxLoadProject.Enabled = !cb.Checked;

            if (cb.Checked)
            {
                //get crm connection
                getConnectionsTargetPlusSource(true);

                if (ReferenceEquals(crmServiceClientSource, null) || ReferenceEquals(crmTarget, null))
                {
                    cb.Checked = false;
                }
            }

            cbxBasedOnFiles.Enabled = cbxFromPortalToPortal.Enabled = cbxAttachmentsRollback.Enabled = cb.Checked;

            if (!cb.Checked)
            {
                cbxAttachmentsKeepIDs.Checked = cbxIncludeTextNotes.Checked = cbxAttachmentsRollback.Checked =  cbxFromPortalToPortal.Checked = cbxBasedOnFiles.Checked = cb.Checked;
                //kill connections
                killConnection(true);
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

        private void btnSourcetConnectionChange_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("If you change the SOURCE connection the project will be reload ", "SOURCE CHANGE", MessageBoxButtons.YesNo))
            {
                crmServiceClientSource = getCrmConnectionOOB();
                linkSource.Text = "Source CRM:   {0} \r\n{1}";
                linkSource.Text = string.Format(linkSource.Text, crmServiceClientSource.ConnectedOrgFriendlyName, crmServiceClientSource.CrmConnectOrgUriActual.Scheme + "://" + crmServiceClientSource.CrmConnectOrgUriActual.DnsSafeHost);
                linkSource.Visible = true;

                //reload project
            }
        }

        private void btnTargetConnectionChange_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to change TARGET connection?", "TARGET CHANGE", MessageBoxButtons.YesNo))
            {
                crmTarget = getCrmConnectionOOB();
                linkTarget.Text = "Target CRM:   {0} \r\n{1}";
                linkTarget.Text = string.Format(linkTarget.Text, crmTarget.ConnectedOrgFriendlyName, crmTarget.CrmConnectOrgUriActual.Scheme + "://" + crmTarget.CrmConnectOrgUriActual.DnsSafeHost);
                linkTarget.Visible = true;
            }

        }


        private CrmServiceClient getCrmConnectionOOB()
        {
            CrmServiceClient current = null;
            
            CRMLogin login = new CRMLogin();
            
            login.ShowDialog();

            if (login.CrmConnectionMgr != null && login.CrmConnectionMgr.CrmSvc != null && login.CrmConnectionMgr.CrmSvc.IsReady)
            {
                try
                {
                    WhoAmIResponse wai = (WhoAmIResponse)login.CrmConnectionMgr.CrmSvc.Execute(new WhoAmIRequest());
                    current = login.CrmConnectionMgr.CrmSvc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot establish connection. \r\n Error: " + ex.Message, "Connection Error");
                    return null;
                }

            }
            return current;
        }

        private void getConnectionsTargetPlusSource(bool addTarget = false)
        {
            MessageBox.Show("Set up SOURCE connection", "SOURCE");

            //get crm connection
            crmServiceClientSource = getCrmConnectionOOB();
            //update header
            if (!ReferenceEquals(crmServiceClientSource, null) && crmServiceClientSource.IsReady)
            {
                linkSource.Text = string.Format(linkSource.Text, crmServiceClientSource.ConnectedOrgFriendlyName, crmServiceClientSource.CrmConnectOrgUriActual.Scheme + "://" + crmServiceClientSource.CrmConnectOrgUriActual.DnsSafeHost);
                linkSource.Visible = crmServiceClientSource.IsReady;

            }
            else return;

            if (addTarget)
            {
                MessageBox.Show("Set up TARGET connection", "TARGET");

                crmTarget = getCrmConnectionOOB();
                //update header
                if (!ReferenceEquals(crmTarget, null) && crmTarget.IsReady)
                {
                    linkTarget.Text = string.Format(linkTarget.Text, crmTarget.ConnectedOrgFriendlyName, crmTarget.CrmConnectOrgUriActual.Scheme + "://" + crmTarget.CrmConnectOrgUriActual.DnsSafeHost);
                    linkTarget.Visible = crmTarget.IsReady;
                }
                else return;
            }

            btnSourcetConnectionChange.Visible = btnTargetConnectionChange.Visible = true;

        }

        private void killConnection(bool both = false)
        {

            //kill source crm connection
            crmServiceClientSource = null;
            //update header
            linkSource.Visible = false;
            linkSource.Text = "Source CRM:   {0} \r\n{1}";

            if (both)
            {
                crmTarget = null;
                //update header
                linkTarget.Visible = false;
                linkTarget.Text = "Target CRM:  {0} \r\n{1}";                
            }

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


                    if (comparer.RecordsCollection.All(r => !ids.Contains(new Guid(r.id), new GuidEqualityComparer())))
                        raw.entities.RemoveAll(d => d.name == comparer.name);
                    else
                        raw.entities.SingleOrDefault(d => d.name == comparer.name).RecordsCollection.RemoveAll(r => !ids.Contains(new Guid(r.id), new GuidEqualityComparer()));

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

        private void populateDropDown(ComboBox cb, List<CrmEntityContainer> ds)
        {
            cb.DataSource = ds;
            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.SelectedItem = null;
            
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
        
        private bool validateGroupCombos(GroupBox targetGroup)
        {

            foreach (var tbx in targetGroup.Controls.OfType<ComboBox>())
            {
                if (!GlobalHelper.isValidString(tbx.Text) && tbx.Enabled)
                {
                    tbx.BackColor = Color.LightSalmon;
                    return false;
                }
                else tbx.BackColor = Color.White;
            }

            return true;
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

            if (ReferenceEquals(allSettings.SelectedUserQueries, null) || ReferenceEquals(allSettings.SelectedUserQueries.FirstOrDefault(x => x.id == view.id), null))
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


        private List<Guid> executeAttachmentsCopyBasedMasterEntity(string datafilePath, bool includeNotes, out int webFilesCount)
        {
            List<Guid> result = new List<Guid>();
            webFilesCount = 0;

            DataEntities entities = IOHelper.DeserializeXmlFromFile<DataEntities>(datafilePath); //web files
            foreach (DataEntity de in entities.entities)
            {
                webFilesCount += de.RecordsCollection.Count;
                //get attachment per entity record, files only, get lates
                foreach (Record rec in de.RecordsCollection)
                {
                    Entity latestAttacnment = CrmHelper.getLattestAttachmentByEntity(crmServiceClientSource, new Guid(rec.id), de.name, includeNotes);
                    if (ReferenceEquals(latestAttacnment, null)) continue;

                    //check is target has same entity
                    Entity targetMaster = crmTarget.Retrieve(de.name, new Guid(rec.id), new ColumnSet());
                    if (ReferenceEquals(targetMaster, null)) continue;

                    //copy to target
                    Guid? newNote = CrmHelper.cloneAnnotation(crmTarget, latestAttacnment);
                    if (newNote.HasValue) result.Add(newNote.Value);
                }
            }

            return result;
        }

        private List<Guid> executeAttachmentsCopyBasedOnWebFileName(List<CrmEntityContainer> source, List<CrmEntityContainer> target, bool includeNotes)
        {

            List<Guid> result = new List<Guid>();
            foreach (CrmEntityContainer enSource in source)
            {
                //get single web file with same name, skip if plural
                List<CrmEntityContainer> enTargets = target.Where(e => e.name == enSource.name).ToList();
                if (ReferenceEquals(enTargets, null) || enTargets.Count == 0) continue;

                Entity latestAttacnment = CrmHelper.getLattestAttachmentByEntity(crmServiceClientSource, enSource.id, enSource.logicalName, includeNotes);

                //copy to all found target webfiles
                foreach (CrmEntityContainer enTarget in enTargets)
                {
                    Guid? newNote = CrmHelper.cloneAnnotationForSpecificID(crmTarget, latestAttacnment,  enTarget.crmEntityRef);
                    if (newNote.HasValue) result.Add(newNote.Value);

                }
            }

            return result;
        }

        #endregion Helpers


        #region Attachments

        private void cbxBasedOnFiles_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            groupAttachmentsCopySettings.Enabled = txtxAttachmentsDataFile.Visible = btnSelectAttachmentsDataFile.Visible = cb.Checked;
            cbxAttachmentsRollback.Enabled = cbxFromPortalToPortal.Enabled = !cb.Checked;
            btnStartAttachmentsCopyText();
            if (!cb.Checked)
            {
                cleanAttachmentsSetting(cb.Checked);
                return;
            }

            //get data file 
            MessageBox.Show("Select a data.xml file to import IDs based on", "Attacments parent entities");

            if (openFileAttachments.ShowDialog() == DialogResult.OK)
            {
                txtxAttachmentsDataFile.Text = openFileAttachments.FileName;
            }

        }

        private void cbxFromPortalToPortal_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            groupAttachmentsCopySettings.Enabled = groupPortalsSources.Visible = cb.Checked;
            cbxAttachmentsRollback.Enabled = cbxBasedOnFiles.Enabled = !cb.Checked;
            btnStartAttachmentsCopyText();

            if (!cb.Checked)
            {
                cleanAttachmentsSetting(cb.Checked);
                return;
            }

            //fill portals drop downs
            //source 
            sourcePortals = CrmHelper.getListOfPortals(crmServiceClientSource);
            populateDropDown(ddlSourcePortal, sourcePortals);
            //target
            targetPortals = CrmHelper.getListOfPortals(crmTarget);
            populateDropDown(ddlTargetPortal, targetPortals);
        }

        private void cbxAttachmentsRollback_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            cbxAttachmentsKeepIDs.Checked = false;
            groupAttachmentsCopySettings.Visible = cbxFromPortalToPortal.Enabled = cbxBasedOnFiles.Enabled = !cb.Checked;
            txtAttachmentsIDsBackUpFile.Visible = btnSelectIDsBackup.Visible = cb.Checked;

            btnStartAttachmentsCopyText();

            if (!cb.Checked)
            {
                cleanAttachmentsSetting(cb.Checked);
                btnTargetConnectionChange.Visible = btnSourcetConnectionChange.Visible = false;
                return;
            }

            killConnection(true);
            //get target connection
            MessageBox.Show("Please set connection to the instance you wish delete attachments from", "Delete Attachments");
            linkSource.Visible = btnSourcetConnectionChange.Visible = false;
            btnTargetConnectionChange.Visible = true;
            crmTarget = getCrmConnectionOOB();
            //update header
            if (!ReferenceEquals(crmTarget, null) && crmTarget.IsReady)
            {
                string.Format(linkTarget.Text, crmTarget.ConnectedOrgFriendlyName, crmTarget.CrmConnectOrgUriActual.Scheme + "://" + crmTarget.CrmConnectOrgUriActual.DnsSafeHost);
                linkTarget.Visible = crmTarget.IsReady;
            }
            else return;
            

            //get IDs file
            MessageBox.Show("Point to file with IDs of created attachment", "Delete Attachments");
            if (openFileAttachments.ShowDialog() == DialogResult.OK)
            {
                txtAttachmentsIDsBackUpFile.Text = openFileAttachments.FileName;
            }

        }

        private void cbxAttachmentsKeepIDs_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (ReferenceEquals(cb, null)) return;

            txtAttachmentsIDsBackUpFile.Visible = btnSelectIDsBackup.Visible = cb.Checked;

            MessageBox.Show("Select an xml file to keep list of created IDs");
            if (openFileAttachments.ShowDialog() == DialogResult.OK)
            {
                txtAttachmentsIDsBackUpFile.Text = openFileAttachments.FileName;
            }


        }

        private void btnSelectAttachmentsDataFile_Click(object sender, EventArgs e)
        {
            //get data file             
            if (openFileAttachments.ShowDialog() == DialogResult.OK)
            {
                txtxAttachmentsDataFile.Text = openFileAttachments.FileName;
            }
        }

        private void btnSelectIDsBackup_Click(object sender, EventArgs e)
        {
            //get data file             
            if (openFileAttachments.ShowDialog() == DialogResult.OK)
            {
                txtAttachmentsIDsBackUpFile.Text = openFileAttachments.FileName;
            }

        }

        private void btnStartAttachmentsCopy_Click(object sender, EventArgs e)
        {
            List<Guid> ids = new List<Guid>();
            //identify type of action
            bool basedOnFile = cbxBasedOnFiles.Checked;
            bool P2P = cbxFromPortalToPortal.Checked;
            bool atRollback = cbxAttachmentsRollback.Checked;
            bool keepIds = cbxAttachmentsKeepIDs.Checked;
            bool includeNotes = cbxIncludeTextNotes.Checked;

            //validate pre-requisites

            if (atRollback)
            {
                //target connection only
                if (crmTarget.IsReady)
                {
                    //validate backup file   
                    if (!GlobalHelper.isValidString(txtAttachmentsIDsBackUpFile.Text) || !IOHelper.isFileExist(txtAttachmentsIDsBackUpFile.Text, ".xml"))
                    {
                        MessageBox.Show("Attachment IDs backup file was not found");
                        return;
                    }

                    try
                    {
                        ids = IOHelper.DeserializeXmlFromFile<List<Guid>>(txtAttachmentsIDsBackUpFile.Text);
                        //execute
                        CrmHelper.deleteEntityByID(crmTarget, "annotation", ids);
                        MessageBox.Show("Delete success");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong. Error: " + ex.Message);
                        return;
                    }

                }
                else MessageBox.Show(crmServiceClientSource.IsReady ? "Connection to target is not set" : "Connection to Source is not set");

                return;
            }


            //validate twoo connections
            if ((basedOnFile || P2P) && crmServiceClientSource.IsReady && crmTarget.IsReady)
            {
                if (basedOnFile)
                {

                    //validate data file
                    if (!GlobalHelper.isValidString(txtxAttachmentsDataFile.Text) || !IOHelper.isFileExist(txtxAttachmentsDataFile.Text, ".xml"))
                    {
                        MessageBox.Show("Data file was not found");
                        return;
                    }
                    //validate backup file
                    if (keepIds)
                    {
                        if (!GlobalHelper.isValidString(txtAttachmentsIDsBackUpFile.Text) || !IOHelper.isFileExist(txtAttachmentsIDsBackUpFile.Text, ".xml"))
                        {
                            MessageBox.Show("Attachment IDs backup file was not found");
                            return;
                        }
                    }
                    //execution
                    try
                    {

                        if (DialogResult.Yes == MessageBox.Show("You're going to copy attachments \r\n from '" + crmServiceClientSource.ConnectedOrgFriendlyName + "' crm \r\n to '" + crmTarget.ConnectedOrgFriendlyName + "' cmr  \r\n based on selected datafile " + txtxAttachmentsDataFile.Text + " \r\n Recording of newly created attachemnts for potntial rollback is " + (keepIds ? "'ON'": "'OFF'") + " \r\n\n Execute?", "CONFIRM COPY", MessageBoxButtons.YesNo))
                        {

                            int webFilesCount = 0;
                            ids = executeAttachmentsCopyBasedMasterEntity(txtxAttachmentsDataFile.Text, includeNotes, out webFilesCount);

                            if (ids.Count > 0 && keepIds) IOHelper.SerializeObjectToXmlFile<List<Guid>>(ids, txtAttachmentsIDsBackUpFile.Text);


                            MessageBox.Show("Attachments found in file - " + webFilesCount.ToString() + "\r\n Attachments copied to target - " + ids.Count.ToString(), "RESULT");

                            //reset collection
                            ids = new List<Guid>();
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong. Error: " + ex.Message, "ERROR");
                        return;
                    }
                }


                if (P2P)
                {

                    //validate dropdouns portal selected
                    if (!validateGroupCombos(groupPortalsSources))
                    {
                        MessageBox.Show("Please select a portal", "Mandatory field");
                        return;
                    }

                    //vlidate not the same portal for same connections
                    if (crmServiceClientSource.ConnectedOrgUniqueName == crmTarget.ConnectedOrgUniqueName
                        && ddlSourcePortal.SelectedValue == ddlTargetPortal.SelectedValue)
                    {
                        MessageBox.Show("Copy from source portal to  itself is not supported. Please select different target.", "WRONG SET");
                        return;
                    }

                    if (keepIds)
                    {
                        if (!GlobalHelper.isValidString(txtAttachmentsIDsBackUpFile.Text) || !IOHelper.isFileExist(txtAttachmentsIDsBackUpFile.Text, ".xml"))
                        {
                            MessageBox.Show("Attachment IDs backup file was not found", "File Not Found");
                            return;
                        }
                    }
                    //execute
                    try
                    {

                        if (DialogResult.Yes == MessageBox.Show("You're going to copy attachments \r\n from '" + crmServiceClientSource.ConnectedOrgFriendlyName + "' crm, Portal '" + ddlSourcePortal.Text + "' \r\n to '" + crmTarget.ConnectedOrgFriendlyName + "' cmr, Portal '" + ddlTargetPortal.Text + "' \r\n Recording of newly created attachemnts for potntial rollback is " + (keepIds ? "'ON'" : "'OFF'") + " \r\n\n Execute?", "CONFIRM COPY", MessageBoxButtons.YesNo))
                        {

                            List<CrmEntityContainer> listOfWebFilesSource = CrmHelper.getWebFilesByPortalId(crmServiceClientSource, new Guid(ddlSourcePortal.SelectedValue.ToString()));
                            List<CrmEntityContainer> listOfWebFilesTarget = CrmHelper.getWebFilesByPortalId(crmTarget, new Guid(ddlSourcePortal.SelectedValue.ToString()));

                            ids = executeAttachmentsCopyBasedOnWebFileName(listOfWebFilesSource, listOfWebFilesTarget, includeNotes);

                            if (ids.Count > 0 && keepIds) IOHelper.SerializeObjectToXmlFile<List<Guid>>(ids, txtAttachmentsIDsBackUpFile.Text);

                            MessageBox.Show("Attachments found in source portal - " + listOfWebFilesSource.Count.ToString() + "\r\n Attachments copied to target portal - " + ids.Count.ToString(), "RESULT");


                            //reset collection
                            ids = new List<Guid>();
                        }

                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong. Error: " + ex.Message, "ERROR");
                        return;
                    }

                }
            }
            else MessageBox.Show( "Connection is not set", "NO CRM CONNECTION");

        }

        #endregion Attachments
        
    }
}
