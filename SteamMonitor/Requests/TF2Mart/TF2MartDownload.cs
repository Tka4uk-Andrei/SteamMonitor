using System;
using System.IO;
using System.Net;
using System.Web;

namespace SteamMonitor.Requests.TF2Mart
{
    public class Tf2MartDownload
    {
        // todo encoding to url format from json string or class
        //public const string TF2_MART_POST_PARAMS =
        //    "filters=%7B%22currency%22%3A%22credits%22%2C%22page" +
        //    "%22%3A%7B%22sort%22%3A%7B%22type%22%3A%22type%22%2C" +
        //    "%22dir%22%3A%22asc%22%7D%2C%22direction%22%3A1%2C%2" +
        //    "2size%22%3A50%2C%22defindex%22%3A{0}%2C%22quality%2" +
        //    "2%3A{2}%2C%22id%22%3A%22{1}%22%7D%2C%22quality%22%3" +
        //    "A%5B%22{2}%22%5D%7D";

        // todo change to getting info from json class?
        private const string TF2_MART_POST_PARAMS_1 =
            "filters=%7B%22currency%22%3A%22credits%22%2C%22page%22" +
            "%3A%7B%22sort%22%3A%7B%22type%22%3A%22type%22%2C%22dir" +
            "%22%3A%22asc%22%7D%2C%22direction%22%3A1%2C%22size%22" +
            "%3A44%2C%22quality%22%3A{0}%7D%2C%22quality%22%3A%5B%22{0}%22%5D%7D";

        // todo change to getting info from json class?
        private const string TF2_MART_POST_PARAMS_2 =
            "filters=%7B%22currency%22%3A%22credits%22%2C%22" +
            "page%22%3A%7B%22sort%22%3A%7B%22type%22%3A%22type" +
            "%22%2C%22dir%22%3A%22asc%22%7D%2C%22direction%22" +
            "%3A1%2C%22size%22%3A44%2C%22defindex%22%3A{0}%2C" +
            "%22quality%22%3A{1}%2C%22id%22%3A%22{2}%3D%22" +
            "%7D%2C%22quality%22%3A%5B%22{1}%22%5D%7D";
 
        // todo static function?
        private string getPostParam(int quality)
        {
            return string.Format(TF2_MART_POST_PARAMS_1, quality);
        }

        // todo static function?
        private string getPostParam(int quality, int defindex, string id)
        {
            return string.Format(TF2_MART_POST_PARAMS_2, defindex, quality, id);
        }

        public StreamReader Download(CookieContainer cookies, int quality, int defindex=0, string id = "")
        {
            string postParam;
            if (id.Equals("")) postParam = getPostParam(quality);
            else               postParam = getPostParam(quality, defindex, id);

            try
            {
                var req = GenerateRequest(cookies, postParam);
                return new StreamReader((req.GetResponse() as HttpWebResponse).GetResponseStream());
            }
            catch (Exception exception)
            {
                // todo Exception handle
                Console.WriteLine(exception);
                return null;
            }
        }

        private HttpWebRequest GenerateRequest(CookieContainer cookies, string post)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var req = (HttpWebRequest) WebRequest.Create("https://tf2mart.net/data/stock/440/page");

            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            req.Referer = "https://tf2mart.net/order";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                            "AppleWebKit/537.36 (KHTML, like Gecko) " +
                            "Chrome/83.0.4103.116 " +
                            "YaBrowser/20.7.3.100 " +
                            "Yowser/2.5 " +
                            "Safari/537.36";

            //req.CookieContainer = new CookieContainer();
            //req.CookieContainer.Add(new Cookie("_ym_uid", "1597341905621764651", "/", "tf2mart.net"));
            //req.CookieContainer.Add(new Cookie("_ga", "GA1.2.518641288.1597341905", "/", "tf2mart.net"));
            //req.CookieContainer.Add(new Cookie("_gid", "GA1.2.717052305.1597341905", "/", "tf2mart.net"));
            //req.CookieContainer.Add(new Cookie("_ym_d", "1597341905", "/", "tf2mart.net"));
            //req.CookieContainer.Add(new Cookie("mart.session_id", "halthC2cHJC95n4H7uoNW5-nM5vIScL-DjkEp71do2vRiEOiudRGVYDmPp7rl8FvD-IQt96y2oXPFTV8ItrE1g", "/", "tf2mart.net"));

            req.CookieContainer = cookies;
            //post = WebUtility.UrlEncode(post);
            req.ContentLength = post.Length;
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write(post);
            }

            return req;
        }



        #region From refactoring

        ///// <summary>
        /////     Type that contains information about supported or/and known versions of Tf2Mart schema DB.
        /////     Store format: "name" = "id (int)"
        ///// </summary>
        //public enum SchemaVersions
        //{
        //    /// <summary>
        //    ///     Version used in previous itterations of program
        //    /// </summary>
        //    VOld = 1499925666,

        //    /// <summary>
        //    ///     Version that relevant for august 2019
        //    /// </summary>
        //    V2019 = 1566329786
        //}

        ///// <summary>
        /////     Forms request to get information about items in Tf2Mart
        ///// </summary>
        ///// <param name="version">version of tf2Mart DB</param>
        ///// <returns>formed request</returns>
        //public static HttpWebRequest GetSchemaRequest(SchemaVersions version = SchemaVersions.VOld)
        //{
        //    var request =
        //        (HttpWebRequest)WebRequest.Create(string.Format("https://tf2mart.net/schema-en.js?v={0}", version));
        //    request.Method = "GET";
        //    // in future we will use settings class to load cookies
        //    request.CookieContainer = CookiesFactory.GetCookieManagerTf2Mart(RequestsNames.Schema).CookieContainer;

        //    return request;
        //}

        //public static HttpWebRequest GetItemsList(ItemQuality quality)
        //{
        //    const string TF2_MART_POST_PARAMS = "filters%3D%7B%22currency%22%3A%22credits%22%2C%22page%22" +
        //                                        "%3A%7B%22sort%22%3A%7B%22type%22%3A%22type%22%2C%22dir%2" +
        //                                        "2%3A%22asc%22%7D%2C%22direction%22%3A1%2C%22size%22%3A5" +
        //                                        "0%7D%2C%22quality%22%3A%5B%22{0}%22%5D%7D";

        //    var req = (HttpWebRequest)WebRequest.Create("https://tf2mart.net/data/stock/440/page");
        //    req.Method = "POST";
        //    // in future we will use settings class to load cookies. Also it's more logical then request knows what cookies does
        //    // it need, but request don't know from where it need to take
        //    req.CookieContainer = CookiesFactory.GetCookieManagerTf2Mart(RequestsNames.ItemsList).CookieContainer;
        //    var postParams = string.Format(TF2_MART_POST_PARAMS, quality.Id);
        //    req.ContentLength = postParams.Length;
        //    using (var writer = new StreamWriter(req.GetRequestStream()))
        //    {
        //        writer.Write(postParams);
        //        writer.Flush();
        //        writer.Close();
        //    }

        //    return req;
        //}

        ///// <summary>
        /////     Forms request to
        ///// </summary>
        ///// <param name="quality">search param, used to select items with specific quality</param>
        ///// <param name="defindex">parameter that sets start position of search</param>
        ///// <param name="id">parameter that sets start position of search</param>
        ///// <returns>formed request</returns>
        //public static HttpWebRequest GetItemsList(ItemQuality quality, int defindex, string id)
        //{
        //    const string TF2_MART_POST_PARAMS = "filters=%7B%22currency%22%3A%22credits%22%2C%22page" +
        //                                        "%22%3A%7B%22sort%22%3A%7B%22type%22%3A%22type%22%2C" +
        //                                        "%22dir%22%3A%22asc%22%7D%2C%22direction%22%3A1%2C%2" +
        //                                        "2size%22%3A50%2C%22defindex%22%3A{0}%2C%22quality%2" +
        //                                        "2%3A{2}%2C%22id%22%3A%22{1}%22%7D%2C%22quality%22%3" +
        //                                        "A%5B%22{2}%22%5D%7D";

        //    var req = (HttpWebRequest)WebRequest.Create("https://tf2mart.net/data/stock/440/page");
        //    req.Method = "POST";
        //    //req.ContentType = "application/x-www-form-urlencoded";
        //    //req.Referer = "http://tf2mart.net/order";
        //    req.CookieContainer = CookiesFactory.GetCookieManagerTf2Mart(RequestsNames.ItemsList).CookieContainer;

        //    // post params forming and sending
        //    var postParams = string.Format(TF2_MART_POST_PARAMS, defindex, id, quality.Id);
        //    req.ContentLength = postParams.Length;
        //    using (var writer = new StreamWriter(req.GetRequestStream()))
        //    {
        //        writer.Write(postParams);
        //        writer.Flush();
        //        writer.Close();
        //    }

        //    return req;
        //}

        ///// <summary>
        /////     Is it sell request???
        ///// </summary>
        ///// <returns></returns>
        //public static HttpWebRequest GetSellRequest()
        //{
        //    var requestUri = string.Format(
        //        "order=%7B%22sell%22%3A%7B%22{0}%22%3A%5B%22{1}%3D%22%5D%7D%2C%22" +
        //        "buy%22%3A%7B%22{2}%22%3A%5B%22{3}%22%5D%7D%2C%22price%22%3A{4}%7D",
        //        440, "dfa", 400, "ads", 0);
        //    var req = WebRequest.Create(requestUri);

        //    return null;
        //}

        #endregion

    }
}