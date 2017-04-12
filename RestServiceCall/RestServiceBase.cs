using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace RestServiceCall
{
    public abstract class RestServiceBase<T>
    {
        public virtual string ApiUrl { get; }

        public abstract Task<List<T>> GetList();

        public abstract Task<T> GetRecord(string word);

        public async Task<List<T>> CallListRestService(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (System.IO.Stream stream = response.GetResponseStream())
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));
                    var objResponse = (List<T>)jsonSerializer.ReadObject(stream);

                    return objResponse;
                }
            }
        }

        public async Task<T> CallTransletWordRestService(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (System.IO.Stream stream = response.GetResponseStream())
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(DictonaryWord));
                    var objResponse = (T)jsonSerializer.ReadObject(stream);

                    return objResponse;
                }
            }
        }

    }
}
