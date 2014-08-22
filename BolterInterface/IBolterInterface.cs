using System.Runtime.InteropServices;
using System.Security;

namespace BolterInterface
{
    /// <summary>
    /// Interface of main Bolter class.
    /// All scripts and plugins use this interface to share data and interact with the game.
    /// </summary>
    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public interface IBolterInterface
    {
        /// <summary>
        /// Global Camera Object.
        /// </summary>
        ICamera GlobalCamera { get; }


        /// <summary>
        /// Retrieves an Entity object.
        /// NOTE: This returns a newly created Entity object. 
        /// It is advised that you assign the return value to a variable, and not work directly from this function.
        /// </summary>
        /// <param name="eType" type="EntityType">
        /// The type of entity.
        /// </param>
        /// <param name="index" type="int">
        /// Zero-based index of the entity.</param>
        /// <returns> An interface of the requested entity </returns>
        IEntity GetEntityObject(EntityType eType, int index);

        /// <summary>
        /// Global Camera Object.
        /// </summary>
        IMovement GlobalMovement { get; }

        /// <summary>
        /// Various Game Calls.
        /// </summary>
        IGameCalls GameCalls { get; }

        /// <summary>
        /// Retrieves a Navigation object.
        /// NOTE: This returns a newly created Navigation object.
        /// It is advised that you assign the return value to a variable, and not work directly from this function.
        /// </summary>
        /// <returns> An interface of the new Navigation object </returns>
        INavigation GetNavigationObject();

        /// <summary>
        /// Global Input Object.
        /// </summary>
        IInput GlobalInput { get; }

        /// <summary>
        /// Global Resources Object.
        /// </summary>
        IResources GlobalResources { get; }

        /// <summary>
        /// Base file path of bolter.
        /// </summary>
        string BasePath { get; }

        /// <summary>
        /// Global Target Object.
        /// </summary>
        ITarget GlobalTarget { get; }

        /// <summary>
        /// Retrieves a NaviMap object.
        /// NOTE: This returns a newly created Navigation object.
        /// It is advised that you assign the return value to a variable, and not work directly from this function.
        /// </summary>
        /// <returns> An interface of the new NaviMap object </returns>
        INaviMap GetNaviMapObject();

        /// <summary>
        /// Retrieves a Synthesis object.
        /// NOTE: This returns a newly created Synthesis object.
        /// It is advised that you assign the return value to a variable, and not work directly from this function.
        /// </summary>
        /// <returns> An interface of the new Synthesis object </returns>
        ISynthesis GetSynthesisObject();

        /// <summary>
        /// Global Zone Object.
        /// </summary>
        IZone GlobalZone { get; }

        /// <summary>
        /// Retrieves a Gather object.
        /// NOTE: This returns a newly created Gather object.
        /// It is advised that you assign the return value to a variable, and not work directly from this function.
        /// </summary>
        /// <returns> An interface of the new Gather object </returns>
        IGather GetGatherObject();

        IInventory GlobalInventory { get; }
    }
}
