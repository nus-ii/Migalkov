using System;
using System.Collections.Generic;
using System.Text;

namespace MigalkovDataSpace
{
	public class FilmList
	{
        IList<FilmEntry> _thisList;

        public IList<FilmEntry> ThisList
        {
            get
            {
                return this._thisList;
            }
            set
            {
                this._thisList = value;
            }
        }


        public void Add()
        {
            this._thisList.Add(new FilmEntry());
        }


    }
}
