using AMS.Data;
using AMS.Data.IO;
using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Catalogs
{
    public class CatalogGroupManager
    {
        private static aFile catalogGroupFileName = new aFile("Catalog Groups", AMS.Settings.Program.Directories.Data, AMS.Data.DataType.Data);
        private static aFile groupReportFilename = new aFile("Catalog Group Reports", AMS.Settings.Program.Directories.Data, DataType.Data);


        public Dictionary<string, string> GroupReport
        {
            get
            {
                if (groupreport == null)
                {
                    groupreport = new Dictionary<string, string>();

                    var list = (List<Group>)AMS.IO.XML_v1.Reader<List<Group>>(groupReportFilename.FullName);
                    if (list != null)
                    {
                        foreach (var i in list)
                            groupreport.Add(i.Name, i.Report);
                    }

                }
                return groupreport;
            }
        }
        private Dictionary<string, string> groupreport;

        private HashSet<string> catalogGroup;
        public HashSet<string> CatalogGroup
        {
            get
            {
                List<string> list = (List<string>)AMS.IO.XML_v1.Reader<List<string>>(catalogGroupFileName.FullName);

                if (list == null) list = new List<string>();
                if (catalogGroup == null) catalogGroup = new HashSet<string>();

                list = list.OrderBy(i => i).ToList();
                foreach (var i in list)
                    catalogGroup.Add(i);

                return catalogGroup;
            }
        }


        public bool SaveReportMapping()
        {
            // Dictionary<string, string> not supported by XML Serializing

            var list = new List<Group>();
            foreach (var g in GroupReport)
                list.Add(new Group
                {
                    Name = g.Key,
                    Report = g.Value
                });

            return AMS.IO.XML_v1.Writter<List<Group>>(list, groupReportFilename, "", true);
        }

        public bool Save()
        {
            return AMS.IO.XML_v1.Writter<HashSet<string>>(catalogGroup, catalogGroupFileName, "", true);
        }

        public void AddGroup(string GroupName)
        {
            if (catalogGroup == null) catalogGroup = new HashSet<string>();

            catalogGroup.Add(GroupName);

            Save();
        }

        public void RenameGroup(string OldName, string NewName)
        {
            var catalist = Data.DMS.CatalogManager.GetDataList(i => i.CatalogGroup == OldName);

            if (catalist == null || catalist.Count == 0)
            {
                AMS.MessageBox_v2.Show(OldName + " catalog group is empty.");
                return;
            }

            catalogGroup.Remove(OldName);
            AddGroup(NewName);

            foreach (var i in catalist)
            {
                i.CatalogGroup = NewName;
                i.Save(true);
            }
        }

        public class Group
        {
            public string Name { get; set; }
            public string Report { get; set; }
        }
    }
}