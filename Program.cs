

using EjercicioAsincronia;
using System.Text;

object bloqueador = new object();
Resultado resultado = new Resultado();
ArregloAsincronico arreglo = new ArregloAsincronico();
arreglo.LlenarArreglo();


Run();

Console.WriteLine(resultado.Mayor);
void BuscarMayor(int comienzo, int final, object bloqueador,Resultado resultado, ArregloAsincronico arreglo)
{
    int mayor = 0;
    for (int i = comienzo; i < final; i++)
    {
        if (arreglo.Numeros[i] > mayor)
        {
            lock (bloqueador) 
            {
                if (arreglo.Numeros[i] > mayor) 
                {
                    lock (bloqueador)
                    {
                        mayor = arreglo.Numeros[i];
                        resultado.Mayor = mayor;//agregado
                    }
                }
            }

        }
    }
    /*  codigo anterior
    lock (bloqueador)
    {
        resultado.Mayor = mayor ;
    }
    */
}

async Task BuscarMayorAsync(int comienzo, int final, object bloqueador, Resultado resultado, ArregloAsincronico arreglo)
{
    await Task.Run(()=> BuscarMayor(comienzo, final, bloqueador, resultado, arreglo));
}

async Task Run()
{
    var task1 = BuscarMayorAsync(0, (arreglo.Numeros.Length) / 2, bloqueador, resultado, arreglo);
    var task2 = BuscarMayorAsync((arreglo.Numeros.Length) / 2, arreglo.Numeros.Length, bloqueador, resultado, arreglo);
    await Task.WhenAll(task1, task2);
}


