namespace GDALViewer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.tabControlImage = new System.Windows.Forms.TabControl();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelDisplayMode = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxDisplayMode = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelR = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxR = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelG = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxG = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelB = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxB = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxSingle = new System.Windows.Forms.ToolStripComboBox();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonNC2Tiff = new System.Windows.Forms.Button();
            this.buttonSpeedTest = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.tabControlImage.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.LightCyan;
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 31);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(736, 450);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // tabControlImage
            // 
            this.tabControlImage.Controls.Add(this.tabPageInfo);
            this.tabControlImage.Controls.Add(this.tabPageImage);
            this.tabControlImage.Controls.Add(this.tabPage1);
            this.tabControlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlImage.Location = new System.Drawing.Point(0, 27);
            this.tabControlImage.Name = "tabControlImage";
            this.tabControlImage.SelectedIndex = 0;
            this.tabControlImage.Size = new System.Drawing.Size(750, 513);
            this.tabControlImage.TabIndex = 1;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.pictureBoxImage);
            this.tabPageImage.Controls.Add(this.toolStrip2);
            this.tabPageImage.Location = new System.Drawing.Point(4, 25);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(742, 484);
            this.tabPageImage.TabIndex = 0;
            this.tabPageImage.Text = "Image";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripSeparator2,
            this.toolStripLabelDisplayMode,
            this.toolStripComboBoxDisplayMode,
            this.toolStripSeparator1,
            this.toolStripLabelR,
            this.toolStripComboBoxR,
            this.toolStripLabelG,
            this.toolStripComboBoxG,
            this.toolStripLabelB,
            this.toolStripComboBoxB,
            this.toolStripComboBoxSingle});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(736, 28);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabelDisplayMode
            // 
            this.toolStripLabelDisplayMode.Name = "toolStripLabelDisplayMode";
            this.toolStripLabelDisplayMode.Size = new System.Drawing.Size(105, 25);
            this.toolStripLabelDisplayMode.Text = "DisplayMode";
            // 
            // toolStripComboBoxDisplayMode
            // 
            this.toolStripComboBoxDisplayMode.Name = "toolStripComboBoxDisplayMode";
            this.toolStripComboBoxDisplayMode.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBoxDisplayMode.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxDisplayMode_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabelR
            // 
            this.toolStripLabelR.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabelR.Name = "toolStripLabelR";
            this.toolStripLabelR.Size = new System.Drawing.Size(19, 25);
            this.toolStripLabelR.Text = "R";
            // 
            // toolStripComboBoxR
            // 
            this.toolStripComboBoxR.DropDownWidth = 50;
            this.toolStripComboBoxR.Name = "toolStripComboBoxR";
            this.toolStripComboBoxR.Size = new System.Drawing.Size(75, 28);
            // 
            // toolStripLabelG
            // 
            this.toolStripLabelG.ForeColor = System.Drawing.Color.LimeGreen;
            this.toolStripLabelG.Name = "toolStripLabelG";
            this.toolStripLabelG.Size = new System.Drawing.Size(20, 25);
            this.toolStripLabelG.Text = "G";
            // 
            // toolStripComboBoxG
            // 
            this.toolStripComboBoxG.Name = "toolStripComboBoxG";
            this.toolStripComboBoxG.Size = new System.Drawing.Size(75, 28);
            // 
            // toolStripLabelB
            // 
            this.toolStripLabelB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.toolStripLabelB.Name = "toolStripLabelB";
            this.toolStripLabelB.Size = new System.Drawing.Size(18, 25);
            this.toolStripLabelB.Text = "B";
            // 
            // toolStripComboBoxB
            // 
            this.toolStripComboBoxB.Name = "toolStripComboBoxB";
            this.toolStripComboBoxB.Size = new System.Drawing.Size(75, 28);
            // 
            // toolStripComboBoxSingle
            // 
            this.toolStripComboBoxSingle.Name = "toolStripComboBoxSingle";
            this.toolStripComboBoxSingle.Size = new System.Drawing.Size(75, 28);
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.richTextBoxInfo);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(742, 484);
            this.tabPageInfo.TabIndex = 1;
            this.tabPageInfo.Text = "Infos";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.BackColor = System.Drawing.Color.White;
            this.richTextBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxInfo.Font = new System.Drawing.Font("华文细黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxInfo.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ReadOnly = true;
            this.richTextBoxInfo.Size = new System.Drawing.Size(736, 478);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonNC2Tiff);
            this.tabPage1.Controls.Add(this.buttonSpeedTest);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(742, 484);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Tools";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonNC2Tiff
            // 
            this.buttonNC2Tiff.Location = new System.Drawing.Point(8, 18);
            this.buttonNC2Tiff.Name = "buttonNC2Tiff";
            this.buttonNC2Tiff.Size = new System.Drawing.Size(192, 46);
            this.buttonNC2Tiff.TabIndex = 3;
            this.buttonNC2Tiff.Text = "NetCDF->时序Tiff";
            this.buttonNC2Tiff.UseVisualStyleBackColor = true;
            this.buttonNC2Tiff.Click += new System.EventHandler(this.buttonNC2Tiff_Click);
            // 
            // buttonSpeedTest
            // 
            this.buttonSpeedTest.Location = new System.Drawing.Point(8, 100);
            this.buttonSpeedTest.Name = "buttonSpeedTest";
            this.buttonSpeedTest.Size = new System.Drawing.Size(192, 46);
            this.buttonSpeedTest.TabIndex = 2;
            this.buttonSpeedTest.Text = "文件访问速度测试";
            this.buttonSpeedTest.UseVisualStyleBackColor = true;
            this.buttonSpeedTest.Click += new System.EventHandler(this.buttonSpeedTest_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(750, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonFile
            // 
            this.toolStripDropDownButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpen,
            this.ToolStripMenuItemClose});
            this.toolStripDropDownButtonFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonFile.Image")));
            this.toolStripDropDownButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonFile.Name = "toolStripDropDownButtonFile";
            this.toolStripDropDownButtonFile.Size = new System.Drawing.Size(48, 24);
            this.toolStripDropDownButtonFile.Text = "File";
            // 
            // ToolStripMenuItemOpen
            // 
            this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
            this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(136, 26);
            this.ToolStripMenuItemOpen.Text = "Open...";
            this.ToolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // ToolStripMenuItemClose
            // 
            this.ToolStripMenuItemClose.Name = "ToolStripMenuItemClose";
            this.ToolStripMenuItemClose.Size = new System.Drawing.Size(136, 26);
            this.ToolStripMenuItemClose.Text = "Close";
            this.ToolStripMenuItemClose.Click += new System.EventHandler(this.ToolStripMenuItemClose_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(750, 25);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(137, 20);
            this.toolStripStatusLabel.Text = "                                ";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(68, 25);
            this.toolStripButtonRefresh.Text = "Refresh";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 565);
            this.Controls.Add(this.tabControlImage);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Title";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.tabControlImage.ResumeLayout(false);
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPageInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TabControl tabControlImage;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClose;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelDisplayMode;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxDisplayMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelR;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxR;
        private System.Windows.Forms.ToolStripLabel toolStripLabelG;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxG;
        private System.Windows.Forms.ToolStripLabel toolStripLabelB;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxB;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSingle;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonSpeedTest;
        private System.Windows.Forms.Button buttonNC2Tiff;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

