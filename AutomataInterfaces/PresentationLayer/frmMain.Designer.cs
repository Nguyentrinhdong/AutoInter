namespace AutomataInterfaces.PresentationLayer
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOPen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAutomataGeneration = new System.Windows.Forms.ToolStripButton();
            this.toolStripPlugggableCheck = new System.Windows.Forms.ToolStripButton();
            this.toolStripRefinementChecked = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStripCheck = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkSatisfyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageDrawRefinementPluggable = new System.Windows.Forms.TabPage();
            this.splitContainerDraw = new System.Windows.Forms.SplitContainer();
            this.treeViewDraw = new System.Windows.Forms.TreeView();
            this.panelGraphic = new System.Windows.Forms.Panel();
            this.toolStripPlugandRefine = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonHighIncreament = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWideIncreament = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDrawAutomata = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonHighDecrement = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonWideDecrement = new System.Windows.Forms.ToolStripButton();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.richTextBoxEditor = new System.Windows.Forms.RichTextBox();
            this.tabControlAI = new System.Windows.Forms.TabControl();
            this.menuStripMain.SuspendLayout();
            this.toolStripMainMenu.SuspendLayout();
            this.contextMenuStripCheck.SuspendLayout();
            this.tabPageDrawRefinementPluggable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDraw)).BeginInit();
            this.splitContainerDraw.Panel1.SuspendLayout();
            this.splitContainerDraw.Panel2.SuspendLayout();
            this.splitContainerDraw.SuspendLayout();
            this.toolStripPlugandRefine.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.tabControlAI.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(841, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "Mainmenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripMenuItem2,
            this.printToolStripMenuItem,
            this.pageSetupToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonOPen_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // pageSetupToolStripMenuItem
            // 
            this.pageSetupToolStripMenuItem.Enabled = false;
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pageSetupToolStripMenuItem.Text = "Page setup";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Enabled = false;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripMainMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMainMenu.ImeMode = System.Windows.Forms.ImeMode.On;
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOPen,
            this.toolStripButtonSave,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripAutomataGeneration,
            this.toolStripPlugggableCheck,
            this.toolStripRefinementChecked});
            this.toolStripMainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripMainMenu.Location = new System.Drawing.Point(0, 24);
            this.toolStripMainMenu.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripMainMenu.Size = new System.Drawing.Size(841, 33);
            this.toolStripMainMenu.Stretch = true;
            this.toolStripMainMenu.TabIndex = 1;
            this.toolStripMainMenu.Text = "Main Menu";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonNew.Text = "Create new automata";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonOPen
            // 
            this.toolStripButtonOPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOPen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOPen.Image")));
            this.toolStripButtonOPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOPen.Name = "toolStripButtonOPen";
            this.toolStripButtonOPen.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonOPen.Text = "Open Automata Interfaces";
            this.toolStripButtonOPen.Click += new System.EventHandler(this.toolStripButtonOPen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonSave.Text = "Save Automata Interfaces Text file";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "Save all content";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripAutomataGeneration
            // 
            this.toolStripAutomataGeneration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAutomataGeneration.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAutomataGeneration.Image")));
            this.toolStripAutomataGeneration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAutomataGeneration.Name = "toolStripAutomataGeneration";
            this.toolStripAutomataGeneration.Size = new System.Drawing.Size(28, 28);
            this.toolStripAutomataGeneration.Text = "Automata Generations";
            this.toolStripAutomataGeneration.Click += new System.EventHandler(this.toolStripAutomataGeneration_Click);
            // 
            // toolStripPlugggableCheck
            // 
            this.toolStripPlugggableCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripPlugggableCheck.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPlugggableCheck.Image")));
            this.toolStripPlugggableCheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPlugggableCheck.Name = "toolStripPlugggableCheck";
            this.toolStripPlugggableCheck.Size = new System.Drawing.Size(28, 28);
            this.toolStripPlugggableCheck.Text = "Pluggable Check";
            this.toolStripPlugggableCheck.Click += new System.EventHandler(this.toolStripPlugggableCheck_Click);
            // 
            // toolStripRefinementChecked
            // 
            this.toolStripRefinementChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefinementChecked.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefinementChecked.Image")));
            this.toolStripRefinementChecked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefinementChecked.Name = "toolStripRefinementChecked";
            this.toolStripRefinementChecked.Size = new System.Drawing.Size(28, 28);
            this.toolStripRefinementChecked.Text = "Refinement Check";
            this.toolStripRefinementChecked.Click += new System.EventHandler(this.toolStripRefinementChecked_Click);
            // 
            // contextMenuStripCheck
            // 
            this.contextMenuStripCheck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkSatisfyToolStripMenuItem});
            this.contextMenuStripCheck.Name = "contextMenuStrip1";
            this.contextMenuStripCheck.Size = new System.Drawing.Size(145, 26);
            // 
            // checkSatisfyToolStripMenuItem
            // 
            this.checkSatisfyToolStripMenuItem.Name = "checkSatisfyToolStripMenuItem";
            this.checkSatisfyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.checkSatisfyToolStripMenuItem.Text = "Check Satisfy";
            this.checkSatisfyToolStripMenuItem.Click += new System.EventHandler(this.checkSatisfyToolStripMenuItem_Click);
            // 
            // tabPageDrawRefinementPluggable
            // 
            this.tabPageDrawRefinementPluggable.Controls.Add(this.splitContainerDraw);
            this.tabPageDrawRefinementPluggable.Location = new System.Drawing.Point(4, 25);
            this.tabPageDrawRefinementPluggable.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageDrawRefinementPluggable.Name = "tabPageDrawRefinementPluggable";
            this.tabPageDrawRefinementPluggable.Size = new System.Drawing.Size(833, 297);
            this.tabPageDrawRefinementPluggable.TabIndex = 3;
            this.tabPageDrawRefinementPluggable.Text = "Refinement & Pluggable Check";
            this.tabPageDrawRefinementPluggable.UseVisualStyleBackColor = true;
            // 
            // splitContainerDraw
            // 
            this.splitContainerDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDraw.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDraw.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerDraw.Name = "splitContainerDraw";
            // 
            // splitContainerDraw.Panel1
            // 
            this.splitContainerDraw.Panel1.Controls.Add(this.treeViewDraw);
            this.splitContainerDraw.Panel1MinSize = 100;
            // 
            // splitContainerDraw.Panel2
            // 
            this.splitContainerDraw.Panel2.Controls.Add(this.panelGraphic);
            this.splitContainerDraw.Panel2.Controls.Add(this.toolStripPlugandRefine);
            this.splitContainerDraw.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainerDraw.Panel2MinSize = 100;
            this.splitContainerDraw.Size = new System.Drawing.Size(833, 297);
            this.splitContainerDraw.SplitterDistance = 273;
            this.splitContainerDraw.TabIndex = 0;
            // 
            // treeViewDraw
            // 
            this.treeViewDraw.BackColor = System.Drawing.Color.White;
            this.treeViewDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewDraw.Location = new System.Drawing.Point(0, 0);
            this.treeViewDraw.Margin = new System.Windows.Forms.Padding(2);
            this.treeViewDraw.Name = "treeViewDraw";
            this.treeViewDraw.Size = new System.Drawing.Size(273, 297);
            this.treeViewDraw.TabIndex = 0;
            // 
            // panelGraphic
            // 
            this.panelGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGraphic.Location = new System.Drawing.Point(37, 0);
            this.panelGraphic.Name = "panelGraphic";
            this.panelGraphic.Size = new System.Drawing.Size(519, 297);
            this.panelGraphic.TabIndex = 2;
            // 
            // toolStripPlugandRefine
            // 
            this.toolStripPlugandRefine.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripPlugandRefine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonHighIncreament,
            this.toolStripButtonWideIncreament,
            this.toolStripButtonDrawAutomata,
            this.toolStripButtonHighDecrement,
            this.toolStripButtonWideDecrement});
            this.toolStripPlugandRefine.Location = new System.Drawing.Point(0, 0);
            this.toolStripPlugandRefine.Name = "toolStripPlugandRefine";
            this.toolStripPlugandRefine.Size = new System.Drawing.Size(37, 297);
            this.toolStripPlugandRefine.TabIndex = 1;
            // 
            // toolStripButtonHighIncreament
            // 
            this.toolStripButtonHighIncreament.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHighIncreament.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHighIncreament.Image")));
            this.toolStripButtonHighIncreament.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonHighIncreament.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHighIncreament.Name = "toolStripButtonHighIncreament";
            this.toolStripButtonHighIncreament.Size = new System.Drawing.Size(34, 36);
            this.toolStripButtonHighIncreament.Text = "Increase the height of graph";
            // 
            // toolStripButtonWideIncreament
            // 
            this.toolStripButtonWideIncreament.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWideIncreament.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWideIncreament.Image")));
            this.toolStripButtonWideIncreament.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonWideIncreament.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWideIncreament.Name = "toolStripButtonWideIncreament";
            this.toolStripButtonWideIncreament.Size = new System.Drawing.Size(34, 36);
            this.toolStripButtonWideIncreament.Text = "Increase the width of graph";
            // 
            // toolStripButtonDrawAutomata
            // 
            this.toolStripButtonDrawAutomata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDrawAutomata.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDrawAutomata.Image")));
            this.toolStripButtonDrawAutomata.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonDrawAutomata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDrawAutomata.Name = "toolStripButtonDrawAutomata";
            this.toolStripButtonDrawAutomata.Size = new System.Drawing.Size(34, 36);
            this.toolStripButtonDrawAutomata.Text = "toolStripButton3";
            this.toolStripButtonDrawAutomata.Click += new System.EventHandler(this.toolStripButtonDrawAutomata_Click);
            // 
            // toolStripButtonHighDecrement
            // 
            this.toolStripButtonHighDecrement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHighDecrement.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHighDecrement.Image")));
            this.toolStripButtonHighDecrement.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonHighDecrement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHighDecrement.Name = "toolStripButtonHighDecrement";
            this.toolStripButtonHighDecrement.Size = new System.Drawing.Size(34, 36);
            this.toolStripButtonHighDecrement.Text = "Decrease the height of graph";
            // 
            // toolStripButtonWideDecrement
            // 
            this.toolStripButtonWideDecrement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWideDecrement.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWideDecrement.Image")));
            this.toolStripButtonWideDecrement.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonWideDecrement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWideDecrement.Name = "toolStripButtonWideDecrement";
            this.toolStripButtonWideDecrement.Size = new System.Drawing.Size(34, 36);
            this.toolStripButtonWideDecrement.Text = "Decrease the width of graph";
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Controls.Add(this.richTextBoxEditor);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 25);
            this.tabPageEdit.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageEdit.Size = new System.Drawing.Size(833, 297);
            this.tabPageEdit.TabIndex = 0;
            this.tabPageEdit.Text = "Edit";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // richTextBoxEditor
            // 
            this.richTextBoxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEditor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxEditor.Location = new System.Drawing.Point(2, 2);
            this.richTextBoxEditor.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxEditor.Name = "richTextBoxEditor";
            this.richTextBoxEditor.Size = new System.Drawing.Size(829, 293);
            this.richTextBoxEditor.TabIndex = 0;
            this.richTextBoxEditor.Text = "";
            // 
            // tabControlAI
            // 
            this.tabControlAI.Controls.Add(this.tabPageEdit);
            this.tabControlAI.Controls.Add(this.tabPageDrawRefinementPluggable);
            this.tabControlAI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlAI.Location = new System.Drawing.Point(0, 57);
            this.tabControlAI.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlAI.Name = "tabControlAI";
            this.tabControlAI.SelectedIndex = 0;
            this.tabControlAI.ShowToolTips = true;
            this.tabControlAI.Size = new System.Drawing.Size(841, 326);
            this.tabControlAI.TabIndex = 2;
            this.tabControlAI.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(841, 383);
            this.Controls.Add(this.tabControlAI);
            this.Controls.Add(this.toolStripMainMenu);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmMain";
            this.Text = "Automata Interfaces";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.contextMenuStripCheck.ResumeLayout(false);
            this.tabPageDrawRefinementPluggable.ResumeLayout(false);
            this.splitContainerDraw.Panel1.ResumeLayout(false);
            this.splitContainerDraw.Panel2.ResumeLayout(false);
            this.splitContainerDraw.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDraw)).EndInit();
            this.splitContainerDraw.ResumeLayout(false);
            this.toolStripPlugandRefine.ResumeLayout(false);
            this.toolStripPlugandRefine.PerformLayout();
            this.tabPageEdit.ResumeLayout(false);
            this.tabControlAI.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOPen;
        private System.Windows.Forms.ToolStripButton toolStripAutomataGeneration;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCheck;
        private System.Windows.Forms.ToolStripMenuItem checkSatisfyToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripPlugggableCheck;
        private System.Windows.Forms.ToolStripButton toolStripRefinementChecked;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tabPageDrawRefinementPluggable;
        private System.Windows.Forms.SplitContainer splitContainerDraw;
        private System.Windows.Forms.TreeView treeViewDraw;
        private System.Windows.Forms.ToolStrip toolStripPlugandRefine;
        private System.Windows.Forms.ToolStripButton toolStripButtonHighIncreament;
        private System.Windows.Forms.ToolStripButton toolStripButtonWideIncreament;
        private System.Windows.Forms.ToolStripButton toolStripButtonDrawAutomata;
        private System.Windows.Forms.ToolStripButton toolStripButtonHighDecrement;
        private System.Windows.Forms.ToolStripButton toolStripButtonWideDecrement;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.RichTextBox richTextBoxEditor;
        private System.Windows.Forms.TabControl tabControlAI;
        private System.Windows.Forms.Panel panelGraphic;
    }
}