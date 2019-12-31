namespace TiffViewer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxDisplayMode = new System.Windows.Forms.ToolStripComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabelR = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxR = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelG = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxG = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelB = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxB = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxSingle = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightCyan;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 503);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageImage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 538);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.toolStrip2);
            this.tabPageImage.Controls.Add(this.pictureBox1);
            this.tabPageImage.Location = new System.Drawing.Point(4, 25);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(742, 509);
            this.tabPageImage.TabIndex = 0;
            this.tabPageImage.Text = "Image";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxDisplayMode,
            this.toolStripSeparator1,
            this.toolStripLabelR,
            this.toolStripComboBoxR,
            this.toolStripLabelG,
            this.toolStripComboBoxG,
            this.toolStripLabelB,
            this.toolStripComboBoxB,
            this.toolStripComboBoxSingle});
            this.toolStrip2.Location = new System.Drawing.Point(3, 478);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(736, 28);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 25);
            this.toolStripLabel1.Text = "显示模式";
            // 
            // toolStripComboBoxDisplayMode
            // 
            this.toolStripComboBoxDisplayMode.Items.AddRange(new object[] {
            "原始样式",
            "波段合成",
            "单波段"});
            this.toolStripComboBoxDisplayMode.Name = "toolStripComboBoxDisplayMode";
            this.toolStripComboBoxDisplayMode.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBoxDisplayMode.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxDisplayMode_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Infos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(736, 503);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(750, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpen,
            this.ToolStripMenuItemClose});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(53, 24);
            this.toolStripDropDownButton1.Text = "文件";
            // 
            // ToolStripMenuItemOpen
            // 
            this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
            this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(126, 26);
            this.ToolStripMenuItemOpen.Text = "打开...";
            this.ToolStripMenuItemOpen.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemClose
            // 
            this.ToolStripMenuItemClose.Name = "ToolStripMenuItemClose";
            this.ToolStripMenuItemClose.Size = new System.Drawing.Size(126, 26);
            this.ToolStripMenuItemClose.Text = "关闭";
            this.ToolStripMenuItemClose.Click += new System.EventHandler(this.ToolStripMenuItemClose_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripComboBoxSingle
            // 
            this.toolStripComboBoxSingle.Name = "toolStripComboBoxSingle";
            this.toolStripComboBoxSingle.Size = new System.Drawing.Size(75, 28);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "GDAL影像查看工具 v0.2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClose;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxDisplayMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelR;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxR;
        private System.Windows.Forms.ToolStripLabel toolStripLabelG;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxG;
        private System.Windows.Forms.ToolStripLabel toolStripLabelB;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxB;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSingle;
    }
}

