using DL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class Numero
    {
        
        public static int CalcularSuperDigito(string numero)
        {
            while (numero.Length > 1)
            {
                int suma = 0;

                for (int i = 0; i < numero.Length; i++)
                {
                    suma += int.Parse(numero[i].ToString());
                }

                numero = suma.ToString();
            }

            return int.Parse(numero);
        }


        public static ML.Result Insertar(string numero, int resultado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SuperDigitoEntities1 context = new SuperDigitoEntities1())
                {
                    int num = int.Parse(numero);
                    DateTime fechahora = DateTime.Now;

                    var query = context.Insertar(num, resultado, fechahora);

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();

            try
            {
                using (SuperDigitoEntities1 context = new SuperDigitoEntities1())
                {
                    var query = context.GetAll().ToList();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Numerox num = new ML.Numerox();

                            num.Numero = item.Numero;
                            num.Resultado = item.Resultado;
                            num.FechaHora = item.FechaHora;

                            result.Objects.Add(num);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Delete()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SuperDigitoEntities1 context = new SuperDigitoEntities1())
                {
                    context.DeleteHistorial();
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

    }
}
