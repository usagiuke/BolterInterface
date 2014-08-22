// file:	Resources.cs
//
// summary:	Implements the resources class

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A resources. </summary>
    ///
    

    [SecuritySafeCritical]
    public class Resources : IResources
    {
        /// <summary>   The items. </summary>
        private IDictionary _Items;
        /// <summary>   Full pathname of the file. </summary>
        private string _path;

        /// <summary>   Constructor. </summary>
        ///
        
        ///
        /// <param name="path" type="string">   Full pathname of the file. </param>

        public Resources(string path)
        {
            _path = path;
        }

        /// <summary>   Gets the items. </summary>
        ///
        /// <value> The items. </value>

        public IDictionary Items
        {
            get
            {
                return _Items ?? (_Items = ReadFromBinaryFile<Dictionary<int, string>>(_path));
            }
        }

        /// <summary>   Reads from binary file. </summary>
        ///
        
        ///
        /// <tparam name="T">   Generic type parameter. </tparam>
        /// <param name="filePath" type="string">   Full pathname of the file. </param>
        ///
        /// <returns>   The data that was read from the binary file. </returns>

        public T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
