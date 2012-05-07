using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPax
{
    public class Driver
    {
        private List<Run> _Runs = null;
        private string _ClassAbbreviation = "";
        private string _IndexedClassPrefix = "";
        private string _Number = "";
        private string _Name = "";
        private string _Car = "";
        private decimal _Index = 1;
        private decimal _BestTimeSplit1 = 0;
        private decimal _BestTimeSplit2 = 0;

        public Driver()
        {
            _Runs = new List<Run>();
        }

        public Driver(string ClassAbbreviation, string Number, string Name, string Car, decimal Index, string IndexedClassPrefix)
        {
            _Runs = new List<Run>();
            _ClassAbbreviation = ClassAbbreviation;
            _Number = Number;
            _Name = Name;
            _Car = Car;
            _Index = Index;
            _IndexedClassPrefix = IndexedClassPrefix;
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

        public string IndexedClassPrefix
        {
            get
            {
                return _IndexedClassPrefix;
            }
            set
            {
                _IndexedClassPrefix = value;
            }
        }

        public string Number
        {
            get
            {
                return _Number;
            }
            set
            {
                _Number = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Car
        {
            get
            {
                return _Car;
            }
            set
            {
                _Car = value;
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

        public decimal BestTimeSplit1
        {
            get 
            {
                return _BestTimeSplit1;
            }
        }

        public decimal BestTimeSplit2
        {
            get 
            {
                return _BestTimeSplit2;
            }
        }

        public decimal TimeCombined
        {
            get
            {
                if (_BestTimeSplit1 == decimal.MaxValue || _BestTimeSplit2 == decimal.MaxValue)
                {
                    return decimal.MaxValue;
                }
                else
                {
                    return _BestTimeSplit1 + _BestTimeSplit2;
                }
            }
        }


        public List<Run> Runs
        {
            get
            {
                return _Runs;
            }
        }

        public Run AddRun(int RunNumber, decimal RawTime, int Penalties, bool DNF)
        {
            Run _rr = new Run(RunNumber, RawTime, Penalties, DNF);
            _rr.CalculateTimeUsingRawAndPenalties();
            _rr.CalculatePAXTime(this.Index);
            _Runs.Add(_rr);

            return _rr;
        }

        public Run AddRun(int RunNumber, decimal RawTime, int Penalties, bool DNF, decimal Time)
        {
            Run _rr = new Run(RunNumber, RawTime, Penalties, DNF, Time);
            _rr.CalculatePAXTime(this.Index);
            _Runs.Add(_rr);

            return _rr;
        }

        public void CalculateBestTimes(int NumberRunsSplit1, int NumberRunsSplit2, int MaxRuns)
        {
            //reset best times.
            _BestTimeSplit1 = decimal.MaxValue;
            _BestTimeSplit2 = decimal.MaxValue;

            //default sort is by run number.
            _Runs.Sort();

            //get best time for split 1
            for (int xx = 0; xx < NumberRunsSplit1; xx++)
            {
                if (!(_Runs.Count <= xx))
                {
                    if (_Runs[xx].PAXTime < _BestTimeSplit1 && !_Runs[xx].DNF)
                    {
                        _BestTimeSplit1 = _Runs[xx].PAXTime;
                    }
                }
            }
            //set time to zero if the number of runs in the split is zero.
            if (NumberRunsSplit1 == 0)
            {
                _BestTimeSplit1 = 0;
            }

            //get best time for split 2
            for (int xx = NumberRunsSplit1; xx < (NumberRunsSplit1 + NumberRunsSplit2); xx++)
            {
                if (!(_Runs.Count <= xx))
                {
                    if (_Runs[xx].PAXTime < _BestTimeSplit2 && !_Runs[xx].DNF)
                    {
                        _BestTimeSplit2 = _Runs[xx].PAXTime;
                    }
                }
            }
            //set time to zero if the number of runs in the split is zero or if the number of runs is less then or equal to the number of runs in split 1.
            if (NumberRunsSplit2 == 0 || MaxRuns <= NumberRunsSplit1)
            {
                _BestTimeSplit2 = 0;
            }

        }

    }
}
