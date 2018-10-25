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
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.linkWiki = new System.Windows.Forms.LinkLabel();
            this.lblAboutSubTitle = new System.Windows.Forms.Label();
            this.btnBegin = new System.Windows.Forms.Button();
            this.lblAbout3 = new System.Windows.Forms.Label();
            this.lblAbout3content = new System.Windows.Forms.Label();
            this.lblAbout2 = new System.Windows.Forms.Label();
            this.lblAbout2content = new System.Windows.Forms.Label();
            this.lblAbout1 = new System.Windows.Forms.Label();
            this.lblAboutTitle = new System.Windows.Forms.Label();
            this.lblAbout1content = new System.Windows.Forms.Label();
            this.tabProject = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTargetConnectionChange = new System.Windows.Forms.Button();
            this.btnSourcetConnectionChange = new System.Windows.Forms.Button();
            this.lblProjectFiles = new System.Windows.Forms.Label();
            this.treeProject = new System.Windows.Forms.TreeView();
            this.lblConnectedTo = new System.Windows.Forms.Label();
            this.tbxProject = new System.Windows.Forms.TextBox();
            this.linkTarget = new System.Windows.Forms.LinkLabel();
            this.linkSource = new System.Windows.Forms.LinkLabel();
            this.lblProject2 = new System.Windows.Forms.Label();
            this.cbxLoadProject = new System.Windows.Forms.CheckBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.cbxCreateProject = new System.Windows.Forms.CheckBox();
            this.cbxAttachmentsMigration = new System.Windows.Forms.CheckBox();
            this.tabModifyDataBasedOnSavedQueries = new System.Windows.Forms.TabPage();
            this.groupViewsAdvanced = new System.Windows.Forms.GroupBox();
            this.lblSorceDataFile = new System.Windows.Forms.Label();
            this.lblResultDataFile = new System.Windows.Forms.Label();
            this.treeResultDataFile = new System.Windows.Forms.TreeView();
            this.treeSorceDataFile = new System.Windows.Forms.TreeView();
            this.groupViewDataFilter = new System.Windows.Forms.GroupBox();
            this.lblTick3 = new System.Windows.Forms.Label();
            this.lblTick2 = new System.Windows.Forms.Label();
            this.lblTick1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblViewsTrans = new System.Windows.Forms.Label();
            this.btnSaveModifyViewsFile = new System.Windows.Forms.Button();
            this.btnViewsBack = new System.Windows.Forms.Button();
            this.lblTransformationSettings = new System.Windows.Forms.Label();
            this.lblTransformedQueryDisplay = new System.Windows.Forms.Label();
            this.cbxExcludeFromResult = new System.Windows.Forms.CheckBox();
            this.treeTransformedQueryDisplay = new System.Windows.Forms.TreeView();
            this.cbxExecuteAsListOfLinkedQueries = new System.Windows.Forms.CheckBox();
            this.cbxCollectAllReferences = new System.Windows.Forms.CheckBox();
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
            this.tabPortalsSync = new System.Windows.Forms.TabPage();
            this.groupPortalsSync = new System.Windows.Forms.GroupBox();
            this.btnAttachmentsLogs = new System.Windows.Forms.Button();
            this.lblSyncStart = new System.Windows.Forms.Label();
            this.lblPortalSyncTo = new System.Windows.Forms.Label();
            this.lblPortalSyncFrom = new System.Windows.Forms.Label();
            this.btnPortalSyncBack = new System.Windows.Forms.Button();
            this.cbxSyncSettings = new System.Windows.Forms.CheckBox();
            this.btnStartAttachmentsCopy = new System.Windows.Forms.Button();
            this.btnSelectAttachmentsDataFile = new System.Windows.Forms.Button();
            this.groupAttachmentsCopySettings = new System.Windows.Forms.GroupBox();
            this.cbxAttachmentsKeepIDs = new System.Windows.Forms.CheckBox();
            this.cbxIncludeTextNotes = new System.Windows.Forms.CheckBox();
            this.txtxAttachmentsDataFile = new System.Windows.Forms.TextBox();
            this.groupPortalsSources = new System.Windows.Forms.GroupBox();
            this.ddlSourcePortal = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlTargetPortal = new System.Windows.Forms.ComboBox();
            this.btnSelectIDsBackup = new System.Windows.Forms.Button();
            this.txtAttachmentsIDsBackUpFile = new System.Windows.Forms.TextBox();
            this.cbxBasedOnFiles = new System.Windows.Forms.CheckBox();
            this.cbxFromPortalToPortal = new System.Windows.Forms.CheckBox();
            this.cbxAttachmentsRollback = new System.Windows.Forms.CheckBox();
            this.tabReplaceIDs = new System.Windows.Forms.TabPage();
            this.groupCopyToolContent = new System.Windows.Forms.GroupBox();
            this.lblDataDouplInfo = new System.Windows.Forms.Label();
            this.btnCopyToolBack = new System.Windows.Forms.Button();
            this.btnCopyToolFromModified = new System.Windows.Forms.Button();
            this.btnCopyToolFromSource = new System.Windows.Forms.Button();
            this.folderBrowserDialogLoadProject = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogLoadSchema = new System.Windows.Forms.OpenFileDialog();
            this.openFileLoadProject = new System.Windows.Forms.OpenFileDialog();
            this.openFileAttachments = new System.Windows.Forms.OpenFileDialog();
            this.tabsPanel.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.tabModifyDataBasedOnSavedQueries.SuspendLayout();
            this.groupViewsAdvanced.SuspendLayout();
            this.groupViewDataFilter.SuspendLayout();
            this.tabPortalsSync.SuspendLayout();
            this.groupPortalsSync.SuspendLayout();
            this.groupAttachmentsCopySettings.SuspendLayout();
            this.groupPortalsSources.SuspendLayout();
            this.tabReplaceIDs.SuspendLayout();
            this.groupCopyToolContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsPanel
            // 
            this.tabsPanel.Controls.Add(this.tabs);
            this.tabsPanel.Location = new System.Drawing.Point(0, 0);
            this.tabsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabsPanel.Name = "tabsPanel";
            this.tabsPanel.Size = new System.Drawing.Size(1931, 1006);
            this.tabsPanel.TabIndex = 1;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabAbout);
            this.tabs.Controls.Add(this.tabProject);
            this.tabs.Controls.Add(this.tabModifyDataBasedOnSavedQueries);
            this.tabs.Controls.Add(this.tabReplaceIDs);
            this.tabs.Controls.Add(this.tabPortalsSync);
            this.tabs.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tabs.Location = new System.Drawing.Point(23, 14);
            this.tabs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(10, 8);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1904, 977);
            this.tabs.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.linkWiki);
            this.tabAbout.Controls.Add(this.lblAboutSubTitle);
            this.tabAbout.Controls.Add(this.btnBegin);
            this.tabAbout.Controls.Add(this.lblAbout3);
            this.tabAbout.Controls.Add(this.lblAbout3content);
            this.tabAbout.Controls.Add(this.lblAbout2);
            this.tabAbout.Controls.Add(this.lblAbout2content);
            this.tabAbout.Controls.Add(this.lblAbout1);
            this.tabAbout.Controls.Add(this.lblAboutTitle);
            this.tabAbout.Controls.Add(this.lblAbout1content);
            this.tabAbout.Location = new System.Drawing.Point(4, 38);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(1896, 935);
            this.tabAbout.TabIndex = 7;
            this.tabAbout.Text = "About DMM365 tool";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // linkWiki
            // 
            this.linkWiki.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.linkWiki.Location = new System.Drawing.Point(1599, 38);
            this.linkWiki.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkWiki.Name = "linkWiki";
            this.linkWiki.Size = new System.Drawing.Size(144, 32);
            this.linkWiki.TabIndex = 65;
            this.linkWiki.TabStop = true;
            this.linkWiki.Text = "Project Wiki";
            this.linkWiki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWiki_LinkClicked);
            // 
            // lblAboutSubTitle
            // 
            this.lblAboutSubTitle.AutoSize = true;
            this.lblAboutSubTitle.Location = new System.Drawing.Point(69, 85);
            this.lblAboutSubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAboutSubTitle.Name = "lblAboutSubTitle";
            this.lblAboutSubTitle.Size = new System.Drawing.Size(449, 19);
            this.lblAboutSubTitle.TabIndex = 64;
            this.lblAboutSubTitle.Text = "Each application tab represents a different functionality:";
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(1603, 860);
            this.btnBegin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(258, 33);
            this.btnBegin.TabIndex = 63;
            this.btnBegin.Text = "To Project";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // lblAbout3
            // 
            this.lblAbout3.AutoSize = true;
            this.lblAbout3.Location = new System.Drawing.Point(79, 405);
            this.lblAbout3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAbout3.Name = "lblAbout3";
            this.lblAbout3.Size = new System.Drawing.Size(159, 19);
            this.lblAbout3.TabIndex = 62;
            this.lblAbout3.Text = "2. Data Dupliacator";
            // 
            // lblAbout3content
            // 
            this.lblAbout3content.AutoSize = true;
            this.lblAbout3content.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout3content.Location = new System.Drawing.Point(95, 455);
            this.lblAbout3content.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAbout3content.Name = "lblAbout3content";
            this.lblAbout3content.Size = new System.Drawing.Size(842, 138);
            this.lblAbout3content.TabIndex = 61;
            this.lblAbout3content.Text = resources.GetString("lblAbout3content.Text");
            // 
            // lblAbout2
            // 
            this.lblAbout2.AutoSize = true;
            this.lblAbout2.Location = new System.Drawing.Point(79, 651);
            this.lblAbout2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAbout2.Name = "lblAbout2";
            this.lblAbout2.Size = new System.Drawing.Size(478, 19);
            this.lblAbout2.TabIndex = 60;
            this.lblAbout2.Text = "3. Copy CRM attachments and sync Portal 365 Site Settings";
            // 
            // lblAbout2content
            // 
            this.lblAbout2content.AutoSize = true;
            this.lblAbout2content.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout2content.Location = new System.Drawing.Point(95, 710);
            this.lblAbout2content.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAbout2content.Name = "lblAbout2content";
            this.lblAbout2content.Size = new System.Drawing.Size(1389, 207);
            this.lblAbout2content.TabIndex = 59;
            this.lblAbout2content.Text = resources.GetString("lblAbout2content.Text");
            // 
            // lblAbout1
            // 
            this.lblAbout1.AutoSize = true;
            this.lblAbout1.Location = new System.Drawing.Point(79, 140);
            this.lblAbout1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAbout1.Name = "lblAbout1";
            this.lblAbout1.Size = new System.Drawing.Size(293, 19);
            this.lblAbout1.TabIndex = 58;
            this.lblAbout1.Text = "1. CRM Granular Data Migration tool";
            // 
            // lblAboutTitle
            // 
            this.lblAboutTitle.AutoSize = true;
            this.lblAboutTitle.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutTitle.Location = new System.Drawing.Point(49, 42);
            this.lblAboutTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAboutTitle.Name = "lblAboutTitle";
            this.lblAboutTitle.Size = new System.Drawing.Size(1359, 29);
            this.lblAboutTitle.TabIndex = 57;
            this.lblAboutTitle.Text = "DMM is stands for Data Migration Manager. The tool dedicated to assist with Dynam" +
    "ics 365 dta migration and Portals 365 deployment. ";
            // 
            // lblAbout1content
            // 
            this.lblAbout1content.AutoSize = true;
            this.lblAbout1content.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout1content.Location = new System.Drawing.Point(95, 190);
            this.lblAbout1content.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAbout1content.Name = "lblAbout1content";
            this.lblAbout1content.Size = new System.Drawing.Size(1429, 161);
            this.lblAbout1content.TabIndex = 56;
            this.lblAbout1content.Text = resources.GetString("lblAbout1content.Text");
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.label4);
            this.tabProject.Controls.Add(this.btnTargetConnectionChange);
            this.tabProject.Controls.Add(this.btnSourcetConnectionChange);
            this.tabProject.Controls.Add(this.lblProjectFiles);
            this.tabProject.Controls.Add(this.treeProject);
            this.tabProject.Controls.Add(this.lblConnectedTo);
            this.tabProject.Controls.Add(this.tbxProject);
            this.tabProject.Controls.Add(this.linkTarget);
            this.tabProject.Controls.Add(this.linkSource);
            this.tabProject.Controls.Add(this.lblProject2);
            this.tabProject.Controls.Add(this.cbxLoadProject);
            this.tabProject.Controls.Add(this.lblProject);
            this.tabProject.Controls.Add(this.cbxCreateProject);
            this.tabProject.Controls.Add(this.cbxAttachmentsMigration);
            this.tabProject.Location = new System.Drawing.Point(4, 38);
            this.tabProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabProject.Name = "tabProject";
            this.tabProject.Size = new System.Drawing.Size(1896, 935);
            this.tabProject.TabIndex = 5;
            this.tabProject.Text = "Project Management";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(36, 791);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(880, 80);
            this.label4.TabIndex = 55;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // btnTargetConnectionChange
            // 
            this.btnTargetConnectionChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTargetConnectionChange.Location = new System.Drawing.Point(1644, 261);
            this.btnTargetConnectionChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTargetConnectionChange.Name = "btnTargetConnectionChange";
            this.btnTargetConnectionChange.Size = new System.Drawing.Size(101, 23);
            this.btnTargetConnectionChange.TabIndex = 54;
            this.btnTargetConnectionChange.Text = "change";
            this.btnTargetConnectionChange.UseCompatibleTextRendering = true;
            this.btnTargetConnectionChange.UseVisualStyleBackColor = true;
            this.btnTargetConnectionChange.Visible = false;
            this.btnTargetConnectionChange.Click += new System.EventHandler(this.btnTargetConnectionChange_Click);
            // 
            // btnSourcetConnectionChange
            // 
            this.btnSourcetConnectionChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSourcetConnectionChange.Location = new System.Drawing.Point(1644, 144);
            this.btnSourcetConnectionChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSourcetConnectionChange.Name = "btnSourcetConnectionChange";
            this.btnSourcetConnectionChange.Size = new System.Drawing.Size(101, 23);
            this.btnSourcetConnectionChange.TabIndex = 53;
            this.btnSourcetConnectionChange.Text = "change";
            this.btnSourcetConnectionChange.UseCompatibleTextRendering = true;
            this.btnSourcetConnectionChange.UseVisualStyleBackColor = true;
            this.btnSourcetConnectionChange.Visible = false;
            this.btnSourcetConnectionChange.Click += new System.EventHandler(this.btnSourcetConnectionChange_Click);
            // 
            // lblProjectFiles
            // 
            this.lblProjectFiles.AutoSize = true;
            this.lblProjectFiles.Location = new System.Drawing.Point(1291, 335);
            this.lblProjectFiles.Name = "lblProjectFiles";
            this.lblProjectFiles.Size = new System.Drawing.Size(171, 19);
            this.lblProjectFiles.TabIndex = 52;
            this.lblProjectFiles.Text = "Project Files Monitor";
            // 
            // treeProject
            // 
            this.treeProject.Location = new System.Drawing.Point(1296, 416);
            this.treeProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeProject.Name = "treeProject";
            this.treeProject.Size = new System.Drawing.Size(489, 470);
            this.treeProject.TabIndex = 0;
            // 
            // lblConnectedTo
            // 
            this.lblConnectedTo.AutoSize = true;
            this.lblConnectedTo.Location = new System.Drawing.Point(1291, 22);
            this.lblConnectedTo.Name = "lblConnectedTo";
            this.lblConnectedTo.Size = new System.Drawing.Size(182, 19);
            this.lblConnectedTo.TabIndex = 51;
            this.lblConnectedTo.Text = "You are connected to:";
            // 
            // tbxProject
            // 
            this.tbxProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxProject.Location = new System.Drawing.Point(1296, 373);
            this.tbxProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxProject.Name = "tbxProject";
            this.tbxProject.ReadOnly = true;
            this.tbxProject.Size = new System.Drawing.Size(489, 23);
            this.tbxProject.TabIndex = 1;
            // 
            // linkTarget
            // 
            this.linkTarget.AutoSize = true;
            this.linkTarget.Font = new System.Drawing.Font("Arial", 10F);
            this.linkTarget.Location = new System.Drawing.Point(1291, 194);
            this.linkTarget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkTarget.Name = "linkTarget";
            this.linkTarget.Size = new System.Drawing.Size(142, 44);
            this.linkTarget.TabIndex = 1;
            this.linkTarget.TabStop = true;
            this.linkTarget.Text = "Target CRM:  {0}\r\n{1}";
            this.linkTarget.UseCompatibleTextRendering = true;
            this.linkTarget.Visible = false;
            this.linkTarget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTarget_LinkClicked);
            // 
            // linkSource
            // 
            this.linkSource.AutoSize = true;
            this.linkSource.Font = new System.Drawing.Font("Arial", 10F);
            this.linkSource.Location = new System.Drawing.Point(1291, 80);
            this.linkSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkSource.Name = "linkSource";
            this.linkSource.Size = new System.Drawing.Size(154, 44);
            this.linkSource.TabIndex = 0;
            this.linkSource.TabStop = true;
            this.linkSource.Text = "Source CRM:   {0}\r\n{1}";
            this.linkSource.UseCompatibleTextRendering = true;
            this.linkSource.Visible = false;
            this.linkSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSource_LinkClicked);
            // 
            // lblProject2
            // 
            this.lblProject2.AutoSize = true;
            this.lblProject2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProject2.Location = new System.Drawing.Point(36, 562);
            this.lblProject2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProject2.Name = "lblProject2";
            this.lblProject2.Size = new System.Drawing.Size(930, 100);
            this.lblProject2.TabIndex = 9;
            this.lblProject2.Text = "Steps:\r\n\r\nSet up source connection then select an existing \"<ProjectName>.xml\" fi" +
    "le from project root directory to load.\r\n\r\nOnce project loaded application will " +
    "take you to \"Saved Views filters\" tab.";
            // 
            // cbxLoadProject
            // 
            this.cbxLoadProject.AutoSize = true;
            this.cbxLoadProject.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxLoadProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxLoadProject.ForeColor = System.Drawing.Color.Navy;
            this.cbxLoadProject.Location = new System.Drawing.Point(40, 506);
            this.cbxLoadProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxLoadProject.Name = "cbxLoadProject";
            this.cbxLoadProject.Size = new System.Drawing.Size(178, 23);
            this.cbxLoadProject.TabIndex = 42;
            this.cbxLoadProject.Text = "Load saved Project";
            this.cbxLoadProject.UseVisualStyleBackColor = true;
            this.cbxLoadProject.CheckedChanged += new System.EventHandler(this.cbxLoadProject_CheckedChanged);
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProject.Location = new System.Drawing.Point(36, 107);
            this.lblProject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(921, 340);
            this.lblProject.TabIndex = 6;
            this.lblProject.Text = resources.GetString("lblProject.Text");
            // 
            // cbxCreateProject
            // 
            this.cbxCreateProject.AutoSize = true;
            this.cbxCreateProject.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxCreateProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCreateProject.ForeColor = System.Drawing.Color.Navy;
            this.cbxCreateProject.Location = new System.Drawing.Point(40, 37);
            this.cbxCreateProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCreateProject.Name = "cbxCreateProject";
            this.cbxCreateProject.Size = new System.Drawing.Size(536, 42);
            this.cbxCreateProject.TabIndex = 41;
            this.cbxCreateProject.Text = "  Create a new Data Migration Project  based on Saved View and \r\n  Configuration " +
    "Migration package";
            this.cbxCreateProject.UseVisualStyleBackColor = true;
            this.cbxCreateProject.CheckedChanged += new System.EventHandler(this.cbxCreateProject_CheckedChanged);
            // 
            // cbxAttachmentsMigration
            // 
            this.cbxAttachmentsMigration.AutoSize = true;
            this.cbxAttachmentsMigration.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxAttachmentsMigration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAttachmentsMigration.ForeColor = System.Drawing.Color.Navy;
            this.cbxAttachmentsMigration.Location = new System.Drawing.Point(40, 736);
            this.cbxAttachmentsMigration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxAttachmentsMigration.Name = "cbxAttachmentsMigration";
            this.cbxAttachmentsMigration.Size = new System.Drawing.Size(673, 23);
            this.cbxAttachmentsMigration.TabIndex = 43;
            this.cbxAttachmentsMigration.Text = "Copy Attachment (Notes)     Roll back Attchment copy    Synchronize Site Settings" +
    "";
            this.cbxAttachmentsMigration.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxAttachmentsMigration.UseVisualStyleBackColor = true;
            this.cbxAttachmentsMigration.CheckedChanged += new System.EventHandler(this.cbxAttachmentsMigration_CheckedChanged);
            // 
            // tabModifyDataBasedOnSavedQueries
            // 
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupViewsAdvanced);
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupViewDataFilter);
            this.tabModifyDataBasedOnSavedQueries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabModifyDataBasedOnSavedQueries.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabModifyDataBasedOnSavedQueries.Location = new System.Drawing.Point(4, 38);
            this.tabModifyDataBasedOnSavedQueries.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabModifyDataBasedOnSavedQueries.Name = "tabModifyDataBasedOnSavedQueries";
            this.tabModifyDataBasedOnSavedQueries.Size = new System.Drawing.Size(1896, 935);
            this.tabModifyDataBasedOnSavedQueries.TabIndex = 3;
            this.tabModifyDataBasedOnSavedQueries.Text = "Saved Views filters";
            this.tabModifyDataBasedOnSavedQueries.UseVisualStyleBackColor = true;
            // 
            // groupViewsAdvanced
            // 
            this.groupViewsAdvanced.Controls.Add(this.lblSorceDataFile);
            this.groupViewsAdvanced.Controls.Add(this.lblResultDataFile);
            this.groupViewsAdvanced.Controls.Add(this.treeResultDataFile);
            this.groupViewsAdvanced.Controls.Add(this.treeSorceDataFile);
            this.groupViewsAdvanced.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupViewsAdvanced.Location = new System.Drawing.Point(1565, 0);
            this.groupViewsAdvanced.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupViewsAdvanced.Name = "groupViewsAdvanced";
            this.groupViewsAdvanced.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupViewsAdvanced.Size = new System.Drawing.Size(331, 935);
            this.groupViewsAdvanced.TabIndex = 44;
            this.groupViewsAdvanced.TabStop = false;
            this.groupViewsAdvanced.Text = "Filters and Results PreView";
            // 
            // lblSorceDataFile
            // 
            this.lblSorceDataFile.AutoSize = true;
            this.lblSorceDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSorceDataFile.Location = new System.Drawing.Point(115, 34);
            this.lblSorceDataFile.Name = "lblSorceDataFile";
            this.lblSorceDataFile.Size = new System.Drawing.Size(91, 17);
            this.lblSorceDataFile.TabIndex = 50;
            this.lblSorceDataFile.Text = "Original Data";
            // 
            // lblResultDataFile
            // 
            this.lblResultDataFile.AutoSize = true;
            this.lblResultDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblResultDataFile.Location = new System.Drawing.Point(75, 457);
            this.lblResultDataFile.Name = "lblResultDataFile";
            this.lblResultDataFile.Size = new System.Drawing.Size(183, 17);
            this.lblResultDataFile.TabIndex = 49;
            this.lblResultDataFile.Text = "Processed Records Monitor";
            // 
            // treeResultDataFile
            // 
            this.treeResultDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.treeResultDataFile.Location = new System.Drawing.Point(20, 475);
            this.treeResultDataFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeResultDataFile.Name = "treeResultDataFile";
            this.treeResultDataFile.Size = new System.Drawing.Size(285, 344);
            this.treeResultDataFile.TabIndex = 46;
            // 
            // treeSorceDataFile
            // 
            this.treeSorceDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.treeSorceDataFile.Location = new System.Drawing.Point(20, 66);
            this.treeSorceDataFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeSorceDataFile.Name = "treeSorceDataFile";
            this.treeSorceDataFile.Size = new System.Drawing.Size(285, 344);
            this.treeSorceDataFile.TabIndex = 0;
            // 
            // groupViewDataFilter
            // 
            this.groupViewDataFilter.Controls.Add(this.lblTick3);
            this.groupViewDataFilter.Controls.Add(this.lblTick2);
            this.groupViewDataFilter.Controls.Add(this.lblTick1);
            this.groupViewDataFilter.Controls.Add(this.label3);
            this.groupViewDataFilter.Controls.Add(this.label2);
            this.groupViewDataFilter.Controls.Add(this.label1);
            this.groupViewDataFilter.Controls.Add(this.lblViewsTrans);
            this.groupViewDataFilter.Controls.Add(this.btnSaveModifyViewsFile);
            this.groupViewDataFilter.Controls.Add(this.btnViewsBack);
            this.groupViewDataFilter.Controls.Add(this.lblTransformationSettings);
            this.groupViewDataFilter.Controls.Add(this.lblTransformedQueryDisplay);
            this.groupViewDataFilter.Controls.Add(this.cbxExcludeFromResult);
            this.groupViewDataFilter.Controls.Add(this.treeTransformedQueryDisplay);
            this.groupViewDataFilter.Controls.Add(this.cbxExecuteAsListOfLinkedQueries);
            this.groupViewDataFilter.Controls.Add(this.cbxCollectAllReferences);
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
            this.groupViewDataFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupViewDataFilter.Enabled = false;
            this.groupViewDataFilter.Location = new System.Drawing.Point(0, 0);
            this.groupViewDataFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupViewDataFilter.Name = "groupViewDataFilter";
            this.groupViewDataFilter.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupViewDataFilter.Size = new System.Drawing.Size(1896, 935);
            this.groupViewDataFilter.TabIndex = 43;
            this.groupViewDataFilter.TabStop = false;
            this.groupViewDataFilter.Text = "Set Saved Views as Data Filters ";
            // 
            // lblTick3
            // 
            this.lblTick3.AutoSize = true;
            this.lblTick3.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTick3.Location = new System.Drawing.Point(351, 752);
            this.lblTick3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTick3.Name = "lblTick3";
            this.lblTick3.Size = new System.Drawing.Size(10, 23);
            this.lblTick3.TabIndex = 73;
            this.lblTick3.Text = "\r\n";
            // 
            // lblTick2
            // 
            this.lblTick2.AutoSize = true;
            this.lblTick2.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTick2.Location = new System.Drawing.Point(351, 623);
            this.lblTick2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTick2.Name = "lblTick2";
            this.lblTick2.Size = new System.Drawing.Size(10, 23);
            this.lblTick2.TabIndex = 72;
            this.lblTick2.Text = "\r\n";
            // 
            // lblTick1
            // 
            this.lblTick1.AutoSize = true;
            this.lblTick1.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTick1.Location = new System.Drawing.Point(351, 471);
            this.lblTick1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTick1.Name = "lblTick1";
            this.lblTick1.Size = new System.Drawing.Size(10, 23);
            this.lblTick1.TabIndex = 71;
            this.lblTick1.Text = "\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 756);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 115);
            this.label3.TabIndex = 70;
            this.label3.Text = "Reverse (Exclude Results)\r\n\r\nResults found by the view will be \r\nexcluded from fi" +
    "nal data file\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 623);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 138);
            this.label2.TabIndex = 69;
            this.label2.Text = "Add Lookup Fields to import\r\n\r\nIf a lookup field added to column set and\r\nit pres" +
    "ents in data file then record will be \r\nkept fo import\r\n\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 471);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(699, 115);
            this.label1.TabIndex = 68;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lblViewsTrans
            // 
            this.lblViewsTrans.AutoSize = true;
            this.lblViewsTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblViewsTrans.Location = new System.Drawing.Point(377, 426);
            this.lblViewsTrans.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblViewsTrans.Name = "lblViewsTrans";
            this.lblViewsTrans.Size = new System.Drawing.Size(288, 20);
            this.lblViewsTrans.TabIndex = 67;
            this.lblViewsTrans.Text = "Views Transformation  (per view)";
            // 
            // btnSaveModifyViewsFile
            // 
            this.btnSaveModifyViewsFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveModifyViewsFile.Location = new System.Drawing.Point(1215, 855);
            this.btnSaveModifyViewsFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveModifyViewsFile.Name = "btnSaveModifyViewsFile";
            this.btnSaveModifyViewsFile.Size = new System.Drawing.Size(267, 33);
            this.btnSaveModifyViewsFile.TabIndex = 5;
            this.btnSaveModifyViewsFile.Text = "Modify And Save Data";
            this.btnSaveModifyViewsFile.UseVisualStyleBackColor = true;
            this.btnSaveModifyViewsFile.Click += new System.EventHandler(this.btnSaveModifyViewsFile_Click);
            // 
            // btnViewsBack
            // 
            this.btnViewsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewsBack.Location = new System.Drawing.Point(13, 875);
            this.btnViewsBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewsBack.Name = "btnViewsBack";
            this.btnViewsBack.Size = new System.Drawing.Size(267, 33);
            this.btnViewsBack.TabIndex = 6;
            this.btnViewsBack.Text = "Return to Project";
            this.btnViewsBack.UseVisualStyleBackColor = true;
            this.btnViewsBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTransformationSettings
            // 
            this.lblTransformationSettings.AutoSize = true;
            this.lblTransformationSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTransformationSettings.Location = new System.Drawing.Point(799, 626);
            this.lblTransformationSettings.Name = "lblTransformationSettings";
            this.lblTransformationSettings.Size = new System.Drawing.Size(264, 18);
            this.lblTransformationSettings.TabIndex = 66;
            this.lblTransformationSettings.Text = "Selected Query transformation settings";
            // 
            // lblTransformedQueryDisplay
            // 
            this.lblTransformedQueryDisplay.AutoSize = true;
            this.lblTransformedQueryDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTransformedQueryDisplay.Location = new System.Drawing.Point(1197, 354);
            this.lblTransformedQueryDisplay.Name = "lblTransformedQueryDisplay";
            this.lblTransformedQueryDisplay.Size = new System.Drawing.Size(197, 17);
            this.lblTransformedQueryDisplay.TabIndex = 63;
            this.lblTransformedQueryDisplay.Text = "Query Transformation Display";
            // 
            // cbxExcludeFromResult
            // 
            this.cbxExcludeFromResult.AutoSize = true;
            this.cbxExcludeFromResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxExcludeFromResult.Location = new System.Drawing.Point(803, 743);
            this.cbxExcludeFromResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxExcludeFromResult.Name = "cbxExcludeFromResult";
            this.cbxExcludeFromResult.Size = new System.Drawing.Size(227, 24);
            this.cbxExcludeFromResult.TabIndex = 65;
            this.cbxExcludeFromResult.Text = "Reverse (Exclude Results)";
            this.cbxExcludeFromResult.UseVisualStyleBackColor = true;
            this.cbxExcludeFromResult.CheckedChanged += new System.EventHandler(this.transformationSettings_CheckedChanged);
            // 
            // treeTransformedQueryDisplay
            // 
            this.treeTransformedQueryDisplay.Location = new System.Drawing.Point(1131, 405);
            this.treeTransformedQueryDisplay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeTransformedQueryDisplay.Name = "treeTransformedQueryDisplay";
            this.treeTransformedQueryDisplay.Size = new System.Drawing.Size(349, 368);
            this.treeTransformedQueryDisplay.TabIndex = 62;
            // 
            // cbxExecuteAsListOfLinkedQueries
            // 
            this.cbxExecuteAsListOfLinkedQueries.AutoSize = true;
            this.cbxExecuteAsListOfLinkedQueries.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxExecuteAsListOfLinkedQueries.Location = new System.Drawing.Point(803, 681);
            this.cbxExecuteAsListOfLinkedQueries.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxExecuteAsListOfLinkedQueries.Name = "cbxExecuteAsListOfLinkedQueries";
            this.cbxExecuteAsListOfLinkedQueries.Size = new System.Drawing.Size(286, 24);
            this.cbxExecuteAsListOfLinkedQueries.TabIndex = 60;
            this.cbxExecuteAsListOfLinkedQueries.Text = "Execute As List Of Linked Queries";
            this.cbxExecuteAsListOfLinkedQueries.UseVisualStyleBackColor = true;
            this.cbxExecuteAsListOfLinkedQueries.CheckedChanged += new System.EventHandler(this.transformationSettings_CheckedChanged);
            // 
            // cbxCollectAllReferences
            // 
            this.cbxCollectAllReferences.AutoSize = true;
            this.cbxCollectAllReferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCollectAllReferences.Location = new System.Drawing.Point(803, 711);
            this.cbxCollectAllReferences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCollectAllReferences.Name = "cbxCollectAllReferences";
            this.cbxCollectAllReferences.Size = new System.Drawing.Size(236, 24);
            this.cbxCollectAllReferences.TabIndex = 61;
            this.cbxCollectAllReferences.Text = "Add Lookup Fields to import";
            this.cbxCollectAllReferences.UseVisualStyleBackColor = true;
            this.cbxCollectAllReferences.CheckedChanged += new System.EventHandler(this.transformationSettings_CheckedChanged);
            // 
            // lstListOfViewsFilters
            // 
            this.lstListOfViewsFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstListOfViewsFilters.FormattingEnabled = true;
            this.lstListOfViewsFilters.ItemHeight = 17;
            this.lstListOfViewsFilters.Location = new System.Drawing.Point(1104, 113);
            this.lstListOfViewsFilters.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstListOfViewsFilters.Name = "lstListOfViewsFilters";
            this.lstListOfViewsFilters.Size = new System.Drawing.Size(383, 140);
            this.lstListOfViewsFilters.Sorted = true;
            this.lstListOfViewsFilters.TabIndex = 55;
            this.lstListOfViewsFilters.SelectedIndexChanged += new System.EventHandler(this.lstListOfViewsFilters_SelectedIndexChanged);
            this.lstListOfViewsFilters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstListOfViewsFilters_MouseDoubleClick);
            // 
            // lblViewsByEntity
            // 
            this.lblViewsByEntity.AutoSize = true;
            this.lblViewsByEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblViewsByEntity.Location = new System.Drawing.Point(701, 48);
            this.lblViewsByEntity.Name = "lblViewsByEntity";
            this.lblViewsByEntity.Size = new System.Drawing.Size(385, 51);
            this.lblViewsByEntity.TabIndex = 54;
            this.lblViewsByEntity.Text = "List of public Saved User Views available for selected entity.\r\n\r\nDouble click a " +
    "view to add to filtters list";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(395, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 17);
            this.label5.TabIndex = 53;
            this.label5.Text = "Selecte Entity to see its Saved Views";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(53, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 17);
            this.label6.TabIndex = 52;
            this.label6.Text = "List of Entities in Schema file";
            // 
            // lstDefaultSchemaDataByViews
            // 
            this.lstDefaultSchemaDataByViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstDefaultSchemaDataByViews.FormattingEnabled = true;
            this.lstDefaultSchemaDataByViews.ItemHeight = 17;
            this.lstDefaultSchemaDataByViews.Location = new System.Drawing.Point(13, 78);
            this.lstDefaultSchemaDataByViews.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstDefaultSchemaDataByViews.Name = "lstDefaultSchemaDataByViews";
            this.lstDefaultSchemaDataByViews.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDefaultSchemaDataByViews.Size = new System.Drawing.Size(273, 599);
            this.lstDefaultSchemaDataByViews.Sorted = true;
            this.lstDefaultSchemaDataByViews.TabIndex = 42;
            // 
            // lstViewsPerEntity
            // 
            this.lstViewsPerEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstViewsPerEntity.FormattingEnabled = true;
            this.lstViewsPerEntity.ItemHeight = 17;
            this.lstViewsPerEntity.Location = new System.Drawing.Point(693, 113);
            this.lstViewsPerEntity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstViewsPerEntity.Name = "lstViewsPerEntity";
            this.lstViewsPerEntity.Size = new System.Drawing.Size(384, 208);
            this.lstViewsPerEntity.Sorted = true;
            this.lstViewsPerEntity.TabIndex = 51;
            this.lstViewsPerEntity.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstViewsPerEntity_MouseDoubleClick);
            // 
            // btnbtnViews_FromDefaultToSelected
            // 
            this.btnbtnViews_FromDefaultToSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnbtnViews_FromDefaultToSelected.Location = new System.Drawing.Point(309, 158);
            this.btnbtnViews_FromDefaultToSelected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnbtnViews_FromDefaultToSelected.Name = "btnbtnViews_FromDefaultToSelected";
            this.btnbtnViews_FromDefaultToSelected.Size = new System.Drawing.Size(52, 28);
            this.btnbtnViews_FromDefaultToSelected.TabIndex = 49;
            this.btnbtnViews_FromDefaultToSelected.Text = " >>";
            this.btnbtnViews_FromDefaultToSelected.UseVisualStyleBackColor = true;
            this.btnbtnViews_FromDefaultToSelected.Click += new System.EventHandler(this.btnbtnViews_FromDefaultToSelected_Click);
            // 
            // btnViews_ReturnToDefaultFromSelected
            // 
            this.btnViews_ReturnToDefaultFromSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnViews_ReturnToDefaultFromSelected.Location = new System.Drawing.Point(309, 242);
            this.btnViews_ReturnToDefaultFromSelected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViews_ReturnToDefaultFromSelected.Name = "btnViews_ReturnToDefaultFromSelected";
            this.btnViews_ReturnToDefaultFromSelected.Size = new System.Drawing.Size(52, 28);
            this.btnViews_ReturnToDefaultFromSelected.TabIndex = 50;
            this.btnViews_ReturnToDefaultFromSelected.Text = " <<";
            this.btnViews_ReturnToDefaultFromSelected.UseVisualStyleBackColor = true;
            this.btnViews_ReturnToDefaultFromSelected.Click += new System.EventHandler(this.btnViews_ReturnToDefaultFromSelected_Click);
            // 
            // lblListOfViewsFilters
            // 
            this.lblListOfViewsFilters.AutoSize = true;
            this.lblListOfViewsFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblListOfViewsFilters.Location = new System.Drawing.Point(1127, 48);
            this.lblListOfViewsFilters.Name = "lblListOfViewsFilters";
            this.lblListOfViewsFilters.Size = new System.Drawing.Size(282, 51);
            this.lblListOfViewsFilters.TabIndex = 47;
            this.lblListOfViewsFilters.Text = "Select a view to set import settings \r\nor\r\nDouble click a view to remove it from " +
    "the list";
            // 
            // lstSelectedSchemaDataByViews
            // 
            this.lstSelectedSchemaDataByViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstSelectedSchemaDataByViews.FormattingEnabled = true;
            this.lstSelectedSchemaDataByViews.ItemHeight = 17;
            this.lstSelectedSchemaDataByViews.Location = new System.Drawing.Point(381, 78);
            this.lstSelectedSchemaDataByViews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstSelectedSchemaDataByViews.Name = "lstSelectedSchemaDataByViews";
            this.lstSelectedSchemaDataByViews.Size = new System.Drawing.Size(273, 293);
            this.lstSelectedSchemaDataByViews.Sorted = true;
            this.lstSelectedSchemaDataByViews.TabIndex = 41;
            this.lstSelectedSchemaDataByViews.SelectedIndexChanged += new System.EventHandler(this.lstSelectedSchemaDataByViews_SelectedIndexChanged);
            // 
            // tabPortalsSync
            // 
            this.tabPortalsSync.Controls.Add(this.groupPortalsSync);
            this.tabPortalsSync.Location = new System.Drawing.Point(4, 38);
            this.tabPortalsSync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPortalsSync.Name = "tabPortalsSync";
            this.tabPortalsSync.Size = new System.Drawing.Size(1896, 935);
            this.tabPortalsSync.TabIndex = 6;
            this.tabPortalsSync.Text = "Portals 365 Sync";
            this.tabPortalsSync.UseVisualStyleBackColor = true;
            // 
            // groupPortalsSync
            // 
            this.groupPortalsSync.Controls.Add(this.btnAttachmentsLogs);
            this.groupPortalsSync.Controls.Add(this.lblSyncStart);
            this.groupPortalsSync.Controls.Add(this.lblPortalSyncTo);
            this.groupPortalsSync.Controls.Add(this.lblPortalSyncFrom);
            this.groupPortalsSync.Controls.Add(this.btnPortalSyncBack);
            this.groupPortalsSync.Controls.Add(this.cbxSyncSettings);
            this.groupPortalsSync.Controls.Add(this.btnStartAttachmentsCopy);
            this.groupPortalsSync.Controls.Add(this.btnSelectAttachmentsDataFile);
            this.groupPortalsSync.Controls.Add(this.groupAttachmentsCopySettings);
            this.groupPortalsSync.Controls.Add(this.txtxAttachmentsDataFile);
            this.groupPortalsSync.Controls.Add(this.groupPortalsSources);
            this.groupPortalsSync.Controls.Add(this.btnSelectIDsBackup);
            this.groupPortalsSync.Controls.Add(this.txtAttachmentsIDsBackUpFile);
            this.groupPortalsSync.Controls.Add(this.cbxBasedOnFiles);
            this.groupPortalsSync.Controls.Add(this.cbxFromPortalToPortal);
            this.groupPortalsSync.Controls.Add(this.cbxAttachmentsRollback);
            this.groupPortalsSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPortalsSync.Enabled = false;
            this.groupPortalsSync.Location = new System.Drawing.Point(0, 0);
            this.groupPortalsSync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupPortalsSync.Name = "groupPortalsSync";
            this.groupPortalsSync.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupPortalsSync.Size = new System.Drawing.Size(1896, 935);
            this.groupPortalsSync.TabIndex = 0;
            this.groupPortalsSync.TabStop = false;
            this.groupPortalsSync.Text = "Synchronize Portals 365 Attachments and Site Settings";
            // 
            // btnAttachmentsLogs
            // 
            this.btnAttachmentsLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnAttachmentsLogs.Location = new System.Drawing.Point(769, 785);
            this.btnAttachmentsLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAttachmentsLogs.Name = "btnAttachmentsLogs";
            this.btnAttachmentsLogs.Size = new System.Drawing.Size(309, 34);
            this.btnAttachmentsLogs.TabIndex = 66;
            this.btnAttachmentsLogs.Text = "Show Logs";
            this.btnAttachmentsLogs.UseVisualStyleBackColor = false;
            this.btnAttachmentsLogs.Click += new System.EventHandler(this.btnAttachmentsLogs_Click);
            // 
            // lblSyncStart
            // 
            this.lblSyncStart.AutoSize = true;
            this.lblSyncStart.Font = new System.Drawing.Font("Arial", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblSyncStart.Location = new System.Drawing.Point(8, 47);
            this.lblSyncStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSyncStart.Name = "lblSyncStart";
            this.lblSyncStart.Size = new System.Drawing.Size(262, 25);
            this.lblSyncStart.TabIndex = 65;
            this.lblSyncStart.Text = "Check an option to start";
            // 
            // lblPortalSyncTo
            // 
            this.lblPortalSyncTo.AutoSize = true;
            this.lblPortalSyncTo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPortalSyncTo.Location = new System.Drawing.Point(1265, 65);
            this.lblPortalSyncTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPortalSyncTo.Name = "lblPortalSyncTo";
            this.lblPortalSyncTo.Size = new System.Drawing.Size(135, 19);
            this.lblPortalSyncTo.TabIndex = 64;
            this.lblPortalSyncTo.Text = "Target CRM: {0}";
            this.lblPortalSyncTo.Visible = false;
            // 
            // lblPortalSyncFrom
            // 
            this.lblPortalSyncFrom.AutoSize = true;
            this.lblPortalSyncFrom.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPortalSyncFrom.Location = new System.Drawing.Point(544, 65);
            this.lblPortalSyncFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPortalSyncFrom.Name = "lblPortalSyncFrom";
            this.lblPortalSyncFrom.Size = new System.Drawing.Size(137, 19);
            this.lblPortalSyncFrom.TabIndex = 63;
            this.lblPortalSyncFrom.Text = "Source Crm: {0}";
            this.lblPortalSyncFrom.Visible = false;
            // 
            // btnPortalSyncBack
            // 
            this.btnPortalSyncBack.Location = new System.Drawing.Point(53, 786);
            this.btnPortalSyncBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPortalSyncBack.Name = "btnPortalSyncBack";
            this.btnPortalSyncBack.Size = new System.Drawing.Size(267, 33);
            this.btnPortalSyncBack.TabIndex = 62;
            this.btnPortalSyncBack.Text = "Return to Project";
            this.btnPortalSyncBack.UseVisualStyleBackColor = true;
            // 
            // cbxSyncSettings
            // 
            this.cbxSyncSettings.AutoSize = true;
            this.cbxSyncSettings.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxSyncSettings.Enabled = false;
            this.cbxSyncSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxSyncSettings.ForeColor = System.Drawing.Color.Navy;
            this.cbxSyncSettings.Location = new System.Drawing.Point(53, 633);
            this.cbxSyncSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSyncSettings.Name = "cbxSyncSettings";
            this.cbxSyncSettings.Size = new System.Drawing.Size(223, 23);
            this.cbxSyncSettings.TabIndex = 61;
            this.cbxSyncSettings.Text = "Sync Portal Site Settings";
            this.cbxSyncSettings.UseVisualStyleBackColor = true;
            this.cbxSyncSettings.CheckedChanged += new System.EventHandler(this.cbxSyncSettings_CheckedChanged);
            // 
            // btnStartAttachmentsCopy
            // 
            this.btnStartAttachmentsCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartAttachmentsCopy.Location = new System.Drawing.Point(1528, 786);
            this.btnStartAttachmentsCopy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartAttachmentsCopy.Name = "btnStartAttachmentsCopy";
            this.btnStartAttachmentsCopy.Size = new System.Drawing.Size(309, 34);
            this.btnStartAttachmentsCopy.TabIndex = 60;
            this.btnStartAttachmentsCopy.Text = "COPY ATTACHMENTS";
            this.btnStartAttachmentsCopy.UseVisualStyleBackColor = false;
            this.btnStartAttachmentsCopy.Click += new System.EventHandler(this.btnStartAttachmentsCopy_Click);
            // 
            // btnSelectAttachmentsDataFile
            // 
            this.btnSelectAttachmentsDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectAttachmentsDataFile.Location = new System.Drawing.Point(548, 209);
            this.btnSelectAttachmentsDataFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectAttachmentsDataFile.Name = "btnSelectAttachmentsDataFile";
            this.btnSelectAttachmentsDataFile.Size = new System.Drawing.Size(197, 27);
            this.btnSelectAttachmentsDataFile.TabIndex = 59;
            this.btnSelectAttachmentsDataFile.Text = "Select Data File";
            this.btnSelectAttachmentsDataFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectAttachmentsDataFile.UseCompatibleTextRendering = true;
            this.btnSelectAttachmentsDataFile.UseVisualStyleBackColor = false;
            this.btnSelectAttachmentsDataFile.Visible = false;
            this.btnSelectAttachmentsDataFile.Click += new System.EventHandler(this.btnSelectAttachmentsDataFile_Click);
            // 
            // groupAttachmentsCopySettings
            // 
            this.groupAttachmentsCopySettings.Controls.Add(this.cbxAttachmentsKeepIDs);
            this.groupAttachmentsCopySettings.Controls.Add(this.cbxIncludeTextNotes);
            this.groupAttachmentsCopySettings.Enabled = false;
            this.groupAttachmentsCopySettings.Location = new System.Drawing.Point(1340, 209);
            this.groupAttachmentsCopySettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupAttachmentsCopySettings.Name = "groupAttachmentsCopySettings";
            this.groupAttachmentsCopySettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupAttachmentsCopySettings.Size = new System.Drawing.Size(497, 126);
            this.groupAttachmentsCopySettings.TabIndex = 52;
            this.groupAttachmentsCopySettings.TabStop = false;
            this.groupAttachmentsCopySettings.Text = "Copy Settings";
            // 
            // cbxAttachmentsKeepIDs
            // 
            this.cbxAttachmentsKeepIDs.AutoSize = true;
            this.cbxAttachmentsKeepIDs.Location = new System.Drawing.Point(47, 75);
            this.cbxAttachmentsKeepIDs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxAttachmentsKeepIDs.Name = "cbxAttachmentsKeepIDs";
            this.cbxAttachmentsKeepIDs.Size = new System.Drawing.Size(340, 23);
            this.cbxAttachmentsKeepIDs.TabIndex = 7;
            this.cbxAttachmentsKeepIDs.Text = "Keep List Of Created Notes for rollback";
            this.cbxAttachmentsKeepIDs.UseVisualStyleBackColor = true;
            this.cbxAttachmentsKeepIDs.CheckedChanged += new System.EventHandler(this.cbxAttachmentsKeepIDs_CheckedChanged);
            // 
            // cbxIncludeTextNotes
            // 
            this.cbxIncludeTextNotes.AutoSize = true;
            this.cbxIncludeTextNotes.Location = new System.Drawing.Point(47, 34);
            this.cbxIncludeTextNotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxIncludeTextNotes.Name = "cbxIncludeTextNotes";
            this.cbxIncludeTextNotes.Size = new System.Drawing.Size(180, 23);
            this.cbxIncludeTextNotes.TabIndex = 6;
            this.cbxIncludeTextNotes.Text = "Include Text Nodes";
            this.cbxIncludeTextNotes.UseVisualStyleBackColor = true;
            // 
            // txtxAttachmentsDataFile
            // 
            this.txtxAttachmentsDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtxAttachmentsDataFile.Location = new System.Drawing.Point(759, 212);
            this.txtxAttachmentsDataFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtxAttachmentsDataFile.Name = "txtxAttachmentsDataFile";
            this.txtxAttachmentsDataFile.ReadOnly = true;
            this.txtxAttachmentsDataFile.Size = new System.Drawing.Size(464, 23);
            this.txtxAttachmentsDataFile.TabIndex = 58;
            this.txtxAttachmentsDataFile.Visible = false;
            // 
            // groupPortalsSources
            // 
            this.groupPortalsSources.Controls.Add(this.ddlSourcePortal);
            this.groupPortalsSources.Controls.Add(this.label9);
            this.groupPortalsSources.Controls.Add(this.label8);
            this.groupPortalsSources.Controls.Add(this.ddlTargetPortal);
            this.groupPortalsSources.Location = new System.Drawing.Point(548, 325);
            this.groupPortalsSources.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupPortalsSources.Name = "groupPortalsSources";
            this.groupPortalsSources.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupPortalsSources.Size = new System.Drawing.Size(675, 121);
            this.groupPortalsSources.TabIndex = 56;
            this.groupPortalsSources.TabStop = false;
            this.groupPortalsSources.Visible = false;
            // 
            // ddlSourcePortal
            // 
            this.ddlSourcePortal.FormattingEnabled = true;
            this.ddlSourcePortal.Location = new System.Drawing.Point(213, 25);
            this.ddlSourcePortal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlSourcePortal.Name = "ddlSourcePortal";
            this.ddlSourcePortal.Size = new System.Drawing.Size(417, 27);
            this.ddlSourcePortal.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 19);
            this.label9.TabIndex = 17;
            this.label9.Text = "Target Portal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Source Portal";
            // 
            // ddlTargetPortal
            // 
            this.ddlTargetPortal.FormattingEnabled = true;
            this.ddlTargetPortal.Location = new System.Drawing.Point(213, 76);
            this.ddlTargetPortal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlTargetPortal.Name = "ddlTargetPortal";
            this.ddlTargetPortal.Size = new System.Drawing.Size(417, 27);
            this.ddlTargetPortal.TabIndex = 16;
            // 
            // btnSelectIDsBackup
            // 
            this.btnSelectIDsBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectIDsBackup.Location = new System.Drawing.Point(548, 527);
            this.btnSelectIDsBackup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectIDsBackup.Name = "btnSelectIDsBackup";
            this.btnSelectIDsBackup.Size = new System.Drawing.Size(143, 27);
            this.btnSelectIDsBackup.TabIndex = 57;
            this.btnSelectIDsBackup.Text = "Select File";
            this.btnSelectIDsBackup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectIDsBackup.UseCompatibleTextRendering = true;
            this.btnSelectIDsBackup.UseVisualStyleBackColor = false;
            this.btnSelectIDsBackup.Visible = false;
            this.btnSelectIDsBackup.Click += new System.EventHandler(this.btnSelectIDsBackup_Click);
            // 
            // txtAttachmentsIDsBackUpFile
            // 
            this.txtAttachmentsIDsBackUpFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtAttachmentsIDsBackUpFile.Location = new System.Drawing.Point(759, 529);
            this.txtAttachmentsIDsBackUpFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAttachmentsIDsBackUpFile.Name = "txtAttachmentsIDsBackUpFile";
            this.txtAttachmentsIDsBackUpFile.ReadOnly = true;
            this.txtAttachmentsIDsBackUpFile.Size = new System.Drawing.Size(464, 23);
            this.txtAttachmentsIDsBackUpFile.TabIndex = 51;
            this.txtAttachmentsIDsBackUpFile.Visible = false;
            // 
            // cbxBasedOnFiles
            // 
            this.cbxBasedOnFiles.AutoSize = true;
            this.cbxBasedOnFiles.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxBasedOnFiles.Enabled = false;
            this.cbxBasedOnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxBasedOnFiles.ForeColor = System.Drawing.Color.Navy;
            this.cbxBasedOnFiles.Location = new System.Drawing.Point(53, 213);
            this.cbxBasedOnFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxBasedOnFiles.Name = "cbxBasedOnFiles";
            this.cbxBasedOnFiles.Size = new System.Drawing.Size(213, 42);
            this.cbxBasedOnFiles.TabIndex = 53;
            this.cbxBasedOnFiles.Text = "Copy Attchments/Notes\r\nBased On Data File";
            this.cbxBasedOnFiles.UseVisualStyleBackColor = true;
            this.cbxBasedOnFiles.CheckedChanged += new System.EventHandler(this.cbxBasedOnFiles_CheckedChanged);
            // 
            // cbxFromPortalToPortal
            // 
            this.cbxFromPortalToPortal.AutoSize = true;
            this.cbxFromPortalToPortal.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxFromPortalToPortal.Enabled = false;
            this.cbxFromPortalToPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFromPortalToPortal.ForeColor = System.Drawing.Color.Navy;
            this.cbxFromPortalToPortal.Location = new System.Drawing.Point(53, 325);
            this.cbxFromPortalToPortal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxFromPortalToPortal.Name = "cbxFromPortalToPortal";
            this.cbxFromPortalToPortal.Size = new System.Drawing.Size(303, 118);
            this.cbxFromPortalToPortal.TabIndex = 54;
            this.cbxFromPortalToPortal.Text = " Copy Web File\'s Attachments from\r\n    from:   Source, Selected Portal \r\n     to:" +
    "      Target,  Selected Portal \r\n\r\n * Based on Web File\'s names\r\n * Selfcopy is " +
    "not supported";
            this.cbxFromPortalToPortal.UseVisualStyleBackColor = true;
            this.cbxFromPortalToPortal.CheckedChanged += new System.EventHandler(this.cbxFromPortalToPortal_CheckedChanged);
            // 
            // cbxAttachmentsRollback
            // 
            this.cbxAttachmentsRollback.AutoSize = true;
            this.cbxAttachmentsRollback.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbxAttachmentsRollback.Enabled = false;
            this.cbxAttachmentsRollback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAttachmentsRollback.ForeColor = System.Drawing.Color.Navy;
            this.cbxAttachmentsRollback.Location = new System.Drawing.Point(53, 527);
            this.cbxAttachmentsRollback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxAttachmentsRollback.Name = "cbxAttachmentsRollback";
            this.cbxAttachmentsRollback.Size = new System.Drawing.Size(258, 23);
            this.cbxAttachmentsRollback.TabIndex = 55;
            this.cbxAttachmentsRollback.Text = "Roll back Attachments Import";
            this.cbxAttachmentsRollback.UseVisualStyleBackColor = true;
            this.cbxAttachmentsRollback.CheckedChanged += new System.EventHandler(this.cbxAttachmentsRollback_CheckedChanged);
            // 
            // tabReplaceIDs
            // 
            this.tabReplaceIDs.Controls.Add(this.groupCopyToolContent);
            this.tabReplaceIDs.Location = new System.Drawing.Point(4, 38);
            this.tabReplaceIDs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabReplaceIDs.Name = "tabReplaceIDs";
            this.tabReplaceIDs.Size = new System.Drawing.Size(1896, 935);
            this.tabReplaceIDs.TabIndex = 4;
            this.tabReplaceIDs.Text = "Data Duplicator";
            this.tabReplaceIDs.UseVisualStyleBackColor = true;
            // 
            // groupCopyToolContent
            // 
            this.groupCopyToolContent.Controls.Add(this.lblDataDouplInfo);
            this.groupCopyToolContent.Controls.Add(this.btnCopyToolBack);
            this.groupCopyToolContent.Controls.Add(this.btnCopyToolFromModified);
            this.groupCopyToolContent.Controls.Add(this.btnCopyToolFromSource);
            this.groupCopyToolContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCopyToolContent.Enabled = false;
            this.groupCopyToolContent.Location = new System.Drawing.Point(0, 0);
            this.groupCopyToolContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupCopyToolContent.Name = "groupCopyToolContent";
            this.groupCopyToolContent.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupCopyToolContent.Size = new System.Drawing.Size(1896, 935);
            this.groupCopyToolContent.TabIndex = 42;
            this.groupCopyToolContent.TabStop = false;
            // 
            // lblDataDouplInfo
            // 
            this.lblDataDouplInfo.AutoSize = true;
            this.lblDataDouplInfo.Location = new System.Drawing.Point(59, 63);
            this.lblDataDouplInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataDouplInfo.Name = "lblDataDouplInfo";
            this.lblDataDouplInfo.Size = new System.Drawing.Size(425, 95);
            this.lblDataDouplInfo.TabIndex = 42;
            this.lblDataDouplInfo.Text = "The \"Data Duplicator\" creates exact copy of data file.\r\n\r\nAll entities are gettin" +
    "g new ids.\r\n\r\nReferences are respected and will be updated.";
            // 
            // btnCopyToolBack
            // 
            this.btnCopyToolBack.Location = new System.Drawing.Point(59, 709);
            this.btnCopyToolBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopyToolBack.Name = "btnCopyToolBack";
            this.btnCopyToolBack.Size = new System.Drawing.Size(267, 33);
            this.btnCopyToolBack.TabIndex = 6;
            this.btnCopyToolBack.Text = "Return to Project";
            this.btnCopyToolBack.UseVisualStyleBackColor = true;
            this.btnCopyToolBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCopyToolFromModified
            // 
            this.btnCopyToolFromModified.Location = new System.Drawing.Point(59, 437);
            this.btnCopyToolFromModified.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopyToolFromModified.Name = "btnCopyToolFromModified";
            this.btnCopyToolFromModified.Size = new System.Drawing.Size(859, 92);
            this.btnCopyToolFromModified.TabIndex = 41;
            this.btnCopyToolFromModified.Text = "Create copy of pre-filtered by Saved Views data file with new GUIDs";
            this.btnCopyToolFromModified.UseCompatibleTextRendering = true;
            this.btnCopyToolFromModified.UseVisualStyleBackColor = true;
            this.btnCopyToolFromModified.Click += new System.EventHandler(this.btnCopyToolFromModified_Click);
            // 
            // btnCopyToolFromSource
            // 
            this.btnCopyToolFromSource.Location = new System.Drawing.Point(59, 226);
            this.btnCopyToolFromSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopyToolFromSource.Name = "btnCopyToolFromSource";
            this.btnCopyToolFromSource.Size = new System.Drawing.Size(859, 92);
            this.btnCopyToolFromSource.TabIndex = 40;
            this.btnCopyToolFromSource.Text = "Create copy of original data file with new GUIDs";
            this.btnCopyToolFromSource.UseCompatibleTextRendering = true;
            this.btnCopyToolFromSource.UseVisualStyleBackColor = true;
            this.btnCopyToolFromSource.Click += new System.EventHandler(this.btnCopyToolFromSource_Click);
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
            // openFileAttachments
            // 
            this.openFileAttachments.Filter = "XML files (*.xml)|*.xml";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1931, 1006);
            this.Controls.Add(this.tabsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Migration Management tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabsPanel.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.tabProject.ResumeLayout(false);
            this.tabProject.PerformLayout();
            this.tabModifyDataBasedOnSavedQueries.ResumeLayout(false);
            this.groupViewsAdvanced.ResumeLayout(false);
            this.groupViewsAdvanced.PerformLayout();
            this.groupViewDataFilter.ResumeLayout(false);
            this.groupViewDataFilter.PerformLayout();
            this.tabPortalsSync.ResumeLayout(false);
            this.groupPortalsSync.ResumeLayout(false);
            this.groupPortalsSync.PerformLayout();
            this.groupAttachmentsCopySettings.ResumeLayout(false);
            this.groupAttachmentsCopySettings.PerformLayout();
            this.groupPortalsSources.ResumeLayout(false);
            this.groupPortalsSources.PerformLayout();
            this.tabReplaceIDs.ResumeLayout(false);
            this.groupCopyToolContent.ResumeLayout(false);
            this.groupCopyToolContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel tabsPanel;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLoadProject;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoadSchema;
        private System.Windows.Forms.TabPage tabModifyDataBasedOnSavedQueries;
        private System.Windows.Forms.TabPage tabReplaceIDs;
        private System.Windows.Forms.Button btnCopyToolBack;
        private System.Windows.Forms.TabPage tabProject;
        private System.Windows.Forms.TextBox tbxProject;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label lblProject2;
        private System.Windows.Forms.TreeView treeProject;
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
        private System.Windows.Forms.Button btnViewsBack;
        private System.Windows.Forms.Button btnSaveModifyViewsFile;
        private System.Windows.Forms.ListBox lstListOfViewsFilters;
        private System.Windows.Forms.Button btnCopyToolFromModified;
        private System.Windows.Forms.Button btnCopyToolFromSource;
        private System.Windows.Forms.CheckBox cbxExecuteAsListOfLinkedQueries;
        private System.Windows.Forms.CheckBox cbxCollectAllReferences;
        private System.Windows.Forms.TreeView treeTransformedQueryDisplay;
        private System.Windows.Forms.Label lblTransformedQueryDisplay;
        private System.Windows.Forms.CheckBox cbxExcludeFromResult;
        private System.Windows.Forms.OpenFileDialog openFileAttachments;
        private System.Windows.Forms.GroupBox groupCopyToolContent;
        private System.Windows.Forms.Label lblTransformationSettings;
        private System.Windows.Forms.CheckBox cbxLoadProject;
        private System.Windows.Forms.CheckBox cbxCreateProject;
        private System.Windows.Forms.CheckBox cbxAttachmentsMigration;
        private System.Windows.Forms.LinkLabel linkTarget;
        private System.Windows.Forms.LinkLabel linkSource;
        private System.Windows.Forms.Label lblProjectFiles;
        private System.Windows.Forms.Label lblConnectedTo;
        private System.Windows.Forms.Button btnTargetConnectionChange;
        private System.Windows.Forms.Button btnSourcetConnectionChange;
        private System.Windows.Forms.Label lblDataDouplInfo;
        private System.Windows.Forms.TabPage tabPortalsSync;
        private System.Windows.Forms.GroupBox groupPortalsSync;
        private System.Windows.Forms.CheckBox cbxSyncSettings;
        private System.Windows.Forms.Button btnStartAttachmentsCopy;
        private System.Windows.Forms.Button btnSelectAttachmentsDataFile;
        private System.Windows.Forms.GroupBox groupAttachmentsCopySettings;
        private System.Windows.Forms.CheckBox cbxAttachmentsKeepIDs;
        private System.Windows.Forms.CheckBox cbxIncludeTextNotes;
        private System.Windows.Forms.TextBox txtxAttachmentsDataFile;
        private System.Windows.Forms.GroupBox groupPortalsSources;
        private System.Windows.Forms.ComboBox ddlSourcePortal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlTargetPortal;
        private System.Windows.Forms.Button btnSelectIDsBackup;
        private System.Windows.Forms.TextBox txtAttachmentsIDsBackUpFile;
        private System.Windows.Forms.CheckBox cbxBasedOnFiles;
        private System.Windows.Forms.CheckBox cbxFromPortalToPortal;
        private System.Windows.Forms.CheckBox cbxAttachmentsRollback;
        private System.Windows.Forms.Button btnPortalSyncBack;
        private System.Windows.Forms.Label lblPortalSyncTo;
        private System.Windows.Forms.Label lblPortalSyncFrom;
        private System.Windows.Forms.Label lblViewsTrans;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label lblAbout1content;
        private System.Windows.Forms.Label lblAbout1;
        private System.Windows.Forms.Label lblAboutTitle;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label lblAbout3;
        private System.Windows.Forms.Label lblAbout3content;
        private System.Windows.Forms.Label lblAbout2;
        private System.Windows.Forms.Label lblAbout2content;
        private System.Windows.Forms.Label lblAboutSubTitle;
        private System.Windows.Forms.LinkLabel linkWiki;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTick1;
        private System.Windows.Forms.Label lblTick3;
        private System.Windows.Forms.Label lblTick2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSyncStart;
        private System.Windows.Forms.Button btnAttachmentsLogs;
    }
}

