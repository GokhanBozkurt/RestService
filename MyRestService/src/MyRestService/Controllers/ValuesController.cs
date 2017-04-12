using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestService.DataLayer;

namespace MyRestService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private IDictionaryRepository dictionaryRepository;

        public ValuesController(IDictionaryRepository repository)
        {
            dictionaryRepository = repository;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<MyDictonaryWord> Get()
        {
            return dictionaryRepository.GetWords();
            //return Import();
        }

    
        // GET api/values/5
        [HttpGet("{word}")]
        public MyDictonaryWord Get(string word)
        {
            return dictionaryRepository.TranslateWord(word);
         

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
