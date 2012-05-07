using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProPax
{
    public class Run : IComparable
    {
        private decimal _RawTime = 0;
        private int _Penalties = 0;
        private decimal _Time = 0;
        private int _RunNumber = 0;
        private decimal _PAXTime = 0;
        private bool _DNF = false;

        public Run()
        {
            
        }

        public Run(int RunNumber, decimal RawTime, int Penalties, bool DNF)
        {
            _RunNumber = RunNumber;
            _RawTime = RawTime;
            _Penalties = Penalties;
            _DNF = DNF;
            CalculateTimeUsingRawAndPenalties();
        }

        public Run(int RunNumber, decimal RawTime, int Penalties, bool DNF, decimal Time)
        {
            _RunNumber = RunNumber;
            _RawTime = RawTime;
            _Penalties = Penalties;
            _DNF = DNF;
            _Time = Time;
        }

        public decimal RawTime
        {
            get
            {
                return _RawTime;
            }
            set
            {
                _RawTime = value;
            }
        }

        public int Penalties
        {
            get
            {
                return _Penalties;
            }
            set
            {
                _Penalties = value;
            }
        }

        public decimal Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }

        public int RunNumber
        {
            get
            {
                return _RunNumber;
            }
            set
            {
                _RunNumber = value;
            }
        }

        public bool DNF
        {
            get
            {
                return _DNF;
            }
            set
            {
                _DNF = value;
            }
        }

        public decimal PAXTime
        {
            get
            {
                return _PAXTime;
            }
        }


        public void CalculateTimeUsingRawAndPenalties()
        {
            _Time = _RawTime + (_Penalties * 2);
        }

        public void CalculatePAXTime(decimal Index)
        {
            //NOTE: Rounding/truncating is done here (you WILL get different results if you change the number of decimals when rounding.)
            //  AXWare seems to truncate so I'll do that too.
            //_PAXTime = (_Time * Index);
            //_PAXTime = Math.Round(_Time * Index, 3);
            //_PAXTime = Math.Truncate(((_Time * Index) * 1000)) / 1000;

            //round to 4 places then truncate to mimic AXWare.
            _PAXTime = Math.Round(_Time * Index, 4);
            _PAXTime = Math.Truncate((_PAXTime * 1000)) / 1000;
        }

        public int CompareTo(object obj)
        {
            if (obj is Run)
                return this.RunNumber.CompareTo(((Run)obj).RunNumber);
            else
                return 0;
        }
    }
}
