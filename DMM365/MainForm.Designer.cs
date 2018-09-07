namespace DMM365
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabsPanel = new System.Windows.Forms.Panel();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.gboxProject = new System.Windows.Forms.GroupBox();
            this.lblProject3 = new System.Windows.Forms.Label();
            this.btnProjectLoad = new System.Windows.Forms.Button();
            this.groupConnectionSource = new System.Windows.Forms.GroupBox();
            this.lblTestConnectionAwait = new System.Windows.Forms.Label();
            this.lblTemp1 = new System.Windows.Forms.Label();
            this.lblTestConnSource = new System.Windows.Forms.Label();
            this.lblAuthType = new System.Windows.Forms.Label();
            this.btnTestConnSource = new System.Windows.Forms.Button();
            this.ddlAuthType = new System.Windows.Forms.ComboBox();
            this.lblUrlPattenSource = new System.Windows.Forms.Label();
            this.lblUniqueNamePathSource = new System.Windows.Forms.Label();
            this.tbxPasswordSource = new System.Windows.Forms.TextBox();
            this.lblPasswordSource = new System.Windows.Forms.Label();
            this.tbxUsernameSource = new System.Windows.Forms.TextBox();
            this.tbxServerUrlSource = new System.Windows.Forms.TextBox();
            this.tbxOrgNameSource = new System.Windows.Forms.TextBox();
            this.lblUserSource = new System.Windows.Forms.Label();
            this.lblServerUrlSource = new System.Windows.Forms.Label();
            this.lblOrgNameSource = new System.Windows.Forms.Label();
            this.btnLoadSchema = new System.Windows.Forms.Button();
            this.lblProject2 = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.btnProject = new System.Windows.Forms.Button();
            this.groupProjectSchema = new System.Windows.Forms.GroupBox();
            this.treeProject = new System.Windows.Forms.TreeView();
            this.tbxProject = new System.Windows.Forms.TextBox();
            this.groupProjectActions = new System.Windows.Forms.GroupBox();
            this.btnProjectSaveAndNext = new System.Windows.Forms.Button();
            this.tabModifyDataBasedOnSavedQueries = new System.Windows.Forms.TabPage();
            this.groupViewsAdvanced = new System.Windows.Forms.GroupBox();
            this.lblSorceDataFile = new System.Windows.Forms.Label();
            this.lblResultDataFile = new System.Windows.Forms.Label();
            this.treeResultDataFile = new System.Windows.Forms.TreeView();
            this.treeSorceDataFile = new System.Windows.Forms.TreeView();
            this.groupViewDataFilter = new System.Windows.Forms.GroupBox();
            this.lblViewsNoConnection = new System.Windows.Forms.Label();
            this.lblConnectionAwaitViews = new System.Windows.Forms.Label();
            this.lblViewsActionTypeOperatot = new System.Windows.Forms.Label();
            this.ddlViewsActionOperator = new System.Windows.Forms.ComboBox();
            this.lstListOfViewsFilters = new System.Windows.Forms.ListBox();
            this.lblViewsByEntity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstDefaultSchemaDataByViews = new System.Windows.Forms.ListBox();
            this.lstViewsPerEntity = new System.Windows.Forms.ListBox();
            this.btnbtnViews_FromDefaultToSelected = new System.Windows.Forms.Button();
            this.btnViews_ReturnToDefaultFromSelected = new System.Windows.Forms.Button();
            this.lblListOfViewsFilters = new System.Windows.Forms.Label();
            this.lstSelectedSchemaDataByViews = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnViewsBack = new System.Windows.Forms.Button();
            this.btnSaveModifyViewsFile = new System.Windows.Forms.Button();
            this.btnViewNext = new System.Windows.Forms.Button();
            this.groupViewsTips = new System.Windows.Forms.GroupBox();
            this.tabReplaceIDs = new System.Windows.Forms.TabPage();
            this.btnCopyToolFromModified = new System.Windows.Forms.Button();
            this.btnCopyToolFromSource = new System.Windows.Forms.Button();
            this.groupCopyToolTips = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCopyToolBack = new System.Windows.Forms.Button();
            this.folderBrowserDialogLoadProject = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogLoadSchema = new System.Windows.Forms.OpenFileDialog();
            this.openFileLoadProject = new System.Windows.Forms.OpenFileDialog();
            this.cbxExecuteAsListOfLinkedQueries = new System.Windows.Forms.CheckBox();
            this.tabsPanel.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.gboxProject.SuspendLayout();
            this.groupConnectionSource.SuspendLayout();
            this.groupProjectSchema.SuspendLayout();
            this.groupProjectActions.SuspendLayout();
            this.tabModifyDataBasedOnSavedQueries.SuspendLayout();
            this.groupViewsAdvanced.SuspendLayout();
            this.groupViewDataFilter.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabReplaceIDs.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsPanel
            // 
            this.tabsPanel.Controls.Add(this.tabs);
            this.tabsPanel.Location = new System.Drawing.Point(12, 12);
            this.tabsPanel.Name = "tabsPanel";
            this.tabsPanel.Size = new System.Drawing.Size(1424, 721);
            this.tabsPanel.TabIndex = 1;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabProject);
            this.tabs.Controls.Add(this.tabModifyDataBasedOnSavedQueries);
            this.tabs.Controls.Add(this.tabReplaceIDs);
            this.tabs.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tabs.Location = new System.Drawing.Point(3, 3);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(10, 8);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1418, 708);
            this.tabs.TabIndex = 0;
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.gboxProject);
            this.tabProject.Controls.Add(this.groupProjectSchema);
            this.tabProject.Controls.Add(this.groupProjectActions);
            this.tabProject.Location = new System.Drawing.Point(4, 35);
            this.tabProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabProject.Name = "tabProject";
            this.tabProject.Size = new System.Drawing.Size(1410, 669);
            this.tabProject.TabIndex = 5;
            this.tabProject.Text = "Project Management";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // gboxProject
            // 
            this.gboxProject.Controls.Add(this.lblProject3);
            this.gboxProject.Controls.Add(this.btnProjectLoad);
            this.gboxProject.Controls.Add(this.groupConnectionSource);
            this.gboxProject.Controls.Add(this.btnLoadSchema);
            this.gboxProject.Controls.Add(this.lblProject2);
            this.gboxProject.Controls.Add(this.lblProject);
            this.gboxProject.Controls.Add(this.btnProject);
            this.gboxProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gboxProject.Location = new System.Drawing.Point(18, 29);
            this.gboxProject.Name = "gboxProject";
            this.gboxProject.Size = new System.Drawing.Size(894, 547);
            this.gboxProject.TabIndex = 39;
            this.gboxProject.TabStop = false;
            this.gboxProject.Text = "Project available actions";
            // 
            // lblProject3
            // 
            this.lblProject3.AutoSize = true;
            this.lblProject3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProject3.Location = new System.Drawing.Point(25, 238);
            this.lblProject3.Name = "lblProject3";
            this.lblProject3.Size = new System.Drawing.Size(745, 34);
            this.lblProject3.TabIndex = 36;
            this.lblProject3.Text = "\r\n   3. A valid crm connection is required for \"Saved Views filters\". Other featu" +
    "res needs no connection.";
            // 
            // btnProjectLoad
            // 
            this.btnProjectLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnProjectLoad.Location = new System.Drawing.Point(28, 89);
            this.btnProjectLoad.Name = "btnProjectLoad";
            this.btnProjectLoad.Size = new System.Drawing.Size(150, 27);
            this.btnProjectLoad.TabIndex = 10;
            this.btnProjectLoad.Text = "Load Project";
            this.btnProjectLoad.UseVisualStyleBackColor = true;
            this.btnProjectLoad.Click += new System.EventHandler(this.btnProjectLoad_Click);
            // 
            // groupConnectionSource
            // 
            this.groupConnectionSource.Controls.Add(this.lblTestConnectionAwait);
            this.groupConnectionSource.Controls.Add(this.lblTemp1);
            this.groupConnectionSource.Controls.Add(this.lblTestConnSource);
            this.groupConnectionSource.Controls.Add(this.lblAuthType);
            this.groupConnectionSource.Controls.Add(this.btnTestConnSource);
            this.groupConnectionSource.Controls.Add(this.ddlAuthType);
            this.groupConnectionSource.Controls.Add(this.lblUrlPattenSource);
            this.groupConnectionSource.Controls.Add(this.lblUniqueNamePathSource);
            this.groupConnectionSource.Controls.Add(this.tbxPasswordSource);
            this.groupConnectionSource.Controls.Add(this.lblPasswordSource);
            this.groupConnectionSource.Controls.Add(this.tbxUsernameSource);
            this.groupConnectionSource.Controls.Add(this.tbxServerUrlSource);
            this.groupConnectionSource.Controls.Add(this.tbxOrgNameSource);
            this.groupConnectionSource.Controls.Add(this.lblUserSource);
            this.groupConnectionSource.Controls.Add(this.lblServerUrlSource);
            this.groupConnectionSource.Controls.Add(this.lblOrgNameSource);
            this.groupConnectionSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupConnectionSource.Location = new System.Drawing.Point(28, 292);
            this.groupConnectionSource.Name = "groupConnectionSource";
            this.groupConnectionSource.Size = new System.Drawing.Size(841, 240);
            this.groupConnectionSource.TabIndex = 0;
            this.groupConnectionSource.TabStop = false;
            this.groupConnectionSource.Text = "Source CRM instance";
            // 
            // lblTestConnectionAwait
            // 
            this.lblTestConnectionAwait.AutoSize = true;
            this.lblTestConnectionAwait.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTestConnectionAwait.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTestConnectionAwait.Location = new System.Drawing.Point(554, 158);
            this.lblTestConnectionAwait.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTestConnectionAwait.Name = "lblTestConnectionAwait";
            this.lblTestConnectionAwait.Size = new System.Drawing.Size(86, 13);
            this.lblTestConnectionAwait.TabIndex = 14;
            this.lblTestConnectionAwait.Text = "... connecting";
            this.lblTestConnectionAwait.Visible = false;
            // 
            // lblTemp1
            // 
            this.lblTemp1.AutoSize = true;
            this.lblTemp1.ForeColor = System.Drawing.Color.Red;
            this.lblTemp1.Location = new System.Drawing.Point(423, 25);
            this.lblTemp1.Name = "lblTemp1";
            this.lblTemp1.Size = new System.Drawing.Size(95, 13);
            this.lblTemp1.TabIndex = 6;
            this.lblTemp1.Text = "under construction";
            // 
            // lblTestConnSource
            // 
            this.lblTestConnSource.AutoSize = true;
            this.lblTestConnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTestConnSource.Location = new System.Drawing.Point(637, 189);
            this.lblTestConnSource.Name = "lblTestConnSource";
            this.lblTestConnSource.Size = new System.Drawing.Size(0, 13);
            this.lblTestConnSource.TabIndex = 13;
            // 
            // lblAuthType
            // 
            this.lblAuthType.AutoSize = true;
            this.lblAuthType.Enabled = false;
            this.lblAuthType.Location = new System.Drawing.Point(23, 30);
            this.lblAuthType.Name = "lblAuthType";
            this.lblAuthType.Size = new System.Drawing.Size(175, 13);
            this.lblAuthType.TabIndex = 5;
            this.lblAuthType.Text = "Authentication type - Office365, firm";
            // 
            // btnTestConnSource
            // 
            this.btnTestConnSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTestConnSource.Location = new System.Drawing.Point(639, 152);
            this.btnTestConnSource.Name = "btnTestConnSource";
            this.btnTestConnSource.Size = new System.Drawing.Size(163, 27);
            this.btnTestConnSource.TabIndex = 12;
            this.btnTestConnSource.Text = "Test Connection";
            this.btnTestConnSource.UseVisualStyleBackColor = true;
            this.btnTestConnSource.Click += new System.EventHandler(this.btnTestConnSource_Click);
            // 
            // ddlAuthType
            // 
            this.ddlAuthType.Enabled = false;
            this.ddlAuthType.FormattingEnabled = true;
            this.ddlAuthType.Location = new System.Drawing.Point(218, 27);
            this.ddlAuthType.Name = "ddlAuthType";
            this.ddlAuthType.Size = new System.Drawing.Size(199, 21);
            this.ddlAuthType.TabIndex = 4;
            // 
            // lblUrlPattenSource
            // 
            this.lblUrlPattenSource.AutoSize = true;
            this.lblUrlPattenSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblUrlPattenSource.Location = new System.Drawing.Point(218, 124);
            this.lblUrlPattenSource.Name = "lblUrlPattenSource";
            this.lblUrlPattenSource.Size = new System.Drawing.Size(178, 13);
            this.lblUrlPattenSource.TabIndex = 11;
            this.lblUrlPattenSource.Text = "https://OrgName.crm.dynamics.com";
            // 
            // lblUniqueNamePathSource
            // 
            this.lblUniqueNamePathSource.AutoSize = true;
            this.lblUniqueNamePathSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblUniqueNamePathSource.Location = new System.Drawing.Point(218, 81);
            this.lblUniqueNamePathSource.Name = "lblUniqueNamePathSource";
            this.lblUniqueNamePathSource.Size = new System.Drawing.Size(319, 13);
            this.lblUniqueNamePathSource.TabIndex = 10;
            this.lblUniqueNamePathSource.Text = "Settings > Customizations > Developer Resources > Unique Name";
            // 
            // tbxPasswordSource
            // 
            this.tbxPasswordSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxPasswordSource.Location = new System.Drawing.Point(216, 185);
            this.tbxPasswordSource.Name = "tbxPasswordSource";
            this.tbxPasswordSource.PasswordChar = '*';
            this.tbxPasswordSource.Size = new System.Drawing.Size(317, 20);
            this.tbxPasswordSource.TabIndex = 8;
            // 
            // lblPasswordSource
            // 
            this.lblPasswordSource.AutoSize = true;
            this.lblPasswordSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPasswordSource.Location = new System.Drawing.Point(23, 187);
            this.lblPasswordSource.Name = "lblPasswordSource";
            this.lblPasswordSource.Size = new System.Drawing.Size(53, 13);
            this.lblPasswordSource.TabIndex = 7;
            this.lblPasswordSource.Text = "Password";
            // 
            // tbxUsernameSource
            // 
            this.tbxUsernameSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxUsernameSource.Location = new System.Drawing.Point(216, 156);
            this.tbxUsernameSource.Name = "tbxUsernameSource";
            this.tbxUsernameSource.Size = new System.Drawing.Size(317, 20);
            this.tbxUsernameSource.TabIndex = 6;
            // 
            // tbxServerUrlSource
            // 
            this.tbxServerUrlSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxServerUrlSource.Location = new System.Drawing.Point(215, 102);
            this.tbxServerUrlSource.Name = "tbxServerUrlSource";
            this.tbxServerUrlSource.Size = new System.Drawing.Size(528, 20);
            this.tbxServerUrlSource.TabIndex = 5;
            // 
            // tbxOrgNameSource
            // 
            this.tbxOrgNameSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxOrgNameSource.Location = new System.Drawing.Point(218, 59);
            this.tbxOrgNameSource.Name = "tbxOrgNameSource";
            this.tbxOrgNameSource.Size = new System.Drawing.Size(320, 20);
            this.tbxOrgNameSource.TabIndex = 4;
            // 
            // lblUserSource
            // 
            this.lblUserSource.AutoSize = true;
            this.lblUserSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblUserSource.Location = new System.Drawing.Point(26, 156);
            this.lblUserSource.Name = "lblUserSource";
            this.lblUserSource.Size = new System.Drawing.Size(29, 13);
            this.lblUserSource.TabIndex = 3;
            this.lblUserSource.Text = "User";
            // 
            // lblServerUrlSource
            // 
            this.lblServerUrlSource.AutoSize = true;
            this.lblServerUrlSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblServerUrlSource.Location = new System.Drawing.Point(23, 105);
            this.lblServerUrlSource.Name = "lblServerUrlSource";
            this.lblServerUrlSource.Size = new System.Drawing.Size(54, 13);
            this.lblServerUrlSource.TabIndex = 2;
            this.lblServerUrlSource.Text = "Server Url";
            // 
            // lblOrgNameSource
            // 
            this.lblOrgNameSource.AutoSize = true;
            this.lblOrgNameSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblOrgNameSource.Location = new System.Drawing.Point(26, 61);
            this.lblOrgNameSource.Name = "lblOrgNameSource";
            this.lblOrgNameSource.Size = new System.Drawing.Size(97, 13);
            this.lblOrgNameSource.TabIndex = 1;
            this.lblOrgNameSource.Text = "Organization Name";
            // 
            // btnLoadSchema
            // 
            this.btnLoadSchema.Enabled = false;
            this.btnLoadSchema.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoadSchema.Location = new System.Drawing.Point(28, 168);
            this.btnLoadSchema.Name = "btnLoadSchema";
            this.btnLoadSchema.Size = new System.Drawing.Size(302, 27);
            this.btnLoadSchema.TabIndex = 35;
            this.btnLoadSchema.Text = "Load Cofiguration Manager Package";
            this.btnLoadSchema.UseVisualStyleBackColor = true;
            this.btnLoadSchema.Click += new System.EventHandler(this.btnLoadSchema_Click);
            // 
            // lblProject2
            // 
            this.lblProject2.AutoSize = true;
            this.lblProject2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProject2.Location = new System.Drawing.Point(416, 145);
            this.lblProject2.Name = "lblProject2";
            this.lblProject2.Size = new System.Drawing.Size(535, 68);
            this.lblProject2.TabIndex = 9;
            this.lblProject2.Text = "\r\n   2. Select location of \"zip\" package created with Configuration Manager\r\n\r\n  " +
    "     tool to add schema and data files to the project.";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProject.Location = new System.Drawing.Point(231, 26);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(621, 102);
            this.lblProject.TabIndex = 6;
            this.lblProject.Text = resources.GetString("lblProject.Text");
            // 
            // btnProject
            // 
            this.btnProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnProject.Location = new System.Drawing.Point(28, 43);
            this.btnProject.Name = "btnProject";
            this.btnProject.Size = new System.Drawing.Size(150, 27);
            this.btnProject.TabIndex = 2;
            this.btnProject.Text = "Create Project";
            this.btnProject.UseVisualStyleBackColor = true;
            this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
            // 
            // groupProjectSchema
            // 
            this.groupProjectSchema.Controls.Add(this.treeProject);
            this.groupProjectSchema.Controls.Add(this.tbxProject);
            this.groupProjectSchema.Location = new System.Drawing.Point(928, 29);
            this.groupProjectSchema.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupProjectSchema.Name = "groupProjectSchema";
            this.groupProjectSchema.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupProjectSchema.Size = new System.Drawing.Size(470, 620);
            this.groupProjectSchema.TabIndex = 38;
            this.groupProjectSchema.TabStop = false;
            this.groupProjectSchema.Text = "Project Files";
            // 
            // treeProject
            // 
            this.treeProject.Location = new System.Drawing.Point(22, 67);
            this.treeProject.Name = "treeProject";
            this.treeProject.Size = new System.Drawing.Size(423, 535);
            this.treeProject.TabIndex = 0;
            // 
            // tbxProject
            // 
            this.tbxProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxProject.Location = new System.Drawing.Point(22, 25);
            this.tbxProject.Name = "tbxProject";
            this.tbxProject.ReadOnly = true;
            this.tbxProject.Size = new System.Drawing.Size(423, 20);
            this.tbxProject.TabIndex = 1;
            // 
            // groupProjectActions
            // 
            this.groupProjectActions.Controls.Add(this.btnProjectSaveAndNext);
            this.groupProjectActions.Location = new System.Drawing.Point(18, 582);
            this.groupProjectActions.Name = "groupProjectActions";
            this.groupProjectActions.Size = new System.Drawing.Size(894, 67);
            this.groupProjectActions.TabIndex = 36;
            this.groupProjectActions.TabStop = false;
            // 
            // btnProjectSaveAndNext
            // 
            this.btnProjectSaveAndNext.Location = new System.Drawing.Point(642, 22);
            this.btnProjectSaveAndNext.Name = "btnProjectSaveAndNext";
            this.btnProjectSaveAndNext.Size = new System.Drawing.Size(200, 27);
            this.btnProjectSaveAndNext.TabIndex = 4;
            this.btnProjectSaveAndNext.Text = "Save and Next";
            this.btnProjectSaveAndNext.UseVisualStyleBackColor = true;
            this.btnProjectSaveAndNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabModifyDataBasedOnSavedQueries
            // 
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupViewsAdvanced);
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupViewDataFilter);
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupBox5);
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupViewsTips);
            this.tabModifyDataBasedOnSavedQueries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabModifyDataBasedOnSavedQueries.Location = new System.Drawing.Point(4, 35);
            this.tabModifyDataBasedOnSavedQueries.Name = "tabModifyDataBasedOnSavedQueries";
            this.tabModifyDataBasedOnSavedQueries.Size = new System.Drawing.Size(1410, 669);
            this.tabModifyDataBasedOnSavedQueries.TabIndex = 3;
            this.tabModifyDataBasedOnSavedQueries.Text = "Modify Data: Saved Views filters";
            this.tabModifyDataBasedOnSavedQueries.UseVisualStyleBackColor = true;
            // 
            // groupViewsAdvanced
            // 
            this.groupViewsAdvanced.Controls.Add(this.lblSorceDataFile);
            this.groupViewsAdvanced.Controls.Add(this.lblResultDataFile);
            this.groupViewsAdvanced.Controls.Add(this.treeResultDataFile);
            this.groupViewsAdvanced.Controls.Add(this.treeSorceDataFile);
            this.groupViewsAdvanced.Location = new System.Drawing.Point(860, 15);
            this.groupViewsAdvanced.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupViewsAdvanced.Name = "groupViewsAdvanced";
            this.groupViewsAdvanced.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupViewsAdvanced.Size = new System.Drawing.Size(248, 589);
            this.groupViewsAdvanced.TabIndex = 44;
            this.groupViewsAdvanced.TabStop = false;
            this.groupViewsAdvanced.Text = "Filters and Results PreView";
            // 
            // lblSorceDataFile
            // 
            this.lblSorceDataFile.AutoSize = true;
            this.lblSorceDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSorceDataFile.Location = new System.Drawing.Point(20, 28);
            this.lblSorceDataFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSorceDataFile.Name = "lblSorceDataFile";
            this.lblSorceDataFile.Size = new System.Drawing.Size(68, 13);
            this.lblSorceDataFile.TabIndex = 50;
            this.lblSorceDataFile.Text = "Original Data";
            // 
            // lblResultDataFile
            // 
            this.lblResultDataFile.AutoSize = true;
            this.lblResultDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblResultDataFile.Location = new System.Drawing.Point(20, 315);
            this.lblResultDataFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultDataFile.Name = "lblResultDataFile";
            this.lblResultDataFile.Size = new System.Drawing.Size(138, 13);
            this.lblResultDataFile.TabIndex = 49;
            this.lblResultDataFile.Text = "Processed Records Monitor";
            // 
            // treeResultDataFile
            // 
            this.treeResultDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.treeResultDataFile.Location = new System.Drawing.Point(15, 348);
            this.treeResultDataFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeResultDataFile.Name = "treeResultDataFile";
            this.treeResultDataFile.Size = new System.Drawing.Size(215, 225);
            this.treeResultDataFile.TabIndex = 46;
            // 
            // treeSorceDataFile
            // 
            this.treeSorceDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.treeSorceDataFile.Location = new System.Drawing.Point(15, 63);
            this.treeSorceDataFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeSorceDataFile.Name = "treeSorceDataFile";
            this.treeSorceDataFile.Size = new System.Drawing.Size(215, 225);
            this.treeSorceDataFile.TabIndex = 0;
            // 
            // groupViewDataFilter
            // 
            this.groupViewDataFilter.Controls.Add(this.cbxExecuteAsListOfLinkedQueries);
            this.groupViewDataFilter.Controls.Add(this.lblViewsNoConnection);
            this.groupViewDataFilter.Controls.Add(this.lblConnectionAwaitViews);
            this.groupViewDataFilter.Controls.Add(this.lblViewsActionTypeOperatot);
            this.groupViewDataFilter.Controls.Add(this.ddlViewsActionOperator);
            this.groupViewDataFilter.Controls.Add(this.lstListOfViewsFilters);
            this.groupViewDataFilter.Controls.Add(this.lblViewsByEntity);
            this.groupViewDataFilter.Controls.Add(this.label5);
            this.groupViewDataFilter.Controls.Add(this.label6);
            this.groupViewDataFilter.Controls.Add(this.lstDefaultSchemaDataByViews);
            this.groupViewDataFilter.Controls.Add(this.lstViewsPerEntity);
            this.groupViewDataFilter.Controls.Add(this.btnbtnViews_FromDefaultToSelected);
            this.groupViewDataFilter.Controls.Add(this.btnViews_ReturnToDefaultFromSelected);
            this.groupViewDataFilter.Controls.Add(this.lblListOfViewsFilters);
            this.groupViewDataFilter.Controls.Add(this.lstSelectedSchemaDataByViews);
            this.groupViewDataFilter.Location = new System.Drawing.Point(15, 15);
            this.groupViewDataFilter.Name = "groupViewDataFilter";
            this.groupViewDataFilter.Size = new System.Drawing.Size(828, 588);
            this.groupViewDataFilter.TabIndex = 43;
            this.groupViewDataFilter.TabStop = false;
            this.groupViewDataFilter.Text = "Set Saved Views as Data Filters ";
            // 
            // lblViewsNoConnection
            // 
            this.lblViewsNoConnection.AutoSize = true;
            this.lblViewsNoConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblViewsNoConnection.ForeColor = System.Drawing.Color.Red;
            this.lblViewsNoConnection.Location = new System.Drawing.Point(94, 513);
            this.lblViewsNoConnection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblViewsNoConnection.Name = "lblViewsNoConnection";
            this.lblViewsNoConnection.Size = new System.Drawing.Size(368, 60);
            this.lblViewsNoConnection.TabIndex = 58;
            this.lblViewsNoConnection.Text = "Cannot connect to crm and download Saved view/s\r\n \r\n               Other tool\'s f" +
    "eatures weren\'t affected";
            this.lblViewsNoConnection.Visible = false;
            // 
            // lblConnectionAwaitViews
            // 
            this.lblConnectionAwaitViews.AutoSize = true;
            this.lblConnectionAwaitViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblConnectionAwaitViews.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblConnectionAwaitViews.Location = new System.Drawing.Point(53, 42);
            this.lblConnectionAwaitViews.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnectionAwaitViews.Name = "lblConnectionAwaitViews";
            this.lblConnectionAwaitViews.Size = new System.Drawing.Size(349, 25);
            this.lblConnectionAwaitViews.TabIndex = 57;
            this.lblConnectionAwaitViews.Text = "... loading, waiting for crm connection ...";
            this.lblConnectionAwaitViews.Visible = false;
            // 
            // lblViewsActionTypeOperatot
            // 
            this.lblViewsActionTypeOperatot.AutoSize = true;
            this.lblViewsActionTypeOperatot.Location = new System.Drawing.Point(522, 347);
            this.lblViewsActionTypeOperatot.Name = "lblViewsActionTypeOperatot";
            this.lblViewsActionTypeOperatot.Size = new System.Drawing.Size(126, 17);
            this.lblViewsActionTypeOperatot.TabIndex = 59;
            this.lblViewsActionTypeOperatot.Text = "Select Action Type";
            // 
            // ddlViewsActionOperator
            // 
            this.ddlViewsActionOperator.Enabled = false;
            this.ddlViewsActionOperator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ddlViewsActionOperator.FormattingEnabled = true;
            this.ddlViewsActionOperator.Items.AddRange(new object[] {
            "Selected Only",
            "All Except Selected"});
            this.ddlViewsActionOperator.Location = new System.Drawing.Point(654, 347);
            this.ddlViewsActionOperator.Name = "ddlViewsActionOperator";
            this.ddlViewsActionOperator.Size = new System.Drawing.Size(157, 21);
            this.ddlViewsActionOperator.TabIndex = 10;
            // 
            // lstListOfViewsFilters
            // 
            this.lstListOfViewsFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstListOfViewsFilters.FormattingEnabled = true;
            this.lstListOfViewsFilters.Location = new System.Drawing.Point(523, 374);
            this.lstListOfViewsFilters.Name = "lstListOfViewsFilters";
            this.lstListOfViewsFilters.Size = new System.Drawing.Size(288, 186);
            this.lstListOfViewsFilters.Sorted = true;
            this.lstListOfViewsFilters.TabIndex = 55;
            this.lstListOfViewsFilters.SelectedIndexChanged += new System.EventHandler(this.lstListOfViewsFilters_SelectedIndexChanged);
            this.lstListOfViewsFilters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstListOfViewsFilters_MouseDoubleClick);
            // 
            // lblViewsByEntity
            // 
            this.lblViewsByEntity.AutoSize = true;
            this.lblViewsByEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblViewsByEntity.Location = new System.Drawing.Point(522, 28);
            this.lblViewsByEntity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblViewsByEntity.Name = "lblViewsByEntity";
            this.lblViewsByEntity.Size = new System.Drawing.Size(290, 39);
            this.lblViewsByEntity.TabIndex = 54;
            this.lblViewsByEntity.Text = "List of public Saved User Views available for selected entity.\r\n\r\nDouble click a " +
    "view to add to filtters list";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(298, 146);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Selecte Entity to see its Saved Views";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(42, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "List of Entities in Schema file";
            // 
            // lstDefaultSchemaDataByViews
            // 
            this.lstDefaultSchemaDataByViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstDefaultSchemaDataByViews.FormattingEnabled = true;
            this.lstDefaultSchemaDataByViews.Location = new System.Drawing.Point(13, 181);
            this.lstDefaultSchemaDataByViews.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstDefaultSchemaDataByViews.Name = "lstDefaultSchemaDataByViews";
            this.lstDefaultSchemaDataByViews.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDefaultSchemaDataByViews.Size = new System.Drawing.Size(206, 277);
            this.lstDefaultSchemaDataByViews.Sorted = true;
            this.lstDefaultSchemaDataByViews.TabIndex = 42;
            // 
            // lstViewsPerEntity
            // 
            this.lstViewsPerEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstViewsPerEntity.FormattingEnabled = true;
            this.lstViewsPerEntity.Location = new System.Drawing.Point(523, 76);
            this.lstViewsPerEntity.Name = "lstViewsPerEntity";
            this.lstViewsPerEntity.Size = new System.Drawing.Size(289, 186);
            this.lstViewsPerEntity.Sorted = true;
            this.lstViewsPerEntity.TabIndex = 51;
            this.lstViewsPerEntity.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstViewsPerEntity_MouseDoubleClick);
            // 
            // btnbtnViews_FromDefaultToSelected
            // 
            this.btnbtnViews_FromDefaultToSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnbtnViews_FromDefaultToSelected.Location = new System.Drawing.Point(238, 284);
            this.btnbtnViews_FromDefaultToSelected.Name = "btnbtnViews_FromDefaultToSelected";
            this.btnbtnViews_FromDefaultToSelected.Size = new System.Drawing.Size(39, 23);
            this.btnbtnViews_FromDefaultToSelected.TabIndex = 49;
            this.btnbtnViews_FromDefaultToSelected.Text = " >>";
            this.btnbtnViews_FromDefaultToSelected.UseVisualStyleBackColor = true;
            this.btnbtnViews_FromDefaultToSelected.Click += new System.EventHandler(this.btnbtnViews_FromDefaultToSelected_Click);
            // 
            // btnViews_ReturnToDefaultFromSelected
            // 
            this.btnViews_ReturnToDefaultFromSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnViews_ReturnToDefaultFromSelected.Location = new System.Drawing.Point(238, 354);
            this.btnViews_ReturnToDefaultFromSelected.Name = "btnViews_ReturnToDefaultFromSelected";
            this.btnViews_ReturnToDefaultFromSelected.Size = new System.Drawing.Size(39, 23);
            this.btnViews_ReturnToDefaultFromSelected.TabIndex = 50;
            this.btnViews_ReturnToDefaultFromSelected.Text = " <<";
            this.btnViews_ReturnToDefaultFromSelected.UseVisualStyleBackColor = true;
            this.btnViews_ReturnToDefaultFromSelected.Click += new System.EventHandler(this.btnViews_ReturnToDefaultFromSelected_Click);
            // 
            // lblListOfViewsFilters
            // 
            this.lblListOfViewsFilters.AutoSize = true;
            this.lblListOfViewsFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblListOfViewsFilters.Location = new System.Drawing.Point(520, 289);
            this.lblListOfViewsFilters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblListOfViewsFilters.Name = "lblListOfViewsFilters";
            this.lblListOfViewsFilters.Size = new System.Drawing.Size(214, 39);
            this.lblListOfViewsFilters.TabIndex = 47;
            this.lblListOfViewsFilters.Text = "Saved views selected for filters\r\n\r\nDouble click a view to remove it from the lis" +
    "t";
            // 
            // lstSelectedSchemaDataByViews
            // 
            this.lstSelectedSchemaDataByViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstSelectedSchemaDataByViews.FormattingEnabled = true;
            this.lstSelectedSchemaDataByViews.Location = new System.Drawing.Point(289, 181);
            this.lstSelectedSchemaDataByViews.Name = "lstSelectedSchemaDataByViews";
            this.lstSelectedSchemaDataByViews.Size = new System.Drawing.Size(206, 277);
            this.lstSelectedSchemaDataByViews.Sorted = true;
            this.lstSelectedSchemaDataByViews.TabIndex = 41;
            this.lstSelectedSchemaDataByViews.SelectedIndexChanged += new System.EventHandler(this.lstSelectedSchemaDataByViews_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnViewsBack);
            this.groupBox5.Controls.Add(this.btnSaveModifyViewsFile);
            this.groupBox5.Controls.Add(this.btnViewNext);
            this.groupBox5.Location = new System.Drawing.Point(15, 609);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1093, 52);
            this.groupBox5.TabIndex = 42;
            this.groupBox5.TabStop = false;
            // 
            // btnViewsBack
            // 
            this.btnViewsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewsBack.Location = new System.Drawing.Point(15, 19);
            this.btnViewsBack.Name = "btnViewsBack";
            this.btnViewsBack.Size = new System.Drawing.Size(200, 27);
            this.btnViewsBack.TabIndex = 6;
            this.btnViewsBack.Text = "Save and Back";
            this.btnViewsBack.UseVisualStyleBackColor = true;
            this.btnViewsBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSaveModifyViewsFile
            // 
            this.btnSaveModifyViewsFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveModifyViewsFile.Location = new System.Drawing.Point(445, 19);
            this.btnSaveModifyViewsFile.Name = "btnSaveModifyViewsFile";
            this.btnSaveModifyViewsFile.Size = new System.Drawing.Size(200, 27);
            this.btnSaveModifyViewsFile.TabIndex = 5;
            this.btnSaveModifyViewsFile.Text = "Modify And Save Data";
            this.btnSaveModifyViewsFile.UseVisualStyleBackColor = true;
            this.btnSaveModifyViewsFile.Click += new System.EventHandler(this.btnSaveModifyViewsFile_Click);
            // 
            // btnViewNext
            // 
            this.btnViewNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewNext.Location = new System.Drawing.Point(875, 19);
            this.btnViewNext.Name = "btnViewNext";
            this.btnViewNext.Size = new System.Drawing.Size(200, 27);
            this.btnViewNext.TabIndex = 4;
            this.btnViewNext.Text = "Save and Next";
            this.btnViewNext.UseVisualStyleBackColor = true;
            this.btnViewNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupViewsTips
            // 
            this.groupViewsTips.Location = new System.Drawing.Point(1127, 9);
            this.groupViewsTips.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupViewsTips.Name = "groupViewsTips";
            this.groupViewsTips.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupViewsTips.Size = new System.Drawing.Size(265, 646);
            this.groupViewsTips.TabIndex = 39;
            this.groupViewsTips.TabStop = false;
            this.groupViewsTips.Text = "Tips";
            // 
            // tabReplaceIDs
            // 
            this.tabReplaceIDs.Controls.Add(this.btnCopyToolFromModified);
            this.tabReplaceIDs.Controls.Add(this.btnCopyToolFromSource);
            this.tabReplaceIDs.Controls.Add(this.groupCopyToolTips);
            this.tabReplaceIDs.Controls.Add(this.groupBox4);
            this.tabReplaceIDs.Location = new System.Drawing.Point(4, 35);
            this.tabReplaceIDs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabReplaceIDs.Name = "tabReplaceIDs";
            this.tabReplaceIDs.Size = new System.Drawing.Size(1410, 669);
            this.tabReplaceIDs.TabIndex = 4;
            this.tabReplaceIDs.Text = "Copy Tool";
            this.tabReplaceIDs.UseVisualStyleBackColor = true;
            // 
            // btnCopyToolFromModified
            // 
            this.btnCopyToolFromModified.Location = new System.Drawing.Point(60, 228);
            this.btnCopyToolFromModified.Name = "btnCopyToolFromModified";
            this.btnCopyToolFromModified.Size = new System.Drawing.Size(644, 75);
            this.btnCopyToolFromModified.TabIndex = 41;
            this.btnCopyToolFromModified.Text = "Create copy of pre-filtered by Saved Views data file with new GUIDs";
            this.btnCopyToolFromModified.UseVisualStyleBackColor = true;
            this.btnCopyToolFromModified.Click += new System.EventHandler(this.btnCopyToolFromModified_Click);
            // 
            // btnCopyToolFromSource
            // 
            this.btnCopyToolFromSource.Location = new System.Drawing.Point(60, 71);
            this.btnCopyToolFromSource.Name = "btnCopyToolFromSource";
            this.btnCopyToolFromSource.Size = new System.Drawing.Size(644, 75);
            this.btnCopyToolFromSource.TabIndex = 40;
            this.btnCopyToolFromSource.Text = "Create copy of original data file with new GUIDs";
            this.btnCopyToolFromSource.UseVisualStyleBackColor = true;
            this.btnCopyToolFromSource.Click += new System.EventHandler(this.btnCopyToolFromSource_Click);
            // 
            // groupCopyToolTips
            // 
            this.groupCopyToolTips.Location = new System.Drawing.Point(1129, 11);
            this.groupCopyToolTips.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupCopyToolTips.Name = "groupCopyToolTips";
            this.groupCopyToolTips.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupCopyToolTips.Size = new System.Drawing.Size(265, 646);
            this.groupCopyToolTips.TabIndex = 39;
            this.groupCopyToolTips.TabStop = false;
            this.groupCopyToolTips.Text = "Tips";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCopyToolBack);
            this.groupBox4.Location = new System.Drawing.Point(16, 590);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1094, 67);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            // 
            // btnCopyToolBack
            // 
            this.btnCopyToolBack.Enabled = false;
            this.btnCopyToolBack.Location = new System.Drawing.Point(44, 20);
            this.btnCopyToolBack.Name = "btnCopyToolBack";
            this.btnCopyToolBack.Size = new System.Drawing.Size(200, 27);
            this.btnCopyToolBack.TabIndex = 6;
            this.btnCopyToolBack.Text = "Save And Back";
            this.btnCopyToolBack.UseVisualStyleBackColor = true;
            this.btnCopyToolBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // openFileDialogLoadSchema
            // 
            this.openFileDialogLoadSchema.Filter = "ZIP Files (*.zip)|*.zip";
            this.openFileDialogLoadSchema.Title = "Select a zip (by Configuration Migration tool)";
            // 
            // openFileLoadProject
            // 
            this.openFileLoadProject.Filter = "XML Files (*.xml)|*.xml";
            this.openFileLoadProject.Title = "Select a project xml to load";
            // 
            // cbxExecuteAsListOfLinkedQueries
            // 
            this.cbxExecuteAsListOfLinkedQueries.AutoSize = true;
            this.cbxExecuteAsListOfLinkedQueries.Location = new System.Drawing.Point(83, 474);
            this.cbxExecuteAsListOfLinkedQueries.Name = "cbxExecuteAsListOfLinkedQueries";
            this.cbxExecuteAsListOfLinkedQueries.Size = new System.Drawing.Size(242, 21);
            this.cbxExecuteAsListOfLinkedQueries.TabIndex = 60;
            this.cbxExecuteAsListOfLinkedQueries.Text = "Execute As List Of Linked Queries";
            this.cbxExecuteAsListOfLinkedQueries.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1448, 735);
            this.Controls.Add(this.tabsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Migration Management tool";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabsPanel.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.gboxProject.ResumeLayout(false);
            this.gboxProject.PerformLayout();
            this.groupConnectionSource.ResumeLayout(false);
            this.groupConnectionSource.PerformLayout();
            this.groupProjectSchema.ResumeLayout(false);
            this.groupProjectSchema.PerformLayout();
            this.groupProjectActions.ResumeLayout(false);
            this.tabModifyDataBasedOnSavedQueries.ResumeLayout(false);
            this.groupViewsAdvanced.ResumeLayout(false);
            this.groupViewsAdvanced.PerformLayout();
            this.groupViewDataFilter.ResumeLayout(false);
            this.groupViewDataFilter.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tabReplaceIDs.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel tabsPanel;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.GroupBox groupConnectionSource;
        private System.Windows.Forms.TextBox tbxPasswordSource;
        private System.Windows.Forms.Label lblPasswordSource;
        private System.Windows.Forms.TextBox tbxUsernameSource;
        private System.Windows.Forms.TextBox tbxServerUrlSource;
        private System.Windows.Forms.TextBox tbxOrgNameSource;
        private System.Windows.Forms.Label lblUserSource;
        private System.Windows.Forms.Label lblServerUrlSource;
        private System.Windows.Forms.Label lblOrgNameSource;
        private System.Windows.Forms.Label lblUniqueNamePathSource;
        private System.Windows.Forms.Label lblUrlPattenSource;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLoadProject;
        private System.Windows.Forms.Label lblTestConnSource;
        private System.Windows.Forms.Button btnTestConnSource;
        private System.Windows.Forms.ComboBox ddlViewsActionOperator;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadSchema;
        private System.Windows.Forms.Button btnLoadSchema;
        private System.Windows.Forms.TabPage tabModifyDataBasedOnSavedQueries;
        private System.Windows.Forms.TabPage tabReplaceIDs;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnCopyToolBack;
        private System.Windows.Forms.TabPage tabProject;
        private System.Windows.Forms.GroupBox groupProjectActions;
        private System.Windows.Forms.Button btnProjectSaveAndNext;
        private System.Windows.Forms.GroupBox groupCopyToolTips;
        private System.Windows.Forms.GroupBox groupViewsTips;
        private System.Windows.Forms.GroupBox groupProjectSchema;
        private System.Windows.Forms.Label lblAuthType;
        private System.Windows.Forms.ComboBox ddlAuthType;
        private System.Windows.Forms.Label lblTemp1;
        private System.Windows.Forms.GroupBox gboxProject;
        private System.Windows.Forms.Button btnProject;
        private System.Windows.Forms.TextBox tbxProject;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblProject2;
        private System.Windows.Forms.TreeView treeProject;
        private System.Windows.Forms.Button btnProjectLoad;
        private System.Windows.Forms.OpenFileDialog openFileLoadProject;
        private System.Windows.Forms.GroupBox groupViewsAdvanced;
        private System.Windows.Forms.Label lblSorceDataFile;
        private System.Windows.Forms.Label lblResultDataFile;
        private System.Windows.Forms.TreeView treeResultDataFile;
        private System.Windows.Forms.TreeView treeSorceDataFile;
        private System.Windows.Forms.GroupBox groupViewDataFilter;
        private System.Windows.Forms.Label lblViewsByEntity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstDefaultSchemaDataByViews;
        private System.Windows.Forms.ListBox lstViewsPerEntity;
        private System.Windows.Forms.Button btnbtnViews_FromDefaultToSelected;
        private System.Windows.Forms.Button btnViews_ReturnToDefaultFromSelected;
        private System.Windows.Forms.Label lblListOfViewsFilters;
        private System.Windows.Forms.ListBox lstSelectedSchemaDataByViews;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnViewsBack;
        private System.Windows.Forms.Button btnSaveModifyViewsFile;
        private System.Windows.Forms.Button btnViewNext;
        private System.Windows.Forms.ListBox lstListOfViewsFilters;
        private System.Windows.Forms.Label lblConnectionAwaitViews;
        private System.Windows.Forms.Label lblViewsNoConnection;
        private System.Windows.Forms.Label lblProject3;
        private System.Windows.Forms.Label lblViewsActionTypeOperatot;
        private System.Windows.Forms.Button btnCopyToolFromModified;
        private System.Windows.Forms.Button btnCopyToolFromSource;
        private System.Windows.Forms.Label lblTestConnectionAwait;
        private System.Windows.Forms.CheckBox cbxExecuteAsListOfLinkedQueries;
    }
}

