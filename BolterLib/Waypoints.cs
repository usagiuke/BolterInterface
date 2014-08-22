// file:	Waypoints.cs
//
// summary:	Implements the waypoints class

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   An XML serialization helper. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    public class XmlSerializationHelper
    {
        /// <summary>   true this object to the given stream. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <tparam name="T">   Generic type parameter. </tparam>
        /// <param name="filename"> Filename of the file. </param>
        /// <param name="obj">      The object. </param>
        ///
        /// ### <typeparam name="T">    Generic type parameter. </typeparam>

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
        /// <tparam name="T">   Generic type parameter. </tparam>
        /// <param name="filename"> Filename of the file. </param>
        ///
        /// <returns>   A T. </returns>
        ///
        /// ### <typeparam name="T">    Generic type parameter. </typeparam>

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
            catch (Exception ex) 
            {
                return default(T);
            }
        }
    }

    /// <summary>   A waypoints. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    [Serializable]
    public class Waypoints
    {
        /// <summary>   The zone. </summary>
        [XmlElement("Zone")]
        public List<Zones> Zone = new List<Zones>();

        /// <summary>   Adds a path to zone to 'pathName'. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="zoneId">   Identifier for the zone. </param>
        /// <param name="pathName"> Full pathname of the file. </param>

        public void AddPathToZone(int zoneId, string pathName)
        {
            Zone.First(p => p.ID == zoneId).Path.Add(new Paths(pathName));
        }

    }

    /// <summary>   A zones. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    [Serializable]
    public class Zones
    {
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>

        public Zones()
        {

        }

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="id">   The identifier. </param>

        [SecuritySafeCritical]
        public Zones(int id)
        {
            ID = id;
            Name = Funcs.GetZoneName();
        }

        /// <summary>   Adds the points. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="pathName">                     Full pathname of the file. </param>
        /// <param name="interval">                     The interval. </param>
        /// <param name="navigator" type="Navigation">  the log. </param>

        public void AddPoints(string pathName, int interval, Navigation navigator)
        {
            if (Path.All(p => p.Name != pathName))
            {
                Path.Add(new Paths(pathName));
                Path.Last().AddPoints(interval, navigator);
            }
            else
                Path.First(p => p.Name == pathName).AddPoints(interval, navigator);
        }

        /// <summary>   The identifier. </summary>
        [XmlAttribute("ID")]
        public int ID;
        /// <summary>   The name. </summary>
        [XmlAttribute("Name")]
        public string Name;
        /// <summary>   Full pathname of the file. </summary>
        [XmlElement("Path")]
        public List<Paths> Path = new List<Paths>();
    }

    /// <summary>   A paths. </summary>
    ///
    /// <remarks>   Bunny 2, 3/14/2014. </remarks>

    [Serializable]
    public class Paths
    {
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>

        public Paths()
        {

        }

        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="pathName"> Full pathname of the file. </param>

        public Paths(string pathName)
        {
            Name = pathName;
        }

        /// <summary>   Adds the points to 'log'. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="interval">                     The interval. </param>
        /// <param name="navigator" type="Navigation">  the log. </param>

        [SecuritySafeCritical]
        public void AddPoints(int interval, Navigation navigator)
        {
            var lastHeading = 0f;
            // Save our current heading.
            if (navigator.TurnFilter)
                lastHeading = Funcs.GetHeading(EntityType.PCMob, 0);

            // Loop while record flag is true.
            while (navigator.RecordFlag)
            {
                // Get current position.
                var currentPos = Funcs.Get2DPos();

                // Get last saved position, or null if there are none.
                var lastPos = Point.LastOrDefault();

                // Check if this is a new entry, or if we have moved from our last position.
                if (lastPos == null || lastPos.x != currentPos.x || lastPos.y != currentPos.y)
                {
                    if (navigator.TurnFilter && (lastHeading == Funcs.GetHeading(EntityType.PCMob, 0)))
                    {
                        Thread.Sleep(interval);
                        continue;
                    }

                    // Add the new waypoint.
                    Point.Add(new D3DXVECTOR2(currentPos.x, currentPos.y));

                    // Save out last heading
                    if (navigator.TurnFilter)
                        lastHeading = Funcs.GetHeading(EntityType.PCMob, 0);
                }
                // End if this is a single add.
                if (interval == 0)
                    return;
                // Hold for the given interval.
                Thread.Sleep(interval);
            }


        }

        /// <summary>   The name. </summary>
        [XmlAttribute("Name")]
        public string Name;
        /// <summary>   The point. </summary>
        [XmlElement("Point")]
        public List<D3DXVECTOR2> Point = new List<D3DXVECTOR2>();
    }

   
}
