using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;

namespace MudkipzCraft
{
    public class Config : XmlSerializer
    {
        const string CONFIG_FILE = "config.xml";
        public string ListenIP { get; set; }
        public int ListenPort { get; set; }
        public bool OnlineMode { get; set; }
        public int MaxPlayers { get; set; }
        public bool SpawnAnimals { get; set; }
        public bool SpawnMonsters { get; set; }

        public Config()
        {
            ListenIP = "0.0.0.0";
            ListenPort = 25565;
            OnlineMode = false;
            MaxPlayers = 16;
            SpawnAnimals = true;
            SpawnMonsters = true;
        }

        public Config Load()
        {
            if (File.Exists(CONFIG_FILE))
            {
                StreamReader sr = new StreamReader(CONFIG_FILE);
                XmlTextReader xr = new XmlTextReader(sr);
                XmlSerializer xs = new XmlSerializer(this.GetType());
                object c;
                if (xs.CanDeserialize(xr))
                {
                    c = xs.Deserialize(xr);
                    Type t = this.GetType();
                    PropertyInfo[] properties = t.GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        p.SetValue(this, p.GetValue(c, null), null);
                    }
                }
                xr.Close();
                sr.Close();
            }
            else
            {
                Logger.Warn("Configuration file not found - loading defaults.");
            }
            return this;
        }

        public void Save()
        {
            try
            {
                StreamWriter w = new StreamWriter(CONFIG_FILE);
                XmlSerializer s = new XmlSerializer(this.GetType());
                s.Serialize(w, this);
                w.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}
