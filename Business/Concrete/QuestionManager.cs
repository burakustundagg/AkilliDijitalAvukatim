using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class QuestionManager {
        static QuestionManager questionManager;
        QuestionDal questionDal;
        string controlText;

        private QuestionManager() {
            questionDal = QuestionDal.GetInstance();
        }

        public string Add(Question entity) {
            try {
                controlText = IsQuestionComplete(entity);
                if (controlText != "") {
                    return controlText;
                }
                return questionDal.Add(entity);
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public string Delete(int id) {
            try {
                if (id < 1) {
                    return "Lütfen Geçerli Bir Soru Kodu Giriniz.";
                }
                return questionDal.Delete(id);
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
                return questionDal.GetList();
            }
            catch {
                return new List<Question>();
            }
        }

        public string Update(Question entity, string oldName) {
            return null;
        }

        string IsQuestionComplete(Question question) {
            if (string.IsNullOrEmpty(question.Que)) {
                return "Lütfen Sorunuzu Boş Bırakmayınız.";
            }
            if (question.Que.Length < 100) {
                return "Lütfen 100 Karakterden Daha Uzun Soru Giriniz.";
            }
            if (question.Que.Length > 2000) {
                return "Lütfen En Fazla 2000 Karakterlik Soru Giriniz";
            }
            return "";
        }

        public static QuestionManager GetInstance() {
            if (questionManager == null) {
                questionManager = new QuestionManager();
            }
            return questionManager;
        }
    }
}
