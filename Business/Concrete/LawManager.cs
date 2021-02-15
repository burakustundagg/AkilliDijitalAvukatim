using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete {
    public class LawManager {
        static LawManager lawManager;
        LawDal lawDal;
        string controlText;

        private LawManager() {
            lawDal = LawDal.GetInstance();
        }

        public string Add(Law entity) {
            try {
                controlText = IsLawComplete(entity);
                if (controlText != "") {
                    return controlText;
                }

                return lawDal.Add(entity);
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
                return lawDal.Delete(id);
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public Law Get(int id) {
            return null;
        }

        public List<Law> GetList() {
            try {
                return lawDal.GetList();
            }
            catch {
                return new List<Law>();
            }
        }

        public List<string> GetStringList(string[] cumle) {
            try {
                List<string> managerGetLaws = new List<string>(lawDal.GetStringList(cumle));
                if (managerGetLaws.Count > 4) {
                    managerGetLaws.Clear();
                    managerGetLaws.Add("Daha fazla detay ve açıklama içeren bir soru sorunuz lütfen.");
                    return managerGetLaws;
                }
                if (managerGetLaws.Count == 0) {
                    managerGetLaws.Add("Sorunuza uygun bir yasa bulunamadı, lütfen sorunuzu farklı biçimde sorunuz.");
                    return managerGetLaws;
                }
                return managerGetLaws;
            }
            catch {
                return new List<string>();
            }
        }

        public string Update(Law entity, string oldName) {
            return null;
        }

        string IsLawComplete(Law law) {
            if (string.IsNullOrEmpty(law.Law_)) {
                return "Lütfen Yasa Kısmını Boş Bırakmayınız.";
            }
            if (law.Law_.Length < 100) {
                return "Lütfen 100 Karakterden Daha Uzun Yasa Giriniz.";
            }
            if (law.Law_.Length > 2000) {
                return "Lütfen En Fazla 2000 Karakterlik Yasa Giriniz";
            }
            return "";
        }

        public static LawManager GetInstance() {
            if (lawManager == null) {
                lawManager = new LawManager();
            }
            return lawManager;
        }
    }
}
