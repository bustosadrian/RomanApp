﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RomanApp.Client.Mobile.Resx {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ValidationMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("RomanApp.Client.Mobile.Resx.ValidationMessages", typeof(ValidationMessages).Assembly);
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
        ///   Looks up a localized string similar to This is not a valid number.
        /// </summary>
        internal static string sheet_add_edit_amount_format {
            get {
                return ResourceManager.GetString("sheet.add.edit.amount.format", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be greater than 0 and less than 1 million.
        /// </summary>
        internal static string sheet_add_edit_expense_amount_range {
            get {
                return ResourceManager.GetString("sheet.add.edit.expense.amount.range", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value is required.
        /// </summary>
        internal static string sheet_add_edit_expense_amount_required {
            get {
                return ResourceManager.GetString("sheet.add.edit.expense.amount.required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A name is required.
        /// </summary>
        internal static string sheet_add_edit_expense_name_required {
            get {
                return ResourceManager.GetString("sheet.add.edit.expense.name.required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The contribution must be equal or greater than zero and less than 1 million.
        /// </summary>
        internal static string sheet_add_edit_guest_amount_range {
            get {
                return ResourceManager.GetString("sheet.add.edit.guest.amount.range", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The contribution is required.
        /// </summary>
        internal static string sheet_add_edit_guest_amount_required {
            get {
                return ResourceManager.GetString("sheet.add.edit.guest.amount.required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A name is required.
        /// </summary>
        internal static string sheet_add_edit_guest_name_required {
            get {
                return ResourceManager.GetString("sheet.add.edit.guest.name.required", resourceCulture);
            }
        }
    }
}
