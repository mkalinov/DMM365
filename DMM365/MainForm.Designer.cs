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
            this.btnTargetConnectionChange = new System.Windows.Forms.Button();
            this.btnSourcetConnectionChange = new System.Windows.Forms.Button();
            this.lblProjectFiles = new System.Windows.Forms.Label();
            this.treeProject = new System.Windows.Forms.TreeView();
            this.lblConnectedTo = new System.Windows.Forms.Label();
            this.tbxProject = new System.Windows.Forms.TextBox();
            this.linkTarget = new System.Windows.Forms.LinkLabel();
            this.btnStartAttachmentsCopy = new System.Windows.Forms.Button();
            this.linkSource = new System.Windows.Forms.LinkLabel();
            this.lblProject2 = new System.Windows.Forms.Label();
            this.btnSelectAttachmentsDataFile = new System.Windows.Forms.Button();
            this.cbxLoadProject = new System.Windows.Forms.CheckBox();
            this.groupAttachmentsCopySettings = new System.Windows.Forms.GroupBox();
            this.cbxAttachmentsKeepIDs = new System.Windows.Forms.CheckBox();
            this.cbxIncludeTextNotes = new System.Windows.Forms.CheckBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.txtxAttachmentsDataFile = new System.Windows.Forms.TextBox();
            this.cbxCreateProject = new System.Windows.Forms.CheckBox();
            this.groupPortalsSources = new System.Windows.Forms.GroupBox();
            this.ddlSourcePortal = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlTargetPortal = new System.Windows.Forms.ComboBox();
            this.lblIntro = new System.Windows.Forms.Label();
            this.btnSelectIDsBackup = new System.Windows.Forms.Button();
            this.txtAttachmentsIDsBackUpFile = new System.Windows.Forms.TextBox();
            this.cbxAttachmentsMigration = new System.Windows.Forms.CheckBox();
            this.cbxBasedOnFiles = new System.Windows.Forms.CheckBox();
            this.cbxFromPortalToPortal = new System.Windows.Forms.CheckBox();
            this.cbxAttachmentsRollback = new System.Windows.Forms.CheckBox();
            this.tabModifyDataBasedOnSavedQueries = new System.Windows.Forms.TabPage();
            this.groupViewsAdvanced = new System.Windows.Forms.GroupBox();
            this.lblSorceDataFile = new System.Windows.Forms.Label();
            this.lblResultDataFile = new System.Windows.Forms.Label();
            this.treeResultDataFile = new System.Windows.Forms.TreeView();
            this.treeSorceDataFile = new System.Windows.Forms.TreeView();
            this.groupViewDataFilter = new System.Windows.Forms.GroupBox();
            this.lblTransformationSettings = new System.Windows.Forms.Label();
            this.lblTransformedQueryDisplay = new System.Windows.Forms.Label();
            this.groupSavedViewsFooter = new System.Windows.Forms.GroupBox();
            this.btnViewsBack = new System.Windows.Forms.Button();
            this.btnSaveModifyViewsFile = new System.Windows.Forms.Button();
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
            this.tabReplaceIDs = new System.Windows.Forms.TabPage();
            this.groupCopyToolContent = new System.Windows.Forms.GroupBox();
            this.btnCopyToolBack = new System.Windows.Forms.Button();
            this.btnCopyToolFromModified = new System.Windows.Forms.Button();
            this.btnCopyToolFromSource = new System.Windows.Forms.Button();
            this.folderBrowserDialogLoadProject = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogLoadSchema = new System.Windows.Forms.OpenFileDialog();
            this.openFileLoadProject = new System.Windows.Forms.OpenFileDialog();
            this.openFileAttachments = new System.Windows.Forms.OpenFileDialog();
            this.lblDataDouplInfo = new System.Windows.Forms.Label();
            this.tabsPanel.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabProject.SuspendLayout();
            this.groupAttachmentsCopySettings.SuspendLayout();
            this.groupPortalsSources.SuspendLayout();
            this.tabModifyDataBasedOnSavedQueries.SuspendLayout();
            this.groupViewsAdvanced.SuspendLayout();
            this.groupViewDataFilter.SuspendLayout();
            this.groupSavedViewsFooter.SuspendLayout();
            this.tabReplaceIDs.SuspendLayout();
            this.groupCopyToolContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsPanel
            // 
            this.tabsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabsPanel.Controls.Add(this.tabs);
            this.tabsPanel.Location = new System.Drawing.Point(11, 11);
            this.tabsPanel.Name = "tabsPanel";
            this.tabsPanel.Size = new System.Drawing.Size(1424, 786);
            this.tabsPanel.TabIndex = 1;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabProject);
            this.tabs.Controls.Add(this.tabModifyDataBasedOnSavedQueries);
            this.tabs.Controls.Add(this.tabReplaceIDs);
            this.tabs.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.tabs.Location = new System.Drawing.Point(17, 11);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(10, 8);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1404, 763);
            this.tabs.TabIndex = 0;
            // 
            // tabProject
            // 
            this.tabProject.Controls.Add(this.btnTargetConnectionChange);
            this.tabProject.Controls.Add(this.btnSourcetConnectionChange);
            this.tabProject.Controls.Add(this.lblProjectFiles);
            this.tabProject.Controls.Add(this.treeProject);
            this.tabProject.Controls.Add(this.lblConnectedTo);
            this.tabProject.Controls.Add(this.tbxProject);
            this.tabProject.Controls.Add(this.linkTarget);
            this.tabProject.Controls.Add(this.btnStartAttachmentsCopy);
            this.tabProject.Controls.Add(this.linkSource);
            this.tabProject.Controls.Add(this.lblProject2);
            this.tabProject.Controls.Add(this.btnSelectAttachmentsDataFile);
            this.tabProject.Controls.Add(this.cbxLoadProject);
            this.tabProject.Controls.Add(this.groupAttachmentsCopySettings);
            this.tabProject.Controls.Add(this.lblProject);
            this.tabProject.Controls.Add(this.txtxAttachmentsDataFile);
            this.tabProject.Controls.Add(this.cbxCreateProject);
            this.tabProject.Controls.Add(this.groupPortalsSources);
            this.tabProject.Controls.Add(this.lblIntro);
            this.tabProject.Controls.Add(this.btnSelectIDsBackup);
            this.tabProject.Controls.Add(this.txtAttachmentsIDsBackUpFile);
            this.tabProject.Controls.Add(this.cbxAttachmentsMigration);
            this.tabProject.Controls.Add(this.cbxBasedOnFiles);
            this.tabProject.Controls.Add(this.cbxFromPortalToPortal);
            this.tabProject.Controls.Add(this.cbxAttachmentsRollback);
            this.tabProject.Location = new System.Drawing.Point(4, 35);
            this.tabProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabProject.Name = "tabProject";
            this.tabProject.Size = new System.Drawing.Size(1396, 724);
            this.tabProject.TabIndex = 5;
            this.tabProject.Text = "Project Management";
            this.tabProject.UseVisualStyleBackColor = true;
            // 
            // btnTargetConnectionChange
            // 
            this.btnTargetConnectionChange.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTargetConnectionChange.Location = new System.Drawing.Point(1233, 212);
            this.btnTargetConnectionChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTargetConnectionChange.Name = "btnTargetConnectionChange";
            this.btnTargetConnectionChange.Size = new System.Drawing.Size(76, 19);
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
            this.btnSourcetConnectionChange.Location = new System.Drawing.Point(1233, 117);
            this.btnSourcetConnectionChange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSourcetConnectionChange.Name = "btnSourcetConnectionChange";
            this.btnSourcetConnectionChange.Size = new System.Drawing.Size(76, 19);
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
            this.lblProjectFiles.Location = new System.Drawing.Point(964, 254);
            this.lblProjectFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProjectFiles.Name = "lblProjectFiles";
            this.lblProjectFiles.Size = new System.Drawing.Size(96, 16);
            this.lblProjectFiles.TabIndex = 52;
            this.lblProjectFiles.Text = "Project Files";
            // 
            // treeProject
            // 
            this.treeProject.Location = new System.Drawing.Point(968, 320);
            this.treeProject.Name = "treeProject";
            this.treeProject.Size = new System.Drawing.Size(368, 383);
            this.treeProject.TabIndex = 0;
            // 
            // lblConnectedTo
            // 
            this.lblConnectedTo.AutoSize = true;
            this.lblConnectedTo.Location = new System.Drawing.Point(968, 18);
            this.lblConnectedTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnectedTo.Name = "lblConnectedTo";
            this.lblConnectedTo.Size = new System.Drawing.Size(163, 16);
            this.lblConnectedTo.TabIndex = 51;
            this.lblConnectedTo.Text = "You are connected to:";
            // 
            // tbxProject
            // 
            this.tbxProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbxProject.Location = new System.Drawing.Point(968, 285);
            this.tbxProject.Name = "tbxProject";
            this.tbxProject.ReadOnly = true;
            this.tbxProject.Size = new System.Drawing.Size(368, 20);
            this.tbxProject.TabIndex = 1;
            // 
            // linkTarget
            // 
            this.linkTarget.AutoSize = true;
            this.linkTarget.Font = new System.Drawing.Font("Arial", 10F);
            this.linkTarget.Location = new System.Drawing.Point(968, 158);
            this.linkTarget.Name = "linkTarget";
            this.linkTarget.Size = new System.Drawing.Size(114, 36);
            this.linkTarget.TabIndex = 1;
            this.linkTarget.TabStop = true;
            this.linkTarget.Text = "Target CRM:  {0}\r\n{1}";
            this.linkTarget.UseCompatibleTextRendering = true;
            this.linkTarget.Visible = false;
            this.linkTarget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTarget_LinkClicked);
            // 
            // btnStartAttachmentsCopy
            // 
            this.btnStartAttachmentsCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartAttachmentsCopy.Location = new System.Drawing.Point(29, 674);
            this.btnStartAttachmentsCopy.Name = "btnStartAttachmentsCopy";
            this.btnStartAttachmentsCopy.Size = new System.Drawing.Size(232, 28);
            this.btnStartAttachmentsCopy.TabIndex = 50;
            this.btnStartAttachmentsCopy.Text = "COPY ATTACHMENTS";
            this.btnStartAttachmentsCopy.UseVisualStyleBackColor = false;
            this.btnStartAttachmentsCopy.Click += new System.EventHandler(this.btnStartAttachmentsCopy_Click);
            // 
            // linkSource
            // 
            this.linkSource.AutoSize = true;
            this.linkSource.Font = new System.Drawing.Font("Arial", 10F);
            this.linkSource.Location = new System.Drawing.Point(968, 65);
            this.linkSource.Name = "linkSource";
            this.linkSource.Size = new System.Drawing.Size(123, 36);
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
            this.lblProject2.Location = new System.Drawing.Point(467, 117);
            this.lblProject2.Name = "lblProject2";
            this.lblProject2.Size = new System.Drawing.Size(355, 34);
            this.lblProject2.TabIndex = 9;
            this.lblProject2.Text = "Select an existing \"<ProjectName>.xml\" file from\r\nproject root directory to load " +
    "a Project";
            // 
            // btnSelectAttachmentsDataFile
            // 
            this.btnSelectAttachmentsDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectAttachmentsDataFile.Location = new System.Drawing.Point(410, 421);
            this.btnSelectAttachmentsDataFile.Name = "btnSelectAttachmentsDataFile";
            this.btnSelectAttachmentsDataFile.Size = new System.Drawing.Size(148, 22);
            this.btnSelectAttachmentsDataFile.TabIndex = 49;
            this.btnSelectAttachmentsDataFile.Text = "Select Data File";
            this.btnSelectAttachmentsDataFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelectAttachmentsDataFile.UseCompatibleTextRendering = true;
            this.btnSelectAttachmentsDataFile.UseVisualStyleBackColor = false;
            this.btnSelectAttachmentsDataFile.Visible = false;
            this.btnSelectAttachmentsDataFile.Click += new System.EventHandler(this.btnSelectAttachmentsDataFile_Click);
            // 
            // cbxLoadProject
            // 
            this.cbxLoadProject.AutoSize = true;
            this.cbxLoadProject.Location = new System.Drawing.Point(470, 64);
            this.cbxLoadProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxLoadProject.Name = "cbxLoadProject";
            this.cbxLoadProject.Size = new System.Drawing.Size(162, 20);
            this.cbxLoadProject.TabIndex = 42;
            this.cbxLoadProject.Text = "Load saved Project";
            this.cbxLoadProject.UseVisualStyleBackColor = true;
            this.cbxLoadProject.CheckedChanged += new System.EventHandler(this.cbxLoadProject_CheckedChanged);
            // 
            // groupAttachmentsCopySettings
            // 
            this.groupAttachmentsCopySettings.Controls.Add(this.cbxAttachmentsKeepIDs);
            this.groupAttachmentsCopySettings.Controls.Add(this.cbxIncludeTextNotes);
            this.groupAttachmentsCopySettings.Enabled = false;
            this.groupAttachmentsCopySettings.Location = new System.Drawing.Point(410, 332);
            this.groupAttachmentsCopySettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupAttachmentsCopySettings.Name = "groupAttachmentsCopySettings";
            this.groupAttachmentsCopySettings.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupAttachmentsCopySettings.Size = new System.Drawing.Size(506, 59);
            this.groupAttachmentsCopySettings.TabIndex = 37;
            this.groupAttachmentsCopySettings.TabStop = false;
            this.groupAttachmentsCopySettings.Text = "Copy Settings";
            // 
            // cbxAttachmentsKeepIDs
            // 
            this.cbxAttachmentsKeepIDs.AutoSize = true;
            this.cbxAttachmentsKeepIDs.Location = new System.Drawing.Point(209, 24);
            this.cbxAttachmentsKeepIDs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxAttachmentsKeepIDs.Name = "cbxAttachmentsKeepIDs";
            this.cbxAttachmentsKeepIDs.Size = new System.Drawing.Size(302, 20);
            this.cbxAttachmentsKeepIDs.TabIndex = 7;
            this.cbxAttachmentsKeepIDs.Text = "Keep List Of Created Notes for rollback";
            this.cbxAttachmentsKeepIDs.UseVisualStyleBackColor = true;
            this.cbxAttachmentsKeepIDs.CheckedChanged += new System.EventHandler(this.cbxAttachmentsKeepIDs_CheckedChanged);
            // 
            // cbxIncludeTextNotes
            // 
            this.cbxIncludeTextNotes.AutoSize = true;
            this.cbxIncludeTextNotes.Location = new System.Drawing.Point(35, 24);
            this.cbxIncludeTextNotes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxIncludeTextNotes.Name = "cbxIncludeTextNotes";
            this.cbxIncludeTextNotes.Size = new System.Drawing.Size(161, 20);
            this.cbxIncludeTextNotes.TabIndex = 6;
            this.cbxIncludeTextNotes.Text = "Include Text Nodes";
            this.cbxIncludeTextNotes.UseVisualStyleBackColor = true;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProject.Location = new System.Drawing.Point(26, 106);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(348, 153);
            this.lblProject.TabIndex = 6;
            this.lblProject.Text = resources.GetString("lblProject.Text");
            // 
            // txtxAttachmentsDataFile
            // 
            this.txtxAttachmentsDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtxAttachmentsDataFile.Location = new System.Drawing.Point(568, 423);
            this.txtxAttachmentsDataFile.Name = "txtxAttachmentsDataFile";
            this.txtxAttachmentsDataFile.ReadOnly = true;
            this.txtxAttachmentsDataFile.Size = new System.Drawing.Size(349, 20);
            this.txtxAttachmentsDataFile.TabIndex = 48;
            this.txtxAttachmentsDataFile.Visible = false;
            // 
            // cbxCreateProject
            // 
            this.cbxCreateProject.AutoSize = true;
            this.cbxCreateProject.Location = new System.Drawing.Point(28, 56);
            this.cbxCreateProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxCreateProject.Name = "cbxCreateProject";
            this.cbxCreateProject.Size = new System.Drawing.Size(261, 36);
            this.cbxCreateProject.TabIndex = 41;
            this.cbxCreateProject.Text = " Create a new Project based on\r\n Configuration Migration package";
            this.cbxCreateProject.UseVisualStyleBackColor = true;
            this.cbxCreateProject.CheckedChanged += new System.EventHandler(this.cbxCreateProject_CheckedChanged);
            // 
            // groupPortalsSources
            // 
            this.groupPortalsSources.Controls.Add(this.ddlSourcePortal);
            this.groupPortalsSources.Controls.Add(this.label9);
            this.groupPortalsSources.Controls.Add(this.label8);
            this.groupPortalsSources.Controls.Add(this.ddlTargetPortal);
            this.groupPortalsSources.Location = new System.Drawing.Point(410, 481);
            this.groupPortalsSources.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupPortalsSources.Name = "groupPortalsSources";
            this.groupPortalsSources.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupPortalsSources.Size = new System.Drawing.Size(506, 98);
            this.groupPortalsSources.TabIndex = 45;
            this.groupPortalsSources.TabStop = false;
            this.groupPortalsSources.Visible = false;
            // 
            // ddlSourcePortal
            // 
            this.ddlSourcePortal.FormattingEnabled = true;
            this.ddlSourcePortal.Location = new System.Drawing.Point(160, 20);
            this.ddlSourcePortal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlSourcePortal.Name = "ddlSourcePortal";
            this.ddlSourcePortal.Size = new System.Drawing.Size(314, 24);
            this.ddlSourcePortal.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 65);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Target Portal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Source Portal";
            // 
            // ddlTargetPortal
            // 
            this.ddlTargetPortal.FormattingEnabled = true;
            this.ddlTargetPortal.Location = new System.Drawing.Point(160, 62);
            this.ddlTargetPortal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ddlTargetPortal.Name = "ddlTargetPortal";
            this.ddlTargetPortal.Size = new System.Drawing.Size(314, 24);
            this.ddlTargetPortal.TabIndex = 16;
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Font = new System.Drawing.Font("Arial", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblIntro.Location = new System.Drawing.Point(26, 14);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(624, 21);
            this.lblIntro.TabIndex = 47;
            this.lblIntro.Text = "Welcome to Data Migration Manager.  Please select from options below:";
            // 
            // btnSelectIDsBackup
            // 
            this.btnSelectIDsBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectIDsBackup.Location = new System.Drawing.Point(410, 618);
            this.btnSelectIDsBackup.Name = "btnSelectIDsBackup";
            this.btnSelectIDsBackup.Size = new System.Drawing.Size(107, 22);
            this.btnSelectIDsBackup.TabIndex = 47;
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
            this.txtAttachmentsIDsBackUpFile.Location = new System.Drawing.Point(568, 620);
            this.txtAttachmentsIDsBackUpFile.Name = "txtAttachmentsIDsBackUpFile";
            this.txtAttachmentsIDsBackUpFile.ReadOnly = true;
            this.txtAttachmentsIDsBackUpFile.Size = new System.Drawing.Size(349, 20);
            this.txtAttachmentsIDsBackUpFile.TabIndex = 21;
            this.txtAttachmentsIDsBackUpFile.Visible = false;
            // 
            // cbxAttachmentsMigration
            // 
            this.cbxAttachmentsMigration.AutoSize = true;
            this.cbxAttachmentsMigration.Location = new System.Drawing.Point(29, 332);
            this.cbxAttachmentsMigration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxAttachmentsMigration.Name = "cbxAttachmentsMigration";
            this.cbxAttachmentsMigration.Size = new System.Drawing.Size(374, 20);
            this.cbxAttachmentsMigration.TabIndex = 43;
            this.cbxAttachmentsMigration.Text = "Execute Attachment (Notes) migration or roll back";
            this.cbxAttachmentsMigration.UseVisualStyleBackColor = true;
            this.cbxAttachmentsMigration.CheckedChanged += new System.EventHandler(this.cbxAttachmentsMigration_CheckedChanged);
            // 
            // cbxBasedOnFiles
            // 
            this.cbxBasedOnFiles.AutoSize = true;
            this.cbxBasedOnFiles.Enabled = false;
            this.cbxBasedOnFiles.Location = new System.Drawing.Point(62, 424);
            this.cbxBasedOnFiles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxBasedOnFiles.Name = "cbxBasedOnFiles";
            this.cbxBasedOnFiles.Size = new System.Drawing.Size(160, 20);
            this.cbxBasedOnFiles.TabIndex = 38;
            this.cbxBasedOnFiles.Text = "Based On Data File";
            this.cbxBasedOnFiles.UseVisualStyleBackColor = true;
            this.cbxBasedOnFiles.CheckedChanged += new System.EventHandler(this.cbxBasedOnFiles_CheckedChanged);
            // 
            // cbxFromPortalToPortal
            // 
            this.cbxFromPortalToPortal.AutoSize = true;
            this.cbxFromPortalToPortal.Enabled = false;
            this.cbxFromPortalToPortal.Location = new System.Drawing.Point(62, 481);
            this.cbxFromPortalToPortal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxFromPortalToPortal.Name = "cbxFromPortalToPortal";
            this.cbxFromPortalToPortal.Size = new System.Drawing.Size(268, 100);
            this.cbxFromPortalToPortal.TabIndex = 39;
            this.cbxFromPortalToPortal.Text = " Copy Web File\'s Attachments from\r\n    from:   Source, Selected Portal \r\n     to:" +
    "      Target,  Selected Portal \r\n\r\n * Based on Web File\'s names\r\n * Selfcopy is " +
    "not supported";
            this.cbxFromPortalToPortal.UseVisualStyleBackColor = true;
            this.cbxFromPortalToPortal.CheckedChanged += new System.EventHandler(this.cbxFromPortalToPortal_CheckedChanged);
            // 
            // cbxAttachmentsRollback
            // 
            this.cbxAttachmentsRollback.AutoSize = true;
            this.cbxAttachmentsRollback.Enabled = false;
            this.cbxAttachmentsRollback.Location = new System.Drawing.Point(62, 621);
            this.cbxAttachmentsRollback.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxAttachmentsRollback.Name = "cbxAttachmentsRollback";
            this.cbxAttachmentsRollback.Size = new System.Drawing.Size(230, 20);
            this.cbxAttachmentsRollback.TabIndex = 40;
            this.cbxAttachmentsRollback.Text = "Roll back Attachments Import";
            this.cbxAttachmentsRollback.UseVisualStyleBackColor = true;
            this.cbxAttachmentsRollback.CheckedChanged += new System.EventHandler(this.cbxAttachmentsRollback_CheckedChanged);
            // 
            // tabModifyDataBasedOnSavedQueries
            // 
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupViewsAdvanced);
            this.tabModifyDataBasedOnSavedQueries.Controls.Add(this.groupViewDataFilter);
            this.tabModifyDataBasedOnSavedQueries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabModifyDataBasedOnSavedQueries.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabModifyDataBasedOnSavedQueries.Location = new System.Drawing.Point(4, 35);
            this.tabModifyDataBasedOnSavedQueries.Name = "tabModifyDataBasedOnSavedQueries";
            this.tabModifyDataBasedOnSavedQueries.Size = new System.Drawing.Size(1396, 724);
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
            this.groupViewsAdvanced.Location = new System.Drawing.Point(1149, 15);
            this.groupViewsAdvanced.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupViewsAdvanced.Name = "groupViewsAdvanced";
            this.groupViewsAdvanced.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupViewsAdvanced.Size = new System.Drawing.Size(248, 707);
            this.groupViewsAdvanced.TabIndex = 44;
            this.groupViewsAdvanced.TabStop = false;
            this.groupViewsAdvanced.Text = "Filters and Results PreView";
            // 
            // lblSorceDataFile
            // 
            this.lblSorceDataFile.AutoSize = true;
            this.lblSorceDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSorceDataFile.Location = new System.Drawing.Point(86, 28);
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
            this.lblResultDataFile.Location = new System.Drawing.Point(56, 371);
            this.lblResultDataFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultDataFile.Name = "lblResultDataFile";
            this.lblResultDataFile.Size = new System.Drawing.Size(138, 13);
            this.lblResultDataFile.TabIndex = 49;
            this.lblResultDataFile.Text = "Processed Records Monitor";
            // 
            // treeResultDataFile
            // 
            this.treeResultDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.treeResultDataFile.Location = new System.Drawing.Point(15, 403);
            this.treeResultDataFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeResultDataFile.Name = "treeResultDataFile";
            this.treeResultDataFile.Size = new System.Drawing.Size(215, 280);
            this.treeResultDataFile.TabIndex = 46;
            // 
            // treeSorceDataFile
            // 
            this.treeSorceDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.treeSorceDataFile.Location = new System.Drawing.Point(15, 54);
            this.treeSorceDataFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeSorceDataFile.Name = "treeSorceDataFile";
            this.treeSorceDataFile.Size = new System.Drawing.Size(215, 280);
            this.treeSorceDataFile.TabIndex = 0;
            // 
            // groupViewDataFilter
            // 
            this.groupViewDataFilter.Controls.Add(this.lblTransformationSettings);
            this.groupViewDataFilter.Controls.Add(this.lblTransformedQueryDisplay);
            this.groupViewDataFilter.Controls.Add(this.groupSavedViewsFooter);
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
            this.groupViewDataFilter.Enabled = false;
            this.groupViewDataFilter.Location = new System.Drawing.Point(15, 15);
            this.groupViewDataFilter.Name = "groupViewDataFilter";
            this.groupViewDataFilter.Size = new System.Drawing.Size(1121, 713);
            this.groupViewDataFilter.TabIndex = 43;
            this.groupViewDataFilter.TabStop = false;
            this.groupViewDataFilter.Text = "Set Saved Views as Data Filters ";
            // 
            // lblTransformationSettings
            // 
            this.lblTransformationSettings.AutoSize = true;
            this.lblTransformationSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblTransformationSettings.Location = new System.Drawing.Point(599, 509);
            this.lblTransformationSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransformationSettings.Name = "lblTransformationSettings";
            this.lblTransformationSettings.Size = new System.Drawing.Size(217, 15);
            this.lblTransformationSettings.TabIndex = 66;
            this.lblTransformationSettings.Text = "Selected Query transformation settings";
            // 
            // lblTransformedQueryDisplay
            // 
            this.lblTransformedQueryDisplay.AutoSize = true;
            this.lblTransformedQueryDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTransformedQueryDisplay.Location = new System.Drawing.Point(898, 288);
            this.lblTransformedQueryDisplay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTransformedQueryDisplay.Name = "lblTransformedQueryDisplay";
            this.lblTransformedQueryDisplay.Size = new System.Drawing.Size(145, 13);
            this.lblTransformedQueryDisplay.TabIndex = 63;
            this.lblTransformedQueryDisplay.Text = "Query Transformation Display";
            // 
            // groupSavedViewsFooter
            // 
            this.groupSavedViewsFooter.Controls.Add(this.btnViewsBack);
            this.groupSavedViewsFooter.Controls.Add(this.btnSaveModifyViewsFile);
            this.groupSavedViewsFooter.Location = new System.Drawing.Point(10, 643);
            this.groupSavedViewsFooter.Name = "groupSavedViewsFooter";
            this.groupSavedViewsFooter.Size = new System.Drawing.Size(1101, 64);
            this.groupSavedViewsFooter.TabIndex = 42;
            this.groupSavedViewsFooter.TabStop = false;
            // 
            // btnViewsBack
            // 
            this.btnViewsBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewsBack.Location = new System.Drawing.Point(16, 22);
            this.btnViewsBack.Name = "btnViewsBack";
            this.btnViewsBack.Size = new System.Drawing.Size(200, 27);
            this.btnViewsBack.TabIndex = 6;
            this.btnViewsBack.Text = "Return to Project";
            this.btnViewsBack.UseVisualStyleBackColor = true;
            this.btnViewsBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSaveModifyViewsFile
            // 
            this.btnSaveModifyViewsFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveModifyViewsFile.Location = new System.Drawing.Point(891, 22);
            this.btnSaveModifyViewsFile.Name = "btnSaveModifyViewsFile";
            this.btnSaveModifyViewsFile.Size = new System.Drawing.Size(200, 27);
            this.btnSaveModifyViewsFile.TabIndex = 5;
            this.btnSaveModifyViewsFile.Text = "Modify And Save Data";
            this.btnSaveModifyViewsFile.UseVisualStyleBackColor = true;
            this.btnSaveModifyViewsFile.Click += new System.EventHandler(this.btnSaveModifyViewsFile_Click);
            // 
            // cbxExcludeFromResult
            // 
            this.cbxExcludeFromResult.AutoSize = true;
            this.cbxExcludeFromResult.Location = new System.Drawing.Point(602, 604);
            this.cbxExcludeFromResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxExcludeFromResult.Name = "cbxExcludeFromResult";
            this.cbxExcludeFromResult.Size = new System.Drawing.Size(194, 21);
            this.cbxExcludeFromResult.TabIndex = 65;
            this.cbxExcludeFromResult.Text = "Reverse (Exclude Results)";
            this.cbxExcludeFromResult.UseVisualStyleBackColor = true;
            this.cbxExcludeFromResult.CheckedChanged += new System.EventHandler(this.transformationSettings_CheckedChanged);
            // 
            // treeTransformedQueryDisplay
            // 
            this.treeTransformedQueryDisplay.Location = new System.Drawing.Point(848, 329);
            this.treeTransformedQueryDisplay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeTransformedQueryDisplay.Name = "treeTransformedQueryDisplay";
            this.treeTransformedQueryDisplay.Size = new System.Drawing.Size(263, 300);
            this.treeTransformedQueryDisplay.TabIndex = 62;
            // 
            // cbxExecuteAsListOfLinkedQueries
            // 
            this.cbxExecuteAsListOfLinkedQueries.AutoSize = true;
            this.cbxExecuteAsListOfLinkedQueries.Location = new System.Drawing.Point(602, 553);
            this.cbxExecuteAsListOfLinkedQueries.Name = "cbxExecuteAsListOfLinkedQueries";
            this.cbxExecuteAsListOfLinkedQueries.Size = new System.Drawing.Size(242, 21);
            this.cbxExecuteAsListOfLinkedQueries.TabIndex = 60;
            this.cbxExecuteAsListOfLinkedQueries.Text = "Execute As List Of Linked Queries";
            this.cbxExecuteAsListOfLinkedQueries.UseVisualStyleBackColor = true;
            this.cbxExecuteAsListOfLinkedQueries.CheckedChanged += new System.EventHandler(this.transformationSettings_CheckedChanged);
            // 
            // cbxCollectAllReferences
            // 
            this.cbxCollectAllReferences.AutoSize = true;
            this.cbxCollectAllReferences.Location = new System.Drawing.Point(602, 578);
            this.cbxCollectAllReferences.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxCollectAllReferences.Name = "cbxCollectAllReferences";
            this.cbxCollectAllReferences.Size = new System.Drawing.Size(203, 21);
            this.cbxCollectAllReferences.TabIndex = 61;
            this.cbxCollectAllReferences.Text = "Add Lookup Fields to import";
            this.cbxCollectAllReferences.UseVisualStyleBackColor = true;
            this.cbxCollectAllReferences.CheckedChanged += new System.EventHandler(this.transformationSettings_CheckedChanged);
            // 
            // lstListOfViewsFilters
            // 
            this.lstListOfViewsFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstListOfViewsFilters.FormattingEnabled = true;
            this.lstListOfViewsFilters.Location = new System.Drawing.Point(828, 92);
            this.lstListOfViewsFilters.Name = "lstListOfViewsFilters";
            this.lstListOfViewsFilters.Size = new System.Drawing.Size(288, 121);
            this.lstListOfViewsFilters.Sorted = true;
            this.lstListOfViewsFilters.TabIndex = 55;
            this.lstListOfViewsFilters.SelectedIndexChanged += new System.EventHandler(this.lstListOfViewsFilters_SelectedIndexChanged);
            this.lstListOfViewsFilters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstListOfViewsFilters_MouseDoubleClick);
            // 
            // lblViewsByEntity
            // 
            this.lblViewsByEntity.AutoSize = true;
            this.lblViewsByEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblViewsByEntity.Location = new System.Drawing.Point(526, 39);
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
            this.label5.Location = new System.Drawing.Point(296, 28);
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
            this.label6.Location = new System.Drawing.Point(40, 28);
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
            this.lstDefaultSchemaDataByViews.Location = new System.Drawing.Point(10, 63);
            this.lstDefaultSchemaDataByViews.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstDefaultSchemaDataByViews.Name = "lstDefaultSchemaDataByViews";
            this.lstDefaultSchemaDataByViews.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDefaultSchemaDataByViews.Size = new System.Drawing.Size(206, 498);
            this.lstDefaultSchemaDataByViews.Sorted = true;
            this.lstDefaultSchemaDataByViews.TabIndex = 42;
            // 
            // lstViewsPerEntity
            // 
            this.lstViewsPerEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstViewsPerEntity.FormattingEnabled = true;
            this.lstViewsPerEntity.Location = new System.Drawing.Point(520, 92);
            this.lstViewsPerEntity.Name = "lstViewsPerEntity";
            this.lstViewsPerEntity.Size = new System.Drawing.Size(289, 173);
            this.lstViewsPerEntity.Sorted = true;
            this.lstViewsPerEntity.TabIndex = 51;
            this.lstViewsPerEntity.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstViewsPerEntity_MouseDoubleClick);
            // 
            // btnbtnViews_FromDefaultToSelected
            // 
            this.btnbtnViews_FromDefaultToSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnbtnViews_FromDefaultToSelected.Location = new System.Drawing.Point(232, 128);
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
            this.btnViews_ReturnToDefaultFromSelected.Location = new System.Drawing.Point(232, 197);
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
            this.lblListOfViewsFilters.Location = new System.Drawing.Point(845, 39);
            this.lblListOfViewsFilters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblListOfViewsFilters.Name = "lblListOfViewsFilters";
            this.lblListOfViewsFilters.Size = new System.Drawing.Size(214, 39);
            this.lblListOfViewsFilters.TabIndex = 47;
            this.lblListOfViewsFilters.Text = "Select a view to set import settings \r\nor\r\nDouble click a view to remove it from " +
    "the list";
            // 
            // lstSelectedSchemaDataByViews
            // 
            this.lstSelectedSchemaDataByViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstSelectedSchemaDataByViews.FormattingEnabled = true;
            this.lstSelectedSchemaDataByViews.Location = new System.Drawing.Point(286, 63);
            this.lstSelectedSchemaDataByViews.Name = "lstSelectedSchemaDataByViews";
            this.lstSelectedSchemaDataByViews.Size = new System.Drawing.Size(206, 342);
            this.lstSelectedSchemaDataByViews.Sorted = true;
            this.lstSelectedSchemaDataByViews.TabIndex = 41;
            this.lstSelectedSchemaDataByViews.SelectedIndexChanged += new System.EventHandler(this.lstSelectedSchemaDataByViews_SelectedIndexChanged);
            // 
            // tabReplaceIDs
            // 
            this.tabReplaceIDs.Controls.Add(this.groupCopyToolContent);
            this.tabReplaceIDs.Location = new System.Drawing.Point(4, 35);
            this.tabReplaceIDs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabReplaceIDs.Name = "tabReplaceIDs";
            this.tabReplaceIDs.Size = new System.Drawing.Size(1396, 724);
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
            this.groupCopyToolContent.Enabled = false;
            this.groupCopyToolContent.Location = new System.Drawing.Point(16, 24);
            this.groupCopyToolContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupCopyToolContent.Name = "groupCopyToolContent";
            this.groupCopyToolContent.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupCopyToolContent.Size = new System.Drawing.Size(1359, 542);
            this.groupCopyToolContent.TabIndex = 42;
            this.groupCopyToolContent.TabStop = false;
            // 
            // btnCopyToolBack
            // 
            this.btnCopyToolBack.Location = new System.Drawing.Point(1116, 485);
            this.btnCopyToolBack.Name = "btnCopyToolBack";
            this.btnCopyToolBack.Size = new System.Drawing.Size(200, 27);
            this.btnCopyToolBack.TabIndex = 6;
            this.btnCopyToolBack.Text = "Return to Project";
            this.btnCopyToolBack.UseVisualStyleBackColor = true;
            this.btnCopyToolBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCopyToolFromModified
            // 
            this.btnCopyToolFromModified.Location = new System.Drawing.Point(44, 355);
            this.btnCopyToolFromModified.Name = "btnCopyToolFromModified";
            this.btnCopyToolFromModified.Size = new System.Drawing.Size(644, 75);
            this.btnCopyToolFromModified.TabIndex = 41;
            this.btnCopyToolFromModified.Text = "Create copy of pre-filtered by Saved Views data file with new GUIDs";
            this.btnCopyToolFromModified.UseCompatibleTextRendering = true;
            this.btnCopyToolFromModified.UseVisualStyleBackColor = true;
            this.btnCopyToolFromModified.Click += new System.EventHandler(this.btnCopyToolFromModified_Click);
            // 
            // btnCopyToolFromSource
            // 
            this.btnCopyToolFromSource.Location = new System.Drawing.Point(44, 184);
            this.btnCopyToolFromSource.Name = "btnCopyToolFromSource";
            this.btnCopyToolFromSource.Size = new System.Drawing.Size(644, 75);
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
            // lblDataDouplInfo
            // 
            this.lblDataDouplInfo.AutoSize = true;
            this.lblDataDouplInfo.Location = new System.Drawing.Point(44, 51);
            this.lblDataDouplInfo.Name = "lblDataDouplInfo";
            this.lblDataDouplInfo.Size = new System.Drawing.Size(377, 80);
            this.lblDataDouplInfo.TabIndex = 42;
            this.lblDataDouplInfo.Text = "The \"Data Duplicator\" creates exact copy of data file.\r\n\r\nAll entities are gettin" +
    "g new ids.\r\n\r\nTheir references will be updated..";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1448, 817);
            this.Controls.Add(this.tabsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Migration Management tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabsPanel.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabProject.ResumeLayout(false);
            this.tabProject.PerformLayout();
            this.groupAttachmentsCopySettings.ResumeLayout(false);
            this.groupAttachmentsCopySettings.PerformLayout();
            this.groupPortalsSources.ResumeLayout(false);
            this.groupPortalsSources.PerformLayout();
            this.tabModifyDataBasedOnSavedQueries.ResumeLayout(false);
            this.groupViewsAdvanced.ResumeLayout(false);
            this.groupViewsAdvanced.PerformLayout();
            this.groupViewDataFilter.ResumeLayout(false);
            this.groupViewDataFilter.PerformLayout();
            this.groupSavedViewsFooter.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupSavedViewsFooter;
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
        private System.Windows.Forms.CheckBox cbxAttachmentsRollback;
        private System.Windows.Forms.CheckBox cbxFromPortalToPortal;
        private System.Windows.Forms.CheckBox cbxBasedOnFiles;
        private System.Windows.Forms.GroupBox groupAttachmentsCopySettings;
        private System.Windows.Forms.CheckBox cbxAttachmentsKeepIDs;
        private System.Windows.Forms.CheckBox cbxIncludeTextNotes;
        private System.Windows.Forms.CheckBox cbxAttachmentsMigration;
        private System.Windows.Forms.GroupBox groupPortalsSources;
        private System.Windows.Forms.ComboBox ddlSourcePortal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlTargetPortal;
        private System.Windows.Forms.Button btnSelectIDsBackup;
        private System.Windows.Forms.TextBox txtAttachmentsIDsBackUpFile;
        private System.Windows.Forms.Button btnSelectAttachmentsDataFile;
        private System.Windows.Forms.TextBox txtxAttachmentsDataFile;
        private System.Windows.Forms.Button btnStartAttachmentsCopy;
        private System.Windows.Forms.LinkLabel linkTarget;
        private System.Windows.Forms.LinkLabel linkSource;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblProjectFiles;
        private System.Windows.Forms.Label lblConnectedTo;
        private System.Windows.Forms.Button btnTargetConnectionChange;
        private System.Windows.Forms.Button btnSourcetConnectionChange;
        private System.Windows.Forms.Label lblDataDouplInfo;
    }
}

