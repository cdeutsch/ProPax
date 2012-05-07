using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProPax
{
    public class Competition
    {
        private List<Driver> _Drivers = null;
        private int _NumberRunsSplit1 = 3;
        private int _NumberRunsSplit2 = 3;
        private RTP _CompetitionRTP = null;

        public Competition(RTP CompetitionRTP)
        {
            _CompetitionRTP = CompetitionRTP;
            _Drivers = new List<Driver>();
        }

        public List<Driver> Drivers
        {
            get
            {
                return _Drivers;
            }
            set
            {
                _Drivers = value;
            }
        }

        public int NumberRunsSplit1
        {
            get
            {
                return _NumberRunsSplit1;
            }
            set
            {
                _NumberRunsSplit1 = value;
                CalculateBestTimes();
            }
        }

        public int NumberRunsSplit2
        {
            get
            {
                return _NumberRunsSplit2;
            }
            set
            {
                _NumberRunsSplit2 = value;
                CalculateBestTimes();
            }
        }

        public Driver AddDriver(string ClassAbbreviation, string Number, string Name, string Car)
        {
            string IndexedClassPrefix = "";
            //check for a class prefix.
            foreach (string prefix in _CompetitionRTP.IndexedClassPrefixes)
            {
                if (ClassAbbreviation.ToUpper().StartsWith(prefix.ToUpper())) 
                {
                    IndexedClassPrefix = prefix;
                    break;
                }
            }

            Driver _dd = new Driver(ClassAbbreviation, Number, Name, Car, _CompetitionRTP.FindIndex(ClassAbbreviation), IndexedClassPrefix);
            _Drivers.Add(_dd);

            return _dd;
        }

        public Driver AddOrGetDriver(string ClassAbbreviation, string Number, string Name, string Car)
        {
            Driver _dd = _Drivers.SingleOrDefault(oo => oo.ClassAbbreviation == ClassAbbreviation && oo.Number == Number);
            if (_dd == null)
            {
                _dd = AddDriver(ClassAbbreviation, Number, Name, Car);
            }           
            return _dd;
        }

        public void CalculateBestTimes()
        {
            foreach (Driver dd in _Drivers)
            {
                dd.CalculateBestTimes(NumberRunsSplit1, NumberRunsSplit2, MaxRuns());
            }
        }

        public int MaxRuns()
        {
            int iMax = 0;
            foreach (Driver dd in _Drivers)
            {
                if (dd.Runs.Count() > iMax)
                {
                    iMax = dd.Runs.Count;
                }
            }
            return iMax;
        }

        /// <summary>
        /// Create a data table with each drivers runs pivoted to a single row.
        /// </summary>
        /// <returns></returns>
        public DataTable ResultsToDataTable()
        {
            ////create the table.
            DataTable dt = new DataTable();
            //add driver columns.
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Indexed Class", typeof(string));
            dt.Columns.Add("Number", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Car", typeof(string));
            dt.Columns.Add("Index", typeof(decimal));

            //add the result driver columns
            dt.Columns.Add("Best 1", typeof(decimal));
            dt.Columns.Add("Best 2", typeof(decimal));
            dt.Columns.Add("Combined", typeof(decimal));
 
            //pivot runs by adding columns for each run.
            for (int xx = 1; xx <= MaxRuns(); xx++)
            {
                dt.Columns.Add("Run " + xx.ToString(), typeof(decimal));
                dt.Columns.Add("PAX " + xx.ToString(), typeof(decimal));
            }
            
            foreach (Driver dd in _Drivers)
            {
                DataRow dr = dt.NewRow();

                dr["Class"] = dd.ClassAbbreviation;
                dr["Indexed Class"] = dd.IndexedClassPrefix;
                dr["Number"] = dd.Number;
                dr["Name"] = dd.Name;
                dr["Car"] = dd.Car;
                dr["Index"] = dd.Index;

                foreach (Run rr in dd.Runs)
                {
                    dr["Run " + rr.RunNumber.ToString()] = rr.Time;
                    dr["PAX " + rr.RunNumber.ToString()] = rr.PAXTime;
                }

                dr["Best 1"] = dd.BestTimeSplit1;
                dr["Best 2"] = dd.BestTimeSplit2;
                dr["Combined"] = dd.TimeCombined;

                dt.Rows.Add(dr);
            }
            
            return dt;
        }

        /// <summary>
        /// Create a data table with each drivers runs pivoted to a single row.
        /// </summary>
        /// <returns></returns>
        public DataView ResultsToSortedDataView()
        {
            DataView dv = new DataView(ResultsToDataTable());
            dv.Sort = "Combined ASC";
            return dv;
        }
    }
}
