using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProPax
{
    public class Axware
    {
        public static readonly int PAX_DEF_COL_INDEX_CLASS_ABREV = 0;
        public static readonly int PAX_DEF_COL_INDEX_INDEX = 1;
        public static readonly int PAX_DEF_COL_INDEX_CLASS_NAME = 3;

        public static Competition ImportStagingFile(string Filename, RTP rtp)
        {
            if (!File.Exists(Filename))
            {
                throw new ApplicationException(string.Format("File '{0}' could not be found", Filename));
            }

            Competition cc = new Competition(rtp);

            StreamReader reader = File.OpenText(Filename);

            Exception expSave = null;
            string sErrors = "";
            try
            {
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    try
                    {
                        //skip lines that don't start with "run"
                        if (line.IndexOf("_run_") > -1)
                        {
                            string run = GetStagingFileValue(line, "run", "");
                            string penalty = GetStagingFileValue(line, "penalty", "0");
                            string time = GetStagingFileValue(line, "tm", "");
                            int iRun;
                            decimal iTime;

                            if (int.TryParse(run, out iRun) && decimal.TryParse(time, out iTime))
                            {
                                //parse numbers.
                                int iPenalty;
                                if (!int.TryParse(penalty, out iPenalty))
                                {
                                    iPenalty = 0;
                                }

                                //ignore non-critical fields.
                                string sCar = "";
                                string sDriver = "";
                                try
                                {
                                    sDriver = GetStagingFileValue(line, "driver");
                                    sCar = GetStagingFileValue(line, "car");
                                }
                                catch (KeyNotFoundException kexp)
                                {
                                    //noop
                                }
                                Driver dd = cc.AddOrGetDriver(GetStagingFileValue(line, "class"), GetStagingFileValue(line, "number"), sDriver, sCar);
                                if (penalty.ToUpper() == "DNF")
                                {
                                    dd.AddRun(iRun, 0, 0, true);
                                }
                                else
                                {
                                    dd.AddRun(iRun, iTime, iPenalty, false);
                                }
                            }
                        }
                    }
                    catch (KeyNotFoundException kexp)
                    {
                        sErrors += "Failed to find a key value in line (results may not be accurate): \r\n" + line + "\r\n\r\n";
                    }
                }

                if (sErrors.Length > 0)
                {
                    throw new StagingFileParsingException(sErrors);
                }
            }
            catch (Exception exp)
            {
                expSave = exp;
            }
            finally
            {
                reader.Close();
                reader = null;
            }

            if (expSave != null)
            {
                throw expSave;
            }

            cc.CalculateBestTimes();

            return cc;
        }

        public static string GetStagingFileValue(string Line, string Key)
        {
            int keyIndex = Line.IndexOf("_" + Key + "_");
            if (keyIndex > -1 && (keyIndex + Key.Length + 2) < Line.Length)
            {
                string tmp = Line.Substring(keyIndex + Key.Length + 2);
                int endIndex = tmp.IndexOf("_");
                if (endIndex > -1)
                {
                    return tmp.Substring(0, endIndex);
                }
                else
                {
                    return tmp;
                }
            }
            else
            {
                throw new KeyNotFoundException("Key not found.");
            }
        }

        public static string GetStagingFileValue(string Line, string Key, string DefaultValue)
        {
            int keyIndex = Line.IndexOf("_" + Key + "_");
            if (keyIndex > -1 && (keyIndex + Key.Length + 2) < Line.Length)
            {
                string tmp = Line.Substring(keyIndex + Key.Length + 2);
                return tmp.Substring(0, tmp.IndexOf("_"));
            }
            else
            {
                return DefaultValue;
            }
        }

        public static RTP ImportRTP(string Filename)
        {
            if (!File.Exists(Filename))
            {
                throw new ApplicationException(string.Format("File '{0}' could not be found", Filename));
            }

            RTP _rtp = new RTP();

            StreamReader reader = File.OpenText(Filename);

            Exception expSave = null;
            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] values = line.Split(new char[] { '\t' });

                    _rtp.AddClassIndex(values[PAX_DEF_COL_INDEX_CLASS_ABREV].ToUpper(), Convert.ToDecimal(values[PAX_DEF_COL_INDEX_INDEX]), values[PAX_DEF_COL_INDEX_CLASS_NAME]);
                }
            }
            catch (Exception exp)
            {
                expSave = exp;
            }
            finally
            {
                reader.Close();
                reader = null;
            }

            if (expSave != null)
            {
                throw expSave;
            }

            return _rtp;
        }

        public static RTP AutoImport()
        {
            FileInfo fiDefinition = null;

            List<FileInfo> lstFiles = GetDefinitionFiles("");

            //select first option if any were found.
            if (lstFiles.Count > 0)
            {
                fiDefinition = lstFiles[0];
            }

            //check if we found a file, if so do import.
            if (fiDefinition != null)
            {
                return ImportRTP(fiDefinition.FullName);
            }
            else
            {
                return null;
            }
        }

        public static List<FileInfo> GetDefinitionFiles(string FirstChoiceDirectoryName)
        {
            FileInfo fiDefinition = null;
            List<FileInfo> lstFI = new List<FileInfo>();

            //try passed in directory first.
            if (Directory.Exists(FirstChoiceDirectoryName))
            {
                fiDefinition = GetDefinitionFile(FirstChoiceDirectoryName);
                if (fiDefinition != null)
                {
                    lstFI.Add(fiDefinition);
                }
            }

            //try location stored in the registry next.
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\AXWare Systems");
            if (rk != null)
            {
                object val = rk.GetValue("InstallLocation");
                if (val != null)
                {
                    fiDefinition = GetDefinitionFile(val.ToString());
                    if (fiDefinition != null)
                    {
                        lstFI.Add(fiDefinition);
                    }
                }
            }
            
            //try current path.
            fiDefinition = GetDefinitionFile(System.Windows.Forms.Application.ExecutablePath);
            if (fiDefinition != null)
            {
                lstFI.Add(fiDefinition);
            }

            return lstFI;
        }

        protected static FileInfo GetDefinitionFile(string DirectoryName)
        {
            FileInfo fiResult = null;
            if (Directory.Exists(DirectoryName))
            {
                //search for ".def" files.
                DirectoryInfo di = new DirectoryInfo(DirectoryName);
                foreach(FileInfo fi in di.GetFiles("*.def").OrderByDescending(oo => oo.CreationTime)) 
                {
                    fiResult = fi;
                    break;
                }
            }
            return fiResult;
        }
    }

    public class KeyNotFoundException : ApplicationException
    {
        public KeyNotFoundException() { }
        public KeyNotFoundException(string message) : base(message) { }
        public KeyNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected KeyNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class StagingFileParsingException : ApplicationException
    {
        public StagingFileParsingException() { }
        public StagingFileParsingException(string message) : base(message) { }
        public StagingFileParsingException(string message, Exception inner) : base(message, inner) { }
        protected StagingFileParsingException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
