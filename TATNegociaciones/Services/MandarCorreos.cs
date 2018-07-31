using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Data.Entity;

namespace TATNegociaciones.Services
{
    public class MandarCorreos
    {
        private TAT001Entities db = new TAT001Entities();

        public List<string> armarCorreos()
        {
            List<string> errores = new List<string>();
            try
            {
                var _hoy = DateTime.Now;
                var _neg = db.NEGOCIACIONs.Where(x => x.FECHAN.Day == _hoy.Day && x.FECHAN.Month == _hoy.Month && x.FECHAN.Year == _hoy.Year && x.ACTIVO == true).FirstOrDefault();
                if (_neg != null)
                {
                    //Realizo una consulta por medio de la coincidencia entre fechas
                    //var fs = db.DOCUMENTOes.Where(f => (f.FECHAC.Value.Day >= _neg.FECHAI.Day && f.FECHAC.Value.Day <= _neg.FECHAF.Day) && f.FECHAC.Value.Month == _neg.FECHAF.Month && f.FECHAC.Value.Year == _neg.FECHAF.Year).ToList();
                    var fs = db.DOCUMENTOes.Where(f => (f.FECHAC >= _neg.FECHAI && f.FECHAC <= _neg.FECHAF)).ToList();
                    var fs3 = fs.DistinctBy(q => q.PAYER_ID).ToList();
                    for (int i = 0; i < fs3.Count; i++)
                    {
                        if (fs3[i].PAYER_ID != null && fs3[i].PAYER_EMAIL != null)
                        {
                            var de = fs3[i].NUM_DOC;
                            var dsa = db.DOCUMENTOAs.Where(x => x.NUM_DOC == de && x.CLASE != "OTR").FirstOrDefault();
                            if (dsa == null || dsa != null)
                            {
                                errores.AddRange(mandarCorreo(fs3[i].PAYER_ID, fs3[i].VKORG, fs3[i].VTWEG, fs3[i].SPART, fs3[i].PAYER_EMAIL, _neg.FECHAI, _neg.FECHAF));
                            }
                        }
                    }
                }
            }
            catch (Exception exe)
            {
                errores.Add(exe.ToString());
            }
            return errores;
        }

        public List<string> mandarCorreo(string pay, string vkorg, string vtweg, string spart, string correo, DateTime fi, DateTime ff)
        {
            List<string> errores = new List<string>();
            try
            {
                //LEJ 20.07.2018------------------------------
                //Validar si hay coincidencias en el filtro
                //var dOCUMENTOes = db.DOCUMENTOes.Where(x => x.PAYER_ID == pay && x.VKORG == vkorg && x.VTWEG == vtweg && x.SPART == spart && x.PAYER_EMAIL == correo && ((x.FECHAC.Value.Day >= fi.Day && x.FECHAC.Value.Day <= ff.Day) && x.FECHAC.Value.Month == ff.Month && x.FECHAC.Value.Year == ff.Year)).Include(d => d.CLIENTE).Include(d => d.PAI).Include(d => d.SOCIEDAD).Include(d => d.TALL).Include(d => d.TSOL).Include(d => d.USUARIO).ToList();
                var dOCUMENTOes = db.DOCUMENTOes.Where(x => x.PAYER_ID == pay && x.VKORG == vkorg && x.VTWEG == vtweg && x.SPART == spart && x.PAYER_EMAIL == correo && (x.FECHAC >= fi && x.FECHAC <= ff)).Include(d => d.CLIENTE).Include(d => d.PAI).Include(d => d.SOCIEDAD).Include(d => d.TALL).Include(d => d.TSOL).Include(d => d.USUARIO).ToList();
                DOCUMENTOA dz = null;
                //Para ver si encuentra un match
                int xv = 0;
                for (int i = 0; i < dOCUMENTOes.Count; i++)
                {
                    //si el documentoref es nullo, significa que no depende de alguno otro
                    if (dOCUMENTOes[i].DOCUMENTO_REF == null)
                    {
                        //recupero el numdoc
                        var de = dOCUMENTOes[i].NUM_DOC;
                        //sino ecuentra una coincidencia con el criterio discriminatorio se agregan o no a la lista
                        dz = db.DOCUMENTOAs.Where(x => x.NUM_DOC == de && x.CLASE != "OTR").FirstOrDefault();
                        if (dz == null || dz != null)
                        {
                            if (dOCUMENTOes[i].TSOL.NEGO == true)//para el ultimo filtro
                            {
                                if (dOCUMENTOes[i].ESTATUS_WF == "P")//LEJ 19.07.2018---------------------------I
                                {
                                    if (dOCUMENTOes[i].FLUJOes.Count > 0)
                                    {
                                        if (dOCUMENTOes[i].FLUJOes.OrderByDescending(a => a.POS).FirstOrDefault().USUARIO != null)
                                        {
                                            //(Pendiente Validación TS)
                                            if (dOCUMENTOes[i].FLUJOes.OrderByDescending(a => a.POS).FirstOrDefault().USUARIO.PUESTO_ID == 8)
                                            {
                                                xv++;
                                            }
                                        }
                                    }
                                }
                                else if (dOCUMENTOes[i].ESTATUS_WF == "R")//(Pendiente Corrección)
                                {
                                    if (dOCUMENTOes[i].FLUJOes.Count > 0)
                                    {
                                        xv++;
                                    }
                                }
                                else if (dOCUMENTOes[i].ESTATUS_WF == "T")//(Pendiente Taxeo)
                                {
                                    if (dOCUMENTOes[i].TSOL_ID == "NCIA")
                                    {
                                        if (dOCUMENTOes[i].PAIS_ID == "CO")//(sólo Colombia)
                                        {
                                            xv++;
                                        }
                                    }
                                }
                                else if (dOCUMENTOes[i].ESTATUS_WF == "A")//(Por Contabilizar)
                                {
                                    if (dOCUMENTOes[i].ESTATUS == "P")
                                    {
                                        xv++;
                                    }
                                }
                                else if (dOCUMENTOes[i].ESTATUS_SAP == "E")//Error en SAP
                                {
                                    // dx.Add(dOCUMENTOes[i]);
                                }
                                else if (dOCUMENTOes[i].ESTATUS_SAP == "X")//Succes en SAP
                                {
                                    xv++;
                                }
                            }
                            //LEJ 19.07.2018----------------------------------------------------------------T
                            // dx.Add(dOCUMENTOes[i]);
                        }
                    }
                }
                //si encontro entra.
                if (xv > 0)//LEJ 20.07.2018-----
                {
                    //string mailt = ConfigurationManager.AppSettings["mailt"];
                    APPSETTING mailC = db.APPSETTINGs.Where(x => x.NOMBRE.Equals("mail") & x.ACTIVO).FirstOrDefault();
                    if (mailC == null) { Console.Write("Falta configuración de tipo de email!"); errores.Add("Falta configuración de tipo de email!"); }//RSG 30.07.2018

                    string mailt = mailC.VALUE;//RSG 30.07.2018
                    CONMAIL conmail = db.CONMAILs.Find(mailt);
                    if (conmail != null)
                    {
                        //MailMessage mail = new MailMessage(conmail.MAIL, "rogelio.sanchez@sf-solutionfactory.com");
                        MailMessage mail = new MailMessage(conmail.MAIL, correo);
                        SmtpClient client = new SmtpClient();
                        if (conmail.SSL)
                        {
                            client.Port = (int)conmail.PORT;
                            client.EnableSsl = conmail.SSL;
                            client.UseDefaultCredentials = false;
                            client.Credentials = new NetworkCredential(conmail.MAIL, conmail.PASS);
                        }
                        else
                        {
                            client.UseDefaultCredentials = true;
                            client.Credentials = new NetworkCredential(conmail.MAIL, conmail.PASS);
                        }
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Host = conmail.HOST;
                        try
                        {
                            APPSETTING urlC = db.APPSETTINGs.Where(x => x.NOMBRE.Equals("url") & x.ACTIVO).FirstOrDefault();
                            //string cadUrl = System.Configuration.ConfigurationManager.AppSettings["url"];                
                            if (urlC == null) { Console.Write("Falta configuración de URL!"); errores.Add("Falta configuración!"); }//RSG 30.07.2018
                            string cadUrl = urlC.VALUE;//RSG 30.07.2018
                            cadUrl += "Negociaciones/Index/";
                            string UrlDirectory = cadUrl;
                            UrlDirectory += "?pay=" + pay + "&vkorg=" + vkorg + "&vtweg=" + vtweg + "&spart=" + spart + "&correo=" + correo + "&fi=" + fi.ToShortDateString() + "&ff=" + ff.ToShortDateString();
                            WebRequest myRequest = WebRequest.Create(UrlDirectory);
                            myRequest.Method = "GET";
                            WebResponse myResponse = myRequest.GetResponse();
                            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                            string result = sr.ReadToEnd();
                            sr.Close();
                            myResponse.Close();
                            mail.IsBodyHtml = true;
                            mail.Body = result;
                            mail.Subject = "TAT Kellogg's - " + DateTime.Now.ToShortDateString();
                            client.Send(mail);
                        }
                        catch (Exception ex)
                        {
                            errores.Add("No se ha podido enviar el email");
                            throw new Exception("No se ha podido enviar el email", ex.InnerException);
                        }
                    }
                }
            }
            catch(Exception exe)
            {
                errores.Add(exe.ToString());
            }
            return errores;
        }
    }
}
