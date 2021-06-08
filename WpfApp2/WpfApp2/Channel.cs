using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lab_4
{
    public class Channel : IXmlSerializable
    {
        public static int count=0;
        private int countChannels;
        private List<Device> _devices = new List<Device>();

        public int CountChannels
        {
            get 
            {
                return countChannels;
            }
            set
            {
                countChannels = value;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public List<Device> Devices
        {
            get 
            {
                return _devices;
            }
            set
            {
                _devices = value;
            }
        }
        public void AddDevice(Device device) 
        {
            _devices.Add(device);
        }

        public void RemoveDevice(Device device)
        {
            _devices.Remove(device);
        }

        public void ClearDevices() 
        {
            _devices.Clear();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name) 
                    {
                        case "CountChannels":
                            reader.Read();
                            countChannels = Int32.Parse(reader.Value);
                            break;
                        case "Devices":
                            _devices = Device.ReadSensorList(reader);
                            break;
                    }
                }
                if (reader.Name.Equals("Channel"))
                {
                    break;
                }
            }
        }
        public static List<Channel> ReadChannelList(string fileName)
        {
            List<Channel> channels = new List<Channel>();
            if (File.Exists(fileName))
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    reader.MoveToContent();
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && !reader.Name.Equals("Channels"))
                        {
                            Channel channel = new Channel();
                            channel.ReadXml(reader);
                            channels.Add(channel);
                        }
                        else
                        { break; }
                    }
                }
            }
            return channels;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Channel");
            writer.WriteElementString("CountChannels",countChannels.ToString());
            writer.WriteStartElement("Devices");
            if (Devices !=null)
            {
                Devices.ForEach(device =>
                {
                    device.WriteXml(writer);
                });
            }
            writer.WriteEndElement();
            writer.WriteEndElement();

        }

        public static void WriteChannelsToFile(string fileName, List<Channel> channels)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = true;
            settings.ConformanceLevel = ConformanceLevel.Auto;

            XmlWriter xmlWriter = XmlWriter.Create(fileName,settings);
            xmlWriter.WriteStartElement("Channels");
            channels.ForEach(journal =>
            {
                journal.WriteXml(xmlWriter);
            });
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        public override string ToString()
        {
            return $"Channels count: {countChannels}, Count{count}";
        }

        public string ToShortStr()
        {
            return $"Channels count: {count}";
        }
    }
}
