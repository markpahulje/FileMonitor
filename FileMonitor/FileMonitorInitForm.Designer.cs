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
            this.txtFolder.Location = new System.Drawing.Point(86, 22);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(382, 26);
            this.txtFolder.TabIndex = 0;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(86, 66);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(260, 26);
            this.txtFilter.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(357, 63);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(112, 35);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(278, 277);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(196, 65);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Monitoring";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter:";
            // 
            // IncludeSubdirs
            // 
            this.IncludeSubdirs.AutoSize = true;
            this.IncludeSubdirs.Checked = true;
            this.IncludeSubdirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncludeSubdirs.Location = new System.Drawing.Point(278, 142);
            this.IncludeSubdirs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IncludeSubdirs.Name = "IncludeSubdirs";
            this.IncludeSubdirs.Size = new System.Drawing.Size(193, 24);
            this.IncludeSubdirs.TabIndex = 8;
            this.IncludeSubdirs.Text = "Include Subdirectories";
            this.IncludeSubdirs.UseVisualStyleBackColor = true;
            // 
            // RunAtLogin
            // 
            this.RunAtLogin.AutoSize = true;
            this.RunAtLogin.Checked = true;
            this.RunAtLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RunAtLogin.Location = new System.Drawing.Point(278, 177);
            this.RunAtLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RunAtLogin.Name = "RunAtLogin";
            this.RunAtLogin.Size = new System.Drawing.Size(128, 24);
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
            this.notifyFiltersChecklistBox.Location = new System.Drawing.Point(9, 35);
            this.notifyFiltersChecklistBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.notifyFiltersChecklistBox.Name = "notifyFiltersChecklistBox";
            this.notifyFiltersChecklistBox.Size = new System.Drawing.Size(230, 172);
            this.notifyFiltersChecklistBox.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.notifyFiltersChecklistBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(250, 235);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes To Monitor";
            // 
            // FileMonitorInitForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 352);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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

