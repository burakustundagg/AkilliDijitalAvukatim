using Business.Concrete;
using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface {
    public partial class FrmSignup : Form {
        MemberManager memberManager;
        public FrmSignup() {
            InitializeComponent();
            memberManager = MemberManager.GetInstance();
        }

        private void btnSign_Click(object sender, EventArgs e) {
            Member member = new Member(txtUsername.Text.ToString(), txtName.Text.ToString() + " " + txtSurname.Text.ToString(), 
                txtMail.Text.ToString(), dtpBirthday.Value.ConDate(), txtPassword.Text.ToString());
            MessageBox.Show(memberManager.Add(member));
        }
    }
}
