using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MigalkovDataSpace; 

namespace FolderIDTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RetArcDiskFolder()
        {
            FolderID A = new FolderID();
            A.Fdigit = 0;
            A.Sdigit = 40;
            A.Letter = "A";
            //Еееееееее!!!!
            Assert.AreEqual("0A40",A.DiskFolder);
           
        }

        [TestMethod]
        public void FullPath()
        {
            FolderID A = new FolderID();
            A.Fdigit = 0;
            A.Sdigit = 40;
            A.Letter = "A";
            A.Rome = "III";
            A.MotherFolder = @"C:\storage\data";

            Assert.AreEqual(@"C:\storage\data\A\0A\0A40\III", A.GetFullPath());

        }

        [TestMethod]
        public void IncFdiditTest()
        {
            FolderID A = new FolderID();
            A.Fdigit = 0;
            A.Sdigit = 40;
            A.Letter = "A";
            A.Rome = "III";

            A.IncFdigit();

            Assert.AreEqual(1, A.Fdigit);

        }

        [TestMethod]
        public void IncSdigitTest()
        {
            FolderID A = new FolderID();
            A.Fdigit = 0;
            A.Sdigit = 40;
            A.Letter = "A";
            A.Rome = "III";

            A.IncSdigit();

            Assert.AreEqual(41, A.Sdigit);
        }

        [TestMethod]
        public void IncRomeTest()
        {
            FolderID A = new FolderID();
            A.Fdigit = 0;
            A.Sdigit = 40;
            A.Letter = "A";
            A.Rome = "III";

            A.IncRome();

            Assert.AreEqual("IV", A.Rome);
        }

        [TestMethod]
        public void IncLetterTest()
        {
            FolderID A = new FolderID();
            A.Fdigit = 0;
            A.Sdigit = 40;
            A.Letter = "A";
            A.Rome = "III";

            A.IncLetter();

            Assert.AreEqual("B", A.Letter);
        }
    }
}
