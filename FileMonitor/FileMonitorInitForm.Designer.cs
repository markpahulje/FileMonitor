namespace FileMonitor
{
    partial class FileMonitorInitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileMonitorInitForm));
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IncludeSubdirs = new System.Windows.Forms.CheckBox();
            this.RunAtLogin = new System.Windows.Forms.CheckBox();
            this.notifyFiltersChecklistBox = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(57, 14);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(256, 20);
            this.txtFolder.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(57, 43);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(175, 20);
            this.txtFilter.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(238, 41);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(185, 174);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(131, 42);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Monitoring";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter:";
            // 
            // IncludeSubdirs
            // 
            this.IncludeSubdirs.AutoSize = true;
            this.IncludeSubdirs.Checked = true;
            this.IncludeSubdirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncludeSubdirs.Location = new System.Drawing.Point(185, 92);
            this.IncludeSubdirs.Name = "IncludeSubdirs";
            this.IncludeSubdirs.Size = new System.Drawing.Size(131, 17);
            this.IncludeSubdirs.TabIndex = 8;
            this.IncludeSubdirs.Text = "Include Subdirectories";
            this.IncludeSubdirs.UseVisualStyleBackColor = true;
            // 
            // RunAtLogin
            // 
            this.RunAtLogin.AutoSize = true;
            this.RunAtLogin.Checked = true;
            this.RunAtLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunAtLogin.Location = new System.Drawing.Point(185, 115);
            this.RunAtLogin.Name = "RunAtLogin";
            this.RunAtLogin.Size = new System.Drawing.Size(88, 17);
            this.RunAtLogin.TabIndex = 9;
            this.RunAtLogin.Text = "Run At Login";
            this.RunAtLogin.UseVisualStyleBackColor = true;
            // 
            // notifyFiltersChecklistBox
            // 
            this.notifyFiltersChecklistBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyFiltersChecklistBox.FormattingEnabled = true;
            this.notifyFiltersChecklistBox.Location = new System.Drawing.Point(6, 23);
            this.notifyFiltersChecklistBox.Name = "notifyFiltersChecklistBox";
            this.notifyFiltersChecklistBox.Size = new System.Drawing.Size(155, 124);
            this.notifyFiltersChecklistBox.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.notifyFiltersChecklistBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 153);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes To Monitor";
            // 
            // FileMonitorInitForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 229);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RunAtLogin);
            this.Controls.Add(this.IncludeSubdirs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.txtFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FileMonitorInitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileMonitor";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox IncludeSubdirs;
        private System.Windows.Forms.CheckBox RunAtLogin;
        private System.Windows.Forms.CheckedListBox notifyFiltersChecklistBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

