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
    
    public partial class DET_AGENTE
    {
        public int PUESTOC_ID { get; set; }
        public int POS { get; set; }
        public int PUESTOA_ID { get; set; }
        public long AGROUP_ID { get; set; }
        public Nullable<decimal> MONTO { get; set; }
        public Nullable<bool> PRESUPUESTO { get; set; }
        public Nullable<bool> ACTIVO { get; set; }
        public string USUARIOA { get; set; }
        public string USUARIOC { get; set; }
    
        public virtual GAUTORIZACION GAUTORIZACION { get; set; }
        public virtual PUESTO PUESTO { get; set; }
        public virtual PUESTO PUESTO1 { get; set; }
    }
}
