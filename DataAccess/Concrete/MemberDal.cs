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
    public class MemberDal : IRepository<Member> {
        static MemberDal memberDal;
        SqlService sqlService;
        SqlDataReader dataReader;
        bool result;

        private MemberDal() {
            sqlService = SqlDatabase.GetInstance();
        }
        public string Add(Member entity) {
            try {
                dataReader = sqlService.StoreReader("UyeEkle", new SqlParameter("@kullaniciadi", entity.UserName.ToString()), 
                    new SqlParameter("@adsoyad", entity.Name.ToString()), new SqlParameter("@mail", entity.Mail.ToString()), 
                    new SqlParameter("@yetkiid", 1), new SqlParameter("@dogumtarihi", entity.Birthday), new SqlParameter("@sifre", entity.Password.ToString()));
                if (dataReader.Read()) {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result) {
                    return entity.UserName + " Kullanıcı Adı Daha Önce Kullanılmış";
                }
                


                return entity.Name + " Üye Kaydı Başarıyla Tamamlanmıştır";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int id) {
            try {
                sqlService.Stored("UyeSil", new SqlParameter("@kullaniciadi", id));
                return "Kullanıcı Başarıyla Silindi";
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
                List<Member> members = new List<Member>();
                dataReader = sqlService.StoreReader("UyeListesi");
                while (dataReader.Read()) {
                    members.Add(new Member(dataReader["ID"].ConInt(), dataReader["YETKI_ID"].ConInt(), dataReader["KULLANICI_ADI"].ToString(),
                        dataReader["AD_SOYAD"].ToString(), dataReader["MAIL"].ToString(), dataReader["YETKI_AD"].ToString(), dataReader["DOGUM_TARIHI"].ConDate()));
                }
                dataReader.Close();
                return members;
            }
            catch {
                return new List<Member>();
            }
        }

        public string Update(Member entity, string oldName) {
            try {
                dataReader = sqlService.StoreReader("UyeGuncelle", new SqlParameter("@kullaniciadi", entity.UserName), new SqlParameter("@adsoyad", entity.Name),
                    new SqlParameter("@mail", entity.Mail), new SqlParameter("@yetkiId", entity.AuthId), new SqlParameter("@dogumtarihi", entity.Birthday));
                return entity.Name + " Kullanıcısı Başarıyla Güncellendi";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public static MemberDal GetInstance() {
            if (memberDal == null) {
                memberDal = new MemberDal();
            }
            return memberDal;
        }

        public object[] Login(string userName, string password) {
            try {
                object[] infos = null;
                dataReader = sqlService.StoreReader("UyeLogin", new SqlParameter("@kullaniciadi", userName), new SqlParameter("@sifre", password));

                if (dataReader.Read()) {
                    string name, authName , mail;
                    int id, authId;
                    DateTime birthday;

                    id = dataReader["ID"].ConInt();
                    name = dataReader["AD_SOYAD"].ToString();
                    mail = dataReader["MAIL"].ToString();
                    birthday = dataReader["DOGUM_TARIHI"].ConDate();
                    authId = dataReader["YETKI_ID"].ConInt();
                    authName = dataReader["YETKI_AD"].ToString();

                    infos = new object[] { id, name, mail, birthday, authId, authName};
                }
                dataReader.Close();
                return infos;
            }
            catch (Exception) {
                return null;
            }
        }
    }
}