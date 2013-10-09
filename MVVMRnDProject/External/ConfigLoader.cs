using MVVMRnDProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;

namespace MVVMRnDProject.External
{
    public class ConfigLoader
    {
        readonly List<PortModel> _ports;

        public ConfigLoader()
        {
            _ports = LoadData("Data/config2.xml");
        }

        static Stream GetResourceStream(string resourceFile)
        {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }

        static List<PortModel> LoadData(string dataFile)
        {
            List<PortModel> list = new List<PortModel>();

            Stream stream = GetResourceStream(dataFile);
            XmlReader xmlReader = new XmlTextReader(stream);

            foreach (XElement portElement in XDocument.Load(xmlReader).Element("HostConfig").Elements("Port"))
            {
                list.Add(PortModel.CreatePort(
                    (string)portElement.Attribute("portOwner"),
                    (string)portElement.Attribute("portName"),
                    (string)portElement.Attribute("address")));
            }

            return list;
        }

        public List<PortModel> GetData()
        {
            return new List<PortModel>(_ports);
        }
    }
}
