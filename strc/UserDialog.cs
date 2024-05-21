using strc.sqlserver;
using strc.model;

using System;
using System.Windows.Forms;
using strc.security;

namespace strc
{
    public partial class UserDialog : Form
    {
        public UserDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            User user = User.Create(
                nameBox.Text,
                surnameBox.Text,
                phoneBox.Text,
                1
            );

            string name = await Compressor.ToBytes(user.Name);
            string sname = await Compressor.ToBytes(user.Surname);
            string phone = await Compressor.ToBytes(user.Phone);

            User raw = User.Create(name, sname, phone, user.Gid);

            bool result = 
                await QueryManager.InsertUserAsync(raw);

            if (result)
            {
                DialogResult = DialogResult.OK;
                
            }
            
        }
    }
}
