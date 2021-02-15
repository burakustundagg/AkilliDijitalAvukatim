using Business.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.MemberForms;

namespace UserInterface {
    public partial class FrmLogin : Form {
        MemberManager memberManager;
        public FrmLogin() {
            InitializeComponent();
            memberManager = MemberManager.GetInstance();
        }

        private void FrmLogin_Load(object sender, EventArgs e) {

        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "") {
                MessageBox.Show("Lütfen Kullanıcı Adınızla Birlikte Şifrenizi Giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            object[] infos = memberManager.Login(txtUsername.Text, txtPassword.Text);
            if (infos == null) {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Sayın " + infos[1] + ", Hoşgeldiniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FrmMemberDashboard frmMemberDashboard = new FrmMemberDashboard();
            //frmMemberDashboard.infos = infos;
            frmMemberDashboard.Show();
            this.Hide();
        }

        private void btnKayit_Click(object sender, EventArgs e) {
            FrmSignup frmSignup = new FrmSignup();
            frmSignup.ShowDialog();
        }
    }
}
