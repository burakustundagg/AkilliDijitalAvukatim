using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class Member {
        int id, authId;
        string userName, name, mail, authName;
        DateTime birthday;
        string password;

        public int Id { get => id; set => id = value; }
        public int AuthId { get => authId; set => authId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Name { get => name; set => name = value; }
        public string Mail { get => mail; set => mail = value; }
        public string AuthName { get => authName; set => authName = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string Password { get => password; set => password = value; }

        public Member(int id, int authId, string userName, string name, string mail, string authName, DateTime birthday) {
            this.id = id;
            this.authId = authId;
            this.userName = userName;
            this.name = name;
            this.mail = mail;
            this.authName = authName;
            this.birthday = birthday;
        }

        public Member(string userName, string name, string mail, DateTime birthday, string password) {
            this.userName = userName;
            this.name = name;
            this.mail = mail;
            this.birthday = birthday;
            this.password = password;
        }
    }
}
