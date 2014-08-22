// file:	INavigation.cs
//
// summary:	Declares the INavigation interface

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BolterInterface
{
    /// <summary>   A player 2 d position. </summary>
    ///
    

    [StructLayout(LayoutKind.Sequential)]
    public class Player2DPos
    {
        /// <summary>   The x coordinate. </summary>
        public float x;
        /// <summary>   The y coordinate. </summary>
        public float y;
    }

    /// <summary>   A 3 dxvector 2. </summary>
    ///
    

    [Serializable]
    public class D3DXVECTOR2
    {
        /// <summary>   The x coordinate. </summary>
        [XmlAttribute("X")]
        public float x;
        /// <summary>   The y coordinate. </summary>
        [XmlAttribute("Y")]
        public float y;

        /// <summary>   true to jump. </summary>
        [XmlAttribute("Jump")]
        public bool Jump;

        /// <summary>   The direction. </summary>
        [XmlAttribute("Direction")]
        public PointDirection Direction;

        /// <summary>   Default constructor. </summary>
        ///
        

        public D3DXVECTOR2()
        {

        }

        /// <summary>   Constructor. </summary>
        ///
        
        ///
        /// <param name="x" type="float">   The x coordinate. </param>
        /// <param name="y" type="float">   The y coordinate. </param>

        public D3DXVECTOR2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

    }

    /// <summary>   Values that represent PointDirection. </summary>
    ///
    

    [Serializable]
    public enum PointDirection
    {
        /// <summary>   An enum constant representing the forward option. </summary>
        Forward,
        /// <summary>   An enum constant representing the back option. </summary>
        Back,
        /// <summary>   An enum constant representing the both option. </summary>
        Both
    }

    /// <summary>   Values that represent Pathing. </summary>
    ///
    

    public enum Pathing
    {
        Normal,
        At_Index,
        Closest
    }

    /// <summary>   Self modify. </summary>
    ///
    
    ///
    /// <param name="pathName" type="string">   Full pathname of the file. </param>
    /// <param name="point" type="D3DXVECTOR2"> The point. </param>
    /// <param name="foraward" type="bool">     true to foraward. </param>

    public delegate void SelfModify(string pathName, D3DXVECTOR2 point, bool foraward);

    /// <summary>   Path complete. </summary>
    ///
    
    ///
    /// <param name="t" type="Thread">          The Thread to process. </param>
    /// <param name="halted" type="bool">       true if halted. </param>
    /// <param name="pathName" type="string">   Full pathname of the file. </param>
    /// <param name="pType" type="Pathing">     The type. </param>
    /// <param name="forward" type="bool">      (Optional) true to forward. </param>
    /// <param name="index" type="int">         (Optional) zero-based index of the. </param>

    public delegate void dPathComplete(Thread t, bool halted, string pathName, Pathing pType, bool forward = true, int index = 0);

    /// <summary>   Interface for navigation. </summary>
    ///


    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface INavigation
    {
        /// <summary>   Gets or sets the jump tolerance. </summary>
        ///
        /// <value> The jump tolerance. </value>

        long JumpTolerance { get; set; }

        /// <summary>   Gets or sets a value indicating whether the record flag. </summary>
        ///
        /// <value> true if record flag, false if not. </value>

        bool RecordFlag { get; set; }

        /// <summary>   Gets or sets a value indicating whether the halt flag. </summary>
        ///
        /// <value> true if halt flag, false if not. </value>

        bool HaltFlag { get; set; }

        /// <summary>   Gets or sets the head toll. </summary>
        ///
        /// <value> The head toll. </value>

        int HeadToll { get; set; }

        /// <summary>   Gets or sets a value indicating whether the moving. </summary>
        ///
        /// <value> true if moving, false if not. </value>

        bool Moving { get; set; }

        /// <summary>   Gets or sets a value indicating whether the cor delay. </summary>
        ///
        /// <value> true if cor delay, false if not. </value>

        bool CorDelay { get; set; }

        /// <summary>   Gets or sets a value indicating whether the turn filter. </summary>
        ///
        /// <value> true if turn filter, false if not. </value>

        bool TurnFilter { get; set; }

        /// <summary>   Gets or sets a value indicating whether the ai correction. </summary>
        ///
        /// <value> true if ai correction, false if not. </value>

        bool AICorrection { get; set; }

        /// <summary>   Gets or sets a value indicating whether the camera reset. </summary>
        ///
        /// <value> true if camera reset, false if not. </value>

        bool CamReset { get; set; }

        /// <summary>   Removes the path. </summary>
        ///
        /// <param name="pathName" type="string">   Full pathname of the file. </param>

        void RemovePath(string pathName);

        /// <summary>   Removes the path. </summary>
        ///
        /// <param name="pathName" type="string">   Full pathname of the file. </param>
        /// <param name="zoneNanme" type="string">  The zone nanme. </param>

        void RemovePath(string pathName, string zoneNanme);

        /// <summary>   Gets path names. </summary>
        ///
        /// <returns>   The path names. </returns>

        IList GetPathNames();

        /// <summary>   Gets path names. </summary>
        ///
        /// <param name="zone" type="string">   The zone. </param>
        ///
        /// <returns>   The path names. </returns>

        IList GetPathNames(string zone);

        /// <summary>   Searches for the first best path. </summary>
        ///
        /// <param name="pathNames" type="IList">           List of names of the paths. </param>
        /// <param name="desiredPOS" type="D3DXVECTOR2">    The desired position. </param>
        /// <param name="name" type="out string">           [out] The name. </param>
        ///
        /// <returns>   The found best path. </returns>

        IList FindBestPath(IList pathNames, D3DXVECTOR2 desiredPOS, out string name);

        /// <summary>   Distances. </summary>
        ///
        /// <param name="x" type="float">   The x coordinate. </param>
        /// <param name="y" type="float">   The y coordinate. </param>
        ///
        /// <returns>   A float. </returns>

        float Distance(float x, float y);

        /// <summary>   Records. </summary>
        ///
        /// <param name="interval" type="int">      The interval. </param>
        /// <param name="pathName" type="string">   Full pathname of the file. </param>

        void Record(int interval, string pathName);

        /// <summary>   Plays the given file. </summary>
        ///
        /// <param name="pathName" type="string">       Full pathname of the file. </param>
        /// <param name="pType" type="Pathing">         The type. </param>
        /// <param name="forward" type="bool">          (Optional) true to forward. </param>
        /// <param name="index" type="int">             (Optional) zero-based index of the. </param>
        /// <param name="callback" type="SelfModify">   (Optional) the callback. </param>

        void Play(string pathName, Pathing pType, bool forward = true, int index = 0, SelfModify callback = null);

        /// <summary>   Walks. </summary>
        ///
        /// <param name="x" type="float">           The x coordinate. </param>
        /// <param name="y" type="float">           The y coordinate. </param>
        /// <param name="KeepWalking" type="bool">  true to keep walking. </param>

        void Walk(float x, float y, bool KeepWalking);
        /// <summary>   Stops a record. </summary>
        void StopRecord();
        /// <summary>   Reloads this object. </summary>
        void Reload();

        /// <summary>   Gets or sets the path complete. </summary>
        ///
        /// <value> The path complete. </value>

        dPathComplete PathComplete { get; set; }
    }
}
