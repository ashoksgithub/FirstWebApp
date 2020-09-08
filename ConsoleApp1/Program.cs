using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Promotions prom = new Promotions();
            NameValueCollection promotionsList = null;
            //Console.WriteLine(prom.repositoryUrls);
            NameValueCollection unitCost = new NameValueCollection();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                unitCost.Add(item, ConfigurationManager.AppSettings[item]);
            }

            promotionsList = prom.list;
            Console.ReadLine();
        }
    }

    public class Promotions
    {
        //List<string,string> lt = null;
        public NameValueCollection list = null;
        public Promotions()
        {
            list = new NameValueCollection();
            var promotions = ConfigurationManager.GetSection("PromotionsGroup/Promotions") as NameValueCollection;
            //repositoryUrls = ConfigurationManager.AppSettings.AllKeys;
            foreach (var key in promotions.AllKeys)
            {
                list.Add(key, promotions[key]);
            }
        }
    }
}
