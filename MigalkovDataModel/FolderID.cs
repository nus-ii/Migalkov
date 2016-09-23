using System;
using System.Collections.Generic;
using System.Text;

namespace MigalkovDataSpace
{
	public class FolderID
	{
        //C:/storage/data/A/0A/0A40/III

        string _motherFolder;
        
        string _letter;
        int _fdigit;
        int _sdigit;
        string _rome;


        /// <summary>
        /// "Материнская папка" содержащая архив фильмов
        /// </summary>
        public string MotherFolder
        {
            get
            {
                return _motherFolder;
            }
            set
            {
                _motherFolder = value;
            }
        }

        /// <summary>
        /// Буквенная часть индекса - раздел
        /// </summary>
        public string Letter
        {
            get
            {
                return _letter;
            }
            set
            {
                _letter = value;
            }
        }

        /// <summary>
        /// Первая "цифровая" часть индекса - подраздел
        /// </summary>
        public int Fdigit
        {
            get
            {
                return _fdigit;
            }
            set
            {
                _fdigit = value;
            }
        }

        /// <summary>
        /// Вторая "цифровая" часть индекса - отражает номер Архивного диска
        /// </summary>
        public int Sdigit
        {
            get
            {
                return _sdigit;
            }

            set
            {
                _sdigit = value;
            }
        }

        /// <summary>
        /// Римская цифра - обозначает папку на архивном диске
        /// </summary>
        public string Rome
        {
            get
            {
                return _rome;
            }
            set
            {
                _rome = value;
            }
        }

        /// <summary>
        /// Полное обозначение Архивного Диска
        /// </summary>
        public string DiskFolder
        {
            get
            {
                return _fdigit.ToString() + _letter + _sdigit.ToString();
            }
        }

        /// <summary>
        /// Пустой конструктор объекта класса FolderID
        /// </summary>
        public FolderID()
        {
            _fdigit = 0;
            _sdigit = 0;
            _letter = "";
            _motherFolder = "";
            _rome = "";
        }

        /// <summary>
        /// Конструктор объекта класса FolderID
        /// </summary>
        /// <param name="MotherFolder">Исходная папка архива фильмов</param>
        /// <param name="Fdigit">Первая часть индекса - подраздел архива</param>
        /// <param name="Letter">Буква - раздел архива</param>
        /// <param name="Sdigit">Втора цифра в индеске - номер архивнго диска</param>
        /// <param name="Rome">Римская цифра - папка на архивном диске</param>
        public FolderID(string MotherFolder, int Fdigit,string Letter, int Sdigit,string Rome)
        {
            this.MotherFolder = MotherFolder;
            this.Fdigit = Fdigit;
            this.Letter = Letter;
            this.Sdigit = Sdigit;
            this.Rome = Rome;

        }

        /// <summary>
        /// Возвращает полный путь с учётом папки на архивном диске
        /// </summary>
        /// <returns></returns>
        public string GetFullPath()
        {
            string Temp = "";

            Temp += this.MotherFolder;
            Temp += @"\" + _letter + @"\" + _fdigit.ToString() + _letter + @"\" + this.DiskFolder + @"\" + _rome;
            return Temp;
        }

        /// <summary>
        /// Увеличение номера подраздела
        /// </summary>
        public void IncFdigit()
        {
            this._fdigit++;
        }

        /// <summary>
        /// Увеличение номера архивного диска
        /// </summary>
        public void IncSdigit()
        {
            this._sdigit++;
        }

        /// <summary>
        /// Увеличение номера папки на архивном диске
        /// </summary>
        public void IncRome()
        {
            string[] AllRome = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "XII", "XIII" };

            for(int i=0;i<AllRome.Length;i++)
            {
                if (this._rome==AllRome[i])
                {
                    this._rome = AllRome[++i];
                    break;
                }
            }



        }

        /// <summary>
        /// Увеличение индекса раздела архива
        /// </summary>
        public void IncLetter()
        {
            char Temp = this._letter[0];
            Temp++;
            this._letter = Temp.ToString();

        }

        //TODO: Сделать такие методы
        public FolderID GetIncFdigit()
        {
            FolderID temp = new FolderID(MotherFolder, Fdigit, Letter, Sdigit, Rome);
            temp.IncFdigit();
            return temp;
        }

    }
}
