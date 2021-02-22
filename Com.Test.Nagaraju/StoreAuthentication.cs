using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Com.Test.Nagaraju
{
    public class StoreAuthentication
    {
        public static async Task<IEnumerable<Cookie>> SignInAsync()
        {
            var cookieContainer = new CookieContainer();
            using var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };
            using var client = new HttpClient(handler);
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("email", "nagarajub1522@gmail.com"),
                        new KeyValuePair<string, string>("passwd", "Raju1522"),
                        new KeyValuePair<string, string>("back", "identity"),
                        new KeyValuePair<string, string>("SubmitLogin", ""),
                    });
            var baseUrl = "http://automationpractice.com/index.php";
            var result = await client.PostAsync($"{baseUrl}?controller=authentication", content);
            return cookieContainer.GetCookies(new Uri(baseUrl)).Cast<Cookie>();
        }
    }
}
