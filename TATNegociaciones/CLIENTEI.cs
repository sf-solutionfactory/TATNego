//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TATNegociaciones
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTEI
    {
        public string VKORG { get; set; }
        public string VTWEG { get; set; }
        public string SPART { get; set; }
        public string KUNNR { get; set; }
        public string MWSKZ { get; set; }
        public bool ACTIVO { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual IMPUESTO IMPUESTO { get; set; }
    }
}
