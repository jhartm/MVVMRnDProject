using MVVMRnDProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MVVMRnDProject.External
{
    public static class ConfigLoader
    {
        public static void LoadData()
        {
            List<DeviceModel> list = new List<DeviceModel>();

            XmlDocument config = new XmlDocument();
            config.Load("config.xml");
            XmlNode root = config.DocumentElement;

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(config.NameTable);
            nsmgr.AddNamespace("hc", "q:hosts-schema");

            //XmlNode root = config["HostConfig"];

            Console.WriteLine(root.Name);

            XmlNodeList nodeList = root.SelectNodes("hc:Device", nsmgr);

            XmlNode deviceNode = root.SelectSingleNode("hc:Device[@deviceName='Parvus'][1]", nsmgr);

            XmlNodeList portNode = deviceNode.SelectNodes("hc:Port", nsmgr);

            XmlNode portNode2 = root.SelectSingleNode("//hc:Device/hc:Port[@portName='hagPort1'][1]", nsmgr);

            Console.WriteLine(deviceNode.Name);

            //return list;
        }

    }
}
