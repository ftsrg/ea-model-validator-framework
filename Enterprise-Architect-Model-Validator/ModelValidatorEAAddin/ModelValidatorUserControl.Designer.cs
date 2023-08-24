namespace ModelValidatorEAAddin
{
    partial class ModelValidatorUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_find_guid = new System.Windows.Forms.Button();
            this.bt_help = new System.Windows.Forms.Button();
            this.gbGeneral = new System.Windows.Forms.GroupBox();
            this.gbValidator = new System.Windows.Forms.GroupBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.cbExporter = new System.Windows.Forms.ComboBox();
            this.lblExporter = new System.Windows.Forms.Label();
            this.lblQueryCollection = new System.Windows.Forms.Label();
            this.cbQueryCollection = new System.Windows.Forms.ComboBox();
            this.gbGeneral.SuspendLayout();
            this.gbValidator.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_find_guid
            // 
            this.bt_find_guid.Location = new System.Drawing.Point(20, 30);
            this.bt_find_guid.Name = "bt_find_guid";
            this.bt_find_guid.Size = new System.Drawing.Size(75, 23);
            this.bt_find_guid.TabIndex = 0;
            this.bt_find_guid.Text = "Find GUID";
            this.bt_find_guid.UseVisualStyleBackColor = true;
            this.bt_find_guid.Click += new System.EventHandler(this.bt_find_guid_Click);
            // 
            // bt_help
            // 
            this.bt_help.Location = new System.Drawing.Point(20, 60);
            this.bt_help.Name = "bt_help";
            this.bt_help.Size = new System.Drawing.Size(75, 23);
            this.bt_help.TabIndex = 1;
            this.bt_help.Text = "Help";
            this.bt_help.UseVisualStyleBackColor = true;
            this.bt_help.Click += new System.EventHandler(this.bt_help_Click);
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.bt_help);
            this.gbGeneral.Controls.Add(this.bt_find_guid);
            this.gbGeneral.Location = new System.Drawing.Point(20, 20);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(120, 100);
            this.gbGeneral.TabIndex = 3;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // gbValidator
            // 
            this.gbValidator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbValidator.Controls.Add(this.btnValidate);
            this.gbValidator.Controls.Add(this.cbExporter);
            this.gbValidator.Controls.Add(this.lblExporter);
            this.gbValidator.Controls.Add(this.lblQueryCollection);
            this.gbValidator.Controls.Add(this.cbQueryCollection);
            this.gbValidator.Location = new System.Drawing.Point(160, 20);
            this.gbValidator.Name = "gbValidator";
            this.gbValidator.Size = new System.Drawing.Size(170, 210);
            this.gbValidator.TabIndex = 4;
            this.gbValidator.TabStop = false;
            this.gbValidator.Text = "Validator";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(20, 170);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // cbExporter
            // 
            this.cbExporter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExporter.FormattingEnabled = true;
            this.cbExporter.Location = new System.Drawing.Point(20, 130);
            this.cbExporter.Name = "cbExporter";
            this.cbExporter.Size = new System.Drawing.Size(130, 21);
            this.cbExporter.TabIndex = 3;
            // 
            // lblExporter
            // 
            this.lblExporter.AutoSize = true;
            this.lblExporter.Location = new System.Drawing.Point(20, 110);
            this.lblExporter.Name = "lblExporter";
            this.lblExporter.Size = new System.Drawing.Size(49, 13);
            this.lblExporter.TabIndex = 2;
            this.lblExporter.Text = "Exporter:";
            // 
            // lblQueryCollection
            // 
            this.lblQueryCollection.AutoSize = true;
            this.lblQueryCollection.Location = new System.Drawing.Point(18, 36);
            this.lblQueryCollection.Name = "lblQueryCollection";
            this.lblQueryCollection.Size = new System.Drawing.Size(87, 13);
            this.lblQueryCollection.TabIndex = 1;
            this.lblQueryCollection.Text = "Query Collection:";
            // 
            // cbQueryCollection
            // 
            this.cbQueryCollection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbQueryCollection.FormattingEnabled = true;
            this.cbQueryCollection.Location = new System.Drawing.Point(20, 60);
            this.cbQueryCollection.Name = "cbQueryCollection";
            this.cbQueryCollection.Size = new System.Drawing.Size(130, 21);
            this.cbQueryCollection.TabIndex = 0;
            // 
            // ModelValidatorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbValidator);
            this.Controls.Add(this.gbGeneral);
            this.Name = "ModelValidatorUserControl";
            this.Size = new System.Drawing.Size(350, 250);
            this.gbGeneral.ResumeLayout(false);
            this.gbValidator.ResumeLayout(false);
            this.gbValidator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_find_guid;
        private System.Windows.Forms.Button bt_help;
        private System.Windows.Forms.GroupBox gbGeneral;
        private System.Windows.Forms.GroupBox gbValidator;
        private System.Windows.Forms.Label lblQueryCollection;
        private System.Windows.Forms.ComboBox cbQueryCollection;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.ComboBox cbExporter;
        private System.Windows.Forms.Label lblExporter;
    }
}
