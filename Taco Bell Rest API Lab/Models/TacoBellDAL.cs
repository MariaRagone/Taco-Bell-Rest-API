using static System.Net.WebRequestMethods;
using System.Net;
using Newtonsoft.Json;

namespace Taco_Bell_Rest_API_Lab.Models
{
    public class TacoBellDAL
    {
        public static Burrito GetBurrito()//adjust- use correct model, update method name
        {	//adjust
            //setup
            string url = "";//link to API call

            //request data
            HttpWebRequest request = WebRequest.CreateHttp(url); //takes the url and calls the website and saves the call
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //saves the response
            //converting to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd(); //takes all the info and saves it into a single string to use in our objects

            //adjust
            //converting to C#
            //right click on JsonConvert. > install Newtonsoft.json
            Burrito result = JsonConvert.DeserializeObject<Burrito>(json);//json is the string name
            return result;

        }
    }
}
