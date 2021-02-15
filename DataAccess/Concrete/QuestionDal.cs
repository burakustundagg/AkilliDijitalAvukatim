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
    public class QuestionDal {
        static QuestionDal questionDal;
        SqlService sqlService;
        SqlDataReader dataReader;
        bool result;

        private QuestionDal() {
            sqlService = SqlDatabase.GetInstance();
        }

        public string Add(Question entity) {
            try {
                dataReader = sqlService.StoreReader("SoruEkle", new SqlParameter("@soru", entity.Que), new SqlParameter("@anahtarkelimeler" , entity.Keywords), 
                    new SqlParameter("@sonuc" , entity.Result));
                if (dataReader.Read()) {
                    result = dataReader[0].ConBool();
                }
                return "Sorunuz kabul edildi";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int qcode) {
            try {
                sqlService.Stored("SoruSil", new SqlParameter("@sorukodu", qcode));
                return qcode + " Kod Numaralı Soru Başarıyla Silindi.";
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public Question Get(int id) {
            return null;
        }

        public List<Question> GetList() {
            try {
                List<Question> questions = new List<Question>();
                dataReader = sqlService.StoreReader("SoruListesi");
                while (dataReader.Read()) {
                    questions.Add(new Question(dataReader["SORU"].ToString(), dataReader["YASA"].ToString(), dataReader["KATEGORI"].ToString(), dataReader["YASA_KODU"].ToString()));
                }
                dataReader.Close();
                return questions;
            }
            catch {
                return new List<Question>();
            }
        }

        public string Update(Question entity, string oldName) {
            return null;
        }

        public static QuestionDal GetInstance() {
            if (questionDal == null) {
                questionDal = new QuestionDal();
            }
            return questionDal;
        }
    }
}
