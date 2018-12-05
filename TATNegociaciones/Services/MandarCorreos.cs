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
        Log log = new Log();

        public List<string> armarCorreos()
        {
            List<string> errores = new List<string>();
            try
            {

                APPSETTING lg = db.APPSETTINGs.Where(x => x.NOMBRE == "logPath" && x.ACTIVO).FirstOrDefault();
                log.ruta = lg.VALUE + "Nego_";
                log.escribeLog("-----------------------------------------------------------------------START");

                var _hoy = DateTime.Now;
                ////var _neg = db.NEGOCIACIONs.Where(x => x.FECHAN.Day == _hoy.Day && x.FECHAN.Month == _hoy.Month && x.FECHAN.Year == _hoy.Year && x.ACTIVO == true).FirstOrDefault();
                List<NEGOCIACION> nn = db.NEGOCIACIONs.Where(x => x.ACTIVO).ToList();
                var _neg = nn.FirstOrDefault(x => x.FECHAN == _hoy.Date && x.ACTIVO);
                if (_neg != null)
                {
                    ////Realizo una consulta por medio de la coincidencia entre fechas
                    ////var fs = db.DOCUMENTOes.Where(f => (f.FECHAC.Value.Day >= _neg.FECHAI.Day && f.FECHAC.Value.Day <= _neg.FECHAF.Day) && f.FECHAC.Value.Month == _neg.FECHAF.Month && f.FECHAC.Value.Year == _neg.FECHAF.Year).ToList();
                    var fs = db.DOCUMENTOes.Where(f => (f.FECHAC >= _neg.FECHAI && f.FECHAC <= _neg.FECHAF)).ToList();
                    var fs3 = fs.DistinctBy(q => new { q.PAYER_ID, q.PAYER_EMAIL }).ToList();
                    for (int i = 0; i < fs3.Count; i++)
                    {
                        ////if (fs3[i].PAYER_ID == "0000400417")
                        ////    fs3[i].PAYER_ID = "0000400417";
                        if (fs3[i].PAYER_ID != null && fs3[i].PAYER_EMAIL != null)
                        {
                            log.escribeLog("PAYER: " + fs3[i].PAYER_ID);
                            log.escribeLog("PAYER MAIL: " + fs3[i].PAYER_EMAIL);
                            ////var cco = db.CONTACTOCs.Where(x => x.KUNNR == fs3[i].PAYER_ID && x.EMAIL == fs3[i].PAYER_EMAIL).Select(x=>x).ToList();
                            var cco = (from c in db.CONTACTOCs
                                       select new { c.KUNNR, c.EMAIL, CARTA = c.CARTA == null ? true : (bool)c.CARTA }).ToList();
                            var co = cco.FirstOrDefault(x => x.KUNNR == fs3[i].PAYER_ID && x.EMAIL == fs3[i].PAYER_EMAIL);
                            if (co == null)
                            {
                                var de = fs3[i].NUM_DOC;
                                if (fs3[i].DOCUMENTOAs.Count > 0)
                                {
                                    var dsa = fs3[i].DOCUMENTOAs.FirstOrDefault(x => x.NUM_DOC == de && x.CLASE == "OTR");
                                    if (dsa == null)
                                    {
                                        ////bool ban = true;
                                        ////if (ban)
                                        errores.AddRange(mandarCorreo(fs3[i].PAYER_ID, fs3[i].VKORG, fs3[i].VTWEG, fs3[i].SPART, fs3[i].PAYER_EMAIL, _neg.FECHAI, _neg.FECHAF));
                                    }
                                }
                            }
                            else
                            {
                                ////if (co.CARTA == null)
                                ////    co.CARTA = true;
                                if (!co.CARTA)
                                {
                                    var de = fs3[i].NUM_DOC;
                                    if (fs3[i].DOCUMENTOAs.Count > 0)
                                    {
                                        var dsa = fs3[i].DOCUMENTOAs.FirstOrDefault(x => x.NUM_DOC == de && x.CLASE == "OTR");
                                        if (dsa == null)
                                        {
                                            ////bool ban = true;
                                            ////if (ban)
                                            errores.AddRange(mandarCorreo(fs3[i].PAYER_ID, fs3[i].VKORG, fs3[i].VTWEG, fs3[i].SPART, fs3[i].PAYER_EMAIL, _neg.FECHAI, _neg.FECHAF));
                                        }
                                    }
                                }
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
                ////var dOCUMENTOes = db.DOCUMENTOes.Where(x => x.PAYER_ID == pay && x.VKORG == vkorg && x.VTWEG == vtweg && x.SPART == spart && x.PAYER_EMAIL == correo && ((x.FECHAC.Value.Day >= fi.Day && x.FECHAC.Value.Day <= ff.Day) && x.FECHAC.Value.Month == ff.Month && x.FECHAC.Value.Year == ff.Year)).Include(d => d.CLIENTE).Include(d => d.PAI).Include(d => d.SOCIEDAD).Include(d => d.TALL).Include(d => d.TSOL).Include(d => d.USUARIO).ToList();
                var dOCUMENTOes = db.DOCUMENTOes.Where(x => x.PAYER_ID == pay && x.VKORG == vkorg && x.VTWEG == vtweg && x.SPART == spart && x.PAYER_EMAIL == correo && (x.FECHAC >= fi && x.FECHAC <= ff)).Include(d => d.CLIENTE).Include(d => d.PAI).Include(d => d.SOCIEDAD).Include(d => d.TALL).Include(d => d.TSOL).Include(d => d.USUARIO).ToList();
                ////DOCUMENTOA dz = null;
                //Para ver si encuentra un match
                ////int xv = 0;
                int xxv = 0;
                for (int i = 0; i < dOCUMENTOes.Count; i++)
                {
                    PorEnviar pe = new PorEnviar();
                    if (pe.seEnvia(dOCUMENTOes[i], db, log))
                        xxv++;
                }
                //si encontro entra.
                if (xxv > 0)//LEJ 20.07.2018-----
                {
                    ////string mailt = ConfigurationManager.AppSettings["mailt"];
                    APPSETTING mailC = db.APPSETTINGs.Where(x => x.NOMBRE.Equals("mail") && x.ACTIVO).FirstOrDefault();
                    if (mailC == null) { Console.Write("Falta configuración de tipo de email!"); errores.Add("Falta configuración de tipo de email!"); return errores; }//RSG 30.07.2018

                    string mailt = mailC.VALUE;//RSG 30.07.2018
                    CONMAIL conmail = db.CONMAILs.Find(mailt);
                    if (conmail != null)
                    {
                        MailMessage mail = new MailMessage(conmail.MAIL, "rogelio.sanchez@kellogg.com");
                        ////MailMessage mail = new MailMessage(conmail.MAIL, correo);
                        log.escribeLog("MAIL TO: TST");
                        log.escribeLog("MAIL TO: " + correo);
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
                            APPSETTING urlC = db.APPSETTINGs.Where(x => x.NOMBRE.Equals("url") && x.ACTIVO).FirstOrDefault();
                            ////string cadUrl = System.Configuration.ConfigurationManager.AppSettings["url"];                
                            if (urlC == null) { Console.Write("Falta configuración de URL!"); errores.Add("Falta configuración!"); return errores; }//RSG 30.07.2018
                            string cadUrl = urlC.VALUE;//RSG 30.07.2018
                            cadUrl += "Negociaciones/Index/";
                            string UrlDirectory = cadUrl;
                            UrlDirectory += "?pay=" + pay + "&vkorg=" + vkorg + "&vtweg=" + vtweg + "&spart=" + spart + "&correo=" + correo + "&fi=" + fi.ToShortDateString() + "&ff=" + ff.ToShortDateString();
                            log.escribeLog("url: " + UrlDirectory);

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
                            log.escribeLog("ENVIADO: NO");
                            errores.Add("No se ha podido enviar el email");
                            log.escribeLog("ERROR: " + ex.InnerException);
                            ////throw new Exception("No se ha podido enviar el email", ex.InnerException);
                            return errores;
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
    }
}
