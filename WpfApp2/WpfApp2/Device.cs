using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Lab_4
{
    public class Device : IXmlSerializable
    {
        private QuantitiesType quantitiesType;
        private Sensor sensor;
        private DateTime dateOfCalibrating;
        private int numb;

        public QuantitiesType QuantitiesType
        {
            get
            {
                return quantitiesType;
            }
            set
            {
                quantitiesType = value;
            }
        }
        
        public Sensor Sensor 
        {
            get
            {
                return sensor;
            }
            set
            {
                sensor = value ?? throw new ArgumentNullException(" This field can't be empty");
            }
        }

        public DateTime DateOfCalibrating
        {
            get
            {
                return dateOfCalibrating;
            }
            set 
            {
                if (value < DateTime.Now)
                {
                    dateOfCalibrating = value;
                }
                else throw new ArgumentException(" Wrong calibration date");
            }
        }
        public int Numb
        {
            get
            {
                return numb;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException(" Mounting number can't be less 0 and more 10 ");
                }
                else
                {
                    numb = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Type {Sensor.Type}, Range{Sensor.Range},Curent Value{Sensor.CuretValue},Quantities type {QuantitiesType}, Mounting number{Numb}";
        }
        public static List<Device> ReadSensorList(XmlReader reader)
        {
            List<Device> devices = new List<Device>();
            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.IsStartElement() && !reader.Name.Equals("Devices"))
                {
                    Device device = new Device();
                    device.ReadXml(reader);
                    devices.Add(device);
                }
                else
                {
                    break;
                }
            }
            return devices;
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
                        case "Sensor":
                            sensor = new Sensor();
                            sensor.ReadXml(reader);
                            break;

                        case "QuantitiesType":
                            reader.Read();
                            quantitiesType = (QuantitiesType)Enum.Parse(typeof(QuantitiesType), reader.Value);
                            break;

                        case "DateOfCalibrating":
                            reader.Read();
                            dateOfCalibrating = DateTime.Parse(reader.Value);
                            break;

                        case "Numb":
                            reader.Read();
                            numb = Int32.Parse(reader.Value);
                            break;
                    }
                }
                if (reader.Name.Equals("Device"))
                {
                    break;
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Device");
            sensor.WriteXml(writer);
            writer.WriteElementString("Quantities Type",quantitiesType.ToString());
            writer.WriteElementString("Date of calibrating",dateOfCalibrating.ToString());
            writer.WriteElementString("Mounting number",numb.ToString());
            writer.WriteEndElement();
        }

        public static void WriteDevicesToFile(string fileName, List<Device> sensors)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.NewLineOnAttributes = true;
            settings.ConformanceLevel = ConformanceLevel.Auto;

            XmlWriter xmlWriter = XmlWriter.Create(fileName,settings);
            xmlWriter.WriteStartElement("Devices");
            sensors.ForEach(device => 
            {
                device.WriteXml(xmlWriter);
            });
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
    }
}
