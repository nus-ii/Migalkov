using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace FilmLib
{
    public partial class Form1 : Form
    {
        JArray allFilm;
        JObject selectedFilm;
        JObject[] Films;
        int selectedFilmNum;

        Settings set;
        string selectedGenre;
        string exeDrive;
        string filmFolder;

        public Form1()
        {
            InitializeComponent();
            set = new Settings();

            //TODO:Изменить
            exeDrive = Application.ExecutablePath[0].ToString();
            var d = JObject.Parse(File.ReadAllText(string.Format("{0}:\\filmList.json", exeDrive)));
            var s = JObject.Parse(File.ReadAllText(string.Format("{0}:\\migasettings.json", exeDrive)));
            filmFolder = s.Value<string>("filmfolder");

            allFilm = d["data"] as JArray;
            radioButton5.Checked = true;
        }

        /// <summary>
        /// Выбор фильмов соответсвующих выбранному жанру
        /// </summary>
        /// <param name="minusFilter">Использование отрицательного фильтра</param>
        /// <param name="minusFilterValue">Значение жанра для отрицательного фильтра</param>
        private void SelecFilmByGenre(bool minusFilter = true, string minusFilterValue = "мульт")
        {
            JArray tempFileList = new JArray();
            JObject tempObj = new JObject();
            string genre = "";

            foreach (var filmItem in allFilm)
            {
                tempObj = filmItem["ThisCard"] as JObject;
                genre = tempObj.Value<string>("Genre").ToLower();

                if (genre.Contains(selectedGenre) || string.IsNullOrEmpty(selectedGenre))
                {
                    if (minusFilter)
                    {
                        if (!genre.Contains(minusFilterValue))
                            tempFileList.Add(filmItem);
                    }
                    else
                    {
                        tempFileList.Add(filmItem);
                    }
                }
            }

            //Перебрасываем отобранный лист фильмов в массив
            SetFilms(tempFileList);

            //Установка выбранного фильма
            SetFirstFilmAsSelected();
        }

        private void SetFirstFilmAsSelected()
        {
            if (Films.Length > 0)
            {
                SetSelectedFilms(0);
                label5.Text = Films.Length.ToString();
            }
        }

        private void SetFilms(JArray temp)
        {
            Films = new JObject[temp.Count];
            int u = 0;
            foreach (var t in temp)
            {
                Films[u] = (JObject)t;
                u++;
            }
        }

        private void SetSelectedFilms(int num)
        {
            if (num < Films.Length)
            {
                selectedFilmNum = num;
                selectedFilm = Films[num];

                var cardObj = selectedFilm["ThisCard"] as JObject;
                this.label2.Text = cardObj.Value<string>("Name");
                this.label7.Text = cardObj.Value<string>("Genre");
                this.label9.Text = cardObj.Value<string>("Director");
                this.label12.Text = cardObj.Value<string>("Year");
                this.label14.Text = cardObj.Value<string>("ImdbID");

                var folderObj = selectedFilm["ThisFolder"] as JObject;
                this.label16.Text = string.Format("{0}{1}",folderObj.Value<string>("DiskFolder"), folderObj.Value<string>("Rome"));
            }
            else
            {
                if (Films.Length > 0)
                {
                    SetSelectedFilms(0);
                }
                else
                {
                    MessageBox.Show("Фильмов в данном жанре нет в коллекции.");
                }
            }
        }

        #region RadioRegion
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                selectedGenre = "приклю";

            SelecFilmByGenre();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                selectedGenre = "боеви";

            SelecFilmByGenre();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                selectedGenre = "комед";

            SelecFilmByGenre();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                selectedGenre = "фанта";

            SelecFilmByGenre();
        }


        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                selectedGenre = "";

            SelecFilmByGenre(false);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                selectedGenre = "трил";

            SelecFilmByGenre();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
                selectedGenre = "ужас";

            SelecFilmByGenre();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
                selectedGenre = "мульт";

            SelecFilmByGenre(false);
        }

        private void radioButton9x_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
                selectedGenre = "вест";

            SelecFilmByGenre();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
                selectedGenre = "драм";

            SelecFilmByGenre();
        }

        private void rb111_CheckedChanged(object sender, EventArgs e)
        {
            if (rb111.Checked)
                selectedGenre = "истор";

            SelecFilmByGenre();
        }
        #endregion

        /// <summary>
        /// Кнопка следующий фильм
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SetSelectedFilms(selectedFilmNum + 1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var tempObj = selectedFilm["ThisCard"] as JObject;
            Process.Start(tempObj.Value<string>("WikiURL"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var tempObj = selectedFilm["ThisFolder"] as JObject;
                string l = tempObj.Value<string>("Letter");
                string f = tempObj.Value<string>("Fdigit");
                string s = tempObj.Value<string>("Sdigit");
                string r = tempObj.Value<string>("Rome");
                string d = tempObj.Value<string>("DiskFolder");
                string path = exeDrive;
                string fullPath = string.Format("{0}:\\{1}\\{2}\\{3}{2}\\{4}\\{5}", path, filmFolder, l, f, d, r);
                Process.Start(fullPath);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось открыть папку");
            }
        }

        #region Garbage
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
