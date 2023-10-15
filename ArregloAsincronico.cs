using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioAsincronia
{
    
    public class ArregloAsincronico
    {
        private int[] numeros = new int[30000];
          

        public ArregloAsincronico() { }

        public int[] Numeros { get => numeros; set => numeros = value; }


        public void LlenarArreglo()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.numeros.Length; i++)
            {
                numeros[i] = rnd.Next(0, 45001);
            }
        }

       
    }
}
