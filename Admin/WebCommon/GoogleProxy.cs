using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Fbiz.Framework.Core.Extensions;

namespace Admin.WebCommon
{
    public class GoogleProxy
    {
        public dynamic GetUserInfo(string authToken)
        {
            dynamic userInfo = HttpWebRequest.Create("https://www.googleapis.com/oauth2/v1/userinfo")
                                                   .WithHeader("Authorization", "Bearer " + authToken)
                                                   .GetJson();
            return userInfo;
            
        }

        public dynamic GetTokenInfo(string accessToken)
        {
            var verificationUri =
                "https://www.googleapis.com/oauth2/v1/tokeninfo?access_token="
                 + accessToken;

            var hc = new HttpClient();

            var response = hc.GetAsync(verificationUri).Result;
            dynamic tokenInfo = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().ToString());
            return tokenInfo;
        }
    }
}