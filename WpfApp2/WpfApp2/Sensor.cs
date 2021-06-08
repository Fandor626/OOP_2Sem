using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lab_4
{
    public class Sensor : IXmlSerializable
    {
        private string type;
        private int range;
        private int curentValue;

        public override string ToString()
        {
            return $"{Type}, {Range}, {CuretValue}" ;
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value ?? throw new ArgumentNullException("This field can't be empty");
            }
        }

        public int Range
        {
            get
            {
                return range;
            }
            set
            {
                if (value > 1)
                {
                    range = value;
                }
                else throw new ArgumentException("Range can't be less than 1");
            }
        }
        public int CuretValue
        {
            get
            {
                return curentValue;
            }
            set
            {
                if (value > 1)
                {
                    curentValue = value;
                }
                else throw new ArgumentException("Curent value can't be less than 1");
            }
        }
        public XmlSchema GetSchema() 
        {
            return null;
        }

        public void ReadXml(XmlReader reader) 
        {
            while (reader.Read()) 
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name)
                    {
                        case "Type":
                            reader.Read();
                            type = reader.Value;
                            break;
                        case "Range":
                            reader.Read();
                            range = Int32.Parse(reader.Value);
                            break;
                        case "CurentValue":
                            reader.Read();
                            curentValue = Int32.Parse(reader.Value);
                            break;
                    }
                }

                if (reader.Name.Equals("Sensor")) 
                {
                    break;
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Sensor");
            writer.WriteElementString("Type",type);
            writer.WriteElementString("Range",range.ToString());
            writer.WriteElementString("CurentValue",curentValue.ToString());
            writer.WriteEndElement();
        }

        public static List<Sensor> ReadSensorList(string fileName)
        {
            List<Sensor> sensors = new List<Sensor>();
            if (File.Exists(fileName))
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    reader.MoveToContent();
                    while (reader.Read())
                    {
                        if (reader.IsStartElement() && !reader.Name.Equals("Sensors"))
                        {
                            Sensor sensor = new Sensor();
                            sensor.ReadXml(reader);
                            sensors.Add(sensor);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return sensors;
        }
        public static void WriteSensorToFile(string fileName, List<Sensor> sensors)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = true;
            settings.ConformanceLevel = ConformanceLevel.Auto;

            XmlWriter xmlWriter = XmlWriter.Create(fileName, settings);
            xmlWriter.WriteStartElement("Sensors");
            sensors.ForEach(sensor =>
            {
                sensor.WriteXml(xmlWriter);
            });
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
    }
}
