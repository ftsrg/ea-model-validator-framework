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
using System;
using System.Data;
using System.Windows.Forms;

namespace EnterpriseArchitectExtension
{
    public partial class ExportWindow : Form
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        public void LoadDataIntoTab(DataTable dataTable, string tabname, DataGridViewCellEventHandler dataGridViewCellEventHandler = null)
        {
            TabPage tabPage = new TabPage(tabname);
            tabControl.TabPages.Add(tabPage);

            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill
            };
            dataGridView.Columns.Clear();

            BindingSource bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
            bindingSource.DataSource = dataTable;
            dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoResizeColumns();

            if (dataGridViewCellEventHandler != null )
            {
                dataGridView.CellClick += dataGridViewCellEventHandler;
            }

            tabPage.Controls.Add(dataGridView);
        }
    }
}
