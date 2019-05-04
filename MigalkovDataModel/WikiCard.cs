using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using MyWikiParser;

namespace MigalkovDataSpace
{
    /// <summary>
    /// Класс отражает данные о фильме полученные с Википедии
    /// </summary>
    public class WikiCard
    {
        string _name;
        string _imdbID;
        string _imdbURL;
        string _year;
        string _genre;
        string _director;
        string _wikiURL;
        bool _readDataSuccess;

        /// <summary>
        /// Название фильма
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        /// <summary>
        /// Идентификатор фильма на IMDB
        /// </summary>
		public string ImdbID
        {
            get
            {
                return this._imdbID;
            }
            set
            {
                this._imdbID = value;
            }
        }

        /// <summary>
        /// URL на IMDB
        /// </summary>
        public string ImdbURL
        {
            get
            {
                return _imdbURL;
            }
            set
            {
                this._imdbURL = value;
            }
        }

        /// <summary>
        /// Год создания фильма
        /// </summary>
        public string Year
        {
            get
            {
                return _year;
            }
            set
            {
                this._year = value;
            }
        }

        /// <summary>
        /// Жанр фильма 
        /// </summary>
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
            }
        }

        /// <summary>
        /// Режиссёр фильма
        /// </summary>
        public string Director
        {
            get
            {
                return _director;
            }
            set
            {
                _director = value;
            }
        }

        /// <summary>
        /// URL на Википедию
        /// </summary>
        public string WikiURL
        {
            get
            {
                return this._wikiURL;
            }
            set
            {
                this._wikiURL = value;
            }
        }

        public bool ReadDataSuccess{
            get
            {
                return _readDataSuccess;
            }
            set
            {
                _readDataSuccess = value;
            }
            }
            
        /// <summary>
        /// Пустой конструтор объекта класса WikiCard
        /// </summary>
        public WikiCard()
        {
            Name = "";
            ImdbID = "";
            ImdbURL = "";
            Year = "";
            Genre = "";
            Director = "";
            WikiURL = "";
            ReadDataSuccess = false;
        }

        /// <summary>
        /// Конструктор объекта класса WikiCard
        /// </summary>
        /// <param name="Name">Название</param>
        /// <param name="ImdbID">ID IMDB</param>
        /// <param name="ImdbURL">IMDB URL</param>
        /// <param name="Year">Год</param>
        /// <param name="Genre">Жанр</param>
        /// <param name="Director">Режиссёр</param>
        /// <param name="WikiURL">Ссылка на Википедию, или в Сибирь...</param>
        public WikiCard(string Name,string ImdbID,string ImdbURL,string Year,string Genre,string Director, string WikiURL)
        {
            this.Name = Name;
            this.ImdbID = ImdbID;
            this.ImdbURL = ImdbURL;
            this.Year = Year;
            this.Genre = Genre;
            this.Director = Director;
            this.WikiURL = WikiURL;
        }

        /// <summary>
        /// Получение данных для фильма с Википедии
        /// </summary>
        /// <param name="WikiUrl"></param>
        /// <returns></returns>
		public void GetDataFromWiki(string WikiUrl)
		{
            string Name = this.Name;
            string ImdbID=this.ImdbID;
            string ImdbURL=this.ImdbURL;
            string Year=this.Year;
            string Genre=this.Genre;
            string Director=this.Director;
            string temp = WikiUrl + "";
            this.ReadDataSuccess = false;

            try
            {
                WikiParser.GetAllData(WikiUrl, ref ImdbID, ref ImdbURL, ref Name, ref Year, ref Genre, ref Director);

                this.Name = Name;
                this.ImdbURL = ImdbURL;
                this.ImdbID = ImdbID;
                this.Year = Year;
                this.Genre = Genre;
                this.Director = Director;
                this.WikiURL = temp;
                this.ReadDataSuccess = true;
            }
            catch (Exception)
            {

               
            }
            //return true; //праду говорить легко и приятно
        }

        public override string ToString()
        {
            string temp = string.Format("{0} {1} {2}", Name,Year,Director,this.Genre);
            return temp;
        }
    }
}
