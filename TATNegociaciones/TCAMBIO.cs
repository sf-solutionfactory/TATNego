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
    
    public partial class TCAMBIO
    {
        public string KURST { get; set; }
        public string FCURR { get; set; }
        public string TCURR { get; set; }
        public System.DateTime GDATU { get; set; }
        public Nullable<decimal> UKURS { get; set; }
    
        public virtual MONEDA MONEDA { get; set; }
        public virtual MONEDA MONEDA1 { get; set; }
    }
}
