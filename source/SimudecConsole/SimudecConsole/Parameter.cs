using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimudecConsole
{
    class Parameter
    {
        private string mId;
        private int mValue;

        public Parameter(string _Id, int _initialValue = 0)
        {
            mId = _Id;
            mValue = _initialValue;
        }

        /// <summary>
        /// Properties
        /// </summary>
        public string Id
        {
            get { return mId; }
            set { mId = value; }
        }

        public int Value
        {
            get { return mValue; }
            set { mValue = value; }
        }
    }
}
