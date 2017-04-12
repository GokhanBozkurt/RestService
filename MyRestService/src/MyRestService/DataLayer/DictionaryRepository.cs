using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestService.DataLayer
{
    public class DictionaryRepository : IDictionaryRepository
    {

        public IEnumerable<MyDictonaryWord> GetWords()
        {
            return Import();
        }

        public MyDictonaryWord TranslateWord(string word)
        {
            var count = Import().Where(a => a.Word == word).Count();
            return count > 0 ? Import().Where(a => a.Word == word).First() : null;
        }

        public IEnumerable<MyDictonaryWord> Import()
        {
            var paymentList = System.IO.File.ReadAllLines("1.Word.csv").Select(
                                                                   line => new MyDictonaryWord
                                                                   {
                                                                       Word = line.Split(";".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)[0].ToUpper().Trim(),
                                                                       TranslatedWord = line.Split(";".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries)[1].ToUpper().Trim(),
                                                                       Language = "Türkçe"
                                                                   });

            return paymentList;
        }

    }
}
