using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPax
{
    public class ClassIndex : IComparable
    {
        private string _ClassAbbreviation = "";
        private string _ClassName = "";
        private decimal _Index = 0;

        public ClassIndex()
        {   

        }

        public ClassIndex(string ClassAbbreviation, decimal Index)
        {
            _ClassAbbreviation = ClassAbbreviation;
            _Index = Index;
        }

        public ClassIndex(string ClassAbbreviation, decimal Index, string ClassName)
        {
            _ClassAbbreviation = ClassAbbreviation;
            _Index = Index;
            _ClassName = ClassName;
        }


        public string ClassAbbreviation
        {
            get
            {
                return _ClassAbbreviation;
            }
            set
            {
                _ClassAbbreviation = value;
            }
        }

        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                _ClassName = value;
            }
        }

        public decimal Index
        {
            get
            {
                return _Index;
            }
            set
            {
                _Index = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is ClassIndex)
                return this.ClassAbbreviation.CompareTo(((ClassIndex)obj).ClassAbbreviation);
            else
                return 0;
        }
    }
}
