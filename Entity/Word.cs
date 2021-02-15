using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class Word {
        int id, usecount;
        string word_, type;

        public int Id { get => id; set => id = value; }
        public int Usecount { get => usecount; set => usecount = value; }
        public string Word_ { get => word_; set => word_ = value; }
        public string Type { get => type; set => type = value; }

        public Word(int id, int usecount, string word_, string type) {
            this.id = id;
            this.usecount = usecount;
            this.word_ = word_;
            this.type = type;
        }

        public Word(int usecount, string word_, string type) {
            this.usecount = usecount;
            this.word_ = word_;
            this.type = type;
        }
    }
}
