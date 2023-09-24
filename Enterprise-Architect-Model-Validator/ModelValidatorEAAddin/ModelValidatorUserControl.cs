/*
 *  Copyright 2023 Gergely Ulicska
 *  
 *  See the README file(s) distributed with this work for additional
 *  information regarding copyright ownership and contributors.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
using EA;
using EA_Addin_Model_Validator.SqlGenerator;
using ModelValidatorLibrary;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ModelValidatorEAAddin
{
    public partial class ModelValidatorUserControl : UserControl
    {
        public Repository Repository;
        private ModelValidator modelValidator;

        public ModelValidatorUserControl()
        {
            InitializeComponent();
        }

        public void CreateModelValidator()
        {
            EAConsoleLogger.Instance.Repository = Repository;
            modelValidator = new ModelValidator(Repository);

            foreach (var queryCollection in modelValidator.QueryCollections)
            {
                cbQueryCollection.Items.Add(queryCollection.Metadata.Name);
            }
            cbQueryCollection.Text = modelValidator.QueryCollections.FirstOrDefault().Metadata.Name;

            foreach (var exporter in modelValidator.Exporters)
            {
                cbExporter.Items.Add(exporter.Metadata.Name);
            }
            cbExporter.Text = modelValidator.Exporters.FirstOrDefault().Metadata.Name;

            foreach (var corrector in modelValidator.Correctors)
            {
                cbCorrector.Items.Add(corrector.Metadata.Name);
            }
            cbCorrector.Text = modelValidator.Correctors.FirstOrDefault().Metadata.Name;
        }

        private void bt_find_guid_Click(object sender, EventArgs e)
        {
            GuidFinder.FindGuid(Repository);
        }

        private void bt_help_Click(object sender, EventArgs e)
        {
            ModelValidatorHelp modelValidatorHelp = new ModelValidatorHelp();
            modelValidatorHelp.Show();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            Package package = Repository.GetTreeSelectedPackage();
            var queryResultsWithName = modelValidator.RunQueries(cbQueryCollection.Text, package);

            if (rbExporter.Checked)
            {
                modelValidator.ExportQueryResults(cbExporter.Text, queryResultsWithName);
            }
            else if (rbCorrector.Checked)
            {
                modelValidator.CorrectQueryResults(cbCorrector.Text, queryResultsWithName);
                MessageBox.Show("Correction complete.");
            }
        }

        private void btn_sql_gen_Click(object sender, EventArgs e)
        {
            var sqlGeneratorWizard = new SqlGeneratorWizard(Repository);
            sqlGeneratorWizard.Show();
        }
    }
}
