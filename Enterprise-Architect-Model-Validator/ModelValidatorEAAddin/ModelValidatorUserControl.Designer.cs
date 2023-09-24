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
            this.btn_sql_gen = new System.Windows.Forms.Button();
            this.gbValidator = new System.Windows.Forms.GroupBox();
            this.gbExecute = new System.Windows.Forms.GroupBox();
            this.rbCorrector = new System.Windows.Forms.RadioButton();
            this.rbExporter = new System.Windows.Forms.RadioButton();
            this.cbExporter = new System.Windows.Forms.ComboBox();
            this.cbCorrector = new System.Windows.Forms.ComboBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.lblQueryCollection = new System.Windows.Forms.Label();
            this.cbQueryCollection = new System.Windows.Forms.ComboBox();
            this.gbGeneral.SuspendLayout();
            this.gbValidator.SuspendLayout();
            this.gbExecute.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_find_guid
            // 
            this.bt_find_guid.Location = new System.Drawing.Point(20, 60);
            this.bt_find_guid.Name = "bt_find_guid";
            this.bt_find_guid.Size = new System.Drawing.Size(85, 23);
            this.bt_find_guid.TabIndex = 0;
            this.bt_find_guid.Text = "Find GUID";
            this.bt_find_guid.UseVisualStyleBackColor = true;
            this.bt_find_guid.Click += new System.EventHandler(this.bt_find_guid_Click);
            // 
            // bt_help
            // 
            this.bt_help.Location = new System.Drawing.Point(20, 90);
            this.bt_help.Name = "bt_help";
            this.bt_help.Size = new System.Drawing.Size(85, 23);
            this.bt_help.TabIndex = 1;
            this.bt_help.Text = "Help";
            this.bt_help.UseVisualStyleBackColor = true;
            this.bt_help.Click += new System.EventHandler(this.bt_help_Click);
            // 
            // gbGeneral
            // 
            this.gbGeneral.Controls.Add(this.btn_sql_gen);
            this.gbGeneral.Controls.Add(this.bt_help);
            this.gbGeneral.Controls.Add(this.bt_find_guid);
            this.gbGeneral.Location = new System.Drawing.Point(20, 20);
            this.gbGeneral.Name = "gbGeneral";
            this.gbGeneral.Size = new System.Drawing.Size(130, 130);
            this.gbGeneral.TabIndex = 3;
            this.gbGeneral.TabStop = false;
            this.gbGeneral.Text = "General";
            // 
            // btn_sql_gen
            // 
            this.btn_sql_gen.Location = new System.Drawing.Point(20, 30);
            this.btn_sql_gen.Name = "btn_sql_gen";
            this.btn_sql_gen.Size = new System.Drawing.Size(85, 23);
            this.btn_sql_gen.TabIndex = 2;
            this.btn_sql_gen.Text = "Generate SQL";
            this.btn_sql_gen.UseVisualStyleBackColor = true;
            this.btn_sql_gen.Click += new System.EventHandler(this.btn_sql_gen_Click);
            // 
            // gbValidator
            // 
            this.gbValidator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbValidator.Controls.Add(this.gbExecute);
            this.gbValidator.Controls.Add(this.btnValidate);
            this.gbValidator.Controls.Add(this.lblQueryCollection);
            this.gbValidator.Controls.Add(this.cbQueryCollection);
            this.gbValidator.Location = new System.Drawing.Point(170, 20);
            this.gbValidator.Name = "gbValidator";
            this.gbValidator.Size = new System.Drawing.Size(230, 280);
            this.gbValidator.TabIndex = 4;
            this.gbValidator.TabStop = false;
            this.gbValidator.Text = "Validator";
            // 
            // gbExecute
            // 
            this.gbExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExecute.Controls.Add(this.rbCorrector);
            this.gbExecute.Controls.Add(this.rbExporter);
            this.gbExecute.Controls.Add(this.cbExporter);
            this.gbExecute.Controls.Add(this.cbCorrector);
            this.gbExecute.Location = new System.Drawing.Point(20, 80);
            this.gbExecute.Name = "gbExecute";
            this.gbExecute.Size = new System.Drawing.Size(190, 150);
            this.gbExecute.TabIndex = 7;
            this.gbExecute.TabStop = false;
            this.gbExecute.Text = "Execute";
            // 
            // rbCorrector
            // 
            this.rbCorrector.AutoSize = true;
            this.rbCorrector.Location = new System.Drawing.Point(20, 90);
            this.rbCorrector.Name = "rbCorrector";
            this.rbCorrector.Size = new System.Drawing.Size(68, 17);
            this.rbCorrector.TabIndex = 8;
            this.rbCorrector.TabStop = true;
            this.rbCorrector.Text = "Corrector";
            this.rbCorrector.UseVisualStyleBackColor = true;
            // 
            // rbExporter
            // 
            this.rbExporter.AutoSize = true;
            this.rbExporter.Checked = true;
            this.rbExporter.Location = new System.Drawing.Point(20, 30);
            this.rbExporter.Name = "rbExporter";
            this.rbExporter.Size = new System.Drawing.Size(64, 17);
            this.rbExporter.TabIndex = 7;
            this.rbExporter.TabStop = true;
            this.rbExporter.Text = "Exporter";
            this.rbExporter.UseVisualStyleBackColor = true;
            // 
            // cbExporter
            // 
            this.cbExporter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExporter.FormattingEnabled = true;
            this.cbExporter.Location = new System.Drawing.Point(20, 50);
            this.cbExporter.Name = "cbExporter";
            this.cbExporter.Size = new System.Drawing.Size(150, 21);
            this.cbExporter.TabIndex = 3;
            // 
            // cbCorrector
            // 
            this.cbCorrector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCorrector.FormattingEnabled = true;
            this.cbCorrector.Location = new System.Drawing.Point(20, 110);
            this.cbCorrector.Name = "cbCorrector";
            this.cbCorrector.Size = new System.Drawing.Size(150, 21);
            this.cbCorrector.TabIndex = 5;
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValidate.Location = new System.Drawing.Point(80, 240);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // lblQueryCollection
            // 
            this.lblQueryCollection.AutoSize = true;
            this.lblQueryCollection.Location = new System.Drawing.Point(20, 30);
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
            this.cbQueryCollection.Location = new System.Drawing.Point(20, 50);
            this.cbQueryCollection.Name = "cbQueryCollection";
            this.cbQueryCollection.Size = new System.Drawing.Size(190, 21);
            this.cbQueryCollection.TabIndex = 0;
            // 
            // ModelValidatorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbValidator);
            this.Controls.Add(this.gbGeneral);
            this.Name = "ModelValidatorUserControl";
            this.Size = new System.Drawing.Size(420, 320);
            this.gbGeneral.ResumeLayout(false);
            this.gbValidator.ResumeLayout(false);
            this.gbValidator.PerformLayout();
            this.gbExecute.ResumeLayout(false);
            this.gbExecute.PerformLayout();
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
        private System.Windows.Forms.Button btn_sql_gen;
        private System.Windows.Forms.ComboBox cbCorrector;
        private System.Windows.Forms.GroupBox gbExecute;
        private System.Windows.Forms.RadioButton rbCorrector;
        private System.Windows.Forms.RadioButton rbExporter;
    }
}
