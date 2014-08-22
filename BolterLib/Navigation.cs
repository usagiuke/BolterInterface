// file:	Navigation.cs
//
// summary:	Implements the navigation class

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A navigation. </summary>
    ///
    

    [SecuritySafeCritical]
    public class Navigation : INavigation
    {
        /// <summary>   Gets or sets the jump tolerance. </summary>
        ///
        /// <value> The jump tolerance. </value>

        public long JumpTolerance { get; set; }

        /// <summary>   Container for our waypoints.xml. </summary>
        ///
        /// <value> The waypoints. </value>

        private Waypoints _Waypoints { get; set; }

        /// <summary>   The waypoint file. </summary>
        private string waypointFile;

        /// <summary>   Flag that stops and starts recording. </summary>
        ///
        /// <value> true if record flag, false if not. </value>

        public bool RecordFlag { get; set; }

        /// <summary>   true to halt flag. </summary>
        ///
        /// <value> true if halt flag, false if not. </value>

        public bool HaltFlag { get; set; }

        /// <summary>   The head toll. </summary>
        ///
        /// <value> The head toll. </value>

        public int HeadToll { get; set; }

        /// <summary>   true to moving. </summary>
        ///
        /// <value> true if moving, false if not. </value>

        public bool Moving { get; set; }

        /// <summary>   The cor delay. </summary>
        ///
        /// <value> true if cor delay, false if not. </value>

        public bool CorDelay { get; set; }

        /// <summary>   A filter specifying the turn. </summary>
        ///
        /// <value> true if turn filter, false if not. </value>

        public bool TurnFilter { get; set; }

        /// <summary>   The ai correction. </summary>
        ///
        /// <value> true if ai correction, false if not. </value>

        public bool AICorrection { get; set; }

        /// <summary>   The camera reset. </summary>
        ///
        /// <value> true if camera reset, false if not. </value>

        public bool CamReset { get; set; }

        /// <summary>   Constructor. </summary>
        ///
        
        ///
        /// <param name="waypointFile" type="string">   The waypoint file. </param>

        public Navigation(string waypointFile)
        {
            this.waypointFile = waypointFile;
            _Waypoints = !File.Exists(waypointFile) ? new Waypoints() : XmlSerializationHelper.Deserialize<Waypoints>(waypointFile);
        }

        /// <summary>   The mut. </summary>
        private static readonly Mutex _mut = new Mutex();

        /// <summary>   Distances. </summary>
        ///
        
        ///
        /// <param name="y1" type="float">  The first y value. </param>
        /// <param name="x1" type="float">  The first x value. </param>
        /// <param name="y2" type="float">  The second y value. </param>
        /// <param name="x2" type="float">  The second x value. </param>
        ///
        /// <returns>   A float. </returns>

        private float Distance(float y1, float x1, float y2, float x2) { return (float)Math.Sqrt(((y1 - y2) * (y1 - y2)) + ((x1 - x2) * (x1 - x2))); }

        /// <summary>   Distances. </summary>
        ///
        
        ///
        /// <param name="p1" type="Player2DPos">    . </param>
        /// <param name="p2" type="D3DXVECTOR2">    The second D3DXVECTOR2. </param>
        ///
        /// <returns>   A float. </returns>
        ///
        /// ### <param name="p1" type="D3DXVECTOR2">    The first D3DXVECTOR2. </param>

        private float Distance(Player2DPos p1, D3DXVECTOR2 p2) { return Distance(p1.y, p1.x, p2.y, p2.x); }

        /// <summary>   Distances. </summary>
        ///
        
        ///
        /// <param name="p1" type="D3DXVECTOR2">    The first D3DXVECTOR2. </param>
        /// <param name="p2" type="D3DXVECTOR2">    The second D3DXVECTOR2. </param>
        ///
        /// <returns>   A float. </returns>

        private float Distance(D3DXVECTOR2 p1, D3DXVECTOR2 p2) { return Distance(p1.y, p1.x, p2.y, p2.x); }

        /// <summary>   Gets path names. </summary>
        ///
        
        ///
        /// <param name="zone" type="string">   The zone. </param>
        ///
        /// <returns>   The path names. </returns>

        public IList GetPathNames(string zone)
        {
            var theZone =  _Waypoints.Zone.FirstOrDefault(z => z.Name == zone);
            return theZone != default(Zones) ? theZone.Path.Select(p => p.Name).ToList() : null;
        }

        /// <summary>   Removes the path described by pathName. </summary>
        ///
        
        ///
        /// <param name="pathName" type="string">   Full pathname of the file. </param>

        [SecuritySafeCritical]
        public void RemovePath(string pathName)
        {
            RemovePath(pathName, Funcs.GetZoneName());
        }

        /// <summary>   Removes the path. </summary>
        ///
        
        ///
        /// <param name="pathName" type="string">   Full pathname of the file. </param>
        /// <param name="zoneNanme" type="string">  The zone nanme. </param>

        public void RemovePath(string pathName, string zoneNanme)
        {
            _Waypoints.Zone.First(p => p.Name == zoneNanme).Path.RemoveAll(i => i.Name == pathName);
            Reload();
        }

        /// <summary>   Gets path names. </summary>
        ///
        
        ///
        /// <returns>   The path names. </returns>

        [SecuritySafeCritical]
        public IList GetPathNames()
        {
            return GetPathNames(Funcs.GetZoneName());
        }

        /// <summary>   Searches for the first best path. </summary>
        ///
        
        ///
        /// <param name="pathNames" type="IList">           List of names of the paths. </param>
        /// <param name="desiredPOS" type="D3DXVECTOR2">    The desired position. </param>
        /// <param name="name" type="out string">           [out] The name. </param>
        ///
        /// <returns>   The found best path. </returns>

        [SecuritySafeCritical]
        public IList FindBestPath(IList pathNames, D3DXVECTOR2 desiredPOS, out string name)
        {
            var changethis = Funcs.Get2DPos();
            var currentPOS = new D3DXVECTOR2(changethis.x,changethis.y);
            var zoneName = Funcs.GetZoneName();
            var walkablePaths = (from path in pathNames as List<string>
                                 where !string.IsNullOrEmpty(path)
                                 select _Waypoints.Zone.First(p => p.Name == zoneName).Path.First(i => i.Name == path)).ToList();

            var shortist = float.MaxValue;
            var returnPath = walkablePaths.First().Point;
            var retName = "";
            foreach (var path in walkablePaths)
            {
                var MyPOSIndex = GetClosestIndex(path.Point, currentPOS);
                var DesiredPOSIndex = GetClosestIndex(path.Point, desiredPOS);
                var overallDistance = 0f;
                if (MyPOSIndex < DesiredPOSIndex)
                {
                    var truncedPath = path.Point.Skip(MyPOSIndex).Take(DesiredPOSIndex - MyPOSIndex).ToList();
                    var counter1 = 0;
                    foreach (var dxvector2 in truncedPath)
                    {
                        counter1++;
                        if (counter1 == truncedPath.Count) break;
                        overallDistance += Distance(dxvector2, truncedPath.ElementAt(counter1));
                    }
                }
                else
                {
                    var truncedPath = path.Point.Skip(0).Reverse().Skip(MyPOSIndex).Take(MyPOSIndex - DesiredPOSIndex).ToList();
                    var counter1 = 0;
                    foreach (var dxvector2 in truncedPath)
                    {
                        counter1++;
                        if (counter1 == truncedPath.Count) break;
                        overallDistance += Distance(dxvector2, truncedPath.ElementAt(counter1));
                    }
                }
                if (!(overallDistance < shortist)) continue;
                returnPath = path.Point;
                shortist = overallDistance;
                retName = path.Name;
            }
            name = retName;
            return returnPath;
        }

        /// <summary>   Distances. </summary>
        ///
        
        ///
        /// <param name="x" type="float">   The x coordinate. </param>
        /// <param name="y" type="float">   The y coordinate. </param>
        ///
        /// <returns>   A float. </returns>

        [SecuritySafeCritical]
        public float Distance(float x, float y)
        {
            
            return Distance(Funcs.Get2DPos(), new D3DXVECTOR2(x, y));
        }

        /// <summary>   Heading to radians. </summary>
        ///
        
        ///
        /// <param name="x">                        The x coordinate. </param>
        /// <param name="y">                        The y coordinate. </param>
        /// <param name="to" type="D3DXVECTOR2">    to. </param>
        ///
        /// <returns>   A float. </returns>

        private float HeadingToRad(float x, float y, D3DXVECTOR2 to) { return (float)Math.Atan2((to.x - x), (to.y - y)); }

        /// <summary>   Rotate character. </summary>
        ///
        
        ///
        /// <param name="newPoint" type="D3DXVECTOR2">  The new point. </param>

        [SecuritySafeCritical]
        private void RotateCharacter(D3DXVECTOR2 newPoint)
        {
            var dx2DPoint = new Player2DPos {x = newPoint.x, y = newPoint.y};
            Funcs.ModelRotation(ref dx2DPoint);
        }

        /// <summary>   Record waypoint. </summary>
        ///
        
        ///
        /// <param name="interval"> Time in ms, between waypoints. </param>
        /// <param name="pathName">
        ///     Name of the path to save the waypoints to. A new on will be created, if it does not exist.
        /// </param>

        [SecuritySafeCritical]
        private void RecordWaypoint(int interval, string pathName)
        {
            if (RecordFlag)
                return;
            // Set recording as true.
            RecordFlag = true;

            // Get ID of current zone.
            var zoneId = Funcs.GetZoneId();

            // Check if we need to make a new Zone entry.
            var nozones = _Waypoints.Zone.All(p => p.ID != zoneId);

            // We need to make a new entry.
            if (nozones)
            {
                // Add new Zone entry for our current zone.
                _Waypoints.Zone.Add(new Zones(zoneId));

                // Add an empty Path entry.
                _Waypoints.AddPathToZone(zoneId, pathName);

                // This is a new entry, so grab the last Zone we added, and the first Path in that Zone,
                // Then start adding new Point entries (at the rate of the given interval), and wait for the user to click stop.
                _Waypoints.Zone.Last().Path.First().AddPoints(interval,this);
            }
            else
                // We already have the Zone in our xml, so lets go strait to adding points.
                _Waypoints.Zone.First(p => p.ID == zoneId).AddPoints(pathName, interval,this);

            // If this is a single add, just reset the record flag and save the xml.
            if (interval == 0)
                StopRecord();
        }

        /// <summary>   Play path. </summary>
        ///
        
        ///
        /// <param name="pathName">
        ///     Name of the path to save the waypoints to. A new on will be created, if it does not exist.
        /// </param>
        /// <param name="pType">                        The type. </param>
        /// <param name="forawrd" type="bool">          true to forawrd. </param>
        /// <param name="index">                        zero-based index of the. </param>
        /// <param name="callback" type="SelfModify">   (Optional) the callback. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>

        [SecuritySafeCritical]
        private bool PlayPath(string pathName, Pathing pType, bool forawrd, int index, SelfModify callback = null)
        {
            if (!_mut.WaitOne(1000))
            {
                Console.WriteLine("Asynchronous action taken on synchronic function.");
                return true;
            }

            var zoneId = Funcs.GetZoneId();
            HaltFlag = false;
            float heading;
            float tobeHeading;
            var count = 0;
            var rebuiltPath =
                RebuildList(_Waypoints.Zone.First(p => p.ID == zoneId).Path.First(i => i.Name == pathName).Point,
                    forawrd, pType, index);
            foreach (
                var waypoint in rebuiltPath)
            {
                if (callback != null)
                    callback(pathName, waypoint, forawrd);

                if (CorDelay)
                    Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;

                RotateCharacter(waypoint);

                if (CamReset)
                    Bolter.GlobalInterface.GlobalInput.SendKeyPress(KeyStates.Toggled, Key.End);

                if (CorDelay)
                    Thread.Sleep(HeadToll);

                var decX = (Funcs.GetPOS(EntityType.PCMob, Axis.X, 0) > waypoint.x);

                var ttl = (long)(1000f * (Distance(Funcs.Get2DPos(), waypoint) / Bolter.GlobalInterface.GlobalMovement.ForwardSpeed));

                Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Autorun | WalkingStatus.Running;
                var timer = new Stopwatch();
                timer.Start();
                if (decX)
                {
                    while (Funcs.GetPOS(EntityType.PCMob, Axis.X, 0) > waypoint.x)
                    {
                        if (HaltFlag)
                        {
                            Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;
                            timer.Stop();
                            goto CleanUpTrue;
                        }
                        if (AICorrection)
                        {
                            heading = Funcs.GetHeading(EntityType.PCMob, 0);

                            tobeHeading = HeadingToRad(Funcs.GetPOS(EntityType.PCMob, Axis.X, 0), Funcs.GetPOS(EntityType.PCMob, Axis.Y, 0), waypoint);

                            // Check if our heading is within our tolerance.
                            if (tobeHeading - heading < 0 ? tobeHeading - heading < -0.1f : tobeHeading - heading > 0.1f)
                                RotateCharacter(waypoint);
                        }
                        Thread.Sleep(10);
                        if (timer.ElapsedMilliseconds <= ttl + JumpTolerance) continue;
                        if (waypoint.Jump == false) continue;
                        if ((waypoint.Direction == PointDirection.Forward && forawrd) || (waypoint.Direction == PointDirection.Back && !forawrd) || (waypoint.Direction == PointDirection.Both))
                            Bolter.GlobalInterface.GlobalInput.SendKeyPress(KeyStates.Toggled, Key.Space);
                    }
                }
                else
                {
                    while (Funcs.GetPOS(EntityType.PCMob, Axis.X, 0) < waypoint.x)
                    {
                        if (HaltFlag)
                        {
                            Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;
                            timer.Stop();
                            goto CleanUpTrue;
                        }
                        if (AICorrection)
                        {
                            heading = Funcs.GetHeading(EntityType.PCMob, 0);
                            tobeHeading = HeadingToRad(Funcs.GetPOS(EntityType.PCMob, Axis.X, 0), Funcs.GetPOS(EntityType.PCMob, Axis.Y, 0), waypoint);

                            // Check if our heading is within our tolerance.
                            if (tobeHeading - heading < 0 ? tobeHeading - heading < -0.1f : tobeHeading - heading > 0.1f)
                                RotateCharacter(waypoint);
                        }
                        Thread.Sleep(10);
                        if (timer.ElapsedMilliseconds <= ttl + JumpTolerance) continue;
                        if (waypoint.Jump == false) continue;
                        if ((waypoint.Direction == PointDirection.Forward && forawrd) || (waypoint.Direction == PointDirection.Back && !forawrd) || (waypoint.Direction == PointDirection.Both))
                            Bolter.GlobalInterface.GlobalInput.SendKeyPress(KeyStates.Toggled, Key.Space);
                    }
                }
                count++;
                timer.Stop();
            }
            Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;
            _mut.ReleaseMutex();
            return false;
        CleanUpTrue:
            _mut.ReleaseMutex();
            return true;
        }

        /// <summary>   Gets closest index. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="PList">    The list. </param>
        /// <param name="curPos">   The current position. </param>
        ///
        /// <returns>   The closest index. </returns>

        private int GetClosestIndex(List<D3DXVECTOR2> PList, D3DXVECTOR2 curPos)
        {
            var n = 0;

            PList.ForEach(p => n = Distance(curPos, p) < Distance(curPos, PList[n]) ? PList.IndexOf(p) : n);

            return n;
        }

        /// <summary>   Gets closest index. </summary>
        ///
        
        ///
        /// <param name="PList">    The list. </param>
        /// <param name="curPos">   The current position. </param>
        ///
        /// <returns>   The closest index. </returns>

        private int GetClosestIndex(List<D3DXVECTOR2> PList, Player2DPos curPos)
        {
            var n = 0;

            PList.ForEach(p => n = Distance(curPos, p) < Distance(curPos, PList[n]) ? PList.IndexOf(p) : n);

            return n;
        }

        /// <summary>   Enumerates rebuild list in this collection. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="pList">    The list. </param>
        /// <param name="forward">  true to forward. </param>
        /// <param name="pType">    The type. </param>
        /// <param name="index">    (Optional) zero-based index of the. </param>
        ///
        /// <returns>
        ///     An enumerator that allows foreach to be used to process rebuild list in this collection.
        /// </returns>

        [SecuritySafeCritical]
        private IEnumerable<D3DXVECTOR2> RebuildList(IEnumerable<D3DXVECTOR2> pList, bool forward, Pathing pType, int index = 0)
        {
            var rPlist = new List<D3DXVECTOR2>(pList);

            if (!forward)
                rPlist.Reverse();

            int localIndex;

            if (pType == Pathing.Normal)
                localIndex = 0;
            else
                localIndex = pType == Pathing.At_Index ? index : GetClosestIndex(rPlist, Funcs.Get2DPos());

            return rPlist.Skip(localIndex);
        }

        /// <summary>   Starts recording waypoints on a new thread. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="interval"> Time in ms, between waypoints. </param>
        /// <param name="pathName">
        ///     Name of the path to save the waypoints to. A new on will be created, if it does not exist.
        /// </param>
        ///
        /// ### <param name="log">  (Optional) the log. </param>

        public void Record(int interval, string pathName)
        {
            new Thread(() => RecordWaypoint(interval, pathName)).Start();
        }

        /// <summary>   Plays the given file. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <value> The path complete. </value>
        ///
        /// ### <param name="pathName">
        ///     Name of the path to save the waypoints to. A new on will be created, if it does not exist.
        /// </param>
        /// ### <param name="pType">    The type. </param>
        /// ### <param name="forward">  (Optional) true to forward. </param>
        /// ### <param name="index">    (Optional) zero-based index of the. </param>
        /// ### <param name="log">      (Optional) the log. </param>

        public dPathComplete PathComplete { get; set; }

        /// <summary>   Plays the given file. </summary>
        ///
        
        ///
        /// <param name="pathName" type="string">       Full pathname of the file. </param>
        /// <param name="pType" type="Pathing">         The type. </param>
        /// <param name="forward" type="bool">          (Optional) true to forward. </param>
        /// <param name="index" type="int">             (Optional) zero-based index of the. </param>
        /// <param name="callback" type="SelfModify">   (Optional) the callback. </param>

        public void Play(string pathName, Pathing pType, bool forward = true, int index = 0, SelfModify callback = null)
        {
            new Thread(() =>
            {
                var halted = PlayPath(pathName, pType, forward, index, callback);
                if (PathComplete != null)
                    PathComplete(Thread.CurrentThread, halted, pathName, pType, forward, index);
            }).Start();
        }
        /// <summary>   The second mut. </summary>
        private readonly Mutex _mut2 = new Mutex();

        /// <summary>   Walks. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>
        ///
        /// <param name="x">            The x coordinate. </param>
        /// <param name="y">            The y coordinate. </param>
        /// <param name="KeepWalking">  true to keep walking. </param>

        [SecuritySafeCritical]
        public void Walk(float x, float y, bool KeepWalking)
        {
            if (!_mut2.WaitOne(1000))
            {
                Console.WriteLine("Asynchronous action taken on synchronic function.");
                goto CleanUp;
            }

            HaltFlag = false;
            float heading;
            float tobeHeading;
            var waypoint = new D3DXVECTOR2(x, y);
            if (CorDelay)
                Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;

            RotateCharacter(waypoint);

            if (CamReset)
                Bolter.GlobalInterface.GlobalInput.SendKeyPress(KeyStates.Toggled, Key.End);

            if (CorDelay)
                Thread.Sleep(HeadToll);

            var decX = (Funcs.GetPOS(EntityType.PCMob, Axis.X, 0) > x);

            Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Autorun | WalkingStatus.Running;

            if (decX)
            {
                while (Funcs.GetPOS(EntityType.PCMob, Axis.X, 0) > x)
                {
                    if (HaltFlag)
                    {
                        Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;
                        goto CleanUp;
                    }
                    if (AICorrection)
                    {
                        heading = Funcs.GetHeading(EntityType.PCMob, 0);

                        tobeHeading = HeadingToRad(Funcs.GetPOS(EntityType.PCMob, Axis.X, 0), Funcs.GetPOS(EntityType.PCMob, Axis.Y, 0), waypoint);

                        // Check if our heading is within our tolerance.
                        if (tobeHeading - heading < 0 ? tobeHeading - heading < -0.1f : tobeHeading - heading > 0.1f)
                            RotateCharacter(waypoint);
                    }
                    Thread.Sleep(10);
                }
            }
            else
            {
                while (Funcs.GetPOS(EntityType.PCMob, Axis.X, 0) < x)
                {
                    if (HaltFlag)
                    {
                        Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;
                        goto CleanUp;
                    }
                    if (AICorrection)
                    {
                        heading = Funcs.GetHeading(EntityType.PCMob, 0);
                        tobeHeading = HeadingToRad(Funcs.GetPOS(EntityType.PCMob, Axis.X, 0), Funcs.GetPOS(EntityType.PCMob, Axis.Y, 0), waypoint);

                        // Check if our heading is within our tolerance.
                        if (tobeHeading - heading < 0 ? tobeHeading - heading < -0.1f : tobeHeading - heading > 0.1f)
                            RotateCharacter(waypoint);
                    }
                    Thread.Sleep(10);
                }
            }
            if (!KeepWalking)
                Bolter.GlobalInterface.GlobalMovement.Status = WalkingStatus.Standing;
        CleanUp:
            _mut2.ReleaseMutex();
        }

        /// <summary>   Stops an active recording session, and saves the results to xml. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>

        public void StopRecord()
        {
            RecordFlag = false;
            XmlSerializationHelper.Serialize(waypointFile, _Waypoints);
        }

        /// <summary>   Reloads this object. </summary>
        ///
        /// <remarks>   Bunny 2, 3/14/2014. </remarks>

        public void Reload()
        {
            XmlSerializationHelper.Serialize(waypointFile, _Waypoints);
            _Waypoints = XmlSerializationHelper.Deserialize<Waypoints>(waypointFile);
        }
    }
}
