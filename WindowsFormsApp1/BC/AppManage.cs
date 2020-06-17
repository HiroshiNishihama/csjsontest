using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace WindowsFormsApp1.BC
{
    [DataContract]
    class MyAppSetting
    {
        [DataMember]
        public string hostip { get; set; }

    }
    class AppManage
    {
        private MyAppSetting _setting;

        public AppManage()
        {
            _setting = new MyAppSetting();
            load();
        }

        public void load()
        {
            string jsonFilePath = @"appinfo.json";

            using (var ms = new FileStream(jsonFilePath, FileMode.Open))
            {
                var serializer = new DataContractJsonSerializer(typeof(MyAppSetting));
                _setting = (MyAppSetting)serializer.ReadObject(ms);
            }
        }

        public void save()
        {
            string jsonFilePath = @"appinfo.json";
            using (var stream = new MemoryStream())
            using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, Encoding.UTF8, true, true," "))
            using (var fs = new FileStream(jsonFilePath, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                var serializer = new DataContractJsonSerializer(typeof(MyAppSetting));
                serializer.WriteObject(writer, _setting);
                writer.Flush();
                var str2write = Encoding.UTF8.GetString(stream.ToArray());
                sw.Write(str2write);
            }
        }

        public string hostip
        {
            get
            {
                return _setting.hostip;
            }
            set
            {
                _setting.hostip = value;
            }
        }
    }
}
