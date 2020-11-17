using System;
using System.Collections.Generic;
using System.Text;

namespace ComplejosLibreria
{
    public class Escaneado
    {
        Complejos.Complejos origen = new Complejos.Complejos(0, 0);
        public static List<Complejos.Complejos> PasoMalla(Complejos.Complejos origen, int dividido, double altura = 0, double anchura = 0)
        {
            if (anchura == 0 || altura == 0)
            {
                anchura = altura;
            }
            double prueba = dividido;


            double origenX = origen.Real - anchura;

            double origenY = origen.Imaginario + altura;
            double reinicioY = origenY;
            double finalX = origenX + 2 * anchura;
            double finalY = origenY - 2 * altura;
            double pasoX = (finalX - origenX) / prueba;
            double pasoY = (finalY - origenY) / prueba;
            //Complejos primerPunto = new Complejos();
            //primerPunto.Real = origen.Real - anchura;
            //primerPunto.Imaginario = origen.Imaginario + altura;
            //double anchuraFinal = primerPunto.Real + 2 * anchura;
            //double AlturaFinal = primerPunto.Imaginario - 2 * altura;

            List<Complejos.Complejos> pasoMalla = new List<Complejos.Complejos>();
            //Complejos malla = new Complejos(0,0);

            int cont = 0;
            int cont1 = 0;

            while (cont < dividido)
            {
                cont++;
                origenX += pasoX;
                origenY = 0;
                cont1 = 0;
                origenY = reinicioY;
                while (cont1 < dividido)
                {

                    Complejos.Complejos malla = new Complejos.Complejos();
                    origenY += pasoY;
                    malla.Real = origenX;
                    malla.Imaginario = origenY;
                    pasoMalla.Add(malla);
                    cont1++;
                }
            }




            Convert.ToDouble(dividido);
            /*
            while (cont < dividido)
            {
                origenX += 1 /prueba;
                malla.Real = 3;
                malla.Imaginario = origenY;
                pasoMalla.Add(malla);
                cont++;
            }
            
            
            do
            {
                Complejos malla = new Complejos();
                origenX += pasoX;
                malla.Real = origenX;
                //malla.Imaginario = origenY;
               //pasoMalla.Add(malla);
                do
                {
                    origenY -= pasoY;
                  
                    malla.Imaginario = origenY;
                    pasoMalla.Add(malla);
                } while (origenY <= finalY);
            } while (origenX <= finalX); */

            return pasoMalla;
        }


        //sabemos que el conjunto de Julia de una funcion f(z)=z^2+c está contenida en el disco de centro c y radio 3
        public static List<Complejos.Complejos> MallaJulia(Complejos.Complejos c, double division)
        {
            double origenX = c.Real - 3;
            double finalX = c.Real + 3;
            double origenY = c.Imaginario + 3;
            double finalY = c.Imaginario - 3;
            double paso = 1 / division;
            List<Complejos.Complejos> Malla3 = new List<Complejos.Complejos>();

            while(origenX<=finalX)
            {

                origenX += paso;
                origenY = c.Imaginario + 3;
                while (origenY <= finalY)
                {
                    Complejos.Complejos malla = new Complejos.Complejos();
                    malla.Real = origenX;
                    malla.Imaginario = origenY;
                    
                    if (Complejos.Complejos.ModuloComplejo(malla) <= 3)
                    {
                        Malla3.Add(malla);

                    }
                    origenY += paso;

                }
            }
            return Malla3;
        }

        public static List<Complejos.Complejos> MallaJulia3(Complejos.Complejos c, double division)
        {
            List<Complejos.Complejos> mallaJulia3 = new List<Complejos.Complejos>();
            mallaJulia3 = MallaJulia(c, division);
            double paso = 1 / division;
            double origenX = c.Real - 3 - paso;
            double finalX = c.Real + 3;
            double origenY = c.Imaginario + 3;
            double finalY = c.Imaginario - 3;

            List<Complejos.Complejos> Malla = new List<Complejos.Complejos>();

            while (origenX < finalX)
            {

                origenX += paso;
                origenY = c.Imaginario + 3;
                while (origenY >= finalY)
                {
                    Complejos.Complejos malla = new Complejos.Complejos();
                    malla.Real = origenX;
                    malla.Imaginario = origenY;
                    Malla.Add(malla);
                    origenY -= paso;

                }
            }
            return Malla;
        }

        public static List<Complejos.Complejos> MetodoEscaneado(Complejos.Complejos c, int iterada, double M, int dividido, double altura = 0, double anchura = 0)
        {
            List<Complejos.Complejos> pasoMalla = new List<Complejos.Complejos>();
            pasoMalla = PasoMalla(c, dividido, altura, anchura);
            List<Complejos.Complejos> mallaJulia = new List<Complejos.Complejos>();
            foreach (Complejos.Complejos item in pasoMalla)
            {
                if ((Complejos.Complejos.ModuloComplejo(Complejos.Complejos.JuliaIterada(item, c, iterada)) < M))

                {
                    //Console.WriteLine((Complejos.ModuloComplejo(Complejos.JuliaIterada(item, c, iterada)) < M));
                    mallaJulia.Add(item);
                }
            }
            return mallaJulia;
        }


        public static List<Complejos.Complejos> MetodoEscaneado1(Complejos.Complejos c, int iterada, double M, int dividido)
        {
            List<Complejos.Complejos> pasoMalla = new List<Complejos.Complejos>();
            pasoMalla = MallaJulia(c, dividido);
            List<Complejos.Complejos> mallaJulia = new List<Complejos.Complejos>();
            foreach (Complejos.Complejos item in pasoMalla)
            {
                //if ((Complejos.Complejos.ModuloComplejo(Complejos.Complejos.JuliaIterada(item, c, iterada)) < M))
                Boolean prueba;
                prueba = (Complejos.Complejos.ModuloComplejo(Complejos.Complejos.JuliaIterada(item, c, iterada)) < M);
                if (prueba)
                {
                    //Console.WriteLine((Complejos.ModuloComplejo(Complejos.JuliaIterada(item, c, iterada)) < M));
                    mallaJulia.Add(item);
                }
            }
            return mallaJulia;
        }
        public static List<Complejos.Complejos> MetodoEscaneado2(Complejos.Complejos c, int iterada, double M, int dividido)
        {
            List<Complejos.Complejos> pasoMalla = new List<Complejos.Complejos>();
            pasoMalla = MallaJulia3(c, dividido);
            List<Complejos.Complejos> mallaJulia = new List<Complejos.Complejos>();
            foreach (Complejos.Complejos item in pasoMalla)
            {

                Boolean prueba;
                prueba = (Complejos.Complejos.ModuloComplejo(Complejos.Complejos.JuliaIterada(item, c, iterada)) < M);
                if (prueba)

                {
                    //Console.WriteLine((Complejos.ModuloComplejo(Complejos.JuliaIterada(item, c, iterada)) < M));
                    mallaJulia.Add(item);
                }
            }
            return mallaJulia;
        }



    }
}
