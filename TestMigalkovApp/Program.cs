using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigalkovDataSpace;
using MyWikiParser;


namespace TestMigalkovApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderID ID = new FolderID(@"C:\storage\", 0, "A", 40, "I");
            var IDb = ID.GetIncFdigit();


            var T = new WikiCard();
            T.GetDataFromWiki(@"https://ru.wikipedia.org/wiki/Изображая_жертву");

           Console.WriteLine(T.ToString());
           Console.ReadLine();
        }
    }
}
