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
    
    public partial class DOCUMENTOBORRP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCUMENTOBORRP()
        {
            this.DOCUMENTOBORRMs = new HashSet<DOCUMENTOBORRM>();
        }
    
        public string USUARIOC_ID { get; set; }
        public decimal POS { get; set; }
        public string MATNR { get; set; }
        public string MATKL { get; set; }
        public Nullable<decimal> CANTIDAD { get; set; }
        public Nullable<decimal> MONTO { get; set; }
        public Nullable<decimal> PORC_APOYO { get; set; }
        public Nullable<decimal> MONTO_APOYO { get; set; }
        public Nullable<decimal> PRECIO_SUG { get; set; }
        public Nullable<decimal> VOLUMEN_EST { get; set; }
        public Nullable<decimal> VOLUMEN_REAL { get; set; }
        public Nullable<decimal> APOYO_REAL { get; set; }
        public Nullable<System.DateTime> VIGENCIA_DE { get; set; }
        public Nullable<System.DateTime> VIGENCIA_AL { get; set; }
        public Nullable<decimal> APOYO_EST { get; set; }
    
        public virtual DOCUMENTBORR DOCUMENTBORR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTOBORRM> DOCUMENTOBORRMs { get; set; }
    }
}
