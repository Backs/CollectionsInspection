﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Collections.Analyzer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Collections.Analyzer.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add ToCharArray call.
        /// </summary>
        internal static string AddToCharArray {
            get {
                return ResourceManager.GetString("AddToCharArray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Redundant string conversion.
        /// </summary>
        internal static string CI0001_Title {
            get {
                return ResourceManager.GetString("CI0001_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Redundant array conversion.
        /// </summary>
        internal static string CI0002_Title {
            get {
                return ResourceManager.GetString("CI0002_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Redundant enumerable conversion.
        /// </summary>
        internal static string CI0003_Title {
            get {
                return ResourceManager.GetString("CI0003_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not optimal List&lt;char&gt; constructor usage.
        /// </summary>
        internal static string CI0004_Title {
            get {
                return ResourceManager.GetString("CI0004_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not optimal count of collection items.
        /// </summary>
        internal static string CI0005_Title {
            get {
                return ResourceManager.GetString("CI0005_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Collection initializer is used without capacity.
        /// </summary>
        internal static string CI0006_Title {
            get {
                return ResourceManager.GetString("CI0006_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Initial collection capacity is less than amount of actual values.
        /// </summary>
        internal static string NotEnoughCapacity {
            get {
                return ResourceManager.GetString("NotEnoughCapacity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove method call {0}.
        /// </summary>
        internal static string RemoveRedundantCall {
            get {
                return ResourceManager.GetString("RemoveRedundantCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Replace with Count call.
        /// </summary>
        internal static string ReplaceWithCountCall {
            get {
                return ResourceManager.GetString("ReplaceWithCountCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Replace with ToCharArray call.
        /// </summary>
        internal static string ReplaceWithToCharArray {
            get {
                return ResourceManager.GetString("ReplaceWithToCharArray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Set actual capacity.
        /// </summary>
        internal static string SetActualCapacity {
            get {
                return ResourceManager.GetString("SetActualCapacity", resourceCulture);
            }
        }
    }
}
