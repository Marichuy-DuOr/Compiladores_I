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
            Semantico semantico;
            CodigoIntermedio codigoIntermedio;

            TreeNode t;

            /* if (args.Length == 0)
            {
                Console.WriteLine("Faltan argumentos");
                Environment.Exit(0);
            } */

            Console.WriteLine("lexico");

            lexico = new Lexico(@"C:\Users\Conchita Paola\Desktop\prueba.txt");
            // lexico = new Lexico(args[0]);

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

            Console.WriteLine("semantico");
            semantico = new Semantico(t);
            t = semantico.analisisSemantico();

            if (semantico.isCorrect)
            {
                Console.WriteLine("Exito: el analisis Semantico fue exitoso :D");
                Console.WriteLine("codigoIntermedio");
                codigoIntermedio = new CodigoIntermedio(t);
                codigoIntermedio.code_generator();
            }
            else
            {
                Console.WriteLine("Error: el analisis Semantico tuvo fallos D:");
                Console.WriteLine("No se generará codigo intermedio :c");
            }

        }
    }
}
