using EA;
using OCLtoSQL;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EA_Addin_Model_Validator.SqlGenerator
{
    public partial class SqlGeneratorWizard : Form
    {
        private Repository repository;
        private GenerationSettings settings;
        private bool checkCancel = true;

        public SqlGeneratorWizard(Repository repository)
        {
            InitializeComponent();

            this.repository = repository;
            settings = new GenerationSettings();

            tbSQL.TextChanged += (object sender, EventArgs e) => { tbOCL.Enabled = false; };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "*.sql|*.*",
                FilterIndex = 0,
                Title = "Save the created query",
                DefaultExt = "sql",
                FileName = tbQueryName.Text + ".sql",
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, tbSQL.Text);
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            checkCancel = false;
            string back = "< Back";
            string translate = "Translate >";
            if (btnTranslate.Text == back)
            {
                tabControl.SelectTab(0);
                btnTranslate.Text = translate;
            }
            else
            {
                translateSQL2OCL();
                tabControl.SelectTab(1);
                btnTranslate.Text = back;
            }
            btnCopySQL.Enabled = true;
        }

        private void translateSQL2OCL()
        {
            string queryName = tbQueryName.Text;
            string ocl = tbOCL.Text;

            int pContext = ocl.IndexOf("context") + "context".Length;
            int pInv = ocl.IndexOf("inv:");

            string context = ocl.Substring(pContext, pInv - pContext);
            ocl = ocl.Substring(pInv);

            DDLPackage DDLPackage = null;
            var validpim = Guid.TryParse(tbpimguid.Text, out Guid PIMPackageGUID);
            var validddl = Guid.TryParse(tbddlguid.Text, out Guid DDLPackageGUID);
            if (validddl || validpim)
            {
                DDLPackage = new DDLPackage(repository, $"{{{PIMPackageGUID}}}", $"{{{DDLPackageGUID}}}");
            }

            Expression expression = OCLtoSQL.OCLtoSQLTranslator.translate(DDLPackage, context, ocl);
            if (expression == null)
            {
                MessageBox.Show("Invalid OCL expression, cannot be parsed.");
                return;
            }

            string sql = TSQLGenerator.generate(expression, context, queryName, settings);
            sql = sql.Replace("\n", Environment.NewLine);
            tbSQL.Text = sql;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = checkCancel;
            checkCancel = true;
        }

        private void btnCopySQL_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (object)tbOCL);
        }
    }
}
