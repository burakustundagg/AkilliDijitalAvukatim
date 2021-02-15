using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete {
    public class AuthDal {
        static AuthDal authDal;
        SqlService sqlService;
        SqlDataReader dataReader;
        bool result;

        private AuthDal() {
            sqlService = SqlDatabase.GetInstance();
        }

        public string Add(Auth entity) {
            try {
                dataReader = sqlService.StoreReader("YetkiEkle", new SqlParameter("@yetkiAd", entity.Name));
                if (dataReader.Read()) {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result) {
                    return entity.Name + "Yetkisi Daha Önce Eklendi";
                }
                return entity.Name + "Yetkisi Başarıyla Eklendi";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int id) {
            try {
                sqlService.Stored("YetkiSil", new SqlParameter("@id", id));
                return "Yetki Başarıyla Silindi";
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
                List<Auth> auths = new List<Auth>();
                dataReader = sqlService.StoreReader("YetkiListesi");
                while (dataReader.Read()) {
                    Auth auth = new Auth(dataReader["ID"].ConInt(), dataReader["YETKI_AD"].ToString());
                    auths.Add(auth);
                }
                dataReader.Close();
                return auths;
            }
            catch {
                return new List<Auth>();
            }
        }

        public string Update(Auth entity, string oldName) {
            try {
                dataReader = sqlService.StoreReader("YetkiGuncelle", new SqlParameter("@id", entity.Id),
                    new SqlParameter("@yetkiAd", entity.Name), new SqlParameter("@yetkiEskiAd", oldName));
                if (dataReader.Read()) {
                    result = dataReader[0].ConBool();
                }
                if (result) {
                    return entity.Name = " İsimli Başka Bir Aktif Kayıt Bulunuyor!";
                }
                return entity.Name + " Yetkisi Başarıyla Güncellendi";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public static AuthDal GetInstance() {
            if (authDal == null) {
                authDal = new AuthDal();
            }
            return authDal;
        }
    }
}

