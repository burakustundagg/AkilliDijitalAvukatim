using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class Law {
        int id;
        string lawcode, law_, category, keywords;
        int usecount;

        public int Id { get => id; set => id = value; }
        public string Lawcode { get => lawcode; set => lawcode = value; }
        public string Law_ { get => law_; set => law_ = value; }
        public string Category { get => category; set => category = value; }
        public string Keywords { get => keywords; set => keywords = value; }
        public int Usecount { get => usecount; set => usecount =  value ; }

        public Law(int id, string lawcode, string law_, string category, string keywords, int usecount) {
            this.id = id;
            this.lawcode = lawcode;
            this.law_ = law_;
            this.category = category;
            this.keywords = keywords;
            this.usecount = usecount;
        }

        public Law(string lawcode, string law_, string category, string keywords, int usecount) {
            this.lawcode = lawcode;
            this.law_ = law_;
            this.category = category;
            this.keywords = keywords;
            this.usecount = usecount;
        }
    }
}
