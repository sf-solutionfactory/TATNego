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
    
    public partial class DOCUMENTBORR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCUMENTBORR()
        {
            this.DOCUMENTOBORRFs = new HashSet<DOCUMENTOBORRF>();
            this.DOCUMENTOBORRNs = new HashSet<DOCUMENTOBORRN>();
            this.DOCUMENTOBORRPs = new HashSet<DOCUMENTOBORRP>();
            this.DOCUMENTOBORRRECs = new HashSet<DOCUMENTOBORRREC>();
        }
    
        public string USUARIOC_ID { get; set; }
        public string TSOL_ID { get; set; }
        public string TALL_ID { get; set; }
        public string SOCIEDAD_ID { get; set; }
        public string PAIS_ID { get; set; }
        public string ESTADO { get; set; }
        public string CIUDAD { get; set; }
        public Nullable<int> PERIODO { get; set; }
        public string EJERCICIO { get; set; }
        public string TIPO_TECNICO { get; set; }
        public string TIPO_RECURRENTE { get; set; }
        public Nullable<decimal> CANTIDAD_EV { get; set; }
        public Nullable<System.DateTime> FECHAD { get; set; }
        public Nullable<System.DateTime> FECHAC { get; set; }
        public Nullable<System.TimeSpan> HORAC { get; set; }
        public Nullable<System.DateTime> FECHAC_PLAN { get; set; }
        public Nullable<System.DateTime> FECHAC_USER { get; set; }
        public Nullable<System.TimeSpan> HORAC_USER { get; set; }
        public string ESTATUS { get; set; }
        public string ESTATUS_C { get; set; }
        public string ESTATUS_SAP { get; set; }
        public string ESTATUS_WF { get; set; }
        public Nullable<decimal> DOCUMENTO_REF { get; set; }
        public string CONCEPTO { get; set; }
        public string NOTAS { get; set; }
        public Nullable<decimal> MONTO_DOC_MD { get; set; }
        public Nullable<decimal> MONTO_FIJO_MD { get; set; }
        public Nullable<decimal> MONTO_BASE_GS_PCT_MD { get; set; }
        public Nullable<decimal> MONTO_BASE_NS_PCT_MD { get; set; }
        public Nullable<decimal> MONTO_DOC_ML { get; set; }
        public Nullable<decimal> MONTO_FIJO_ML { get; set; }
        public Nullable<decimal> MONTO_BASE_GS_PCT_ML { get; set; }
        public Nullable<decimal> MONTO_BASE_NS_PCT_ML { get; set; }
        public Nullable<decimal> MONTO_DOC_ML2 { get; set; }
        public Nullable<decimal> MONTO_FIJO_ML2 { get; set; }
        public Nullable<decimal> MONTO_BASE_GS_PCT_ML2 { get; set; }
        public Nullable<decimal> MONTO_BASE_NS_PCT_ML2 { get; set; }
        public Nullable<decimal> PORC_ADICIONAL { get; set; }
        public string IMPUESTO { get; set; }
        public Nullable<System.DateTime> FECHAI_VIG { get; set; }
        public Nullable<System.DateTime> FECHAF_VIG { get; set; }
        public string ESTATUS_EXT { get; set; }
        public string SOLD_TO_ID { get; set; }
        public string PAYER_ID { get; set; }
        public string PAYER_NOMBRE { get; set; }
        public string PAYER_EMAIL { get; set; }
        public string GRUPO_CTE_ID { get; set; }
        public string CANAL_ID { get; set; }
        public string MONEDA_ID { get; set; }
        public string MONEDAL_ID { get; set; }
        public string MONEDAL2_ID { get; set; }
        public Nullable<decimal> TIPO_CAMBIO { get; set; }
        public Nullable<decimal> TIPO_CAMBIOL { get; set; }
        public Nullable<decimal> TIPO_CAMBIOL2 { get; set; }
        public string NO_FACTURA { get; set; }
        public Nullable<System.DateTime> FECHAD_SOPORTE { get; set; }
        public string METODO_PAGO { get; set; }
        public string NO_PROVEEDOR { get; set; }
        public Nullable<int> PASO_ACTUAL { get; set; }
        public string AGENTE_ACTUAL { get; set; }
        public Nullable<System.DateTime> FECHA_PASO_ACTUAL { get; set; }
        public string VKORG { get; set; }
        public string VTWEG { get; set; }
        public string SPART { get; set; }
        public string TIPO_TECNICO2 { get; set; }
        public string MONEDA_DIS { get; set; }
        public Nullable<decimal> PORC_APOYO { get; set; }
        public string LIGADA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTOBORRF> DOCUMENTOBORRFs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTOBORRN> DOCUMENTOBORRNs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTOBORRP> DOCUMENTOBORRPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCUMENTOBORRREC> DOCUMENTOBORRRECs { get; set; }
    }
}
