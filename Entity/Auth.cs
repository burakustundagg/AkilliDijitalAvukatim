using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class Auth {
        int id;
        string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }


        public Auth(int id, string name) {
            this.id = id;
            this.name = name;
        }

        public Auth(string name) {
            this.name = name;
        }
    }
}
