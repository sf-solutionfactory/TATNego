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
    
    public partial class TREVERSAT
    {
        public string SPRAS_ID { get; set; }
        public int TREVERSA_ID { get; set; }
        public string TXT100 { get; set; }
    
        public virtual SPRA SPRA { get; set; }
        public virtual TREVERSA TREVERSA { get; set; }
    }
}
