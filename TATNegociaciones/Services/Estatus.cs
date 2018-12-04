using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TATNegociaciones.Services
{
    class Estatus
    {
        public string getEstatus(DOCUMENTO d)
        {
            TAT001Entities db = new TAT001Entities();
            decimal doc = decimal.Parse(d.NUM_DOC.ToString());
            string estatus = "";
            ////bool rev = false;
            var estatusPar = (from docs in db.DOCUMENTOes where docs.DOCUMENTO_REF == doc select docs).ToList();
            if (d.ESTATUS != null) { estatus += d.ESTATUS; } else { estatus += " "; }
            if (d.ESTATUS_C != null) { estatus += d.ESTATUS_C; } else { estatus += " "; }
            if (d.ESTATUS_SAP != null) { estatus += d.ESTATUS_SAP; } else { estatus += " "; }
            if (d.ESTATUS_WF != null) { estatus += d.ESTATUS_WF; } else { estatus += " "; }
            ////foreach (var childDoc in estatusPar)
            ////{
            ////    if (childDoc.ESTATUS == "N" && childDoc.ESTATUS_C == null && childDoc.ESTATUS_SAP == null && childDoc.ESTATUS_WF == "P")
            ////    {
            ////        rev = false;
            ////    }
            ////}
            if (d.FLUJOes.Count > 0)
            {
                estatus += d.FLUJOes.OrderByDescending(a => a.POS).FirstOrDefault().WORKFP.ACCION.TIPO;
            }
            else
            {
                estatus += " ";
            }
            if (d.TSOL != null)
                if (d.TSOL.PADRE) { estatus += "P"; } else { estatus += " "; }
            else { estatus += " "; }
            if (d.FLUJOes.Where(x => x.ESTATUS == "R").ToList().Count > 0)
            {
                FLUJO flujo = d.FLUJOes.Where(x => x.ESTATUS == "R").OrderByDescending(a => a.POS).FirstOrDefault();
                estatus += db.USUARIOs.First(x => x.ID == flujo.USUARIOA_ID).PUESTO_ID;
            }
            else
            {
                estatus += " ";
            }
            if (d.DOCUMENTORECs.Count > 0)
            {
                estatus += "R";
            }
            else
            {
                estatus += " ";
            }
            if (estatusPar.Any(a => a.TSOL.REVERSO && a.DOCUMENTO_SAP != null))
                estatus += "1";
            else
                estatus += "0";
            return estatus;
        }
    }
}
