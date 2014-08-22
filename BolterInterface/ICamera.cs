using System.Runtime.InteropServices;
using System.Security;

namespace BolterInterface
{
    /// <summary>
    /// Interface for the game's camera.
    /// </summary>
    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface ICamera
    {
        /// <summary>
        /// Gets or sets the current zoom value.
        /// </summary>
        float Zoom { get; set; }

        /// <summary>
        /// Gets or sets the minimum zoom value.
        /// </summary>
        float ZoomMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum zoom value.
        /// </summary>
        float ZoomMax { get; set; }

        /// <summary>
        /// Gets or sets the current pitch value.
        /// </summary>
        float Pitch { get; set; }

        /// <summary>
        /// Gets or sets the minimum pitch value.
        /// </summary>
        float PitchMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum pitch value.
        /// </summary>
        float PitchMax { get; set; }
    }
}
