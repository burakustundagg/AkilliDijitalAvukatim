using Business.Concrete;
using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.MemberForms {
    public partial class FrmMemberDashboard : Form {
        LawManager lawManager;
        public object[] infos;
        string membercumle;
        string[] splitcumle;
        FrmMultiAnswer fma = new FrmMultiAnswer();

        public FrmMemberDashboard() {
            InitializeComponent();
            RichTxtSoru.Text = "Sorunuzu giriniz";
            RichTxtCevap.Text = "Cevabınız Burada Gözükecek...";
            lawManager = LawManager.GetInstance();
        }

        private void FrmMemberDashboard_Load(object sender, EventArgs e) {
            RichTxtSoru.Text = "Sorunuzu giriniz";
            RichTxtCevap.Text = "Cevabınız Burada Gözükecek...";
        }

        private void BtnSor_Click(object sender, EventArgs e) {
            membercumle = RichTxtSoru.Text.ToLower();
            splitcumle = membercumle.Split('.', '?', '!', ' ', ';', ':', ',');
            string[] mdresult = ( lawManager.GetStringList(splitcumle) ).ToArray();
            if (mdresult.Length > 1) {

                fma.buttonsList1.OnClick += new ButtonsList.Clicked(clicked);
                fma.fmacount = mdresult.Length;
                fma.fmaresult = mdresult;
                fma.ShowDialog();
            }
            RichTxtCevap.Text = mdresult[0];

        }

        void clicked(Button btn, int index) {
            RichTxtCevap.Text = btn.Text;
            fma.Dispose();
            fma.Close();
        }
    }
}
