using System;
using System.Collections.Generic;
using System.Text;

namespace MigalkovDataSpace
{
	public class FilmEntry
	{
     WikiCard _thiscard;
     FolderID _thisfolder;
        Guid uid;

        public WikiCard ThisCard
     {
            get
         {
             return this._thiscard;
         }
            set
         {
             this._thiscard = value;
         }
     }

        public FolderID ThisFolder
        {
            get
            {
                return this._thisfolder;
            }
            set
            {
                this._thisfolder = value;
            }
        }

        public string Id
        {
            get
            {
                return uid.ToString();
            }
        }



     public FilmEntry()
     {
         this.ThisCard = new WikiCard();
         this.ThisFolder = new FolderID();
            this.uid = Guid.NewGuid();
     }



    }
}
