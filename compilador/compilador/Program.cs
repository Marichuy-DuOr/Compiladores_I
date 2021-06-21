using System;
using System.Collections.Generic;

namespace compilador
{
    class Program
    {
        // public static List<Token> lista;

        static void Main(string[] args)
        {
            Lexico lexico;
            Sintactico sintactico;

            TreeNode t;

            if (args.Length == 0)
            {
                Console.WriteLine("Faltan argumentos");
                Environment.Exit(0);
            }

            // lexico = new Lexico(@"C:\Users\Conchita Paola\Desktop\prueba.txt");

            Console.WriteLine("lexico");
            lexico = new Lexico(args[0]);

            if (lexico.analisisLexico())
            {
                Console.WriteLine("Exito: el analisis Lexico fue exitoso :D");
            }
            else
            {
                Console.WriteLine("Error: el analisis Lexico tuvo fallos D:");
            }

            Console.WriteLine("sintactico");
            sintactico = new Sintactico(lexico.lista);
            t = sintactico.parse();

            if (sintactico.isCorrect)
            {
                Console.WriteLine("Exito: el analisis Sintactico fue exitoso :D");
            }
            else
            {
                Console.WriteLine("Error: el analisis Sintactico tuvo fallos D:");
            }

        }
    }
}
