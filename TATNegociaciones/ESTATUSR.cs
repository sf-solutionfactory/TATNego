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
    
    public partial class ESTATUSR
    {
        public int ESTATUS_ID { get; set; }
        public int POS { get; set; }
        public string REGEX { get; set; }
        public bool ACTIVO { get; set; }
    
        public virtual ESTATU ESTATU { get; set; }
    }
}