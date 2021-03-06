using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_pbo
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "")
            {
                MessageBox.Show("Username jangan kosong!");
            }
            else if (tb_pass.Text == "")
            {
                MessageBox.Show("Password jangan kosong!");
            }
            else
            {
                if (tb_pass.Text != "pbo123")
                {
                    MessageBox.Show("Gagal login :(");
                }
                else
                {
                    menu me = new menu();
                    me.Show();
                    this.Hide();
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tb_username.ResetText();
            tb_pass.ResetText();
        }
    }
}
