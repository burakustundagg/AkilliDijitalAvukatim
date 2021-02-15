using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.MemberForms {
    public partial class FrmMultiAnswer : Form {
        public int fmacount;
        public string[] fmaresult;
        public string sonuc;
        public FrmMultiAnswer() {
            InitializeComponent();
        }
        private void FrmMultiAnswer_Load(object sender, EventArgs e) {
            ButtonListAtama();
        }
        protected void Button_Click(object sender, EventArgs e) {
            ButtonListAtama();
        }

        public void ButtonListAtama() {
            for (int i = 0; i < fmacount; i++) {
                buttonsList1.AddButon(fmaresult[i]);
            }

        }
        private void buttonsList1_OnClick(Button btn, int index) {
            sonuc = btn.Text;
        }
    }
}
