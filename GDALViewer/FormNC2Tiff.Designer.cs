namespace GDALViewer
{
    partial class FormNC2Tiff
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNCPath = new System.Windows.Forms.TextBox();
            this.buttonNCPath = new System.Windows.Forms.Button();
            this.buttonTiffOutputPath = new System.Windows.Forms.Button();
            this.textBoxTiffOutputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.checkBoxStartTime = new System.Windows.Forms.CheckBox();
            this.comboBoxUnit = new System.Windows.Forms.ComboBox();
            this.labelUnit = new System.Windows.Forms.Label();
            this.groupboxGeoTransform = new System.Windows.Forms.GroupBox();
            this.checkboxGeoTransform = new System.Windows.Forms.CheckBox();
            this.textBoxTop = new System.Windows.Forms.TextBox();
            this.textBoxBottom = new System.Windows.Forms.TextBox();
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.groupboxGeoTransform.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "nc文件路径";
            // 
            // textBoxNCPath
            // 
            this.textBoxNCPath.Location = new System.Drawing.Point(12, 48);
            this.textBoxNCPath.Name = "textBoxNCPath";
            this.textBoxNCPath.Size = new System.Drawing.Size(533, 25);
            this.textBoxNCPath.TabIndex = 1;
            // 
            // buttonNCPath
            // 
            this.buttonNCPath.Location = new System.Drawing.Point(562, 50);
            this.buttonNCPath.Name = "buttonNCPath";
            this.buttonNCPath.Size = new System.Drawing.Size(41, 23);
            this.buttonNCPath.TabIndex = 2;
            this.buttonNCPath.Text = "...";
            this.buttonNCPath.UseVisualStyleBackColor = true;
            this.buttonNCPath.Click += new System.EventHandler(this.buttonNCPath_Click);
            // 
            // buttonTiffOutputPath
            // 
            this.buttonTiffOutputPath.Location = new System.Drawing.Point(562, 107);
            this.buttonTiffOutputPath.Name = "buttonTiffOutputPath";
            this.buttonTiffOutputPath.Size = new System.Drawing.Size(41, 23);
            this.buttonTiffOutputPath.TabIndex = 5;
            this.buttonTiffOutputPath.Text = "...";
            this.buttonTiffOutputPath.UseVisualStyleBackColor = true;
            this.buttonTiffOutputPath.Click += new System.EventHandler(this.buttonTiffOutputPath_Click);
            // 
            // textBoxTiffOutputPath
            // 
            this.textBoxTiffOutputPath.Location = new System.Drawing.Point(15, 105);
            this.textBoxTiffOutputPath.Name = "textBoxTiffOutputPath";
            this.textBoxTiffOutputPath.Size = new System.Drawing.Size(530, 25);
            this.textBoxTiffOutputPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "tiff输出目录";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(413, 420);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(86, 33);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(520, 420);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 33);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "起始日期";
            this.toolTip1.SetToolTip(this.label3, "查看信息里的Metadata中的time#units标签内容来设置\r\n起始时间，每个nc文件定义不同，需要自行解译。");
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(15, 159);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(207, 25);
            this.dateTimePickerDate.TabIndex = 10;
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(382, 159);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(163, 25);
            this.dateTimePickerTime.TabIndex = 12;
            // 
            // checkBoxStartTime
            // 
            this.checkBoxStartTime.AutoSize = true;
            this.checkBoxStartTime.Location = new System.Drawing.Point(258, 165);
            this.checkBoxStartTime.Name = "checkBoxStartTime";
            this.checkBoxStartTime.Size = new System.Drawing.Size(89, 19);
            this.checkBoxStartTime.TabIndex = 13;
            this.checkBoxStartTime.Text = "起始时刻";
            this.checkBoxStartTime.UseVisualStyleBackColor = true;
            this.checkBoxStartTime.CheckedChanged += new System.EventHandler(this.checkBoxStartTime_CheckedChanged);
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.Items.AddRange(new object[] {
            "年",
            "月",
            "日",
            "时",
            "分",
            "秒"});
            this.comboBoxUnit.Location = new System.Drawing.Point(129, 204);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(93, 23);
            this.comboBoxUnit.TabIndex = 14;
            // 
            // labelUnit
            // 
            this.labelUnit.AutoSize = true;
            this.labelUnit.Location = new System.Drawing.Point(12, 207);
            this.labelUnit.Name = "labelUnit";
            this.labelUnit.Size = new System.Drawing.Size(97, 15);
            this.labelUnit.TabIndex = 15;
            this.labelUnit.Text = "时间计算单位";
            // 
            // groupboxGeoTransform
            // 
            this.groupboxGeoTransform.Controls.Add(this.textBoxRight);
            this.groupboxGeoTransform.Controls.Add(this.textBoxLeft);
            this.groupboxGeoTransform.Controls.Add(this.textBoxBottom);
            this.groupboxGeoTransform.Controls.Add(this.textBoxTop);
            this.groupboxGeoTransform.Location = new System.Drawing.Point(15, 243);
            this.groupboxGeoTransform.Name = "groupboxGeoTransform";
            this.groupboxGeoTransform.Size = new System.Drawing.Size(588, 162);
            this.groupboxGeoTransform.TabIndex = 16;
            this.groupboxGeoTransform.TabStop = false;
            // 
            // checkboxGeoTransform
            // 
            this.checkboxGeoTransform.AutoSize = true;
            this.checkboxGeoTransform.Location = new System.Drawing.Point(21, 230);
            this.checkboxGeoTransform.Name = "checkboxGeoTransform";
            this.checkboxGeoTransform.Size = new System.Drawing.Size(119, 19);
            this.checkboxGeoTransform.TabIndex = 0;
            this.checkboxGeoTransform.Text = "重设地理范围";
            this.toolTip1.SetToolTip(this.checkboxGeoTransform, "NetCDF文件大部分没有地理范围，而是在\r\n和标签中定义，定义格式不相同，需要自行解译。");
            this.checkboxGeoTransform.UseVisualStyleBackColor = true;
            this.checkboxGeoTransform.CheckedChanged += new System.EventHandler(this.checkboxGeoTransform_CheckedChanged);
            // 
            // textBoxTop
            // 
            this.textBoxTop.Location = new System.Drawing.Point(222, 24);
            this.textBoxTop.Name = "textBoxTop";
            this.textBoxTop.Size = new System.Drawing.Size(161, 25);
            this.textBoxTop.TabIndex = 1;
            // 
            // textBoxBottom
            // 
            this.textBoxBottom.Location = new System.Drawing.Point(222, 122);
            this.textBoxBottom.Name = "textBoxBottom";
            this.textBoxBottom.Size = new System.Drawing.Size(161, 25);
            this.textBoxBottom.TabIndex = 2;
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Location = new System.Drawing.Point(6, 73);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(161, 25);
            this.textBoxLeft.TabIndex = 3;
            // 
            // textBoxRight
            // 
            this.textBoxRight.Location = new System.Drawing.Point(421, 73);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(161, 25);
            this.textBoxRight.TabIndex = 4;
            // 
            // FormNC2Tiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 465);
            this.Controls.Add(this.checkboxGeoTransform);
            this.Controls.Add(this.groupboxGeoTransform);
            this.Controls.Add(this.labelUnit);
            this.Controls.Add(this.comboBoxUnit);
            this.Controls.Add(this.checkBoxStartTime);
            this.Controls.Add(this.dateTimePickerTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerDate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonTiffOutputPath);
            this.Controls.Add(this.textBoxTiffOutputPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonNCPath);
            this.Controls.Add(this.textBoxNCPath);
            this.Controls.Add(this.label1);
            this.Name = "FormNC2Tiff";
            this.Text = "NetCDF转时序Tiff";
            this.groupboxGeoTransform.ResumeLayout(false);
            this.groupboxGeoTransform.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNCPath;
        private System.Windows.Forms.Button buttonNCPath;
        private System.Windows.Forms.Button buttonTiffOutputPath;
        private System.Windows.Forms.TextBox textBoxTiffOutputPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private System.Windows.Forms.CheckBox checkBoxStartTime;
        private System.Windows.Forms.ComboBox comboBoxUnit;
        private System.Windows.Forms.Label labelUnit;
        private System.Windows.Forms.GroupBox groupboxGeoTransform;
        private System.Windows.Forms.CheckBox checkboxGeoTransform;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxBottom;
        private System.Windows.Forms.TextBox textBoxTop;
    }
}