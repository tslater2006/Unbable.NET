using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using DynamicJsonParser;
namespace Unbable.NET
{
    public class Unbabel
    {
        private String UserName;
        private String Key;
        public bool Sandbox;
        private static Dictionary<String, String> Endpoints = new Dictionary<string, string>();

        private JavaScriptSerializer serializer = new JavaScriptSerializer();

        static Unbabel()
        {
            Endpoints.Add("GETLANGPAIRS", "https://www.unbabel.co/tapi/v2/language_pair/");
            Endpoints.Add("GETLANGPAIRS_SAND", "http://sandbox.unbabel.com/tapi/v2/language_pair/");
        }

        public Unbabel(String name, String key)
        {
            UserName = name;
            Key = key;
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() }); 
        }

        public List<LanguagePair> GetLanguagePairs()
        {
            List<LanguagePair> pairs = new List<LanguagePair>();
            String endpoint = Sandbox ? Endpoints["GETLANGPAIRS_SAND"] : Endpoints["GETLANGPAIRS"];

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(endpoint);
            request.Headers.Add("Authorization", String.Format("ApiKey {0}:{1}", UserName, Key));
            request.ContentType = "application/json";
            request.Method = "GET";
            
            String test = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();

                
            }
            dynamic data = serializer.Deserialize<object>(test);
            
            foreach (dynamic o in data.objects)
            {
                Language sourceLang = new Language();
                sourceLang.Name = o.lang_pair.source_language.name;
                sourceLang.ShortName = o.lang_pair.source_language.shortname;

                Language targetLang = new Language();
                targetLang.Name = o.lang_pair.target_language.name;
                targetLang.ShortName = o.lang_pair.target_language.shortname;

                LanguagePair pair = new LanguagePair() { Source = sourceLang, Target = targetLang };
                pairs.Add(pair);
            }
            return pairs;
        }
    }

    public class UnbabelCredentials
    {

    }
}
