using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWikiParser;
using MigalkovDataSpace;
using System.IO;
using Newtonsoft.Json;

namespace Miga
{
    public partial class FormMain : Form
    {
        WikiCard wCard;
        FolderID ID;
        Newtonsoft.Json.Linq.JArray oldData;
        //List<FilmEntry> newData;
       

        public FormMain()
        {
            InitializeComponent();
            this.button6.Enabled = false;
            wCard = new WikiCard();
            ID = new FolderID(@"D:\filmData", 0, "A", 43, "I");
            //newData = readNew();// List<FilmEntry>();

            var t = File.ReadAllText("resultFilm.json");
            Newtonsoft.Json.Linq.JObject j= Newtonsoft.Json.Linq.JObject.Parse(t);
            oldData = (Newtonsoft.Json.Linq.JArray)j["data"];

            updateFolderText();

        }

        private List<FilmEntry> readNew()
        {
            List<FilmEntry> result = new List<FilmEntry>();

            var temp = Newtonsoft.Json.Linq.JObject.Parse(File.ReadAllText("filmList.json")).GetValue("data");
            Newtonsoft.Json.Linq.JArray dataArray = (Newtonsoft.Json.Linq.JArray)temp;

            foreach(var i in dataArray)
            {
                result.Add(JsonConvert.DeserializeObject<FilmEntry>(i.ToString()));
            }

            return result;
        }

        private void updateFolderText()
        {
            if(Directory.Exists(ID.GetFullPath()))
            {
                button6.Enabled = false;
                //MessageBox.Show(string.Format("Папка {0} уже существует!",ID.GetFullPath()));
            }
            else
            {
                button6.Enabled = true;
            }          

            textBox3.Text = ID.GetFullPath();
            textBox4.Text = ID.Fdigit.ToString();
            textBox5.Text = ID.Letter.ToString();
            textBox6.Text = ID.Sdigit.ToString();
            textBox7.Text = ID.Rome.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.GetData(DataFormats.Text) != null)
                {
                    textBox1.Text = Clipboard.GetData(DataFormats.Text).ToString();
                    var cardTemp = new WikiCard();
                    cardTemp.GetDataFromWiki(textBox1.Text);
                    textBox2.Text = cardTemp.ToString();

                    if (NewCheck(cardTemp) && OldCheck(cardTemp))
                    {
                        wCard = cardTemp;
                        this.button6.Enabled = true;
                    } 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Неудалось получить данные. {0} {1}",ex.Message,ex.StackTrace));
            }

        }

        private bool NewCheck(WikiCard target)
        {

            List<FilmEntry> newData = readNew();
            if (newData!=null || newData.Count>0)
            {
                foreach(var i in newData)
                {
                    if(i.ThisCard.ImdbID == target.ImdbID)
                    {
                        MessageBox.Show("Фильм уже добавлен!");
                        return false;
                    }
                }     
            }
            return true;
        }

        private bool OldCheck(WikiCard target)
        {
            string newId = target.ImdbID;

            foreach(Newtonsoft.Json.Linq.JObject i in oldData)
            {
                string temp = i.Value<string>("Imdbid");

                if(temp.Contains(newId))
                {
                    string mes = string.Format("Фильм {0} уже есть в папке {1}{2}", i.Value<string>("Name"), i.Value<string>("BaseFolder"), i.Value<string>("SubFolder"));
                    
                    MessageBox.Show(mes);
                    return false;
                }      
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ID.IncFdigit();           
            //updateFolderText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ID.IncLetter();
            ID.Sdigit = 0;
            ID.Rome = "I";
            updateFolderText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ID.IncSdigit();
            ID.Rome = "I";
            updateFolderText();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ID.IncRome();
            updateFolderText();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (Directory.Exists(ID.GetFullPath()))
            {
                button6.Enabled = false;
                MessageBox.Show(string.Format("Папка {0} уже существует!",ID.GetFullPath()));
            }
            else
            {
                if (NewCheck(wCard) && OldCheck(wCard))
                {
                    System.IO.Directory.CreateDirectory(ID.GetFullPath());
                    FilmEntry card = new FilmEntry();
                    card.ThisCard = wCard;
                    card.ThisFolder = ID;
                    List<FilmEntry> newData = readNew();                  
                    newData.Add(card);
                    SaveSeans(newData);
                }
            }           



            button6.Enabled = false;

            
        }

        private void SaveSeans(List<FilmEntry> newData)
        {
            Newtonsoft.Json.Linq.JArray res = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JObject data = new Newtonsoft.Json.Linq.JObject();
            foreach(var c in newData)
            {
                var temp = Newtonsoft.Json.Linq.JObject.Parse(JsonConvert.SerializeObject(c));
                res.Add(temp);
            }
            data["data"] = res;

            File.WriteAllText("filmList.json", data.ToString());
          
        }
    }
}
