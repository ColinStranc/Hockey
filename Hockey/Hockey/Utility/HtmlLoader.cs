using HtmlAgilityPack;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Utility
{
    public class HtmlLoader
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HtmlLoader));
        public static HtmlDocument LoadPage(string url)
        {
            using (var client = new WebClient())
            {
                string webPageContent = client.DownloadString(url);

                // If you want to see the HTML...
                Log.DebugFormat("##### HTML FOR {0} #####{1}{2}{1}", url, Environment.NewLine, webPageContent);

                using (var textReader = new StringReader(webPageContent))
                {
                    var htmlDoc = new HtmlDocument();

                    htmlDoc.OptionFixNestedTags = true;
                    htmlDoc.Load(textReader);

                    return htmlDoc;
                }
            }

        }

    }
}
