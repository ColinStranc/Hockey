using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using Hockey.Model;
using Hockey.Loaders;
using Hockey.Database;

namespace Hockey
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        private const string connectionString = "HockeyDB";
        public static bool isDev = true;

        static void Main(string[] args)
        {
            try
            {
                var hockeyModel = new HockeyModel();
                //ImportHockeyModelFromDatabase(hockeyModel);
                //ImportHockeyModelFromNhl(hockeyModel);
                ImportHockeyModelFromOhl(hockeyModel);
                //ImportHockeyModelFromWhl(hockeyModel);
                //ImportHockeyModelFromQmjhl(hockeyModel);
                //ImportHockeyModelFromAhl(hockeyModel);

                SaveHockeyModel(hockeyModel);
                Log.Info("Lack of Exceptions");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            
        }

        private static void SaveHockeyModel(HockeyModel hockeyModel)
        {
            ModelSaver saver = new ModelSaver(hockeyModel, connectionString);
            saver.SaveModel();
        }

        private static void ImportHockeyModelFromOhl(HockeyModel hockeyModel)
        {
            OhlLoader loader = new OhlLoader(hockeyModel);
            loader.ImportData();
        }

        
        /*
        static void Main(string[] args)
        {
            Log.InfoFormat("Today {0} is a good day", DateTime.Now);
            var doc = LoadPage("http://www.nhl.com/");
            var sw = new StringWriter();
            doc.Save(sw);
            Log.InfoFormat(sw.ToString());
        }
         * */
    }
}
