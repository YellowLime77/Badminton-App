
namespace BadmintonApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.courtPanel = new System.Windows.Forms.Panel();
            this.endPictureBox = new System.Windows.Forms.PictureBox();
            this.startPictureBox = new System.Windows.Forms.PictureBox();
            this.courtPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataframeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.submitButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.shotsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flatClearButton = new System.Windows.Forms.Button();
            this.highClearButton = new System.Windows.Forms.Button();
            this.fastDropButton = new System.Windows.Forms.Button();
            this.slowDropButton = new System.Windows.Forms.Button();
            this.fullSmashButton = new System.Windows.Forms.Button();
            this.halfSmashButton = new System.Windows.Forms.Button();
            this.farBlockButton = new System.Windows.Forms.Button();
            this.closeBlockButton = new System.Windows.Forms.Button();
            this.farNetButton = new System.Windows.Forms.Button();
            this.closeNetButton = new System.Windows.Forms.Button();
            this.crossNetButton = new System.Windows.Forms.Button();
            this.netSpinButton = new System.Windows.Forms.Button();
            this.pushButton = new System.Windows.Forms.Button();
            this.liftButton = new System.Windows.Forms.Button();
            this.lowServeButton = new System.Windows.Forms.Button();
            this.highServeButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.situationFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.neutralButton = new System.Windows.Forms.Button();
            this.attackingButton = new System.Windows.Forms.Button();
            this.defendingButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.turnFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.playerButton = new System.Windows.Forms.Button();
            this.opponentButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.winnerGroupBox = new System.Windows.Forms.GroupBox();
            this.opponentWinnerButton = new System.Windows.Forms.Button();
            this.playerWinnerButton = new System.Windows.Forms.Button();
            this.submitRallyButton = new System.Windows.Forms.Button();
            this.analysisWindowButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastInputTextBox = new System.Windows.Forms.TextBox();
            this.courtPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courtPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.shotsFlowLayoutPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.situationFlowLayoutPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.turnFlowLayoutPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.winnerGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // courtPanel
            // 
            this.courtPanel.Controls.Add(this.endPictureBox);
            this.courtPanel.Controls.Add(this.startPictureBox);
            this.courtPanel.Controls.Add(this.courtPictureBox);
            this.courtPanel.Location = new System.Drawing.Point(14, 61);
            this.courtPanel.Name = "courtPanel";
            this.courtPanel.Size = new System.Drawing.Size(213, 460);
            this.courtPanel.TabIndex = 0;
            // 
            // endPictureBox
            // 
            this.endPictureBox.Image = global::BadmintonApp.Properties.Resources.redend;
            this.endPictureBox.Location = new System.Drawing.Point(0, 0);
            this.endPictureBox.Name = "endPictureBox";
            this.endPictureBox.Size = new System.Drawing.Size(20, 20);
            this.endPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.endPictureBox.TabIndex = 2;
            this.endPictureBox.TabStop = false;
            this.endPictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_LoadCompleted);
            this.endPictureBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            // 
            // startPictureBox
            // 
            this.startPictureBox.Image = global::BadmintonApp.Properties.Resources.bluestart;
            this.startPictureBox.Location = new System.Drawing.Point(0, 229);
            this.startPictureBox.Name = "startPictureBox";
            this.startPictureBox.Size = new System.Drawing.Size(20, 20);
            this.startPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.startPictureBox.TabIndex = 1;
            this.startPictureBox.TabStop = false;
            this.startPictureBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox_LoadCompleted);
            this.startPictureBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            // 
            // courtPictureBox
            // 
            this.courtPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.courtPictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.courtPictureBox.Image = global::BadmintonApp.Properties.Resources.basic_badmintoncourt_dimensions_metric_horizontal;
            this.courtPictureBox.Location = new System.Drawing.Point(0, 0);
            this.courtPictureBox.Name = "courtPictureBox";
            this.courtPictureBox.Size = new System.Drawing.Size(213, 460);
            this.courtPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.courtPictureBox.TabIndex = 0;
            this.courtPictureBox.TabStop = false;
            this.courtPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.courtPictureBox_Paint);
            this.courtPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CourtMouseClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataframeLabel);
            this.panel2.Location = new System.Drawing.Point(458, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 461);
            this.panel2.TabIndex = 2;
            // 
            // dataframeLabel
            // 
            this.dataframeLabel.AutoSize = true;
            this.dataframeLabel.Location = new System.Drawing.Point(5, 4);
            this.dataframeLabel.Name = "dataframeLabel";
            this.dataframeLabel.Size = new System.Drawing.Size(83, 20);
            this.dataframeLabel.TabIndex = 0;
            this.dataframeLabel.Text = "Dataframe:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.submitButton);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(232, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 609);
            this.panel1.TabIndex = 4;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(5, 577);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(213, 29);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.shotsFlowLayoutPanel);
            this.groupBox4.Location = new System.Drawing.Point(3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(214, 315);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shots";
            // 
            // shotsFlowLayoutPanel
            // 
            this.shotsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shotsFlowLayoutPanel.Controls.Add(this.flatClearButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.highClearButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.fastDropButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.slowDropButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.fullSmashButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.halfSmashButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.farBlockButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.closeBlockButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.farNetButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.closeNetButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.crossNetButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.netSpinButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.pushButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.liftButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.lowServeButton);
            this.shotsFlowLayoutPanel.Controls.Add(this.highServeButton);
            this.shotsFlowLayoutPanel.Location = new System.Drawing.Point(7, 27);
            this.shotsFlowLayoutPanel.Name = "shotsFlowLayoutPanel";
            this.shotsFlowLayoutPanel.Size = new System.Drawing.Size(201, 281);
            this.shotsFlowLayoutPanel.TabIndex = 0;
            // 
            // flatClearButton
            // 
            this.flatClearButton.Location = new System.Drawing.Point(3, 3);
            this.flatClearButton.Name = "flatClearButton";
            this.flatClearButton.Size = new System.Drawing.Size(94, 29);
            this.flatClearButton.TabIndex = 0;
            this.flatClearButton.Text = "Flat Clear";
            this.flatClearButton.UseVisualStyleBackColor = true;
            this.flatClearButton.Click += new System.EventHandler(this.flatClearButton_Click);
            // 
            // highClearButton
            // 
            this.highClearButton.Location = new System.Drawing.Point(103, 3);
            this.highClearButton.Name = "highClearButton";
            this.highClearButton.Size = new System.Drawing.Size(94, 29);
            this.highClearButton.TabIndex = 1;
            this.highClearButton.Text = "High Clear";
            this.highClearButton.UseVisualStyleBackColor = true;
            this.highClearButton.Click += new System.EventHandler(this.highClearButton_Click);
            // 
            // fastDropButton
            // 
            this.fastDropButton.Location = new System.Drawing.Point(3, 38);
            this.fastDropButton.Name = "fastDropButton";
            this.fastDropButton.Size = new System.Drawing.Size(94, 29);
            this.fastDropButton.TabIndex = 2;
            this.fastDropButton.Text = "Fast Drop";
            this.fastDropButton.UseVisualStyleBackColor = true;
            this.fastDropButton.Click += new System.EventHandler(this.fastDropButton_Click);
            // 
            // slowDropButton
            // 
            this.slowDropButton.Location = new System.Drawing.Point(103, 38);
            this.slowDropButton.Name = "slowDropButton";
            this.slowDropButton.Size = new System.Drawing.Size(94, 29);
            this.slowDropButton.TabIndex = 3;
            this.slowDropButton.Text = "Slow Drop";
            this.slowDropButton.UseVisualStyleBackColor = true;
            this.slowDropButton.Click += new System.EventHandler(this.slowDropButton_Click);
            // 
            // fullSmashButton
            // 
            this.fullSmashButton.Location = new System.Drawing.Point(3, 73);
            this.fullSmashButton.Name = "fullSmashButton";
            this.fullSmashButton.Size = new System.Drawing.Size(94, 29);
            this.fullSmashButton.TabIndex = 5;
            this.fullSmashButton.Text = "Full Smash";
            this.fullSmashButton.UseVisualStyleBackColor = true;
            this.fullSmashButton.Click += new System.EventHandler(this.fullSmashButton_Click);
            // 
            // halfSmashButton
            // 
            this.halfSmashButton.Location = new System.Drawing.Point(103, 73);
            this.halfSmashButton.Name = "halfSmashButton";
            this.halfSmashButton.Size = new System.Drawing.Size(94, 29);
            this.halfSmashButton.TabIndex = 4;
            this.halfSmashButton.Text = "Half Smash";
            this.halfSmashButton.UseVisualStyleBackColor = true;
            this.halfSmashButton.Click += new System.EventHandler(this.halfSmashButton_Click);
            // 
            // farBlockButton
            // 
            this.farBlockButton.Location = new System.Drawing.Point(3, 108);
            this.farBlockButton.Name = "farBlockButton";
            this.farBlockButton.Size = new System.Drawing.Size(94, 29);
            this.farBlockButton.TabIndex = 13;
            this.farBlockButton.Text = "Far Block";
            this.farBlockButton.UseVisualStyleBackColor = true;
            this.farBlockButton.Click += new System.EventHandler(this.farBlockButton_Click);
            // 
            // closeBlockButton
            // 
            this.closeBlockButton.Location = new System.Drawing.Point(103, 108);
            this.closeBlockButton.Name = "closeBlockButton";
            this.closeBlockButton.Size = new System.Drawing.Size(94, 29);
            this.closeBlockButton.TabIndex = 12;
            this.closeBlockButton.Text = "Close Block";
            this.closeBlockButton.UseVisualStyleBackColor = true;
            this.closeBlockButton.Click += new System.EventHandler(this.closeBlockButton_Click);
            // 
            // farNetButton
            // 
            this.farNetButton.Location = new System.Drawing.Point(3, 143);
            this.farNetButton.Name = "farNetButton";
            this.farNetButton.Size = new System.Drawing.Size(94, 29);
            this.farNetButton.TabIndex = 7;
            this.farNetButton.Text = "Far Net";
            this.farNetButton.UseVisualStyleBackColor = true;
            this.farNetButton.Click += new System.EventHandler(this.farNetButton_Click);
            // 
            // closeNetButton
            // 
            this.closeNetButton.Location = new System.Drawing.Point(103, 143);
            this.closeNetButton.Name = "closeNetButton";
            this.closeNetButton.Size = new System.Drawing.Size(94, 29);
            this.closeNetButton.TabIndex = 6;
            this.closeNetButton.Text = "Close Net";
            this.closeNetButton.UseVisualStyleBackColor = true;
            this.closeNetButton.Click += new System.EventHandler(this.closeNetButton_Click);
            // 
            // crossNetButton
            // 
            this.crossNetButton.Location = new System.Drawing.Point(3, 178);
            this.crossNetButton.Name = "crossNetButton";
            this.crossNetButton.Size = new System.Drawing.Size(94, 29);
            this.crossNetButton.TabIndex = 9;
            this.crossNetButton.Text = "Cross Net";
            this.crossNetButton.UseVisualStyleBackColor = true;
            this.crossNetButton.Click += new System.EventHandler(this.crossNetButton_Click);
            // 
            // netSpinButton
            // 
            this.netSpinButton.Location = new System.Drawing.Point(103, 178);
            this.netSpinButton.Name = "netSpinButton";
            this.netSpinButton.Size = new System.Drawing.Size(94, 29);
            this.netSpinButton.TabIndex = 8;
            this.netSpinButton.Text = "Net Spin";
            this.netSpinButton.UseVisualStyleBackColor = true;
            this.netSpinButton.Click += new System.EventHandler(this.netSpinButton_Click);
            // 
            // pushButton
            // 
            this.pushButton.Location = new System.Drawing.Point(3, 213);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(94, 29);
            this.pushButton.TabIndex = 11;
            this.pushButton.Text = "Push";
            this.pushButton.UseVisualStyleBackColor = true;
            this.pushButton.Click += new System.EventHandler(this.pushButton_Click);
            // 
            // liftButton
            // 
            this.liftButton.Location = new System.Drawing.Point(103, 213);
            this.liftButton.Name = "liftButton";
            this.liftButton.Size = new System.Drawing.Size(94, 29);
            this.liftButton.TabIndex = 10;
            this.liftButton.Text = "Lift";
            this.liftButton.UseVisualStyleBackColor = true;
            this.liftButton.Click += new System.EventHandler(this.liftButton_Click);
            // 
            // lowServeButton
            // 
            this.lowServeButton.Location = new System.Drawing.Point(3, 248);
            this.lowServeButton.Name = "lowServeButton";
            this.lowServeButton.Size = new System.Drawing.Size(94, 29);
            this.lowServeButton.TabIndex = 14;
            this.lowServeButton.Text = "Low Serve";
            this.lowServeButton.UseVisualStyleBackColor = true;
            this.lowServeButton.Click += new System.EventHandler(this.lowServeButton_Click);
            // 
            // highServeButton
            // 
            this.highServeButton.Location = new System.Drawing.Point(103, 248);
            this.highServeButton.Name = "highServeButton";
            this.highServeButton.Size = new System.Drawing.Size(94, 29);
            this.highServeButton.TabIndex = 15;
            this.highServeButton.Text = "High Serve";
            this.highServeButton.UseVisualStyleBackColor = true;
            this.highServeButton.Click += new System.EventHandler(this.highServeButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.situationFlowLayoutPanel);
            this.groupBox3.Location = new System.Drawing.Point(5, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 137);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Situation";
            // 
            // situationFlowLayoutPanel
            // 
            this.situationFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.situationFlowLayoutPanel.Controls.Add(this.neutralButton);
            this.situationFlowLayoutPanel.Controls.Add(this.attackingButton);
            this.situationFlowLayoutPanel.Controls.Add(this.defendingButton);
            this.situationFlowLayoutPanel.Location = new System.Drawing.Point(6, 27);
            this.situationFlowLayoutPanel.Name = "situationFlowLayoutPanel";
            this.situationFlowLayoutPanel.Size = new System.Drawing.Size(201, 105);
            this.situationFlowLayoutPanel.TabIndex = 0;
            // 
            // neutralButton
            // 
            this.neutralButton.Location = new System.Drawing.Point(3, 3);
            this.neutralButton.Name = "neutralButton";
            this.neutralButton.Size = new System.Drawing.Size(198, 29);
            this.neutralButton.TabIndex = 0;
            this.neutralButton.Text = "Neutral";
            this.neutralButton.UseVisualStyleBackColor = true;
            this.neutralButton.Click += new System.EventHandler(this.neutralButton_Click);
            // 
            // attackingButton
            // 
            this.attackingButton.Location = new System.Drawing.Point(3, 38);
            this.attackingButton.Name = "attackingButton";
            this.attackingButton.Size = new System.Drawing.Size(198, 29);
            this.attackingButton.TabIndex = 1;
            this.attackingButton.Text = "Attacking";
            this.attackingButton.UseVisualStyleBackColor = true;
            this.attackingButton.Click += new System.EventHandler(this.attackingButton_Click);
            // 
            // defendingButton
            // 
            this.defendingButton.Location = new System.Drawing.Point(3, 73);
            this.defendingButton.Name = "defendingButton";
            this.defendingButton.Size = new System.Drawing.Size(198, 29);
            this.defendingButton.TabIndex = 2;
            this.defendingButton.Text = "Defending";
            this.defendingButton.UseVisualStyleBackColor = true;
            this.defendingButton.Click += new System.EventHandler(this.defendingButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.turnFlowLayoutPanel);
            this.groupBox2.Location = new System.Drawing.Point(3, 467);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 104);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Turn";
            // 
            // turnFlowLayoutPanel
            // 
            this.turnFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.turnFlowLayoutPanel.Controls.Add(this.playerButton);
            this.turnFlowLayoutPanel.Controls.Add(this.opponentButton);
            this.turnFlowLayoutPanel.Location = new System.Drawing.Point(7, 27);
            this.turnFlowLayoutPanel.Name = "turnFlowLayoutPanel";
            this.turnFlowLayoutPanel.Size = new System.Drawing.Size(201, 71);
            this.turnFlowLayoutPanel.TabIndex = 0;
            // 
            // playerButton
            // 
            this.playerButton.Location = new System.Drawing.Point(3, 3);
            this.playerButton.Name = "playerButton";
            this.playerButton.Size = new System.Drawing.Size(198, 29);
            this.playerButton.TabIndex = 0;
            this.playerButton.Text = "Player";
            this.playerButton.UseVisualStyleBackColor = true;
            this.playerButton.Click += new System.EventHandler(this.playerButton_Click);
            // 
            // opponentButton
            // 
            this.opponentButton.Location = new System.Drawing.Point(3, 38);
            this.opponentButton.Name = "opponentButton";
            this.opponentButton.Size = new System.Drawing.Size(198, 29);
            this.opponentButton.TabIndex = 1;
            this.opponentButton.Text = "Opponent";
            this.opponentButton.UseVisualStyleBackColor = true;
            this.opponentButton.Click += new System.EventHandler(this.opponentButton_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.winnerGroupBox);
            this.panel3.Controls.Add(this.submitRallyButton);
            this.panel3.Location = new System.Drawing.Point(458, 493);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(555, 141);
            this.panel3.TabIndex = 5;
            // 
            // winnerGroupBox
            // 
            this.winnerGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.winnerGroupBox.Controls.Add(this.opponentWinnerButton);
            this.winnerGroupBox.Controls.Add(this.playerWinnerButton);
            this.winnerGroupBox.Location = new System.Drawing.Point(5, 3);
            this.winnerGroupBox.Name = "winnerGroupBox";
            this.winnerGroupBox.Size = new System.Drawing.Size(549, 101);
            this.winnerGroupBox.TabIndex = 1;
            this.winnerGroupBox.TabStop = false;
            this.winnerGroupBox.Text = "Winner";
            // 
            // opponentWinnerButton
            // 
            this.opponentWinnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.opponentWinnerButton.Location = new System.Drawing.Point(7, 63);
            this.opponentWinnerButton.Name = "opponentWinnerButton";
            this.opponentWinnerButton.Size = new System.Drawing.Size(536, 29);
            this.opponentWinnerButton.TabIndex = 1;
            this.opponentWinnerButton.Text = "Opponent";
            this.opponentWinnerButton.UseVisualStyleBackColor = true;
            this.opponentWinnerButton.Click += new System.EventHandler(this.opponentWinnerButton_Click);
            // 
            // playerWinnerButton
            // 
            this.playerWinnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerWinnerButton.Location = new System.Drawing.Point(7, 27);
            this.playerWinnerButton.Name = "playerWinnerButton";
            this.playerWinnerButton.Size = new System.Drawing.Size(536, 29);
            this.playerWinnerButton.TabIndex = 0;
            this.playerWinnerButton.Text = "Player";
            this.playerWinnerButton.UseVisualStyleBackColor = true;
            this.playerWinnerButton.Click += new System.EventHandler(this.playerWinnerButton_Click);
            // 
            // submitRallyButton
            // 
            this.submitRallyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitRallyButton.Location = new System.Drawing.Point(3, 109);
            this.submitRallyButton.Name = "submitRallyButton";
            this.submitRallyButton.Size = new System.Drawing.Size(550, 29);
            this.submitRallyButton.TabIndex = 0;
            this.submitRallyButton.Text = "Submit Rally";
            this.submitRallyButton.UseVisualStyleBackColor = true;
            this.submitRallyButton.Click += new System.EventHandler(this.submitRallyButton_Click);
            // 
            // analysisWindowButton
            // 
            this.analysisWindowButton.Location = new System.Drawing.Point(11, 27);
            this.analysisWindowButton.Name = "analysisWindowButton";
            this.analysisWindowButton.Size = new System.Drawing.Size(214, 29);
            this.analysisWindowButton.TabIndex = 6;
            this.analysisWindowButton.Text = "Analysis Window";
            this.analysisWindowButton.UseVisualStyleBackColor = true;
            this.analysisWindowButton.Click += new System.EventHandler(this.analysisWindowButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1026, 30);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // fastInputTextBox
            // 
            this.fastInputTextBox.Location = new System.Drawing.Point(14, 529);
            this.fastInputTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fastInputTextBox.Name = "fastInputTextBox";
            this.fastInputTextBox.Size = new System.Drawing.Size(114, 27);
            this.fastInputTextBox.TabIndex = 8;
            this.fastInputTextBox.TextChanged += new System.EventHandler(this.fastInputTextBox_TextChanged);
            this.fastInputTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fastInputTextBox_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 648);
            this.Controls.Add(this.fastInputTextBox);
            this.Controls.Add(this.analysisWindowButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.courtPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Badminton App - Data Input";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.courtPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.endPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courtPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.shotsFlowLayoutPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.situationFlowLayoutPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.turnFlowLayoutPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.winnerGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel courtPanel;
        private System.Windows.Forms.PictureBox courtPictureBox;
        private System.Windows.Forms.PictureBox endPictureBox;
        private System.Windows.Forms.PictureBox startPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label dataframeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button submitRallyButton;
        private System.Windows.Forms.GroupBox winnerGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel turnFlowLayoutPanel;
        private System.Windows.Forms.Button playerButton;
        private System.Windows.Forms.Button opponentButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel situationFlowLayoutPanel;
        private System.Windows.Forms.Button neutralButton;
        private System.Windows.Forms.Button attackingButton;
        private System.Windows.Forms.Button defendingButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel shotsFlowLayoutPanel;
        private System.Windows.Forms.Button flatClearButton;
        private System.Windows.Forms.Button highClearButton;
        private System.Windows.Forms.Button fastDropButton;
        private System.Windows.Forms.Button slowDropButton;
        private System.Windows.Forms.Button halfSmashButton;
        private System.Windows.Forms.Button fullSmashButton;
        private System.Windows.Forms.Button closeNetButton;
        private System.Windows.Forms.Button farNetButton;
        private System.Windows.Forms.Button netSpinButton;
        private System.Windows.Forms.Button crossNetButton;
        private System.Windows.Forms.Button liftButton;
        private System.Windows.Forms.Button pushButton;
        private System.Windows.Forms.Button closeBlockButton;
        private System.Windows.Forms.Button farBlockButton;
        private System.Windows.Forms.Button lowServeButton;
        private System.Windows.Forms.Button highServeButton;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button analysisWindowButton;
        private System.Windows.Forms.Button playerWinnerButton;
        private System.Windows.Forms.Button opponentWinnerButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.TextBox fastInputTextBox;
    }
}

