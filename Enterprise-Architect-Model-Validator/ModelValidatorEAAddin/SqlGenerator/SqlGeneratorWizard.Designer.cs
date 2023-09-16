namespace EA_Addin_Model_Validator.SqlGenerator
{
    partial class SqlGeneratorWizard
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
            this.lbFilename = new System.Windows.Forms.Label();
            this.tbQueryName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOCL = new System.Windows.Forms.TabPage();
            this.tbOCL = new System.Windows.Forms.TextBox();
            this.tabSQL = new System.Windows.Forms.TabPage();
            this.tbSQL = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnCopySQL = new System.Windows.Forms.Button();
            this.lbpimguid = new System.Windows.Forms.Label();
            this.lbddlguid = new System.Windows.Forms.Label();
            this.tbpimguid = new System.Windows.Forms.TextBox();
            this.tbddlguid = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabOCL.SuspendLayout();
            this.tabSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbFilename
            // 
            this.lbFilename.AutoSize = true;
            this.lbFilename.Location = new System.Drawing.Point(20, 20);
            this.lbFilename.Name = "lbFilename";
            this.lbFilename.Size = new System.Drawing.Size(79, 13);
            this.lbFilename.TabIndex = 0;
            this.lbFilename.Text = "Name of query:";
            // 
            // tbQueryName
            // 
            this.tbQueryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQueryName.Location = new System.Drawing.Point(150, 20);
            this.tbQueryName.Name = "tbQueryName";
            this.tbQueryName.Size = new System.Drawing.Size(400, 20);
            this.tbQueryName.TabIndex = 1;
            this.tbQueryName.Text = "versionCheck";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSize = true;
            this.btnSave.Location = new System.Drawing.Point(24, 520);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save As...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabOCL);
            this.tabControl.Controls.Add(this.tabSQL);
            this.tabControl.Location = new System.Drawing.Point(20, 110);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(540, 360);
            this.tabControl.TabIndex = 5;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Selecting);
            // 
            // tabOCL
            // 
            this.tabOCL.Controls.Add(this.tbOCL);
            this.tabOCL.Location = new System.Drawing.Point(4, 22);
            this.tabOCL.Name = "tabOCL";
            this.tabOCL.Padding = new System.Windows.Forms.Padding(3);
            this.tabOCL.Size = new System.Drawing.Size(532, 334);
            this.tabOCL.TabIndex = 0;
            this.tabOCL.Text = "[OCL]";
            this.tabOCL.UseVisualStyleBackColor = true;
            // 
            // tbOCL
            // 
            this.tbOCL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOCL.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.tbOCL.Location = new System.Drawing.Point(0, 0);
            this.tbOCL.Multiline = true;
            this.tbOCL.Name = "tbOCL";
            this.tbOCL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOCL.Size = new System.Drawing.Size(532, 334);
            this.tbOCL.TabIndex = 1;
            this.tbOCL.TabStop = false;
            this.tbOCL.Text = "context Requirement inv: Version = 2.0\r\n";
            // 
            // tabSQL
            // 
            this.tabSQL.Controls.Add(this.tbSQL);
            this.tabSQL.Location = new System.Drawing.Point(4, 22);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQL.Size = new System.Drawing.Size(532, 374);
            this.tabSQL.TabIndex = 1;
            this.tabSQL.Text = "[SQL]";
            this.tabSQL.UseVisualStyleBackColor = true;
            // 
            // tbSQL
            // 
            this.tbSQL.AcceptsReturn = true;
            this.tbSQL.AcceptsTab = true;
            this.tbSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSQL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSQL.Location = new System.Drawing.Point(0, 0);
            this.tbSQL.Multiline = true;
            this.tbSQL.Name = "tbSQL";
            this.tbSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSQL.Size = new System.Drawing.Size(532, 374);
            this.tbSQL.TabIndex = 1;
            this.tbSQL.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(481, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTranslate.AutoSize = true;
            this.btnTranslate.Location = new System.Drawing.Point(248, 497);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(75, 23);
            this.btnTranslate.TabIndex = 7;
            this.btnTranslate.Text = "Translate >";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // btnCopySQL
            // 
            this.btnCopySQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopySQL.AutoSize = true;
            this.btnCopySQL.Enabled = false;
            this.btnCopySQL.Location = new System.Drawing.Point(105, 520);
            this.btnCopySQL.Name = "btnCopySQL";
            this.btnCopySQL.Size = new System.Drawing.Size(75, 23);
            this.btnCopySQL.TabIndex = 8;
            this.btnCopySQL.Text = "Copy SQL";
            this.btnCopySQL.UseVisualStyleBackColor = true;
            this.btnCopySQL.Click += new System.EventHandler(this.btnCopySQL_Click);
            // 
            // lbpimguid
            // 
            this.lbpimguid.AutoSize = true;
            this.lbpimguid.Location = new System.Drawing.Point(20, 50);
            this.lbpimguid.Name = "lbpimguid";
            this.lbpimguid.Size = new System.Drawing.Size(117, 13);
            this.lbpimguid.TabIndex = 2;
            this.lbpimguid.Text = "GUID of PIM Package:";
            // 
            // lbddlguid
            // 
            this.lbddlguid.AutoSize = true;
            this.lbddlguid.Location = new System.Drawing.Point(20, 80);
            this.lbddlguid.Name = "lbddlguid";
            this.lbddlguid.Size = new System.Drawing.Size(120, 13);
            this.lbddlguid.TabIndex = 3;
            this.lbddlguid.Text = "GUID of DDL Package:";
            // 
            // tbpimguid
            // 
            this.tbpimguid.Location = new System.Drawing.Point(150, 50);
            this.tbpimguid.Name = "tbpimguid";
            this.tbpimguid.Size = new System.Drawing.Size(400, 20);
            this.tbpimguid.TabIndex = 4;
            this.tbpimguid.Text = "(optional)";
            // 
            // tbddlguid
            // 
            this.tbddlguid.Location = new System.Drawing.Point(150, 80);
            this.tbddlguid.Name = "tbddlguid";
            this.tbddlguid.Size = new System.Drawing.Size(400, 20);
            this.tbddlguid.TabIndex = 5;
            this.tbddlguid.Text = "(optional)";
            // 
            // SqlGeneratorWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.lbpimguid);
            this.Controls.Add(this.tbpimguid);
            this.Controls.Add(this.lbddlguid);
            this.Controls.Add(this.tbddlguid);
            this.Controls.Add(this.btnCopySQL);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbQueryName);
            this.Controls.Add(this.lbFilename);
            this.Name = "SqlGeneratorWizard";
            this.Text = "SqlGeneratorWizard";
            this.tabControl.ResumeLayout(false);
            this.tabOCL.ResumeLayout(false);
            this.tabOCL.PerformLayout();
            this.tabSQL.ResumeLayout(false);
            this.tabSQL.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFilename;
        private System.Windows.Forms.TextBox tbQueryName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOCL;
        private System.Windows.Forms.TabPage tabSQL;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbOCL;
        private System.Windows.Forms.TextBox tbSQL;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnCopySQL;
        private System.Windows.Forms.Label lbpimguid;
        private System.Windows.Forms.Label lbddlguid;
        private System.Windows.Forms.TextBox tbpimguid;
        private System.Windows.Forms.TextBox tbddlguid;
    }
}