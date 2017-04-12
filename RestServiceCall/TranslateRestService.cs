using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestServiceCall
{
    public class TranslateRestService<T> : RestServiceBase<T>
    {
        public override string ApiUrl
        {
            get
            {
                return "http://localhost:17059/api/values";
            }
        }

        public override async Task<List<T>> GetList()
        {
            var wordList = CallListRestService(ApiUrl);
            return await wordList;
        }

        public override async Task<T> GetRecord(string word)
        {
            var transletedWord = CallTransletWordRestService($"{ApiUrl}/{word}");
            return await transletedWord;
        }
    }
}
