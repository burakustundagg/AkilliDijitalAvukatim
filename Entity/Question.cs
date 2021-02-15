using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class Question {
        int id;
        string quecode, que, keywords, result;

        public int Id { get => id; set => id = value; }
        public string Quecode { get => quecode; set => quecode = value; }
        public string Que { get => que; set => que = value; }
        public string Keywords { get => keywords; set => keywords = value; }
        public string Result { get => result; set => result = value; }

        public Question(int id, string quecode, string que, string keyword, string result) {
            this.id = id;
            this.quecode = quecode;
            this.que = que;
            this.keywords = keyword;
            this.result = result;
        }

        public Question(string quecode, string que, string keyword, string result) {
            this.quecode = quecode;
            this.que = que;
            this.keywords = keyword;
            this.result = result;
        }
    }
}
