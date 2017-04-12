using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestService.DataLayer
{
    public interface IDictionaryRepository
    {
        IEnumerable<MyDictonaryWord> GetWords();

        MyDictonaryWord TranslateWord(string word);

    }
}
