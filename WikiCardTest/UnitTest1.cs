using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MigalkovDataSpace;
using MyWikiParser;
using HtmlAgilityPack;
using System.Threading;


namespace WikiCardTest
{
    [TestClass]
    public class UnitTest1
    {
        WikiCard B;

        [TestInitialize]
        public void Init()
        {
             B = new WikiCard();
             B.GetDataFromWiki(@"https://ru.wikipedia.org/wiki/Изображая_жертву");
            Thread.Sleep(500);
        }

        [TestMethod]
        public void ID()
        {
            //WikiCard A = new WikiCard();
            //A.GetDataFromWiki(@"https://ru.wikipedia.org/wiki/Изображая_жертву");
            Assert.AreEqual("0820096", B.ImdbID);
        }

        [TestMethod]
        public void Name()
        {
            //WikiCard A = new WikiCard();
            //A.GetDataFromWiki(@"https://ru.wikipedia.org/wiki/Изображая_жертву");
            Assert.AreEqual("Изображая жертву",B.Name);
        }


        [TestMethod]
        public void Dir()
        {
            Assert.AreEqual("Кирилл Серебренников", B.Director);            
        }

        [TestMethod]
        public void Year()
        {
            Assert.AreEqual("2006", B.Year);
        }

        [TestMethod]
        public void Genre()
        {
            Assert.AreEqual("чёрная комедия", B.Genre);
        }
    }
}
