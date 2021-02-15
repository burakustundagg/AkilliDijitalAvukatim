using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class AuthManager {
        static AuthManager authMenager;
        AuthDal authDal;
        string controlText;

        private AuthManager() {
            authDal = AuthDal.GetInstance();
        }

        public string Add(Auth entity) {
            try {
                controlText = IsAuthComplete(entity);
                if (controlText != "") {
                    return controlText;
                }

                return authDal.Add(entity);
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int id) {
            try {
                if (id < 1) {
                    return "Lütfen Geçerli Bir Yetki Seçiniz";
                }
                return authDal.Delete(id);
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public Auth Get(int id) {
            return null;
        }

        public List<Auth> GetList() {
            try {
                return authDal.GetList();
            }
            catch {
                return new List<Auth>();
            }
        }

        public string Update(Auth entity, string oldName) {
            try {
                if (entity.Id < 1) {
                    return "Lütfen Geçerli Bir Yetki Seçiniz";
                }
                controlText = IsAuthComplete(entity);
                if (controlText != "") {
                    return controlText;
                }
                if (string.IsNullOrEmpty(oldName)) {
                    return "Yetkiyle İlgili Bilgiye Ulaşılamadı";
                }
                return authDal.Update(entity, oldName);
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        string IsAuthComplete(Auth auth) {
            if (string.IsNullOrEmpty(auth.Name)) {
                return "Lütfen Yetki İçin İsim Bilgisi Giriniz";
            }
            if (auth.Name.Length > 20) {
                return "Lütfen En Fazla 20 Karakterlik Bilgi Giriniz";
            }
            return "";
        }

        public static AuthManager GetInstance() {
            if (authMenager == null) {
                authMenager = new AuthManager();
            }
            return authMenager;
        }
    }
}
