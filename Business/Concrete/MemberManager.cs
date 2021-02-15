using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class MemberManager {
        static MemberManager memberManager;
        MemberDal memberDal;
        string controlText;
        private MemberManager() {
            memberDal = MemberDal.GetInstance();
        }

        public string Add(Member entity) {
            try {
                controlText = IsPersonnelComplete(entity);
                if (controlText != "") {
                    return controlText;
                }
                return memberDal.Add(entity);
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int id) {
            try {
                if (id < 1) {
                    return "Lütfen Geçerli Bir Personel Seçiniz";
                }
                return memberDal.Delete(id);
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public Member Get(int id) {
            return null;
        }

        public List<Member> GetList() {
            try {
                return memberDal.GetList();
            }
            catch {
                return new List<Member>();
            }
        }

        public string Update(Member entity) {
            try {
                if (entity.Id < 1) {
                    return "Lütfen Geçerli Bir Personel Seçiniz";
                }
                controlText = IsPersonnelComplete(entity);
                if (controlText != "") {
                    return controlText;
                }
                return memberDal.Update(entity, "");
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }
        public static MemberManager GetInstance() {
            if (memberManager == null) {
                memberManager = new MemberManager();
            }
            return memberManager;
        }

        string IsPersonnelComplete(Member member) {
            if (member.UserName.Length > 50) {
                return "Kullanıcı Adı 50 Karakterden Az Olmalıdır";
            }
            if (string.IsNullOrEmpty(member.Name) || string.IsNullOrEmpty(member.Mail) || member.Birthday == DateTime.MinValue) {
                return "Lütfen Personel Bilgilerini Tam Giriniz";
            }
            if (member.Name.Length > 50) {
                return "İsim ve Soyisim İçin En Fazla 50 Karakter Kullanabilirsiniz";
            }
            return "";
        }

        public object[] Login(string userName, string password) {
            try {
                return memberDal.Login(userName.Trim(), password.Trim());
            }
            catch (Exception) {
                return null;
            }
        }

    }
}
