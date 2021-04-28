using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace compilador
{
	class Lexico
	{
		//
		string[] lineas;
		bool blocComments;
		public List<Token> lista { get; set; }
		bool isCorrect;

		//definimos enumeracion para el estado
		enum States
		{
			IN_START,
			IN_ID,
			IN_NUM,
			IN_LPAREN,
			IN_RPAREN,
			IN_LBRACE,
			IN_RBRACE,
			IN_SEMICOLON,
			IN_ALERT,
			IN_COMMA,
			IN_ASSIGN,
			IN_ADD,
			IN_MINUS,
			IN_MULTI,
			IN_DIV,
			IN_POW,
			IN_LESS,
			IN_ELESS,
			IN_MORE,
			IN_EMORE,
			IN_EQUAL,
			IN_NEQUAL,
			IN_EOF,
			IN_ERROR,
			IN_DONE,
			IN_LCOMMENT,
			IN_BCOMMENT
		}

		// palabras reservadas
		string [] reservedWords = {
			"program", "if", "else", "fi", "do", "until", "while", "read", "write",
			"float", "int", "bool", "not", "and", "or",
		};

		public Lexico(string nombreArchivo)
        {
			// Read each line of the file into a string array.
			blocComments = false; // inicia en falso, cuando esta en true es porque hay comentarios
			lista = new List<Token>();
			isCorrect = true; // se pone en falso en caso de encontrar tokens de error

			this.lineas = File.ReadAllLines(nombreArchivo); // lee el archivo de texto
			
        }

		public bool analisisLexico()
		{
			int i = 0;
			foreach (string linea in lineas)
			{
				// Console.WriteLine("\t" + linea); // Imprime el archivo leido en la consola
				i++;
				getToken(linea, i);
			}

			writeFile();

			return isCorrect;
		}

		public void writeFile()
		{
			try
			{
				// Queda guardado en \compilador\compilador\bin\Debug\netcoreapp3.1
				// Si lo corres desde el ide de java se guarda en la raiz del proyecto
				StreamWriter sw = new StreamWriter("tokens.txt");
				foreach (Token elToken in lista)
				{
					sw.WriteLine("Lexema: " + elToken.lexema +"	Tipo: "+ elToken.tipo + "	Linea: " + elToken.linea + "	Columna: "+ elToken.columna);
					// Console.WriteLine("Lexema: " + elToken.lexema + "	Tipo: " + elToken.tipo + "	Linea: " + elToken.linea + "	Columna: " + elToken.columna);
				}
				sw.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
				Console.WriteLine("Executing finally block.");
			}
		}

		public bool isAlpha( char caracter ) {
			// creo que es mas facil utilizar directo la funcion pero pues ya, meh
			return char.IsLetter(caracter);
		}

		public bool isDigit(string numero)
		{
			decimal number1 = 0;
			bool canConvert = decimal.TryParse(numero, out number1);
			return canConvert;
		}

		public Token LookUpReservedWords( Token token )
		{
			// cambia el tipo de token si en caso de que sea una palabra reservada
			// si no, se conserva como TKN_ID
			switch (token.lexema)
			{
				case "if":
					token.tipo = Token.Token_types.TKN_IF;
					break;
				case "read":
					token.tipo = Token.Token_types.TKN_READ;
					break;
				case "write":
					token.tipo = Token.Token_types.TKN_WRITE;
					break;
				case "fi":
					token.tipo = Token.Token_types.TKN_FI;
					break;
				case "else":
					token.tipo = Token.Token_types.TKN_ELSE;
					break;
				case "do":
					token.tipo = Token.Token_types.TKN_DO;
					break;
				case "until":
					token.tipo = Token.Token_types.TKN_UNTIL;
					break;
				case "program":
					token.tipo = Token.Token_types.TKN_PROGRAM;
					break;
				case "float":
					token.tipo = Token.Token_types.TKN_TIPO;
					break;
				case "int":
					token.tipo = Token.Token_types.TKN_TIPO;
					break;
				case "bool":
					token.tipo = Token.Token_types.TKN_TIPO;
					break;
				case "while":
					token.tipo = Token.Token_types.TKN_WHILE;
					break;
				case "or":
					token.tipo = Token.Token_types.TKN_OR;
					break;
				case "and":
					token.tipo = Token.Token_types.TKN_AND;
					break;
				case "not":
					token.tipo = Token.Token_types.TKN_NOT;
					break;
				/*default:
					// Checa esta parte si algo no sirve
					// tok.tipo = Token.Token_types.TKN_ID;
					tok.tipo = Token.Token_types.TKN_RESERVED;
					break;*/
			}
			/*
			for (i = 0; i < reservedWords.Length; i++)
			{
				if (lexema == reservedWords[i])
				{
					tok.lexema = lexema;
					return tok;
				}
			}

			tok.lexema = lexema;
			tok.tipo = Token.Token_types.TKN_ID;


			// tok.lexema = lexema;*/
			return token;
		}

		public bool isDelim(string caracter)
		{
			if (caracter == " ") // espacio
			{
				return true;
			} else if (caracter == "\t") // tabulacion
			{
				return true;
			} else
			{
				return false;
			}
		}


		public void getToken(string line, int n )
		{
			// inicializamos token
			/*token.lexema = "";
			token.columna = 1;
			token.linea = 1;
			token.tipo = Token.Token_types.TKN_VOID;*/

			Token token = new Token();


			char caracter = '\0'; // char de apoyo para analizar
			line = line + " "; // evita que en algunos casos se pierda el ultimo token de cada línea
			int tam = line.Length; // tamaño de la linea
			char[] characters = line.ToCharArray(); // convertimos la linea string a array de char

			bool casiFin = false; // bandera para los comentarios /**/
			States state; // stado para determinar tipos de tokens
			int i = 0;

			// cambia el estado para que se distingan los comentarios
			if (blocComments)
			{
				state = States.IN_BCOMMENT;
			}
			else
			{
				state = States.IN_START;
			}


			while (i < tam)
			{
				// vaidamos que no se salga de los bordes
				// cuando ya sirva pruebas esta parte para ver si la borras
				if (i != tam)
				{
					caracter = characters[i];
				}

				switch (state)
				{
					case States.IN_START:

						// evita tabulaciones y espacios 
						for (int j = i; j < tam; j++)
						{
							if (!isDelim(caracter.ToString()))
							{
								// rompe el ciclo cuando se encuentra con un caracter
								break;
							}
							else
							{
								i++; // avanza en el arreglo
								if (i < tam)
								{
									// renueva el valor del caracter en la posicion del array
									caracter = characters[i];
								}
								else
								{
									// rompe el ciclo cuando llega al borde
									break;
								}
							}
						}

						// asigna entonces valores al token
						token.linea = n;
						token.columna = i;

						if (isAlpha(caracter))
						{
							// si es una letra, la guarda en el lexema y avanza en el ciclo
							token.tipo = Token.Token_types.TKN_ID;
							state = States.IN_ID;
							token.lexema += caracter;
							i++;
						}
						else if (isDigit(caracter.ToString()))
						{
							token.tipo = Token.Token_types.TKN_NUM;
							state = States.IN_NUM;
							token.lexema += caracter;
						}
						else if (caracter == '(')
						{
							token.tipo = Token.Token_types.TKN_LPAREN;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == ')')
						{
							token.tipo = Token.Token_types.TKN_RPAREN;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == '{')
						{
							token.tipo = Token.Token_types.TKN_LBRACE;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == '}')
						{
							token.tipo = Token.Token_types.TKN_RBRACE;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == ';')
						{
							token.tipo = Token.Token_types.TKN_SEMICOLON;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == ',')
						{
							token.tipo = Token.Token_types.TKN_COMMA;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == '+')
						{
							token.tipo = Token.Token_types.TKN_ADD;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == '-')
						{
							token.tipo = Token.Token_types.TKN_MINUS;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == '*')
						{
							token.tipo = Token.Token_types.TKN_MULTI;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == '^')
						{
							token.tipo = Token.Token_types.TKN_POW;
							state = States.IN_DONE;
							token.lexema = caracter.ToString();
						}
						else if (caracter == ':')
						{
							state = States.IN_ASSIGN;
							token.lexema = caracter.ToString();
							i++;
						}
						else if (caracter == '=')
						{
							state = States.IN_ASSIGN;
							token.lexema = caracter.ToString();
							i++;
						}
						else if (caracter == '<')
						{
							state = States.IN_LESS;
							token.lexema = caracter.ToString();
							i++;
						}
						else if (caracter == '>')
						{
							state = States.IN_MORE;
							token.lexema = caracter.ToString();
							i++;
						}
						else if (caracter == '!')
						{
							state = States.IN_ALERT;
							token.lexema = caracter.ToString();
							i++;
						}
						else if (caracter == '/')
						{
							token.tipo = Token.Token_types.TKN_MULTI;
							state = States.IN_DIV;
							token.lexema = caracter.ToString();
							i++;
						}
						else
						{
							if (isDelim(caracter.ToString()))
							{
								i++;
							}
							else
							{
								Console.WriteLine("Error en la linea " + n + ", caracter no reconocido: " + caracter);
								token.tipo = Token.Token_types.TKN_ERROR;
								token.lexema = caracter.ToString();
								state = States.IN_DONE;
								isCorrect = false;
							}
						}

						break;

					case (States.IN_NUM):
						string caracter2 = "a";
						if (tam > i + 1 && characters[i + 1] != ' ' && characters[i + 1] != '\t')
						{
							caracter2 = characters[i + 1].ToString();
						}

						if (!isDigit(token.lexema + caracter2))
						{
							if (token.lexema.Length > 1)
							{
								// numeros en general
								token.tipo = Token.Token_types.TKN_NUM;
							} 
							else
							{
								// digito 0-9
								// token.tipo = Token.Token_types.TKN_DIG;
								token.tipo = Token.Token_types.TKN_NUM;
							}
							state = States.IN_DONE;
						}
						else
						{
							token.lexema += caracter2;
							i++;
						}
						break;

					case (States.IN_ID):
						// el if ayuda a acumular las letras hasta que no haya letras, numeros o guiones bajos
						if (!((isAlpha(caracter) || isDigit(caracter.ToString())) || caracter == '_'))
						{
							token.tipo = Token.Token_types.TKN_ID;
							state = States.IN_DONE;
							token = LookUpReservedWords(token);
							i--; // evita perder el caracter que acaba de comprobar
						}
						else
						{
							token.lexema += caracter;
							i++;
						}
						break;

					case (States.IN_ASSIGN):
						if (caracter == '=')
						{
							// ==
							token.tipo = Token.Token_types.TKN_EQUAL;
							state = States.IN_DONE;
							token.lexema += caracter;
						}
						else
						{
							// : =
							i--;
							token.tipo = Token.Token_types.TKN_ASSIGN;
							state = States.IN_DONE;
						}
						break;

					case (States.IN_LESS):
						if (caracter == '=')
						{
							// <=
							token.tipo = Token.Token_types.TKN_ELESS;
							state = States.IN_DONE;
							token.lexema += caracter;
						}
						else
						{
							// <
							i--;
							token.tipo = Token.Token_types.TKN_LESS;
							state = States.IN_DONE;
						}
						break;

					case (States.IN_MORE):
						if (caracter == '=')
						{
							// >=
							token.tipo = Token.Token_types.TKN_EMORE;
							state = States.IN_DONE;
							token.lexema += caracter;
						}
						else
						{
							// >
							i--;
							token.tipo = Token.Token_types.TKN_MORE;
							state = States.IN_DONE;
						}
						break;

					case (States.IN_ALERT):
						if (caracter == '=')
						{
							// !=
							token.tipo = Token.Token_types.TKN_NEQUAL;
							token.lexema += caracter;
							state = States.IN_DONE;
						}
						else
						{
							Console.WriteLine("Error en la linea " + n + ", caracter no reconocido: " + token.lexema);
							token.tipo = Token.Token_types.TKN_ERROR;
							state = States.IN_DONE;
							isCorrect = false;
							i--;
						}
						break;

					case (States.IN_DIV):
						if (caracter == '*')
						{
							// inicio de comentario /*
							state = States.IN_BCOMMENT;
							blocComments = true;
						}
						else if (caracter == '/')
						{
							// inicio de comentario //
							i = tam;
							state = States.IN_LCOMMENT;
						}
						else
						{
							// division /
							state = States.IN_DONE;
							i--;
						}
						break;

					case (States.IN_BCOMMENT):
						// para terminar los comentarios */
						i++;
						if (caracter == '*')
						{
							casiFin = true;
						}
						else if (caracter == '/')
						{
							if (casiFin)
							{
								state = States.IN_START;
								blocComments = false;
							}
						}
						else
						{
							if (casiFin)
							{
								casiFin = false;
							}
						}
						break;

					case (States.IN_DONE):
						
						break;

					default:
						// cualquier símbolo no reconocido en el if
						token.tipo = Token.Token_types.TKN_ERROR;
						state = States.IN_DONE;
						token.linea = n;
						token.columna = i;
						token.lexema += caracter;
						isCorrect = false;
						Console.WriteLine("Error en la linea " + n + ", caracter no reconocido: " + token.lexema);
						break;

				}

				if (state == States.IN_DONE) // Se agrega el token a la lista
				{
					i++;
					lista.Add(token);
					token = new Token();
					state = States.IN_START;
				}
				// Console.WriteLine(i);
			}

			/*Al terminar el while, si no existe un espacio o una tabulación al
			   final de la línea, el ultimo token no se agrega.
			   Este if valida estos casos */
			// Se soluciona mejor agregando un espacio al final de la linea pero lo dejo por ahora por si acaso
			/* if (state == States.IN_LCOMMENT) {}
			else if (state == States.IN_BCOMMENT) {}
			else if (token.tipo == Token.Token_types.TKN_ID)
			{
				token = LookUpReservedWords(token);
				lista.Add(token);
			}
			else
			{
				if (!isDelim(token.lexema))
				{
					if (token.tipo != Token.Token_types.TKN_VOID)
					{
						if (token.lexema != "" || token.lexema != " ")
						{
							lista.Add(token);
						}
					}
				}
			}*/


		}

	}
}
