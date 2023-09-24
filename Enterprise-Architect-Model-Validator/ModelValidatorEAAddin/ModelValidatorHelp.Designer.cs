namespace ModelValidatorEAAddin
{
    partial class ModelValidatorHelp
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
            this.pbAddin = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabAddin = new System.Windows.Forms.TabPage();
            this.tabWizard = new System.Windows.Forms.TabPage();
            this.pbWizard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddin)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabAddin.SuspendLayout();
            this.tabWizard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWizard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbAddin
            // 
            this.pbAddin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAddin.Location = new System.Drawing.Point(0, 0);
            this.pbAddin.Name = "pbAddin";
            this.pbAddin.Size = new System.Drawing.Size(778, 436);
            this.pbAddin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddin.TabIndex = 0;
            this.pbAddin.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabAddin);
            this.tabControl.Controls.Add(this.tabWizard);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(786, 462);
            this.tabControl.TabIndex = 1;
            // 
            // tabAddin
            // 
            this.tabAddin.Controls.Add(this.pbAddin);
            this.tabAddin.Location = new System.Drawing.Point(4, 22);
            this.tabAddin.Name = "tabAddin";
            this.tabAddin.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddin.Size = new System.Drawing.Size(778, 436);
            this.tabAddin.TabIndex = 0;
            this.tabAddin.Text = "ModelValidator AddIn";
            this.tabAddin.UseVisualStyleBackColor = true;
            // 
            // tabWizard
            // 
            this.tabWizard.Controls.Add(this.pbWizard);
            this.tabWizard.Location = new System.Drawing.Point(4, 22);
            this.tabWizard.Name = "tabWizard";
            this.tabWizard.Padding = new System.Windows.Forms.Padding(3);
            this.tabWizard.Size = new System.Drawing.Size(772, 434);
            this.tabWizard.TabIndex = 1;
            this.tabWizard.Text = "SQL Generator Wizard";
            this.tabWizard.UseVisualStyleBackColor = true;
            // 
            // pbWizard
            // 
            this.pbWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbWizard.Location = new System.Drawing.Point(0, 0);
            this.pbWizard.Name = "pbWizard";
            this.pbWizard.Size = new System.Drawing.Size(772, 434);
            this.pbWizard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbWizard.TabIndex = 1;
            this.pbWizard.TabStop = false;
            // 
            // ModelValidatorHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl);
            this.Name = "ModelValidatorHelp";
            this.Text = "ModelValidatorHelp";
            ((System.ComponentModel.ISupportInitialize)(this.pbAddin)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabAddin.ResumeLayout(false);
            this.tabWizard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWizard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbAddin;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabAddin;
        private System.Windows.Forms.TabPage tabWizard;
        private System.Windows.Forms.PictureBox pbWizard;
    }
}