using System;
using System.Security;

namespace BolterInterface
{
    /// <summary>
    /// Entry Constructor Attribute.
    /// Set this attribute to the constructor you would like Bolter to use as an entry point for your script.
    /// </summary>
    public class ScriptEntryPoint : Attribute
    {

    }

    /// <summary>
    /// Entry Class Attribute.
    /// Set this attribute to the class you would like Bolter to instantiate as your main script class.
    /// </summary>
    public class ScriptEntryClass : Attribute
    {
        [SecuritySafeCritical]
        public ScriptEntryClass()
        {
            Bolter.GlobalInterface = Bolter.GetBolterInterface();
        }
    }
    public class ScriptUnload : Attribute
    {

    }
    public class OnNewChatLineEvent : Attribute
    {

    }
    public class OnCommandEvent : Attribute
    {

    }
}
