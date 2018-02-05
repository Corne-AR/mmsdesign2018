using AMS.Data.IO;
using AMS_Script.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS_Script
{
    public static class ScriptManager
    {
        private static aFile ScriptFileName = new aFile("AMS Script", AMS.Settings.Program.Directories.Data, AMS.Data.DataType.Data);
        private static aFile FactorFileName = new aFile("AMS Script Factors", AMS.Settings.Program.Directories.Data, AMS.Data.DataType.Data);

        public static Commands.Variable ABSAFx { get { return FactorList.Where(x => x.Name == "AbsaFx").FirstOrDefault(); } }
        public static Commands.Variable ExportFx { get { return FactorList.Where(x => x.Name == "ExportGpsUSD").FirstOrDefault(); } }

        private static HashSet<Commands.Variable> factorList;
        public static HashSet<Commands.Variable> FactorList
        {
            get
            {
                List<Commands.Variable> list = (List<Commands.Variable>)AMS.IO.XML_v1.Reader<List<Commands.Variable>>(FactorFileName.FullName);

                if (list == null) list = new List<Commands.Variable>();
                if (factorList == null) factorList = new HashSet<Commands.Variable>();

                list = list.OrderBy(i => i.Name).ToList();
                foreach (var i in list)
                    factorList.Add(i);

                return factorList;
            }
        }

        private static HashSet<aScript> scriptList;
        /// <summary>
        /// Gets AMS Script List
        /// </summary>
        public static HashSet<aScript> GetScriptList()
        {
            List<aScript> sList = (List<aScript>)AMS.IO.XML_v1.Reader<List<aScript>>(ScriptFileName.FullName);

            if (sList == null) sList = new List<aScript>();
            if (scriptList == null) scriptList = new HashSet<aScript>();

            sList = sList.OrderBy(i => i.Name).ToList();
            foreach (var i in sList)
                scriptList.Add(i);

            return scriptList;
        }

        public static aScript GetScript(string Name)
        {
            return (from i in GetScriptList()
                    where i.Name == Name
                    select i).FirstOrDefault();
        }

        public static void Save()
        {
            AMS.IO.XML_v1.Writter<HashSet<aScript>>(scriptList, ScriptFileName, "", true);
            AMS.IO.XML_v1.Writter<HashSet<Commands.Variable>>(factorList, FactorFileName, "", true);
        }

        public static void Save(aScript Script)
        {
            var queryList = (from i in scriptList
                             where i.Name == Script.Name
                             select i).FirstOrDefault();

            if (queryList == null) scriptList.Add(Script);
            else queryList = Script;

            Save();
        }

        public static void EditScript(aScript Script)
        {
            using (Forms.ScriptEditor f = new Forms.ScriptEditor(Script))
                f.ShowDialog();
        }

        internal static void Remove(aScript script)
        {
            var queryList = (from i in scriptList
                             where i.Name == script.Name
                             select i).FirstOrDefault();

            if (queryList != null) scriptList.Remove(script);

            Save();
        }

        public static void EditFactors()
        {
            using (Forms.FactorEditor f = new Forms.FactorEditor(FactorList))
            {
                f.ShowDialog();
                if (f.FactorList != null) factorList = f.FactorList;
            }

            Save();
        }
    }
}
