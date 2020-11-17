using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complejos;

namespace ComplejosLibreria
{
    public class IteradaInversa
    {
        public static Complejos.Complejos uno = new Complejos.Complejos(1, 0);
        public static Complejos.Complejos menosuno = new Complejos.Complejos(-1, 0);

        public static Complejos.Complejos PuntoFijoPositivo(Complejos.Complejos c)
        {
            Complejos.Complejos puntofijopos = new Complejos.Complejos();

            Complejos.Complejos radicando = new Complejos.Complejos();
            radicando = Complejos.Complejos.Radicando(c);
            puntofijopos = Complejos.Complejos.Dividirpor2(Complejos.Complejos.SumaComplejos(menosuno, radicando));
            return puntofijopos;
        }

        public static Complejos.Complejos PuntoFijoNegativo(Complejos.Complejos c)
        {
            Complejos.Complejos puntofijoneg = new Complejos.Complejos();

            Complejos.Complejos radicando = new Complejos.Complejos();
            radicando = Complejos.Complejos.Radicando(c);
            puntofijoneg = Complejos.Complejos.Dividirpor2(Complejos.Complejos.RestaComplejos(menosuno, radicando));
            return puntofijoneg;
        }

        public static Complejos.Complejos IteradaInversaNegativa(Complejos.Complejos c)
        {
            Complejos.Complejos resultado = new Complejos.Complejos();
            Complejos.Complejos puntofijo = PuntoFijoNegativo(c);
            resultado = Complejos.Complejos.RaizCuadradaComplejo(Complejos.Complejos.RestaComplejos(puntofijo, c));
            return resultado;
        }


        public static Complejos.Complejos InversaFuncionJulia(Complejos.Complejos y, Complejos.Complejos c, string signoraiz)
        {
            Complejos.Complejos resultado = new Complejos.Complejos();
            resultado = Complejos.Complejos.RaizCuadradaComplejo(Complejos.Complejos.RestaComplejos(y, c));
            if (signoraiz == "positivo")
            {

                return resultado;
            }
            else if (signoraiz == "negativo")
            {

                return Complejos.Complejos.MultiplicarPorReal(resultado, -1); ;
            }
            else
            {
                Console.WriteLine("El signo tiene que ser positivo o negativo");
                return null;
            }
        }

        public static List<Complejos.Complejos> IteradaInversaPuntoFijoNegativa(Complejos.Complejos c)
        {
            List<Complejos.Complejos> InversaPositivayNegativa = new List<Complejos.Complejos>();
            Complejos.Complejos puntoFijoNegativo = new Complejos.Complejos();
            puntoFijoNegativo = PuntoFijoNegativo(c);
            Complejos.Complejos InversaPositiva = new Complejos.Complejos();
            InversaPositiva = InversaFuncionJulia(puntoFijoNegativo, c, "positivo");
            Complejos.Complejos inversaNegativa = new Complejos.Complejos();
            inversaNegativa = InversaFuncionJulia(puntoFijoNegativo, c, "negativo");
            InversaPositivayNegativa.Add(inversaNegativa);
            InversaPositivayNegativa.Add(InversaPositiva);
            return InversaPositivayNegativa;
        }

        public static List<Complejos.Complejos> IteradaInversaPuntoFijoPositivo(Complejos.Complejos c)
        {
            List<Complejos.Complejos> InversaPositivayNegativa = new List<Complejos.Complejos>();
            Complejos.Complejos puntoFijoPositivo = new Complejos.Complejos();
            puntoFijoPositivo = PuntoFijoPositivo(c);
            Complejos.Complejos InversaPositiva = new Complejos.Complejos();
            InversaPositiva = InversaFuncionJulia(puntoFijoPositivo, c, "positivo");
            Complejos.Complejos inversaNegativa = new Complejos.Complejos();
            inversaNegativa = InversaFuncionJulia(puntoFijoPositivo, c, "negativo");
            InversaPositivayNegativa.Add(inversaNegativa);
            InversaPositivayNegativa.Add(InversaPositiva);
            return InversaPositivayNegativa;
        }

        public static List<Complejos.Complejos> IteradaConDistanciaFijoPositivo(Complejos.Complejos c, double distancia)
        {
            List<Complejos.Complejos> puntosJulia = new List<Complejos.Complejos>();
            puntosJulia.Add(c);
            Complejos.Complejos puntoFijoPositivo = new Complejos.Complejos();
            List<Complejos.Complejos> juliaPuntoFijoPos = new List<Complejos.Complejos>();
            juliaPuntoFijoPos = Complejos.Complejos.IteradaInversaPuntoFijoPositivo(c);
            if (Complejos.Complejos.CompruebaDistaciaAListaMayorP(puntosJulia, juliaPuntoFijoPos[0], distancia))
            {
                puntosJulia.Add(juliaPuntoFijoPos[0]);
            }
            if (Complejos.Complejos.CompruebaDistaciaAListaMayorP(puntosJulia, juliaPuntoFijoPos[1], distancia))
            {
                puntosJulia.Add(juliaPuntoFijoPos[1]);
            }
            puntosJulia.Remove(c);
            return puntosJulia;

        }

        public static List<Complejos.Complejos> IteradasInversasConDistanciaFijoPositivo(Complejos.Complejos c, double distancia, int totalIteradas)
        {
            List<Complejos.Complejos> puntosJulia = new List<Complejos.Complejos>();
            //puntosJulia.Add(c);
            Complejos.Complejos puntoFijoPositivo = new Complejos.Complejos();
            puntoFijoPositivo = PuntoFijoPositivo(c);
            puntosJulia.Add(puntoFijoPositivo);
            List<Complejos.Complejos> NuevospuntosJulia = new List<Complejos.Complejos>();
            List<Complejos.Complejos> ListaAuxiliar = new List<Complejos.Complejos>();
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
                    if (Complejos.Complejos.CompruebaDistaciaAListaMayorP(puntosJulia, ListaAuxiliar[0], distancia))
                    {
                        puntosJulia.Add(ListaAuxiliar[0]);
                        nuevosElementosJulia++;
                    }
                    if (Complejos.Complejos.CompruebaDistaciaAListaMayorP(puntosJulia, ListaAuxiliar[1], distancia))
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
        public static List<Complejos.Complejos> IteradasInversasConDistanciaFijoPositivo1(Complejos.Complejos c, double distancia, int totalIteradas)
        {
            List<Complejos.Complejos> puntosJulia = new List<Complejos.Complejos>();
            //puntosJulia.Add(c);
            Complejos.Complejos puntoFijoPositivo = new Complejos.Complejos();
            puntoFijoPositivo = PuntoFijoPositivo(c);
            puntosJulia.Add(puntoFijoPositivo);
            List<Complejos.Complejos> NuevospuntosJulia = new List<Complejos.Complejos>();
            List<Complejos.Complejos> ListaAuxiliar = new List<Complejos.Complejos>();
            Complejos.Complejos inversaPositiva = new Complejos.Complejos();
            Complejos.Complejos inversaNegativa = new Complejos.Complejos();
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

        public static Boolean CompruebaDistaciaAListaMayorP(List<Complejos.Complejos> listaComplejos, Complejos.Complejos elemento, double p)
        {
            Boolean distancia = true;
            foreach (Complejos.Complejos item in listaComplejos)
            {
                if (Complejos.Complejos.DistanciaEntreComplejos(item, elemento) < p)
                {
                    distancia = false;
                    break;
                }
            }
            return distancia;
        }

        public static List<Complejos.Complejos> IntroduceEltoEnLtcomplejosSiDistanciaMayorP(List<Complejos.Complejos> listaComplejos, Complejos.Complejos elemento, double p)
        {
            Boolean elementosLejanos = true;
            foreach (Complejos.Complejos item in listaComplejos)
            {
                if (Complejos.Complejos.DistanciaEntreComplejos(item, elemento) < p)
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
    }
}
