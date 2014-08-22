// file:	InterDomainOps.cs
//
// summary:	Implements the inter domain ops class

using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace BolterInterface
{
    /// <summary>   Gets global interface. </summary>
    ///
    
    ///
    /// <returns>   An IBolterInterface. </returns>

    [UnmanagedFunctionPointer(CallingConvention.StdCall), SuppressUnmanagedCodeSecurity]
    public delegate IBolterInterface GetGlobalInterface();

    /// <summary>   A bolter. </summary>
    ///
    

    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class Bolter
    {
        /// <summary>   Gets bolter interface. </summary>
        ///
        
        ///
        /// <returns>   The bolter interface. </returns>

        [DllImport("TachyonEmitter.dll", CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.Interface)]
        internal static extern IBolterInterface GetBolterInterface();
        /// <summary>   The global interface. </summary>
        public static IBolterInterface GlobalInterface;

    }

    /// <summary>   An inter domain ops. </summary>
    ///
    

    [ComVisible(true), SuppressUnmanagedCodeSecurity, SecuritySafeCritical]
    public class InterDomainOps
    {
        /// <summary>   Default constructor. </summary>
        ///
        

        public InterDomainOps()
        {
            
        }

        /// <summary>   Creates application domain cross link. </summary>
        ///
        
        ///
        /// <tparam name="T">   Generic type parameter. </tparam>
        /// <param name="ptr" type="IntPtr">                The pointer. </param>
        /// <param name="conv" type="CallingConvention">    The convert. </param>
        ///
        /// <returns>   The new application domain cross link. </returns>

        public static T CreateAppDomainCrossLink<T>(IntPtr ptr, CallingConvention conv)
        where T : class
        {
            var delegateType = typeof(T);
            var method = delegateType.GetMethod("Invoke");
            var returnType = method.ReturnType;
            var paramTypes =
                method
                .GetParameters()
                .Select((x) => x.ParameterType)
                .ToArray();
            var invoke = new DynamicMethod("Invoke", returnType, paramTypes, typeof(Delegate));

            var il = invoke.GetILGenerator();
            for (int i = 0; i < paramTypes.Length; i++)
                il.Emit(OpCodes.Ldarg, i);
            if (IntPtr.Size == sizeof(int))
                il.Emit(OpCodes.Ldc_I4, ptr.ToInt32());
            else
                il.Emit(OpCodes.Ldc_I8, ptr.ToInt64());
            il.EmitCalli(OpCodes.Calli, conv, returnType, paramTypes);
            il.Emit(OpCodes.Ret);
            return invoke.CreateDelegate(delegateType) as T;
        }

        /// <summary>   Gets function pointer for generic delegate. </summary>
        ///
        
        ///
        /// <tparam name="T">   Generic type parameter. </tparam>
        /// <param name="delegateCallback" type="T">    The delegate callback. </param>
        /// <param name="binder" type="out object">     [out] The binder. </param>
        ///
        /// <returns>   The function pointer for generic delegate. </returns>

        public static IntPtr GetFunctionPointerForGenericDelegate<T>(T delegateCallback, out object binder)
            where T : class
        {
            var del = delegateCallback as Delegate;
            IntPtr result;

            try
            {
                result = Marshal.GetFunctionPointerForDelegate(del);
                binder = del;
            }
            catch (ArgumentException) // generic type delegate
            {
                var delegateType = typeof(T);
                var method = delegateType.GetMethod("Invoke");
                var returnType = method.ReturnType;
                var paramTypes =
                    method
                        .GetParameters()
                        .Select((x) => x.ParameterType)
                        .ToArray();

                // builder a friendly name for our assembly, module, and proxy type
                var nameBuilder = new StringBuilder();
                nameBuilder.Append(delegateType.Name);
                foreach (var pType in paramTypes)
                {
                    nameBuilder
                        .Append("`")
                        .Append(pType.Name);
                }
                var name = nameBuilder.ToString();

                // check if we've previously proxied this type before
                var proxyAssemblyExist =
                    AppDomain.CurrentDomain
                        .GetAssemblies()
                        .FirstOrDefault((x) => x.GetName().Name == name);

                Type proxyType;
                if (proxyAssemblyExist == null)
                {
                    /// create a proxy assembly
                    var proxyAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
                        new AssemblyName(name),
                        AssemblyBuilderAccess.Run
                        );
                    var proxyModule = proxyAssembly.DefineDynamicModule(name);
                    // begin creating the proxy type
                    var proxyTypeBuilder = proxyModule.DefineType(name,
                        TypeAttributes.AutoClass |
                        TypeAttributes.AnsiClass |
                        TypeAttributes.Sealed |
                        TypeAttributes.Public,
                        typeof(MulticastDelegate)
                        );
                    // implement the basic methods of a delegate as the compiler does
                    var methodAttributes =
                        MethodAttributes.Public |
                        MethodAttributes.HideBySig |
                        MethodAttributes.NewSlot |
                        MethodAttributes.Virtual;
                    proxyTypeBuilder
                        .DefineConstructor(
                            MethodAttributes.FamANDAssem |
                            MethodAttributes.Family |
                            MethodAttributes.HideBySig |
                            MethodAttributes.RTSpecialName,
                            CallingConventions.Standard,
                            new Type[] { typeof(object), typeof(IntPtr) })
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed
                        );
                    proxyTypeBuilder
                        .DefineMethod(
                            "BeginInvoke",
                            methodAttributes,
                            typeof(IAsyncResult),
                            paramTypes)
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed);
                    proxyTypeBuilder
                        .DefineMethod(
                            "EndInvoke",
                            methodAttributes,
                            null,
                            new Type[] { typeof(IAsyncResult) })
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed);
                    proxyTypeBuilder
                        .DefineMethod(
                            "Invoke",
                            methodAttributes,
                            returnType,
                            paramTypes)
                        .SetImplementationFlags(
                            MethodImplAttributes.Runtime |
                            MethodImplAttributes.Managed);
                    // create & wrap an instance of the proxy type
                    proxyType = proxyTypeBuilder.CreateType();
                }
                else
                {
                    // pull the type from an existing proxy assembly
                    proxyType = proxyAssemblyExist.GetType(name);
                }
                // marshal and bind the proxy so the pointer doesn't become invalid
                var repProxy = Delegate.CreateDelegate(proxyType, del.Target, del.Method);
                result = Marshal.GetFunctionPointerForDelegate(repProxy);
                binder = Tuple.Create(del, repProxy);
            }
            return result;
        }
    }
}
