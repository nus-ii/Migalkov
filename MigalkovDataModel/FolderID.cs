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
        /// "����������� �����" ���������� ����� �������
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
        /// ��������� ����� ������� - ������
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
        /// ������ "��������" ����� ������� - ���������
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
        /// ������ "��������" ����� ������� - �������� ����� ��������� �����
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
        /// ������� ����� - ���������� ����� �� �������� �����
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
        /// ������ ����������� ��������� �����
        /// </summary>
        public string DiskFolder
        {
            get
            {
                return _fdigit.ToString() + _letter + _sdigit.ToString();
            }
        }

        /// <summary>
        /// ������ ����������� ������� ������ FolderID
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
        /// ����������� ������� ������ FolderID
        /// </summary>
        /// <param name="MotherFolder">�������� ����� ������ �������</param>
        /// <param name="Fdigit">������ ����� ������� - ��������� ������</param>
        /// <param name="Letter">����� - ������ ������</param>
        /// <param name="Sdigit">����� ����� � ������� - ����� �������� �����</param>
        /// <param name="Rome">������� ����� - ����� �� �������� �����</param>
        public FolderID(string MotherFolder, int Fdigit,string Letter, int Sdigit,string Rome)
        {
            this.MotherFolder = MotherFolder;
            this.Fdigit = Fdigit;
            this.Letter = Letter;
            this.Sdigit = Sdigit;
            this.Rome = Rome;

        }

        /// <summary>
        /// ���������� ������ ���� � ������ ����� �� �������� �����
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
        /// ���������� ������ ����������
        /// </summary>
        public void IncFdigit()
        {
            this._fdigit++;
        }

        /// <summary>
        /// ���������� ������ ��������� �����
        /// </summary>
        public void IncSdigit()
        {
            this._sdigit++;
        }

        /// <summary>
        /// ���������� ������ ����� �� �������� �����
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
        /// ���������� ������� ������� ������
        /// </summary>
        public void IncLetter()
        {
            char Temp = this._letter[0];
            Temp++;
            this._letter = Temp.ToString();

        }

        //TODO: ������� ����� ������
        public FolderID GetIncFdigit()
        {
            FolderID temp = new FolderID(MotherFolder, Fdigit, Letter, Sdigit, Rome);
            temp.IncFdigit();
            return temp;
        }

    }
}
