using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace compilador
{
    class Sintactico
    {
        public Token token;
        public bool isCorrect;
        public int auxVar;
        public List<Token> tokens;

        public Sintactico(List<Token> lista)
        {
            this.token = new Token();
            this.isCorrect = true;
            this.auxVar = 0;
            this.tokens = lista;
        }

        public Token getToken2()
        {
            Token tok;
            if (auxVar < tokens.Count)
            {
                if (tokens[auxVar].lexema == "")
                {
                    if (auxVar + 1 < tokens.Count)
                    {
                        auxVar++;
                        tok = tokens[auxVar];
                    }
                    else
                    {
                        tok = new Token(Token.Token_types.TKN_RBRACE, "", 0, 0);
                    }
                }
                else
                {
                    tok = tokens[auxVar];
                }
                tok = tokens[auxVar];
            }
            else
            {
                tok = new Token(Token.Token_types.TKN_RBRACE, "", 0, 0);
                return tok;
            }

            auxVar++;
            return tok;
        }
        public void match(Token.Token_types expected)
        {
            if (expected == token.tipo)
            {
                token = getToken2();
            }
            else
            {
                isCorrect = false;

                if (token.tipo == Token.Token_types.TKN_ERROR)
                {
                    token = getToken2();
                }
                Console.WriteLine("sysntaxis error en match " + token.lexema +" "+ token.linea + " " + token.tipo + " " + expected);
            }
        }

        public TreeNode newStmtNode(TreeNode.StmtKind kind)
        {
            TreeNode t;
            t = new TreeNode();
            t.token = token;

            t.nodeKind = TreeNode.NodeKind.StmtK;
            t.kind.stmt = kind;

            return t;
        }

        public TreeNode newExpNode(TreeNode.ExpKind expKind)
        {
            TreeNode t;
            t = new TreeNode();
            t.token = token;

            t.nodeKind = TreeNode.NodeKind.Expk;
            t.kind.exp = expKind;

            return t;
        }
        
        public TreeNode stmt_sequence()
        {
            TreeNode t = statement();
            TreeNode p = t;

            while (token.tipo != Token.Token_types.TKN_RBRACE)
            {
                TreeNode q = statement();

                if (q != null)
                {
                    if (t == null)
                    {
                        p = q;
                        t = p;
                    }
                    else
                    {
                        p.sibling = q;
                        p = q;
                    }
                }
            }

            match(Token.Token_types.TKN_RBRACE);
            return t;
        }

        public TreeNode if_stmt_secuence()
        {
            TreeNode t = statement();
            TreeNode p = t;

            bool flag = true;

            if (token.tipo == Token.Token_types.TKN_ELSE)
            {
                flag = false;
            } else if (token.tipo == Token.Token_types.TKN_RBRACE)
            {
                flag = false;
                match(Token.Token_types.TKN_RBRACE);
            } else
            {

            }

            while (flag)
            {
                TreeNode q;
                match(Token.Token_types.TKN_SEMICOLON);

                q = statement();

                if (q != null)
                {
                    if (t == null)
                    {
                        p = q;
                        t = p;
                    }
                    else
                    {
                        p.sibling = q;
                        p = q;
                    }
                }

                if (token.tipo == Token.Token_types.TKN_ELSE)
                {
                    flag = false;
                } else if (token.tipo == Token.Token_types.TKN_RBRACE)
                {
                    flag = false;
                    match(Token.Token_types.TKN_RBRACE);
                } else
                {

                }
            }
            return t;
        }

        public TreeNode statement()
        {
            TreeNode t = null;

            switch (token.tipo)
            {
                case Token.Token_types.TKN_ID:
                    t = assign_stmt();
                    match(Token.Token_types.TKN_SEMICOLON);
                    break;
                
                case Token.Token_types.TKN_IF:
                    t = if_stmt();
                    break;

                case Token.Token_types.TKN_READ:
                    t = read_stmt();
                    match(Token.Token_types.TKN_SEMICOLON);
                    break;
                
                case Token.Token_types.TKN_WRITE:
                    t = write_stmt();
                    match(Token.Token_types.TKN_SEMICOLON);
                    break;
                
                case Token.Token_types.TKN_TIPO:
                    t = declaration_stmt();
                    match(Token.Token_types.TKN_SEMICOLON);
                    break;
                
                case Token.Token_types.TKN_RBRACE:
                    
                    break;

                case Token.Token_types.TKN_WHILE:
                    t = while_stmt();
                    break;

                case Token.Token_types.TKN_DO:
                    t = do_stmt();
                    match(Token.Token_types.TKN_SEMICOLON);
                    break;
                
                case Token.Token_types.TKN_PROGRAM:
                    t = program_stmt();
                    break;

                default:
                    Console.WriteLine("syntaxis error en stmt " + token.lexema + " " + token.tipo);
                    token = getToken2();
                    break;
            }

            return t;
        }

        public TreeNode program_stmt()
        {
            TreeNode t = newStmtNode(TreeNode.StmtKind.ProgramK);
            match(Token.Token_types.TKN_PROGRAM);
            match(Token.Token_types.TKN_LBRACE);

            if (t != null)
            {
                t.branch[0] = stmt_sequence();
            }
            return t;
        }

        public TreeNode if_stmt()
        {
            TreeNode t = newStmtNode(TreeNode.StmtKind.Ifk);

            match(Token.Token_types.TKN_IF);

            if (t != null)
            {
                match(Token.Token_types.TKN_LPAREN);
                t.branch[0] = expresion();
                match(Token.Token_types.TKN_RPAREN);
            }

            match(Token.Token_types.TKN_LBRACE);

            if (t != null)
            {
                t.branch[1] = stmt_sequence();
            }

            if (token.lexema == "else")
            {
                match(Token.Token_types.TKN_ELSE);
                match(Token.Token_types.TKN_LBRACE);
                if (t != null)
                {
                    t.branch[2] = stmt_sequence();
                }
            }

            match(Token.Token_types.TKN_FI);

            if (token.tipo == Token.Token_types.TKN_RBRACE)
            {

            } 
            else
            {
                t.sibling = statement();
            }

            return t;
        }

        public TreeNode while_stmt()
        {
            TreeNode t = newStmtNode(TreeNode.StmtKind.WhileK);
            match(Token.Token_types.TKN_WHILE);

            if (t != null)
            {
                match(Token.Token_types.TKN_LPAREN);
                t.branch[0] = expresion();
                match(Token.Token_types.TKN_RPAREN);
            }

            match(Token.Token_types.TKN_LBRACE);

            if (t != null)
            {
                t.branch[1] = stmt_sequence();
            }

            return t;
        }

        public TreeNode do_stmt()
        {
            TreeNode t = newStmtNode(TreeNode.StmtKind.Dok);
            match(Token.Token_types.TKN_DO);
            match(Token.Token_types.TKN_LBRACE);

            if (t != null)
            {
                t.branch[0] = stmt_sequence();
            }

            match(Token.Token_types.TKN_UNTIL);

            if ( t != null)
            {
                match(Token.Token_types.TKN_LPAREN);
                t.branch[1] = expresion();
                match(Token.Token_types.TKN_RPAREN);
            }

            return t;
        }

        public TreeNode declaration_stmt()
        {
            TreeNode t = newStmtNode(TreeNode.StmtKind.DeclK);
            string tipe = "";

            bool flag = false;

            switch (token.lexema)
            {
                case "float":
                    tipe = "float";
                    break;
                case "bool":
                    tipe = "bool";
                    break;
                case "int":
                    tipe = "int";
                    break;
            }

            match(Token.Token_types.TKN_TIPO);
            TreeNode w = newStmtNode(TreeNode.StmtKind.AssignK);
            t.branch[0] = w;

            while (token.tipo == Token.Token_types.TKN_ID || token.tipo == Token.Token_types.TKN_COMMA)
            {
                TreeNode q = new TreeNode();
                TreeNode p = newStmtNode(TreeNode.StmtKind.AssignK);

                for (TreeNode e = t.branch[0]; e!= null; e = e.sibling)
                {
                    q = e;
                }

                if (token.tipo == Token.Token_types.TKN_ID)
                {
                    if (!flag)
                    {
                        q.attr.name = token.lexema;
                        q.attr.tipe = tipe;
                    } else
                    {
                        p.attr.name = token.lexema;
                        p.attr.tipe = tipe;
                        q.sibling = p;
                    }
                } 
                else
                {
                    Console.WriteLine("Sintaxis error declaration stmt " + token.lexema + " " + token.linea);
                }

                match(Token.Token_types.TKN_ID);
                
                if (token.tipo == Token.Token_types.TKN_COMMA)
                {
                    match(Token.Token_types.TKN_COMMA);
                }

                flag = true;
            }

            return t;
        }

        public TreeNode assign_stmt()
        {
            TreeNode q = newStmtNode(TreeNode.StmtKind.AssignK);

            if (q != null && token.tipo == Token.Token_types.TKN_ID)
            {
                q.attr.name = token.lexema;
            }

            match(Token.Token_types.TKN_ID);
            TreeNode t = newStmtNode(TreeNode.StmtKind.AssignK);

            if (t != null && token.tipo == Token.Token_types.TKN_ASSIGN)
            {
                t.attr.name = token.lexema;
            }

            match(Token.Token_types.TKN_ASSIGN);

            if (t != null)
            {
                t.branch[0] = q;
                t.branch[1] = expresion();
            }

            return t;
        }

        public TreeNode read_stmt()
        {
            TreeNode t = newStmtNode(TreeNode.StmtKind.ReadK);
            match(Token.Token_types.TKN_READ);

            if (t != null && token.tipo == Token.Token_types.TKN_ID)
            {
                t.attr.name = token.lexema;
                t.branch[0] = newExpNode(TreeNode.ExpKind.IdK);
            }

            match(Token.Token_types.TKN_ID);
            return t;
        }

        public TreeNode write_stmt()
        {
            TreeNode t = newStmtNode(TreeNode.StmtKind.WriteK);
            match(Token.Token_types.TKN_WRITE);

            if (t != null)
            {
                t.branch[0] = expresion();
            }
            return t;
        }

        public bool isLogic()
        {
            if (token.tipo == Token.Token_types.TKN_LESS || token.tipo == Token.Token_types.TKN_ELESS)
            {
                return true;
            } else if (token.tipo == Token.Token_types.TKN_EQUAL || token.tipo == Token.Token_types.TKN_NEQUAL)
            {
                return true;
            } else if (token.tipo == Token.Token_types.TKN_MORE || token.tipo == Token.Token_types.TKN_EMORE)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public TreeNode expresion()
        {
            TreeNode t = exp();

            while ( token.tipo == Token.Token_types.TKN_AND || token.tipo == Token.Token_types.TKN_OR)
            {
                TreeNode p = newExpNode(TreeNode.ExpKind.OpK);

                if (p != null)
                {
                    p.branch[0] = t;
                    p.attr.op = token.tipo;
                    t = p;
                }

                match(token.tipo);

                if (t != null)
                {
                    t.branch[1] = exp();
                }
            }
            return t;
        }

        public TreeNode exp()
        {
            TreeNode t = simple_exp();

            if (isLogic())
            {
                TreeNode p = newExpNode(TreeNode.ExpKind.OpK);

                if (p != null)
                {
                    p.branch[0] = t;
                    p.attr.op = token.tipo;
                    t = p;
                }

                match(token.tipo);

                if (t != null)
                {
                    t.branch[1] = simple_exp();
                }
            }
            return t;
        }

        public TreeNode simple_exp()
        {
            TreeNode t = term();

            while (token.tipo == Token.Token_types.TKN_ADD || token.tipo == Token.Token_types.TKN_MINUS)
            {
                TreeNode p = newExpNode(TreeNode.ExpKind.OpK);

                if (p != null)
                {
                    p.branch[0] = t;
                    p.attr.op = token.tipo;
                    t = p;

                    match(token.tipo);

                    t.branch[1] = term();
                }
            }
            return t;
        }

        public TreeNode term()
        {
            TreeNode t = factor();

            while (token.tipo == Token.Token_types.TKN_MULTI || token.tipo == Token.Token_types.TKN_DIV)
            {
                TreeNode p = newExpNode(TreeNode.ExpKind.OpK);

                if ( p != null)
                {
                    p.branch[0] = t;
                    p.attr.op = token.tipo;
                    t = p;

                    match(token.tipo);

                    p.branch[1] = factor();
                }
            }
            return t;
        }

        public TreeNode factor()
        {
            TreeNode t = null;

            switch (token.tipo) {
                case Token.Token_types.TKN_NUM:
                    t = newExpNode(TreeNode.ExpKind.ConstK);
                    if (t == null && token.tipo == Token.Token_types.TKN_NUM)
                    {
                        double variable = double.Parse(token.lexema, System.Globalization.CultureInfo.InvariantCulture);
                        t.attr.val = variable;
                    }
                    match(Token.Token_types.TKN_NUM);
                    break;

                case Token.Token_types.TKN_ID:
                    t = newExpNode(TreeNode.ExpKind.IdK);
                    if (t == null && token.tipo == Token.Token_types.TKN_ID)
                    {
                        t.attr.name = token.lexema;
                    }
                    match(Token.Token_types.TKN_ID);
                    break;

                case Token.Token_types.TKN_ADD:
                    t = newExpNode(TreeNode.ExpKind.OpK);
                    if (t == null && token.tipo == Token.Token_types.TKN_ID)
                    {
                        t.attr.name = token.lexema;
                    }
                    match(Token.Token_types.TKN_MORE);
                    t.branch[0] = factor();
                    break;

                case Token.Token_types.TKN_MINUS:
                    t = newExpNode(TreeNode.ExpKind.OpK);
                    if (t == null && token.tipo == Token.Token_types.TKN_ID)
                    {
                        t.attr.name = token.lexema;
                    }
                    match(Token.Token_types.TKN_MINUS);
                    t.branch[0] = factor();
                    break;

                case Token.Token_types.TKN_NOT:
                    t = newExpNode(TreeNode.ExpKind.OpK);
                    if (t == null && token.tipo == Token.Token_types.TKN_ID)
                    {
                        t.attr.name = token.lexema;
                    }
                    match(Token.Token_types.TKN_NOT);
                    t.branch[0] = factor();
                    break;

                case Token.Token_types.TKN_LPAREN:
                    match(Token.Token_types.TKN_LPAREN);
                    t = exp();
                    match(Token.Token_types.TKN_RPAREN);
                    break;

                default:
                    Console.WriteLine("Syntaxis error en factor " + token.lexema + " " + token.linea);
                    token = getToken2();
                    break;
            }

            return t;
        }

        public TreeNode parse()
        {
            TreeNode t;
            token = getToken2();
            t = stmt_sequence();

            writeTree(t);

            return t;
        }

        public void writeTree(TreeNode root)
        {
            try
            {
                // Queda guardado en \compilador\compilador\bin\Debug\netcoreapp3.1
                // Si lo corres desde el ide de java se guarda en la raiz del proyecto
                StreamWriter sw = new StreamWriter("tree.txt");
                
                for (TreeNode e = root.branch[0]; e != null; e = e.sibling)
                {
                    // sw.WriteLine("Lexema: " + elToken.lexema + "	Tipo: " + elToken.tipo + "	Linea: " + elToken.linea + "	Columna: " + elToken.columna);
                    Console.WriteLine(e.token.lexema);
                    sw.WriteLine(e.token.lexema);
                    mostratHijos(e, "", sw);
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

        public void mostratHijos(TreeNode root, string tabulacion, StreamWriter sw)
        {
            for (int i = 0; i < 3; i++)
            {
                if ( root.branch[i] != null)
                {
                    mostrarHermanos(root.branch[i], tabulacion + "    ",sw);
                }
            }
        }

        public void mostrarHermanos(TreeNode root, string tabulacion, StreamWriter sw)
        {
            for (TreeNode e = root; e != null; e = e.sibling)
            {
                Console.WriteLine(tabulacion + e.token.lexema);
                sw.WriteLine(tabulacion + e.token.lexema);
                mostratHijos(e, tabulacion + "  ", sw);
            }
        }


    }
}
