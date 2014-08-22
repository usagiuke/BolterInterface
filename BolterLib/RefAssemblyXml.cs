using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BolterLib
{
    public class XmlSerializationHelper
    {
        /// <summary>   true this object to the given stream. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="filename"> Filename of the file. </param>
        /// <param name="obj">      The object. </param>

        public static void Serialize<T>(string filename, T obj)
        {
            var xs = new XmlSerializer(typeof(T));

            var dir = Path.GetDirectoryName(filename);

            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using (var sw = new StreamWriter(filename))
            {
                xs.Serialize(sw, obj);
            }
        }

        /// <summary>   true this object to the given stream. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="filename"> Filename of the file. </param>
        ///
        /// <returns>   A T. </returns>

        public static T Deserialize<T>(string filename)
        {
            try
            {
                var xs = new XmlSerializer(typeof(T));

                using (var rd = new StreamReader(filename))
                {
                    return (T)xs.Deserialize(rd);
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }


    [Serializable]
    public class Imports
    {
        [XmlElement("Module")]
        public List<Module> Modules = new List<Module>();
    }


    [Serializable]
    public class Module
    {
        [XmlAttribute("Name")]
        public string Name;
    }
}
