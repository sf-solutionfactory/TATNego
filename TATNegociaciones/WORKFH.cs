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
    
    public partial class WORKFH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WORKFH()
        {
            this.WORKFVs = new HashSet<WORKFV>();
        }
    
        public string ID { get; set; }
        public string DESCRIPCION { get; set; }
        public string TSOL_ID { get; set; }
        public Nullable<bool> ESTATUS { get; set; }
        public string USUARIO_ID { get; set; }
        public Nullable<System.DateTime> FECHAC { get; set; }
        public string BUKRS { get; set; }
        public Nullable<int> ROL_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WORKFV> WORKFVs { get; set; }
    }
}
