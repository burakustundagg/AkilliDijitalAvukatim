using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace UserInterface {
    public class ButtonsList : Component {
        int startIndex = 0;
        public int count = 0;
        public Control ctr;

        public ButtonsList() {
        }

        void controlRemoved(object sender, ControlEventArgs e) {
            int new_count = 0;
            for (int i = 0; i < ctr.Controls.Count; i++) {
                if ((string)ctr.Controls[i].Tag == "b") {
                    new_count++;
                }
            }
            count = new_count;
        }

        public Control ParentControl { get { return ctr; } set { SetParentControl(value); } }
        public delegate void Clicked(Button btn, int index);
        public event Clicked OnClick;



        public void SetParentControl(Control c) {
            ctr = c;
            startIndex = c.Controls.Count;
            c.ControlRemoved += new ControlEventHandler(controlRemoved);
        }

        void click(object sender, EventArgs args) {
            for (int i = 0; i < count; i++) {
                if (GetButton(i).Focused == true) {
                    try {
                        OnClick(GetButton(i), i);
                        break;
                    }
                    catch {

                    }
                }
            }
        }
        public Button GetButton(int index) {
            return (Button)ctr.Controls[startIndex + index];
        }

        public int AddButon(string text) {
            int ret = 0;
            Button btn = new Button();
            ret = ctr.Controls.Count;
            btn.Size = new System.Drawing.Size(340, 150);
            btn.Text = text;
            btn.Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold);
            btn.Tag = "b";
            btn.Click += new EventHandler(click);
            ctr.Controls.Add(btn);
            count++;
            return ret;
        }
    }
}