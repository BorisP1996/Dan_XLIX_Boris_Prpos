//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblManager
    {
        public int ManagerID { get; set; }
        public Nullable<int> AllIDman { get; set; }
        public Nullable<int> ManagerFlor { get; set; }
        public Nullable<int> Experience { get; set; }
        public string SSS { get; set; }
    
        public virtual tblAll tblAll { get; set; }
    }
}
