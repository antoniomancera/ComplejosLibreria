using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complejos
{

    public class Complejos
    {
        public Complejos()
        {

        }

        private double real;
        private double imaginario;
        public Complejos(double Real, double Imaginario)
        {
            this.Real = Real;
            this.Imaginario = Imaginario;
        }
        public double Real { get; set; }
        public double Imaginario { get; set; }


        public static Complejos uno = new Complejos(1, 0);
        public static Complejos menosuno = new Complejos(-1, 0);

        public static double Ro(Complejos complejo)
        {
            double ro;
            ro = Math.Sqrt(Math.Pow(complejo.Real, 2) + Math.Pow(complejo.Imaginario, 2));
            return ro;
        }

        public static double Tita(Complejos complejo)
        {
            double tita;
            tita = Math.Atan2(complejo.Imaginario, complejo.Real);
            return tita;
        }

        public static Complejos SumaComplejos(Complejos numero1, Complejos numero2)
        {
            Complejos resultado = new Complejos();
            resultado.Real = numero1.Real + numero2.Real;
            resultado.Imaginario = numero1.Imaginario + numero2.Imaginario;
            return resultado;
        }

        public static Complejos RestaComplejos(Complejos numero1, Complejos numero2)
        {
            Complejos resultado = new Complejos();
            resultado.Real = numero1.Real - numero2.Real;
            resultado.Imaginario = numero1.Imaginario - numero2.Imaginario;
            return resultado;
        }

        public static Complejos Dividirpor2(Complejos complejo)
        {
            Complejos resultado = new Complejos();
            resultado.Real = complejo.Real / 2;
            resultado.Imaginario = complejo.Imaginario / 2;
            return resultado;
        }

        public static Complejos MultiplicarPorReal(Complejos complejo, double numero)
        {
            Complejos resultado = new Complejos
            {
                Real = complejo.Real * numero,
                Imaginario = complejo.Imaginario * numero
            };
            return resultado;
        }

        public static double DistanciaEntreComplejos(Complejos complejo1, Complejos complejo2)
        {
            double distancia;
            distancia = Math.Sqrt(Math.Pow((complejo1.Real - complejo2.Real), 2) + Math.Pow((complejo1.Imaginario - complejo2.Imaginario), 2));
            return distancia;
        }
        public static double ModuloComplejo(Complejos z)
        {
            double resultado;
            resultado = Math.Sqrt(Math.Pow(z.Real, 2) + Math.Pow(z.Imaginario, 2));
            return resultado;
        }
        public static int CantidadListaComplejos(List<Complejos> listaComplejos)
        {
            int cont = 0;
            foreach (Complejos item in listaComplejos)
            {
                cont++;
            }

            return cont;
        }

        public static Complejos Radicando(Complejos c)
        {
            Complejos radicando = new Complejos();

            Complejos cuatroC = new Complejos();
            cuatroC = MultiplicarPorReal(c, 4);
            radicando = RaizCuadradaComplejo(RestaComplejos(uno, cuatroC));
            return radicando;
        }
        public static Complejos RaizCuadradaComplejo(Complejos complejo)
        {
            Complejos raizcuadradacomplejo = new Complejos();
            double ro = Ro(complejo);
            double tita = Tita(complejo);
            raizcuadradacomplejo.Imaginario = Math.Sqrt(ro) * Math.Sin(tita / 2);
            raizcuadradacomplejo.Real = Math.Sqrt(ro) * Math.Cos(tita / 2);
            return raizcuadradacomplejo;
        }

        public static Complejos CuadradoComplejos(Complejos z)
        {
            Complejos resultado = new Complejos();
            resultado.Real = Math.Pow(z.Real, 2) - Math.Pow(z.Imaginario, 2);
            resultado.Imaginario = 2 * z.Real * z.Imaginario;
            return resultado;

        }
        public static Complejos PuntoFijoPositivo(Complejos c)
        {
            Complejos puntofijopos = new Complejos();

            Complejos radicando = new Complejos();
            radicando = Radicando(c);
            puntofijopos = Dividirpor2(SumaComplejos(menosuno, radicando));
            return puntofijopos;
        }

        public static Complejos PuntoFijoNegativo(Complejos c)
        {
            Complejos puntofijoneg = new Complejos();

            Complejos radicando = new Complejos();
            radicando = Radicando(c);
            puntofijoneg = Dividirpor2(RestaComplejos(menosuno, radicando));
            return puntofijoneg;
        }

        public static Complejos IteradaInversaNegativa(Complejos c)
        {
            Complejos resultado = new Complejos();
            Complejos puntofijo = PuntoFijoNegativo(c);
            resultado = RaizCuadradaComplejo(RestaComplejos(puntofijo, c));
            return resultado;
        }

        public static Complejos Julia(Complejos z, Complejos c)
        {
            Complejos resultado = new Complejos();
            resultado = SumaComplejos(CuadradoComplejos(z), c);
            return resultado;
        }

        public static Complejos JuliaIterada(Complejos z, Complejos c, int iterada)
        {
            int cont = 1;
            Complejos resultado = new Complejos();
            resultado = Julia(z, c);
            while (cont < iterada)
            {
                resultado = Julia(resultado, c);
                cont++;
            }
            return resultado;
        }
        public static Complejos InversaFuncionJulia(Complejos y, Complejos c, string signoraiz)
        {
            Complejos resultado = new Complejos();
            resultado = RaizCuadradaComplejo(RestaComplejos(y, c));
            if (signoraiz == "positivo")
            {

                return resultado;
            }
            else if (signoraiz == "negativo")
            {

                return MultiplicarPorReal(resultado, -1); ;
            }
            else
            {
                Console.WriteLine("El signo tiene que ser positivo o negativo");
                return null;
            }
        }

        public static List<Complejos> IteradaInversaPuntoFijoNegativa(Complejos c)
        {
            List<Complejos> InversaPositivayNegativa = new List<Complejos>();
            Complejos puntoFijoNegativo = new Complejos();
            puntoFijoNegativo = PuntoFijoNegativo(c);
            Complejos InversaPositiva = new Complejos();
            InversaPositiva = InversaFuncionJulia(puntoFijoNegativo, c, "positivo");
            Complejos inversaNegativa = new Complejos();
            inversaNegativa = InversaFuncionJulia(puntoFijoNegativo, c, "negativo");
            InversaPositivayNegativa.Add(inversaNegativa);
            InversaPositivayNegativa.Add(InversaPositiva);
            return InversaPositivayNegativa;
        }

        public static List<Complejos> IteradaInversaPuntoFijoPositivo(Complejos c)
        {
            List<Complejos> InversaPositivayNegativa = new List<Complejos>();
            Complejos puntoFijoPositivo = new Complejos();
            puntoFijoPositivo = PuntoFijoPositivo(c);
            Complejos InversaPositiva = new Complejos();
            InversaPositiva = InversaFuncionJulia(puntoFijoPositivo, c, "positivo");
            Complejos inversaNegativa = new Complejos();
            inversaNegativa = InversaFuncionJulia(puntoFijoPositivo, c, "negativo");
            InversaPositivayNegativa.Add(inversaNegativa);
            InversaPositivayNegativa.Add(InversaPositiva);
            return InversaPositivayNegativa;
        }

        public static List<Complejos> IteradaConDistanciaFijoPositivo(Complejos c, double distancia)
        {
            List<Complejos> puntosJulia = new List<Complejos>();
            puntosJulia.Add(c);
            Complejos puntoFijoPositivo = new Complejos();
            List<Complejos> juliaPuntoFijoPos = new List<Complejos>();
            juliaPuntoFijoPos = IteradaInversaPuntoFijoPositivo(c);
            if (CompruebaDistaciaAListaMayorP(puntosJulia, juliaPuntoFijoPos[0], distancia))
            {
                puntosJulia.Add(juliaPuntoFijoPos[0]);
            }
            if (CompruebaDistaciaAListaMayorP(puntosJulia, juliaPuntoFijoPos[1], distancia))
            {
                puntosJulia.Add(juliaPuntoFijoPos[1]);
            }
            puntosJulia.Remove(c);
            return puntosJulia;

        }

        public static List<Complejos> IteradasInversasConDistanciaFijoPositivo(Complejos c, double distancia, int totalIteradas)
        {
            List<Complejos> puntosJulia = new List<Complejos>();
            //puntosJulia.Add(c);
            Complejos puntoFijoPositivo = new Complejos();
            puntoFijoPositivo = PuntoFijoPositivo(c);
            puntosJulia.Add(puntoFijoPositivo);
            List<Complejos> NuevospuntosJulia = new List<Complejos>();
            List<Complejos> ListaAuxiliar = new List<Complejos>();
            int iter = 0;
            int longitudJulia = 1;
            int posicionEmpiezaIteradas = 0;
            int nuevosElementosJulia = 0;
            do
            {

                for (int i = posicionEmpiezaIteradas; i < longitudJulia; i++)
                {
                    ListaAuxiliar = IteradaInversaPuntoFijoPositivo(puntosJulia[i]);
                    //ListaAuxiliar=IteradaConDistanciaFijoPositivo(puntosJulia[i],distancia);
                    if (CompruebaDistaciaAListaMayorP(puntosJulia, ListaAuxiliar[0], distancia))
                    {
                        puntosJulia.Add(ListaAuxiliar[0]);
                        nuevosElementosJulia++;
                    }
                    if (CompruebaDistaciaAListaMayorP(puntosJulia, ListaAuxiliar[1], distancia))
                    {
                        puntosJulia.Add(ListaAuxiliar[1]);
                        nuevosElementosJulia++;
                    }
                }
                posicionEmpiezaIteradas = puntosJulia.Count - nuevosElementosJulia;
                //longitudJulia =CantidadListaComplejos(puntosJulia)-1;
                longitudJulia = puntosJulia.Count;
                ListaAuxiliar.Clear();
                iter++;
                nuevosElementosJulia = 0;
            } while (iter < totalIteradas);
            return puntosJulia;
        }


        /*  public static List<Complejos> IteradasInversasConDistanciaFijoPositivo(Complejos c,double distancia, int totalIteradas)
      {
          List<Complejos> puntosJulia = new List<Complejos>();
          puntosJulia.Add(c);
          List<Complejos> listaAuxiliarParaPuntosJulia=new List<Complejos>();
          Complejos puntoFijoPositivo = new Complejos();
          puntoFijoPositivo = PuntoFijoPositivo(c);
          int iter = 0;
          int posicionDondeAplicaInversaFuncion = 0;
          int longitudListaJuliaIteradaAnterior = 1;
          int valoresIntroducidos = 0;

          do
          {
              listaAuxiliarParaPuntosJulia = IteradaInversaPuntoFijoPositivo(c);
              while (posicionDondeAplicaInversaFuncion < longitudListaJuliaIteradaAnterior) 
              {
                  //listaAuxiliarParaPuntosJulia = IteradaInversaPuntoFijoPositivo(c);
                  if (CompruebaDistaciaAListaMayorP(puntosJulia, listaAuxiliarParaPuntosJulia[0], distancia)){
                      puntosJulia.Add(listaAuxiliarParaPuntosJulia[0]);
                      valoresIntroducidos++;
                  }
                  if (CompruebaDistaciaAListaMayorP(puntosJulia, listaAuxiliarParaPuntosJulia[1], distancia))
                  {
                      puntosJulia.Add(listaAuxiliarParaPuntosJulia[1]);
                      valoresIntroducidos++;
                  }
              }
              posicionDondeAplicaInversaFuncion = puntosJulia.Count - valoresIntroducidos;
              valoresIntroducidos = 0;
              iter++;

          } while (iter < totalIteradas);

          return puntosJulia;
      }
        */

        public static Boolean CompruebaDistaciaAListaMayorP(List<Complejos> listaComplejos, Complejos elemento, double p)
        {
            Boolean distancia = true;
            foreach (Complejos item in listaComplejos)
            {
                if (DistanciaEntreComplejos(item, elemento) < p)
                {
                    distancia = false;
                    break;
                }
            }
            return distancia;
        }

        public static List<Complejos> IntroduceEltoEnLtcomplejosSiDistanciaMayorP(List<Complejos> listaComplejos, Complejos elemento, double p)
        {
            Boolean elementosLejanos = true;
            foreach (Complejos item in listaComplejos)
            {
                if (DistanciaEntreComplejos(item, elemento) < p)
                {
                    elementosLejanos = false;
                    break;
                }
            }
            if (elementosLejanos)
            {
                listaComplejos.Add(elemento);
            }
            return listaComplejos;
        }

        public static void MostrarEnpantallaUnComplejo(Complejos complejo)
        {
            if (complejo.Imaginario > 0)
            {
                Console.WriteLine("El número es " + complejo.Real + " + " + complejo.Imaginario + "i");
            }
            else if (complejo.Imaginario < 0)
            {
                Console.WriteLine("El número es " + complejo.Real + complejo.Imaginario + "i");

            }
            else
            {
                Console.WriteLine("El número es " + complejo.Real);
            }
        }
        public static void ImprimeListaComplejos(List<Complejos> listaComplejos)
        {
            foreach (Complejos item in listaComplejos)
            {
                MostrarEnpantallaUnComplejo(item);
            }
        }
        public static List<Complejos> IteradasInversasConDistanciaFijoPositivo1(Complejos c, double distancia, int totalIteradas)
        {
            List<Complejos> puntosJulia = new List<Complejos>();
            //puntosJulia.Add(c);
            Complejos puntoFijoPositivo = new Complejos();
            puntoFijoPositivo = PuntoFijoPositivo(c);
            puntosJulia.Add(puntoFijoPositivo);
            List<Complejos> NuevospuntosJulia = new List<Complejos>();
            List<Complejos> ListaAuxiliar = new List<Complejos>();
            Complejos inversaPositiva = new Complejos();
            Complejos inversaNegativa = new Complejos();
            int iter = 0;
            int longitudJulia = 1;
            int posicionEmpiezaIteradas = 0;
            int nuevosElementosJulia = 0;
            do
            {

                for (int i = posicionEmpiezaIteradas; i < longitudJulia; i++)
                {
                    ListaAuxiliar = IteradaInversaPuntoFijoPositivo(puntosJulia[i]);
                    inversaPositiva = InversaFuncionJulia(puntosJulia[i], c, "positivo");
                    inversaNegativa = InversaFuncionJulia(puntosJulia[i], c, "negativo");
                    //ListaAuxiliar=IteradaConDistanciaFijoPositivo(puntosJulia[i],distancia);
                    if (CompruebaDistaciaAListaMayorP(puntosJulia, inversaPositiva, distancia))
                    {
                        puntosJulia.Add(inversaPositiva);
                        nuevosElementosJulia++;
                    }
                    if (CompruebaDistaciaAListaMayorP(puntosJulia, inversaNegativa, distancia))
                    {
                        puntosJulia.Add(inversaNegativa);
                        nuevosElementosJulia++;
                    }
                }
                posicionEmpiezaIteradas = puntosJulia.Count - nuevosElementosJulia;
                //longitudJulia =CantidadListaComplejos(puntosJulia)-1;
                longitudJulia = puntosJulia.Count;
                ListaAuxiliar.Clear();
                iter++;
                nuevosElementosJulia = 0;
            } while (iter < totalIteradas);
            return puntosJulia;
        }

        public static void prueba() { }
    }

}