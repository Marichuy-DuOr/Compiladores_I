using System;
using System.Collections.Generic;
using System.Text;

namespace compilador
{


    class Token
    {
		//definimos una enumeracion para los tipos de tokens
		public enum Token_types
		{
			TKN_BEGIN,     //0
			TKN_RESERVED,  //1
			TKN_END,       //2
			TKN_READ,      //3
			TKN_WRITE,     //4
			TKN_TIPO,      //5
			TKN_IF,        //6
			TKN_ELSE,      //7
			TKN_FI,        //8
			TKN_PROGRAM,   //9
			TKN_ID,        //10
			TKN_NUM,       //11
			TKN_DIG,	   //12
			TKN_LPAREN,    //13
			TKN_RPAREN,    //14
			TKN_LBRACE,    //15
			TKN_RBRACE,    //16
			TKN_SEMICOLON, //17
			TKN_COMMA,     //18
			TKN_ASSIGN,    //19
			TKN_LESS,      //20
			TKN_ELESS,     //21
			TKN_MORE,      //22
			TKN_EMORE,     //23
			TKN_EQUAL,     //24
			TKN_NEQUAL,    //25
			TKN_ADD,       //26
			TKN_MINUS,     //27
			TKN_MULTI,     //28
			TKN_DIV,       //29
			TKN_POW,       //30
			TKN_EOF,       //31
			TKN_ERROR,     //32
			TKN_DO,        //33
			TKN_UNTIL,     //34
			TKN_WHILE,     //35
			TKN_AND,       //36
			TKN_OR,        //37
			TKN_NOT        //38
		}

		public Token_types tipo { get; set; }
		public string lexema { get; set; }
		public int linea { get; set; }
		public int columna { get; set; }

		public Token(){}
		public Token(Token_types tipo, string lexema, int linea, int columna)
		{
			this.tipo = tipo;
			this.lexema = lexema;
			this.linea = linea;
			this.columna = columna;
		}
	}
}
