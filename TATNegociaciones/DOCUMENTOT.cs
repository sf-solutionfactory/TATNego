//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TATNegociaciones
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOCUMENTOT
    {
        public decimal NUM_DOC { get; set; }
        public int TSFORM_ID { get; set; }
        public Nullable<bool> CHECKS { get; set; }
    
        public virtual DOCUMENTO DOCUMENTO { get; set; }
        public virtual TS_FORM TS_FORM { get; set; }
    }
}