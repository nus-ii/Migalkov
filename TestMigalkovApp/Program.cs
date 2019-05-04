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

            List<string> urlS = new List<string>
            {
                @"https://ru.wikipedia.org/wiki/Изображая_жертву",
                @"https://ru.wikipedia.org/wiki/Одержимая_(фильм,_2012)",
                @"https://ru.wikipedia.org/wiki/Жизнь_в_мотеле_(фильм)",
                @"https://ru.wikipedia.org/wiki/Джунгли_зовут!_В_поисках_Марсупилами", //жанр строкой
                @"https://ru.wikipedia.org/wiki/Золотая_пуговица",
                @"https://ru.wikipedia.org/wiki/Моли_о_смерти",
                @"https://ru.wikipedia.org/wiki/Изображая_жертву",
                @"https://ru.wikipedia.org/wiki/Третья_планета_(фильм)",
                @"https://ru.wikipedia.org/wiki/Другие_сорок_восемь_часов",
                @"https://ru.wikipedia.org/wiki/Зимняя_вишня_2",
                @"https://ru.wikipedia.org/wiki/Запах_страсти",
                @"https://ru.wikipedia.org/wiki/Глюки_(фильм)"//жанр ссылками

            };

            foreach(var s in urlS)
            {
                ReadAndPrint(s);
            }

           Console.ReadLine();
        }

        public static void ReadAndPrint(string url)
        {
            var tempCard = new WikiCard();
            tempCard.GetDataFromWiki(url);
            PrintCard(tempCard);
        }

        public static void PrintCard(WikiCard wCard)
        {
            Console.WriteLine("**************************");
            PrintValue("Название", wCard.Name);
            PrintValue("Год", wCard.Year);
            PrintValue("Режиссёр", wCard.Director);
            PrintValue("Жанр", wCard.Genre);
            PrintValue("Imdb", wCard.ImdbID);
            PrintValue("Чтение", wCard.ReadDataSuccess == true ? "Успех!!!" : "Провал...");
            Console.WriteLine("**************************");
        }

        public static void PrintValue(string header,string value,int length=10)
        {
            string result = "";
            for(int i = 0; i < length; i++)
            {
                if (header.Length >= i+1)
                {
                    result = result + header[i].ToString();
                }
                else
                {
                    if (i == length-1)
                    {
                        result = result + ">";
                    }
                    else
                    {
                        result = result + "-";
                    }
                }
            }
            Console.WriteLine(result + " " + value);
        }
    }
}
