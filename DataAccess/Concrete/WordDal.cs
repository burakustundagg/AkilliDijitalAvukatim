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
    public class WordDal {
        static WordDal wordDal;
        SqlService sqlService;
        SqlDataReader dataReader;
        bool result;

        private WordDal() {
            sqlService = SqlDatabase.GetInstance();
        }

        public string Add(Word entity) {
            try {
                dataReader = sqlService.StoreReader("KelimeEkle", new SqlParameter("@kelime", entity.Word_), new SqlParameter("@tip", entity.Type),
                    new SqlParameter("@kullanimsayisi", entity.Usecount));
                if (dataReader.Read()) {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result) {
                    if (entity.Usecount == 0) {
                        return entity.Word_ + " Kelimesi eklendi";
                    }
                    else {
                        entity.Usecount++;
                        return entity.Word_ + " Kelimesi 1 Kez Daha Kullanıldı";
                    }
                }
                return "Kelime Ekleme Başarıyla Tamamlandı";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int id) {
            try {
                sqlService.Stored("KelimeSil", new SqlParameter("@id", id));
                return "Kelime Başarıyla Silindi";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public Word Get(int id) {
            return null;
        }

        public List<Word> GetList() {
            try {
                List<Word> words = new List<Word>();
                dataReader = sqlService.StoreReader("KelimeListesi");
                while (dataReader.Read()) {
                    words.Add(new Word(dataReader["ID"].ConInt(), dataReader["KULLANIM_SAYISI"].ConInt(),
                        dataReader["KELIME"].ToString(), dataReader["TIP"].ToString()));
                }
                dataReader.Close();
                return words;
            }
            catch {
                return new List<Word>();
            }

        }

        public string Update(Word entity, string oldName) {
            return null;
        }

        public static WordDal GetInstance() {
            if (wordDal == null) {
                wordDal = new WordDal();
            }
            return wordDal;
        }
    }
}
