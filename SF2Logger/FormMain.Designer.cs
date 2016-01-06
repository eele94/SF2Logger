namespace SF2Logger
{
    partial class FormMain
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.listViewLogs = new System.Windows.Forms.ListView();
            this.columnHeaderIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLenReal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSub = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlSide = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonReplay = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.tabPageFilter = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelFilterExplanation = new System.Windows.Forms.Label();
            this.tabPagePlaintext = new System.Windows.Forms.TabPage();
            this.textBoxPlainText = new System.Windows.Forms.TextBox();
            this.buttonSaveBinary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlSide.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabPageFilter.SuspendLayout();
            this.tabPagePlaintext.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.listViewLogs);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlSide);
            this.splitContainerMain.Size = new System.Drawing.Size(1264, 681);
            this.splitContainerMain.SplitterDistance = 832;
            this.splitContainerMain.TabIndex = 0;
            // 
            // listViewLogs
            // 
            this.listViewLogs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIP,
            this.columnHeaderLen,
            this.columnHeaderLenReal,
            this.columnHeaderID,
            this.columnHeaderSub,
            this.columnHeaderData});
            this.listViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLogs.FullRowSelect = true;
            this.listViewLogs.GridLines = true;
            this.listViewLogs.Location = new System.Drawing.Point(0, 0);
            this.listViewLogs.MultiSelect = false;
            this.listViewLogs.Name = "listViewLogs";
            this.listViewLogs.Size = new System.Drawing.Size(832, 681);
            this.listViewLogs.TabIndex = 0;
            this.listViewLogs.UseCompatibleStateImageBehavior = false;
            this.listViewLogs.View = System.Windows.Forms.View.Details;
            this.listViewLogs.SelectedIndexChanged += new System.EventHandler(this.listViewLogs_SelectedIndexChanged);
            // 
            // columnHeaderIP
            // 
            this.columnHeaderIP.Text = "IP";
            this.columnHeaderIP.Width = 137;
            // 
            // columnHeaderLen
            // 
            this.columnHeaderLen.Text = "Len";
            // 
            // columnHeaderLenReal
            // 
            this.columnHeaderLenReal.Text = "Len Real";
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "ID";
            // 
            // columnHeaderSub
            // 
            this.columnHeaderSub.Text = "Sub";
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.Text = "Data";
            this.columnHeaderData.Width = 511;
            // 
            // tabControlSide
            // 
            this.tabControlSide.Controls.Add(this.tabPageInfo);
            this.tabControlSide.Controls.Add(this.tabPageFilter);
            this.tabControlSide.Controls.Add(this.tabPagePlaintext);
            this.tabControlSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSide.Location = new System.Drawing.Point(0, 0);
            this.tabControlSide.Name = "tabControlSide";
            this.tabControlSide.SelectedIndex = 0;
            this.tabControlSide.Size = new System.Drawing.Size(428, 681);
            this.tabControlSide.TabIndex = 0;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.buttonSaveBinary);
            this.tabPageInfo.Controls.Add(this.buttonFilter);
            this.tabPageInfo.Controls.Add(this.buttonReplay);
            this.tabPageInfo.Controls.Add(this.textBoxInfo);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(420, 655);
            this.tabPageInfo.TabIndex = 0;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonFilter.Location = new System.Drawing.Point(3, 606);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(414, 23);
            this.buttonFilter.TabIndex = 2;
            this.buttonFilter.Text = "Filter Packet";
            this.buttonFilter.UseVisualStyleBackColor = true;
            // 
            // buttonReplay
            // 
            this.buttonReplay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonReplay.Location = new System.Drawing.Point(3, 629);
            this.buttonReplay.Name = "buttonReplay";
            this.buttonReplay.Size = new System.Drawing.Size(414, 23);
            this.buttonReplay.TabIndex = 1;
            this.buttonReplay.Text = "Replay Packet";
            this.buttonReplay.UseVisualStyleBackColor = true;
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInfo.Location = new System.Drawing.Point(3, 3);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(414, 649);
            this.textBoxInfo.TabIndex = 0;
            this.textBoxInfo.Click += new System.EventHandler(this.textBoxInfo_Click);
            // 
            // tabPageFilter
            // 
            this.tabPageFilter.Controls.Add(this.textBox1);
            this.tabPageFilter.Controls.Add(this.labelFilterExplanation);
            this.tabPageFilter.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilter.Name = "tabPageFilter";
            this.tabPageFilter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilter.Size = new System.Drawing.Size(420, 655);
            this.tabPageFilter.TabIndex = 1;
            this.tabPageFilter.Text = "Filter";
            this.tabPageFilter.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(414, 636);
            this.textBox1.TabIndex = 1;
            // 
            // labelFilterExplanation
            // 
            this.labelFilterExplanation.AutoSize = true;
            this.labelFilterExplanation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFilterExplanation.Location = new System.Drawing.Point(3, 3);
            this.labelFilterExplanation.Name = "labelFilterExplanation";
            this.labelFilterExplanation.Size = new System.Drawing.Size(295, 13);
            this.labelFilterExplanation.TabIndex = 0;
            this.labelFilterExplanation.Text = "Blocks packets based on ID & Sub.  Seperate with ( , ) comma";
            // 
            // tabPagePlaintext
            // 
            this.tabPagePlaintext.Controls.Add(this.textBoxPlainText);
            this.tabPagePlaintext.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlaintext.Name = "tabPagePlaintext";
            this.tabPagePlaintext.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlaintext.Size = new System.Drawing.Size(420, 655);
            this.tabPagePlaintext.TabIndex = 2;
            this.tabPagePlaintext.Text = "Plaintext";
            this.tabPagePlaintext.UseVisualStyleBackColor = true;
            // 
            // textBoxPlainText
            // 
            this.textBoxPlainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPlainText.Location = new System.Drawing.Point(3, 3);
            this.textBoxPlainText.Multiline = true;
            this.textBoxPlainText.Name = "textBoxPlainText";
            this.textBoxPlainText.Size = new System.Drawing.Size(414, 649);
            this.textBoxPlainText.TabIndex = 0;
            // 
            // buttonSaveBinary
            // 
            this.buttonSaveBinary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSaveBinary.Location = new System.Drawing.Point(3, 583);
            this.buttonSaveBinary.Name = "buttonSaveBinary";
            this.buttonSaveBinary.Size = new System.Drawing.Size(414, 23);
            this.buttonSaveBinary.TabIndex = 3;
            this.buttonSaveBinary.Text = "Save Binary";
            this.buttonSaveBinary.UseVisualStyleBackColor = true;
            this.buttonSaveBinary.Click += new System.EventHandler(this.buttonSaveBinary_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Logger";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlSide.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.tabPageFilter.ResumeLayout(false);
            this.tabPageFilter.PerformLayout();
            this.tabPagePlaintext.ResumeLayout(false);
            this.tabPagePlaintext.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ColumnHeader columnHeaderIP;
        private System.Windows.Forms.ColumnHeader columnHeaderLen;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderSub;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
        private System.Windows.Forms.TabControl tabControlSide;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TabPage tabPageFilter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelFilterExplanation;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonReplay;
        public System.Windows.Forms.TextBox textBoxInfo;
        public System.Windows.Forms.ListView listViewLogs;
        private System.Windows.Forms.ColumnHeader columnHeaderLenReal;
        private System.Windows.Forms.TabPage tabPagePlaintext;
        private System.Windows.Forms.TextBox textBoxPlainText;
        private System.Windows.Forms.Button buttonSaveBinary;
    }
}

