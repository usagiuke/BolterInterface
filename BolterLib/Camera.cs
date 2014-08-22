// file:	Camera.cs
//
// summary:	Implements the camera class

using System;
using System.Security;
using BolterInterface;

namespace BolterLib
{
    /// <summary>   A camera. </summary>
    ///
    

    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public unsafe class Camera : ICamera
    {
        /// <summary>   The structure base. </summary>
        private readonly IntPtr StructBase;

        /// <summary>   Default constructor. </summary>
        ///
        

        public Camera()
        {
            StructBase = Funcs.GetCam();
        }

        /// <summary>   Gets or sets the zoom. </summary>
        ///
        /// <value> The zoom. </value>

        public float Zoom
        {
            get { return *(float*)(StructBase + CamStruct.Zoom); }
            set { *(float*)(StructBase + CamStruct.Zoom) = value; }
        }

        /// <summary>   Gets or sets the zoom minimum. </summary>
        ///
        /// <value> The zoom minimum. </value>

        public float ZoomMin
        {
            get { return *(float*)(StructBase + CamStruct.ZoomMin); }
            set { *(float*)(StructBase + CamStruct.ZoomMin) = value; }
        }

        /// <summary>   Gets or sets the zoom maximum. </summary>
        ///
        /// <value> The zoom maximum. </value>

        public float ZoomMax
        {
            get { return *(float*)(StructBase + CamStruct.ZoomMax); }
            set { *(float*)(StructBase + CamStruct.ZoomMax) = value; }
        }

        /// <summary>   Gets or sets the pitch. </summary>
        ///
        /// <value> The pitch. </value>

        public float Pitch
        {
            get { return *(float*)(StructBase + CamStruct.Pitch); }
            set { *(float*)(StructBase + CamStruct.Pitch) = value; }
        }

        /// <summary>   Gets or sets the pitch minimum. </summary>
        ///
        /// <value> The pitch minimum. </value>

        public float PitchMin
        {
            get { return *(float*)(StructBase + CamStruct.PitchMin); }
            set { *(float*)(StructBase + CamStruct.PitchMin) = value; }
        }

        /// <summary>   Gets or sets the pitch maximum. </summary>
        ///
        /// <value> The pitch maximum. </value>

        public float PitchMax
        {
            get { return *(float*)(StructBase + CamStruct.PitchMax); }
            set { *(float*)(StructBase + CamStruct.PitchMax) = value; }
        }
    }
}
