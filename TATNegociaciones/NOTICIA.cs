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
    
    public partial class NOTICIA
    {
        public long ID { get; set; }
        public System.DateTime FECHAI { get; set; }
        public System.DateTime FECHAF { get; set; }
        public string PATH { get; set; }
        public string USUARIOC_ID { get; set; }
        public Nullable<System.DateTime> FECHAC { get; set; }
        public bool ACTIVO { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
