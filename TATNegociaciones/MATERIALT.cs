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
    
    public partial class MATERIALT
    {
        public string SPRAS { get; set; }
        public string MATERIAL_ID { get; set; }
        public string MAKTX { get; set; }
        public string MAKTG { get; set; }
    
        public virtual MATERIAL MATERIAL { get; set; }
        public virtual SPRA SPRA { get; set; }
    }
}
