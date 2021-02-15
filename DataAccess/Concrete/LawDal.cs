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
    public class LawDal {
        static LawDal lawDal;
        SqlService sqlService;
        SqlDataReader dataReader;
        bool result;

        private LawDal() {
            sqlService = SqlDatabase.GetInstance();
        }

        public string Add(Law entity) {
            try {
                dataReader = sqlService.StoreReader("YasaEkle", new SqlParameter("@yasakodu", entity.Lawcode), new SqlParameter("@yasa", entity.Law_), 
                    new SqlParameter("@kategori", entity.Category), new SqlParameter("@anahtarkelimeler", entity.Keywords), new SqlParameter("@kullanimsayisi", entity.Usecount));
                if (dataReader.Read()) {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result) {
                    return entity.Lawcode + " Yasa Daha Önce Oluşturulmuş";
                }
                return entity.Lawcode + " Kod Numaralı Yasa Başarıyla Oluşturulmuştur";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int lcode) {
            try {
                sqlService.Stored("YasaSil", new SqlParameter("@yasakodu", lcode));
                return lcode + " Kod Numaralı Yasa Başarıyla Silindi";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public Member Get(int id) {
            return null;
        }

        public List<Law> GetList() {
            try {
                List<Law> laws = new List<Law>();
                dataReader = sqlService.StoreReader("YasaListesi");
                while (dataReader.Read()) {
                    Law law = new Law(dataReader["ID"].ConInt(), dataReader["YASA_KODU"].ToString(), dataReader["YASA"].ToString(),
                        dataReader["KATEGORI"].ToString(), dataReader["ANAHTAR_KELIMELER"].ToString(), dataReader["KULLANIM_SAYISI"].ConInt());
                    laws.Add(law);
                }

                dataReader.Close();
                return laws;
            }
            catch {
                return new List<Law>();
            }
        }

        public List<string> GetStringList(string[] memberQuestion) {
            try {
                List<Law> lawsGet = new List<Law>();
                dataReader = sqlService.StoreReader("YasaListesi");
                List<string> lawsSentence = new List<string>();
                while (dataReader.Read()) {
                    lawsSentence.Add(dataReader["YASA"].ToString());
                }
                int matchCount = 0;
                
                List<string> result = new List<string>();
                string[] splittedLaw;

                foreach (string itemLaw in lawsSentence) {
                    splittedLaw = (itemLaw.ToLower().Split('.', '?', '!', ' ', ';', ':', ','));
                    
                    foreach (string itemSplittedLaw in splittedLaw) {
                        if (memberQuestion.Contains(itemSplittedLaw) == true){
                            matchCount++;
                            if (matchCount >= (int) memberQuestion.Length*0.60) {
                                result.Add(itemLaw);
                                break;
                            }
                        }
                    }
                    matchCount = 0;
                }
                dataReader.Close();
                return result;
            }
            catch {
                return new List<string>();
            }
        }

        public string Update(Law entity, string oldName) {
            try {
                dataReader = sqlService.StoreReader("YasaGuncelle", new SqlParameter("@yasakodu", entity.Lawcode), new SqlParameter("@yasa", entity.Law_),
                    new SqlParameter("@kategori", entity.Category), new SqlParameter("@anahtarkelimeler", entity.Keywords), new SqlParameter("@kullanimsayisi", entity.Usecount));
                return entity.Lawcode + " Kod Numaralı Yasa Başarıyla Güncellendi";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public static LawDal GetInstance() {
            if (lawDal == null) {
                lawDal = new LawDal();
            }
            return lawDal;
        }
    }
}
