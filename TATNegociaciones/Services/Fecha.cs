using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATNegociaciones.Services
{
    class Fecha
    {

        public static DateTime obtenerProximaFecha(NEGOCIACION2 modelo, string tipomes)
        {
            DateTime proximafecha = modelo.FINICIO;
            if (modelo.FRECUENCIA == "S")
            {
                var diasemana = getDiaNombre(modelo.DIA_SEMANA);
                if (modelo.FINICIO.DayOfWeek.ToString() == diasemana)
                {
                    return modelo.FINICIO;
                }
                else
                {
                    var dia_semana = getDiaNum(getDiaNombre(modelo.DIA_SEMANA));
                    var dia_inicio = getDiaNum(modelo.FINICIO.DayOfWeek.ToString());
                    if (dia_inicio == 7)
                    {
                        if (dia_semana == 6)
                            proximafecha = proximafecha.AddDays(6);
                        else if (dia_semana == 5)
                            proximafecha = proximafecha.AddDays(5);
                        else if (dia_semana == 4)
                            proximafecha = proximafecha.AddDays(4);
                        else if (dia_semana == 3)
                            proximafecha = proximafecha.AddDays(3);
                        else if (dia_semana == 2)
                            proximafecha = proximafecha.AddDays(2);
                        else if (dia_semana == 1)
                            proximafecha = proximafecha.AddDays(1);
                    }
                    if (dia_inicio == 6)
                    {
                        if (dia_semana > dia_inicio)
                            proximafecha = proximafecha.AddDays((dia_semana - dia_inicio));
                        else if (dia_semana == 5)
                            proximafecha = proximafecha.AddDays(6);
                        else if (dia_semana == 4)
                            proximafecha = proximafecha.AddDays(5);
                        else if (dia_semana == 3)
                            proximafecha = proximafecha.AddDays(4);
                        else if (dia_semana == 2)
                            proximafecha = proximafecha.AddDays(3);
                        else if (dia_semana == 1)
                            proximafecha = proximafecha.AddDays(2);
                    }
                    if (dia_inicio == 5)
                    {
                        if (dia_semana > dia_inicio)
                            proximafecha = proximafecha.AddDays((dia_semana - dia_inicio));
                        else if (dia_semana == 4)
                            proximafecha = proximafecha.AddDays(6);
                        else if (dia_semana == 3)
                            proximafecha = proximafecha.AddDays(5);
                        else if (dia_semana == 2)
                            proximafecha = proximafecha.AddDays(4);
                        else if (dia_semana == 1)
                            proximafecha = proximafecha.AddDays(3);
                    }
                    if (dia_inicio == 4)
                    {
                        if (dia_semana > dia_inicio)
                            proximafecha = proximafecha.AddDays((dia_semana - dia_inicio));
                        else if (dia_semana == 3)
                            proximafecha = proximafecha.AddDays(6);
                        else if (dia_semana == 2)
                            proximafecha = proximafecha.AddDays(5);
                        else if (dia_semana == 1)
                            proximafecha = proximafecha.AddDays(dia_inicio);
                    }
                    if (dia_inicio == 3)
                    {
                        if (dia_semana > dia_inicio)
                            proximafecha = proximafecha.AddDays((dia_semana - dia_inicio));
                        else if (dia_semana == 2)
                            proximafecha = proximafecha.AddDays(6);
                        else if (dia_semana == 1)
                            proximafecha = proximafecha.AddDays(5);
                    }
                    if (dia_inicio == 2)
                    {
                        if (dia_semana > dia_inicio)
                            proximafecha = proximafecha.AddDays((dia_semana - dia_inicio));
                        else if (dia_semana == 1)
                            proximafecha = proximafecha.AddDays(6);
                    }
                    if (dia_inicio == 1)
                    {
                        proximafecha = proximafecha.AddDays((dia_semana - dia_inicio));
                    }
                }
            }
            else
            {
                if (tipomes == "1")
                {
                    if ((int)modelo.FINICIO.Day <= modelo.DIA_MES)
                    {
                        proximafecha = new DateTime(modelo.FINICIO.Year, modelo.FINICIO.Month, (int)modelo.DIA_MES);
                    }
                    else
                    {
                        proximafecha = new DateTime(modelo.FINICIO.Year, modelo.FINICIO.Month, (int)modelo.DIA_MES).AddMonths(modelo.FRECUENCIA_N);
                    }
                }
                else
                {
                    var dia = getDiaNombre(modelo.ORDINAL_DSEMANA);
                    var ordinal = modelo.ORDINAL_MES;
                    var diasmes = DateTime.DaysInMonth(modelo.FINICIO.Year, modelo.FINICIO.Month);
                    for (int i = 1; i <= diasmes; i++)
                    {
                        var fecha = new DateTime(modelo.FINICIO.Year, modelo.FINICIO.Month, i);
                        if (fecha.DayOfWeek.ToString() == dia)
                        {
                            var mes = fecha.Month;
                            fecha = fecha.AddDays((7 * (int)(modelo.ORDINAL_MES - 1)));
                            var mes2 = fecha.Month;
                            if (mes != mes2)
                                fecha = fecha.AddDays(-7);
                            if (modelo.FINICIO < fecha)
                                return fecha;
                            var fecha2 = new DateTime(modelo.FINICIO.Year, modelo.FINICIO.Month, 1).AddMonths(1);
                            var diasmes2 = DateTime.DaysInMonth(fecha2.Year, fecha2.Month);
                            for (int j = 1; j <= diasmes2; j++)
                            {
                                var fechatemp = new DateTime(fecha2.Year, fecha2.Month, j);
                                if (fechatemp.DayOfWeek.ToString() == dia)
                                {
                                    fechatemp = fechatemp.AddDays((7 * (int)(modelo.ORDINAL_MES - 1)));
                                    return fechatemp;
                                }
                            }
                        }
                    }

                }
            }
            return proximafecha;
        }
        
        public static string getDiaNombre(string nombre)
        {
            if (nombre == "D") return "Sunday";
            if (nombre == "L") return "Monday";
            if (nombre == "M") return "Tuesday";
            if (nombre == "X") return "Wednesday";
            if (nombre == "J") return "Thursday";
            if (nombre == "V") return "Friday";
            if (nombre == "S") return "Saturday";
            else return "";
        }
        public static int getDiaNum(string nombre)
        {
            if (nombre == "Sunday") return 7;
            if (nombre == "Monday") return 1;
            if (nombre == "Tuesday") return 2;
            if (nombre == "Wednesday") return 3;
            if (nombre == "Thursday") return 4;
            if (nombre == "Friday") return 5;
            if (nombre == "Saturday") return 6;
            else return 1;
        }
    }
}
