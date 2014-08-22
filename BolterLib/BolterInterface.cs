using System;
using System.IO;
using System.Security;
using BolterInterface;


namespace BolterLib
{
    /// <summary>   A bolter interface. </summary>
    ///
    [SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class BolterInterface : IBolterInterface
    {
        /// <summary>   The local camera. </summary>
        private readonly ICamera _localCamera;
        /// <summary>   The local movement. </summary>
        private readonly IMovement _localMovement;
        /// <summary>   The local game calls. </summary>
        private readonly IGameCalls _localGameCalls;
        /// <summary>   The local input. </summary>
        private readonly IInput _localInput;
        /// <summary>   The local resources. </summary>
        private readonly IResources _localResources;
        /// <summary>   Full pathname of the base file. </summary>
        private readonly string _basePath;

        private readonly ITarget _localTarget;

        private readonly IZone _localZone;
        private readonly IInventory _localInventory;

        /// <summary>   Default constructor. </summary>
        ///
        
        public BolterInterface()
        {
            _basePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(new[] { '\\' });
            _localCamera = new Camera();
            _localMovement = new Movement();
            _localGameCalls = new GameCalls();
            _localInput = new Input();
            _localResources = new Resources(Path.GetDirectoryName(_basePath) + "\\Resources\\Items.obj");
            _localTarget = new Target();
            _localZone = new Zone();
            _localInventory = new Inventory();
            Bolter.GlobalInterface = this;
        }

        /// <summary>   Gets the global resources. </summary>
        ///
        /// <value> The global resources. </value>

        public IResources GlobalResources 
        {
            get { return _localResources; }
        }

        /// <summary>   Gets the full pathname of the base file. </summary>
        ///
        /// <value> The full pathname of the base file. </value>

        public string BasePath 
        {
            get { return _basePath; }
        }

        public ITarget GlobalTarget
        {
            get { return _localTarget; }
        }

        public INaviMap GetNaviMapObject()
        {
            return new NaviMap();
        }

        public ISynthesis GetSynthesisObject()
        {
           return new Synthesis();
        }

        public IZone GlobalZone 
        {
            get { return _localZone; }
        }

        public IGather GetGatherObject()
        {
            return new Gather();
        }

        public IInventory GlobalInventory 
        {
            get { return _localInventory; }
        }

        /// <summary>   Gets the game calls. </summary>
        ///
        /// <value> The game calls. </value>

        public IGameCalls GameCalls
        {
            get { return _localGameCalls; }
        }

        /// <summary>   Gets the global camera. </summary>
        ///
        /// <value> The global camera. </value>

        public ICamera GlobalCamera
        {
            get { return _localCamera; }
        }

        /// <summary>   Gets the global movement. </summary>
        ///
        /// <value> The global movement. </value>

        public IMovement GlobalMovement
        {
            get { return _localMovement; }
        }

        /// <summary>   Gets entity object. </summary>
        ///
        
        ///
        /// <param name="eType" type="EntityType">  The type. </param>
        /// <param name="index" type="int">         Zero-based index of the. </param>
        ///
        /// <returns>   The entity object. </returns>

        public IEntity GetEntityObject(EntityType eType, int index)
        {
            return new Entity(eType, index);
        }

        /// <summary>   Gets navigation object. </summary>
        ///
        
        ///
        /// <returns>   The navigation object. </returns>

        public INavigation GetNavigationObject()
        {
            return new Navigation(Path.GetDirectoryName(_basePath) + "\\Resources\\waypoints.xml");
        }

        /// <summary>   Gets the global input. </summary>
        ///
        /// <value> The global input. </value>

        public IInput GlobalInput
        {
            get { return _localInput; }
        }
    }
}
