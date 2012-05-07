using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPax
{
    public class RTP
    {
        public RTP()
        {
            _ClassIndexes = new List<ClassIndex>();
            _IndexedClassPrefixes = new List<string>();
        }
        
        private List<ClassIndex> _ClassIndexes = null;

        public List<ClassIndex> ClassIndexes
        {
            get
            {
                return _ClassIndexes;
            }
        }

        private List<string> _IndexedClassPrefixes = null;

        public List<string> IndexedClassPrefixes
        {
            get
            {
                return _IndexedClassPrefixes;
            }
        }

        public void AddClassIndex(string ClassAbbreviation, decimal Index)
        {
            AddClassIndex(ClassAbbreviation, Index, "");
        }

        public void AddClassIndex(string ClassAbbreviation, decimal Index, string ClassName)
        {
            string sAcceptableIndexedClassPrefixes = System.Configuration.ConfigurationManager.AppSettings["indexedClassPrefixes"];
            if (string.IsNullOrEmpty(sAcceptableIndexedClassPrefixes))
            {
                sAcceptableIndexedClassPrefixes = "";
            }
            List<string> lstAcceptableIndexedClassPrefixes = sAcceptableIndexedClassPrefixes.Split(',').ToList();
            //check if the index is zero (in that case count it as an indexed class prefix)
            if (Index == 0 || lstAcceptableIndexedClassPrefixes.Contains(ClassAbbreviation))
            {
                AddIndexedClassPrefix(ClassAbbreviation);
            }
            else
            {
                ClassIndex ci = new ClassIndex(ClassAbbreviation, Index, ClassName);
                if (!_ClassIndexes.Exists(delegate(ClassIndex obj) { return obj.ClassAbbreviation == ci.ClassAbbreviation; }))
                {
                    _ClassIndexes.Add(ci);
                }
                else
                {
                    throw new ApplicationException(string.Format("Class '{0}' already exists.", ClassAbbreviation));
                }
            }
        }

        public void AddIndexedClassPrefix(string IndexedClassPrefix)
        {
            if (!_IndexedClassPrefixes.Contains(IndexedClassPrefix))
            {
                _IndexedClassPrefixes.Add(IndexedClassPrefix);
            }
            else
            {
                throw new ApplicationException(string.Format("PAX class '{0}' already exists.", IndexedClassPrefix));
            }
        }

        public decimal FindIndex(string ClassAbbreviation)
        {
            foreach (ClassIndex ci in _ClassIndexes)
            {
                if (ci.ClassAbbreviation.ToLower() == ClassAbbreviation.ToLower())
                {
                    return ci.Index;
                }
            }
            //loop thru each indexed class prefix.
            foreach (string prefix in _IndexedClassPrefixes)
            {
                foreach (ClassIndex ci in _ClassIndexes)
                {
                    if ((prefix.ToLower() + ci.ClassAbbreviation.ToLower()) == ClassAbbreviation.ToLower())
                    {
                        return ci.Index;
                    }
                }
            }
            throw new RTPClassNotFoundException(string.Format("Class '{0}' could not be found", ClassAbbreviation));
        }
    }

    public class RTPClassNotFoundException : ApplicationException
    {
        public RTPClassNotFoundException() { }
        public RTPClassNotFoundException(string message) : base(message) { }
        public RTPClassNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected RTPClassNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
