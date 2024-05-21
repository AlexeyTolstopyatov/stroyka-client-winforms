using System;
using System.Windows.Forms;

using strc.config;
using strc.sqlserver;

namespace strc
{
    public partial class ConfigDialog : Form
    {
        public ConfigDialog()
        {
            InitializeComponent();
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            Settings.Default.connection = connectionBox.Text;
            Settings.Default.Save();
            
            bool isconnect = 
                await ConfigManager.HasConnection();

            if (!isconnect)
            {
                MessageBox.Show("Нет соединения. Попробуйте указать данные еще раз.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool hasaccount =
                await ConfigManager.HasAccounts();

            if (!hasaccount) 
            {

                DialogResult result = MessageBox.Show(
                    "В указанной базе данных не содержится учетных данных пользователей. Создать их?", 
                    "Внимание",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes) 
                {
                    // Создание временной сессии для указания действующего администратора.
                    new GroupDialog().ShowDialog();

                    UserDialog dialog = 
                        new UserDialog();

                     
                    dialog.ShowDialog();

                    if (dialog.DialogResult == DialogResult.OK)
                    {
                        ErrorManager.Journal.errBox.Text += "Регистрация пройдена\n";
                    }
                    else
                    {
                        MessageBox.Show("Администратор системы не был создан. Вход в систему не будет осуществлен, если в ней нет учетных данных пользователей", "Приложение остановлено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else 
                {
                    Application.Exit();
                }
            }

            // ЕСЛИ: Учетные данные в базе содержатся
            new MainForm().Show();
            Hide();
        }

        private void ConfigDialog_Load(object sender, EventArgs e)
        {
            ErrorManager.Journal.Show();
        }
    }
}
