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
//using xrm = Microsoft.Xrm.Sdk;
//using System.Threading;

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
            setOperatorsDropDown(ddlAuthType, listAuthType_DS);


            #region Bindings

            tbxProject.DataBindings.Add("Text", bindings_Settings, "ProjectPath", false, DataSourceUpdateMode.OnPropertyChanged);
            tbxOrgNameSource.DataBindings.Add("Text", bindings_Settings, "OrgUniqueNameSource", false, DataSourceUpdateMode.OnPropertyChanged);
            tbxServerUrlSource.DataBindings.Add("Text", bindings_Settings, "ServerUrlSource", false, DataSourceUpdateMode.OnPropertyChanged);
            tbxUsernameSource.DataBindings.Add("Text", bindings_Settings, "UsernameSource", false, DataSourceUpdateMode.OnPropertyChanged);
            tbxPasswordSource.DataBindings.Add("Text", bindings_Settings, "PasswordSource", false, DataSourceUpdateMode.OnPropertyChanged);

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
            // start/keep connection and load crm dependent tabs
            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            lblConnectionAwaitViews.Visible = true;
            //TO DO: check "no internet connection" situation
            Task.Factory.StartNew(delegate
            {
                crmServiceClientSource =
                    ConnectionHelper.getOnLineConnection(allSettings.OrgUniqueNameSource, allSettings.ServerUrlSource, allSettings.UsernameSource, CredentialsHelper.getLocalPassword(string.Concat(allSettings.OrgUniqueNameSource, allSettings.ServerUrlSource, allSettings.UsernameSource)));

            }, backgroundScheduler).ContinueWith(delegate { loadViewsConfiguration(); }, uiScheduler);
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

                            //SettingsHelper.projectFileLoad(tbxProject.Text, allSettings);
                            SettingsHelper.projectFileLoad(allSettings);
                            bindings_Settings.ResetBindings(false);

                            //set directories if not there
                            IOHelper.setInnerProjectStructure(allSettings);
                            //
                            updateProjectTree();
                            //control of load package load. Once project is created/loaded
                            btnLoadSchema.Enabled = GlobalHelper.isValidString(tbxProject.Text);

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


        private void updateProjectTree()
        {
            if (!Directory.Exists(allSettings.ProjectPath)) return;
            DirectoryInfo inf = new DirectoryInfo(allSettings.ProjectPath);
            treeProject.Nodes.Clear();
            treeProject.Nodes.Add(treeHelper.CreateDirectoryNode(inf));
            treeProject.Nodes[0].Expand();
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogLoadProject.ShowDialog() == DialogResult.OK)
            {
                //project mode
                isCreate = true;

                tbxProject.Text = folderBrowserDialogLoadProject.SelectedPath;
            }
        }

        private void btnProjectLoad_Click(object sender, EventArgs e)
        {

            if (openFileLoadProject.ShowDialog() == DialogResult.OK)
            {
                //project mode
                isCreate = false;

                tbxProject.Text = Path.GetDirectoryName(openFileLoadProject.FileName);
            }
        }

        private void btnLoadSchema_Click(object sender, EventArgs e)
        {

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
        }


        #region Connection 

        private void cbxIsOnPremSource_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox current = sender as CheckBox;
            if (!ReferenceEquals(current, null))
                lblUniqueNamePathSource.Visible = !current.Checked;
        }

        private void btnTestConnSource_Click(object sender, EventArgs e)
        {
            if (validateGroup(groupConnectionSource))
            {
                crmServiceClientSource = ConnectionHelper.getOnLineConnection(tbxOrgNameSource.Text, tbxServerUrlSource.Text, tbxUsernameSource.Text, tbxPasswordSource.Text);
                setStatusLabel(lblTestConnSource, crmServiceClientSource.IsReady);
                //allSettings
                //set local credentials
                if (CredentialsHelper.setLocalCredentials(tbxOrgNameSource.Text, tbxServerUrlSource.Text, tbxUsernameSource.Text, tbxPasswordSource.Text))
                {
                    //successefully saved
                }
                else
                {
                    //not saved
                }
            }
        }

        private void btnConnectionsSave_Click(object sender, EventArgs e)
        {

            // validation
            if (!validateGroup(groupConnectionSource)) return;

            try
            {
                SettingsHelper.saveProject(allSettings);
                //save credentials
                if (GlobalHelper.isValidString(tbxPasswordSource.Text))
                    CredentialsHelper.setLocalCredentials(allSettings.OrgUniqueNameSource, allSettings.ServerUrlSource, allSettings.UsernameSource, tbxPasswordSource.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion Connection 


        #endregion Project Tab


        #region Saved Views Tab 


        #region buttons

        private void btnSaveModifyViewsFile_Click(object sender, EventArgs e)
        {
            //validate action operator
            if (!validateLogicalOperator(ddlViewsActionOperator))
            {
                MessageBox.Show("Please select Action Operator");
                ddlViewsActionOperator.Focus();
                return;
            }

            allSettings.SelectedViewsActionOperator = ddlViewsActionOperator.Text;

            try
            {
                //save tab
                SettingsHelper.saveProject(allSettings);

                if (lstListOfViewsFilters.Items.Count > 0)
                    allSettings.SelectedUserQueries = SelectedSavedUserViews_DS.Select(s => s.id).ToList();

                //execute views, get and merge all guids
                List<Guid> ids = CrmHelper.getIdsFromViewsExecution(crmServiceClientSource, SelectedSavedUserViews_DS);

                //file create an object for transformation
                DataEntities raw = IOHelper.DeserializeXmlFromFile<DataEntities>(IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileSource, fileName.dataFileXml));

                foreach (DataEntity comparer in listOfData_DS.entities)
                {

                    switch (ddlViewsActionOperator.Text)
                    {
                        case "Selected Only":

                            if (comparer.RecordsCollection.All(r => !ids.Contains(new Guid(r.id), new GuidEqualityComparer())))
                                raw.entities.RemoveAll(d => d.name == comparer.name);
                            else
                                raw.entities.SingleOrDefault(d => d.name == comparer.name).RecordsCollection.RemoveAll(r => !ids.Contains(new Guid(r.id), new GuidEqualityComparer()));

                            break;
                        case "All Except Selected":

                            if (comparer.RecordsCollection.All(r => ids.Contains(new Guid(r.id), new GuidEqualityComparer())))
                                raw.entities.RemoveAll(d => d.name == comparer.name);
                            else
                                raw.entities.SingleOrDefault(d => d.name == comparer.name).RecordsCollection.RemoveAll(r => ids.Contains(new Guid(r.id), new GuidEqualityComparer()));

                            break;

                        default: break;
                    }


                }

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
                    if (!SelectedSavedUserViews_DS.Contains(selected))
                    {
                        SelectedSavedUserViews_DS.Add(selected);
                        bindings_SelectedSavedUserViews_DS.DataSource = SelectedSavedUserViews_DS;
                        lstListOfViewsFilters.DataSource = bindings_SelectedSavedUserViews_DS;
                        bindings_SelectedSavedUserViews_DS.ResetBindings(false);
                    }
                }
            }
            enableActionsOperator();
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
            enableActionsOperator();

        }


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

        private void setOperatorsDropDown(ComboBox cb, IEnumerable<KeyValuePair<int, string>> ds)
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

        private void showFile(string path, StreamReader stream = null)
        {
            if (GlobalHelper.isValidString(path) && File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(openFileDialogLoadSchema.FileName))
                { MessageBox.Show(sr.ReadToEnd()); }
            }
            else if (!ReferenceEquals(stream, null))
            {

                MessageBox.Show(stream.ReadToEnd());
                stream.Close();
            }
            else MessageBox.Show("File not found");
        }

        private bool validateGroup(GroupBox targetGroup)
        {

            foreach (var tbx in targetGroup.Controls.OfType<TextBox>())
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

        private bool validateLogicalOperator(ComboBox logicOperatorDDL)
        {
            if (!GlobalHelper.isValidString(logicOperatorDDL.Text))
            {
                logicOperatorDDL.BackColor = Color.LightSalmon;
                return false;
            }
            else logicOperatorDDL.BackColor = Color.White;

            return true;
        }

        private void setStatusLabel(Label handler, bool isSuccess)
        {
            lblViewsNoConnection.Visible = !isSuccess;

            if (isSuccess)
            {
                handler.Text = "SuCCeSS";
                handler.ForeColor = Color.Green;
            }
            else
            {
                lblTestConnSource.Text = "FaileD";
                lblTestConnSource.ForeColor = Color.Red;
            }
        }

        #endregion Private methods


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

        private void enableActionsOperator()
        {
            bool isThereViews = (lstListOfViewsFilters.Items.Count > 0);
            if (!isThereViews)
            {
                ddlViewsActionOperator.SelectedIndex = -1;
            }
            ddlViewsActionOperator.Enabled = isThereViews;
        }

        private void loadViewsConfiguration()
        {

        //connection to crm established
        lblConnectionAwaitViews.Visible = false;
            lblViewsNoConnection.Visible = !crmServiceClientSource.IsReady;

            reinitViewsData();

            List<DataEntity> modifiedDataEntities = new List<DataEntity>();
            //if modified schema exist - create a slash of the past 
            string modifiedDataFilePath = IOHelper.getProjectSubfolderPath(allSettings, subFolders.DataFileByViews, fileName.dataFileXml);
            if (File.Exists(modifiedDataFilePath))
            {
                modifiedDataEntities = IOHelper.DeserializeXmlFromFile<DataEntities>(modifiedDataFilePath).entities;
            }
            else return;

            lstDefaultSchemaDataByViews.ClearSelected();
            List<SchemaEntity> d = lstDefaultSchemaDataByViews.Items.Cast<SchemaEntity>().ToList();

            
            //set selected in default source
            modifiedDataEntities.ForEach(e =>
            {

                int index = d.FindIndex(c => c.name == e.name);
                if (index != -1)
                    lstDefaultSchemaDataByViews.SetSelected(index, true);
            });
            //remove selected entities from defaults to selected
            moveListBoxItems(lstDefaultSchemaDataByViews, DefaultViewsSchema_DS, bindings_DefaultViewsSchema, SelectedEntitiesViews_DS, bindings_SelectedEntitiesViews);
            //mimis lstSelectedSchemaDataByViews.SelectedIndexChanged
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
            ////
            // add load of selected user views / filters: lstListOfViewsFilters
            if (!ReferenceEquals(allSettings.SelectedUserQueries, null) && allSettings.SelectedUserQueries.Count > 0)
            {
                Task.Factory.StartNew(() =>
                {
                    bindings_SelectedSavedUserViews_DS.DataSource = SelectedSavedUserViews_DS
                    = CrmHelper.convertEntityToEntityContainer(CrmHelper.getUserQueryListByIds(crmServiceClientSource, allSettings.SelectedUserQueries));
                    lstListOfViewsFilters.DataSource = bindings_SelectedSavedUserViews_DS;
                    bindings_SelectedSavedUserViews_DS.ResetBindings(false);
                });
            }

            //action operator set selected 
            if (GlobalHelper.isValidString(allSettings.SelectedViewsActionOperator))
            {
                ddlViewsActionOperator.Enabled = true;
                ddlViewsActionOperator.SelectedIndex = ddlViewsActionOperator.Items.IndexOf(allSettings.SelectedViewsActionOperator);
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

    }
}
