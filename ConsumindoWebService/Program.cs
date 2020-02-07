using System;

namespace ConsumindoWebService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string usuario = "MIUSUARIO";
            string clave = "MICLAVE";
            string bloque = "";
            string respuesta = ""; //en esta variable quedará la respuesta del llamado a la API de SMS MASIVOS

            bloque = bloque + "ID1\t1144444444\tMi texto 1\n";
            bloque = bloque + "ID2\t1155555555\tMi texto 2\n";
        }
    }
}
