using strc.sqlserver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using strc.security;
using System.Diagnostics;
using System.Reflection;

namespace strc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private String _lastQuery = "";

        private async void MainForm_Load(object sender, EventArgs e)
        {
            string alltables = 
                "SELECT TABLE_NAME FROM strc.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            string[] vec = await QueryManager.ExecuteVectorAsync(alltables);

            foreach (string s in vec) 
            {
                tablesList.Items.Add(s);
            }
        }

        private async void tablesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tableView.DataSource = null;

            _lastQuery = $"SELECT * FROM [{tablesList.SelectedItem}]";

            await LoadTable(DoDecompressCheck.Checked);

        }

        private void DoDecompressCheck_CheckedChanged(object sender, EventArgs e)
        {
            tableView.DataSource = null;

            _ = LoadTable(DoDecompressCheck.Checked);
        }
        private static DataRow counter;
        private async Task LoadTable(bool iscompress)
        {
            DataTable table = await QueryManager.ExecuteMapAsync(_lastQuery);

            if (!iscompress)
            {
                MessageBox.Show(
                    "Расшифровка таблицы еще реализована. Обновите ПО до более поздней версии ИЛИ измените флажок нормализации данных", 
                    "Внимание", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk
                );
            }
            //counter.Table.Clear();
            tableView.DataSource = table; 
        }
    }
}
