using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using strc.model;
using strc.sqlserver;
using strc.security;

namespace strc
{
    public partial class GroupDialog : Form
    {
        public static Group GroupInfo { get; set; }


        public GroupDialog()
        {
            InitializeComponent();

            if (GroupInfo == null)
                GroupInfo = new Group();

            if (GroupInfo.Id > 0)
                okButton.Text = "Изменить";
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            string title = 
                await Compressor.ToBytes(titleBox.Text);
            string content = 
                await Compressor.ToBytes(contentBox.Text);

            if (GroupInfo.Id == 0) 
            {
                object next = await QueryManager.ExecuteInt32Async("SELECT COUNT(*) FROM [groups]");

                Group raw = Group.Create(
                    (int)next,
                    title,
                    content
                );

                bool result = 
                    await QueryManager.InsertGroupAsync(raw);

                if (result)
                {
                    DialogResult = DialogResult.OK;
                    Hide();
                }
                else 
                {
                    await ErrorManager.ReportAsync(
                        new Exception("Что-то пошло не так. Повторите попытку")
                    );
                }
            }
        }
    }
}
