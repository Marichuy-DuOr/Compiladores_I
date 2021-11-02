using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace compilador
{
    class Semantico
    {
        public bool isCorrect;
        public TreeNode t;
        public StreamWriter wf;
        string primitivo;
        Token token; 
        Dictionary<int, Dictionary<string, int>> tableSymbols = new Dictionary<int, Dictionary<string, int>>();
        Dictionary<int, Dictionary<string, string>> symbolKind = new Dictionary<int, Dictionary<string, string>>();

        public Semantico(TreeNode t)
        {
            this.t = t;
            this.isCorrect = true;
        }

        public TreeNode analisisSemantico()
        {
            this.wf = new StreamWriter("variable.txt");
            writeTable("");

            node_secuence(this.t, 0);

            this.wf.Close();
            return this.t;
        }

        public void writeTable(string message)
        {
            Console.WriteLine(message);
            this.wf.WriteLine(message);
        }

        public void node_secuence(TreeNode t, int deep)
        {
            if (t == null)
            {
                return;
            }

            switch (t.nodeKind)
            {
                case TreeNode.NodeKind.StmtK:
                    switch (t.kind.stmt)
                    {
                        case TreeNode.StmtKind.ProgramK:
                            node_secuence(t.branch[0], (deep + 1));
                            kill_instance_variables(deep + 1);
                            break;

                        case TreeNode.StmtKind.Ifk:
                            validate_boolean_expresion(t.branch[0], (deep + 1));
                            kill_instance_variables(deep + 1);
                            node_secuence(t.branch[1], (deep + 1));
                            kill_instance_variables(deep + 1);
                            node_secuence(t.branch[2], (deep + 1));
                            kill_instance_variables(deep + 1);
                            break;

                        case TreeNode.StmtKind.WriteK:
                            validate_write_expresion(t.branch[0], deep);
                            break;

                        case TreeNode.StmtKind.ReadK:
                            does_variable_exist(t.branch[0], deep);
                            break;

                        case TreeNode.StmtKind.AssignK:
                            if (does_variable_exist(t.branch[0], deep))
                            {
                                this.primitivo = get_primitive(t.branch[0], deep);
                                writeTable("Asignación a la variable " + t.branch[0].token.lexema + " " + primitivo);

                                if (this.primitivo.Equals("bool"))
                                {
                                    validate_boolean_expresion(t.branch[1], deep);
				                } else {
                                    validate_exp_tree(t.branch[1], deep);
				                }
                            }
                            break;

                        case TreeNode.StmtKind.DeclK:
                            makeVariable(t.branch[0], deep);
                            break;

                        case TreeNode.StmtKind.Dok:
                            node_secuence(t.branch[0], (deep + 1));
                            kill_instance_variables(deep + 1);
                            validate_boolean_expresion(t.branch[1], (deep + 1));
                            kill_instance_variables(deep + 1);
                            break;

                        case TreeNode.StmtKind.UntilK:
                            break;

                        case TreeNode.StmtKind.WhileK:
                            validate_boolean_expresion(t.branch[0], (deep + 1));
                            node_secuence(t.branch[1], (deep + 1));
                            kill_instance_variables(deep + 1);
                            break;

                        default:
                            break;
                    }
                    break;
                case TreeNode.NodeKind.Expk:
                    break;
            }
            node_secuence(t.sibling, deep);
        }

        public void kill_instance_variables(int deep)
        {
            try
            {
                Dictionary<string, int> mm = tableSymbols[deep];
                foreach (KeyValuePair<string, int> kvp in mm)
                {
                    writeTable("Eliminada variable de instancia " + kvp.Key);
                    // Console.WriteLine("Key = {0}, Value = {1}",
                    //     kvp.Key, kvp.Value);
                }
                tableSymbols.Remove(deep);
                symbolKind.Remove(deep);
            }
            catch (KeyNotFoundException)
            {
                // Console.WriteLine("Key = " + deep + " is not found.");
            }
        }

        public void validate_boolean_expresion(TreeNode t, int deep)
        {
            this.token = t.token;

            if (isLogicFirstOrder())
            {
                validate_boolean_expresion(t.branch[0], deep);
                validate_boolean_expresion(t.branch[1], deep);
            } 
            else if (isLogicSecondOrder())
            {
                this.primitivo = "float";
                validate_exp_tree(t.branch[0], deep);
                validate_exp_tree(t.branch[1], deep);
            }
            else if (t.kind.exp == TreeNode.ExpKind.IdK)
            {
                this.primitivo = "bool";
		        if (does_variable_exist(t, deep) && get_primitive(t, deep).Equals("bool")) {

		        } else {
                    writeTable("asignacion incorrecta en linea " + t.token.linea + " lexema " + t.token.lexema);
                    this.isCorrect = false;
		        }
            }
            else if (t.kind.exp == TreeNode.ExpKind.ConstK)
            {
                if (validate_consts(t.token)) {

		        } else {
                    writeTable("asignacion incorrecta en linea " + t.token.linea + " lexema " + t.token.lexema);
                    this.isCorrect = false;
		        }
            }
            else
            {
                writeTable("Uso incorrecto de expresion booleana en linea " + t.token.linea);
		        this.isCorrect = false;
            }
        }

        public void validate_write_expresion(TreeNode t, int deep)
        {
            this.token = t.token;

            if (isLogicFirstOrder()) 
            {
                validate_boolean_expresion(t.branch[0], deep);
		        validate_boolean_expresion(t.branch[1], deep);
	        }
            else if (isLogicSecondOrder()) 
            {
                this.primitivo = "float";
		        validate_exp_tree(t.branch[0], deep);
		        validate_exp_tree(t.branch[1], deep);
	        }
            else if (t.kind.exp == TreeNode.ExpKind.IdK) 
            {
		        if (does_variable_exist(t, deep)) {

		        } 
                else 
                {
                    writeTable("no existe la variable de la linea " + t.token.linea + " lexema " + t.token.lexema);
			        this.isCorrect = false;
		        }
	        }
            else if (t.kind.exp == TreeNode.ExpKind.ConstK)
            {

            }
            else if (t.kind.exp == TreeNode.ExpKind.OpK)
            {
                this.primitivo = "float";
		        validate_exp_tree(t, deep);
	        }
            else 
            {
                writeTable("Uso incorrecto de expresion write en linea " + t.token.linea);
                this.isCorrect = false;
	        }
        }

        public bool does_variable_exist(TreeNode t, int deep)
        {
            Token token = t.token;
            try
            {
                Dictionary<string, int> mm = tableSymbols[deep];
                int i = tableSymbols[deep][token.lexema];
                if (i == 1) 
                {
                    return true;
		        } else {
                    if (deep == 0)
                    {
                        writeTable("Error: variable " + token.lexema + " is not defined in the line " + token.lexema);
                        this.isCorrect = false;
                        return false;
                    }
                    else
                    {
                        return does_variable_exist(t, (deep - 1));
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                if (deep == 0)
                {
                    writeTable("Error: variable " + token.lexema + " is not defined in the line " + token.lexema);
                    isCorrect = false;
			        return false;
                }
                else
                {
                    return does_variable_exist(t, (deep - 1));
                }
            }
        }

        public string get_primitive(TreeNode t, int deep)
        {
            Token token = t.token;
            int i;
            string j = "";
            try
            {
                Dictionary<string, int> mm = tableSymbols[deep];
                i = tableSymbols[deep][token.lexema];
                j = symbolKind[deep][token.lexema];

                if (i == 1) 
                {
                    return j;
		        } 
                else 
                {
                    if (deep == 0)
                    {
                        writeTable("Error: variable " + token.lexema + " is not defined in the line " + token.lexema);
                        this.isCorrect = false;
                        return j;
                    }
                    else
                    {
                        return get_primitive(t, (deep - 1));
                    }
                }
            }
            catch (KeyNotFoundException)
            {
                if (deep == 0) 
                {
                    writeTable("Error: variable " + token.lexema + " is not defined in the line " + token.lexema);
                    this.isCorrect = false;
                    return j;
		        } else {
                    return get_primitive(t, (deep - 1));
		        }
            }
        }

        public void validate_exp_tree (TreeNode t, int deep)
        {
            if (t == null) 
            {
                return;
	        }

            switch (t.kind.exp)
            {
                case TreeNode.ExpKind.OpK:
                    this.token = t.token;
                    if (token.lexema.Equals("/") && this.primitivo.Equals("int"))
                    {
                        writeTable("posible perdida de precision en linea " + token.linea + " lexema " + token.lexema);
                    }
                    if (!is_operator_correct(this.primitivo)) {
                        writeTable("el token " + t.token.lexema + " no corresponde a " + this.primitivo);
                        isCorrect = false;
                        return;
		            }
                    break;
                case TreeNode.ExpKind.ConstK:
                    validate_consts(t.token);
                    break;
                case TreeNode.ExpKind.IdK:
                    does_variable_exist(t, deep);
		            if (!is_type_correct(t, deep)) 
                    {
                        writeTable("Token equivocado en la asignacion " + this.primitivo + " " + t.token.lexema + " linea: " + t.token.linea);
                        this.isCorrect = false;
		            }
                    break;
                default:
                    break;
            }
            validate_exp_tree(t.branch[0], deep);
            validate_exp_tree(t.branch[1], deep);
        }

        public void makeVariable(TreeNode t, int deep)
        {
            if (t == null)
            {
                return;
	        }

            try
            {
                Dictionary<string, int> mm = tableSymbols[deep];
            }
            catch (KeyNotFoundException)
            {
                tableSymbols[deep] = new Dictionary<string, int>();
                symbolKind[deep] = new Dictionary<string, string>();
            }

            Token token = t.token;

            /*try
            {
                int i = tableSymbols[deep][token.lexema];

                tableSymbols[deep][token.lexema] = 1;
                symbolKind[deep][token.lexema] = t.attr.tipe;
                writeTable("" + t.attr.tipe + " " + token.lexema);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("error, variable " + token.lexema + " is already defined");
		        isCorrect = false;
            }*/
            try
            {
                int i = tableSymbols[deep][token.lexema];
                writeTable("error, variable " + token.lexema + " is already defined");
            }
            catch (KeyNotFoundException)
            {
                tableSymbols[deep][token.lexema] = 1;
                symbolKind[deep][token.lexema] = t.attr.tipe;
                writeTable(t.attr.tipe + " " + token.lexema);
            }
            makeVariable(t.sibling, deep);
        }

        public bool isLogicFirstOrder() {
	        if (token.tipo == Token.Token_types.TKN_AND || token.tipo == Token.Token_types.TKN_OR) 
            {
                return true;
	        } 
            else 
            {
                return false;
	        }
        }

        public bool is_type_correct(TreeNode t, int tipo)
        {
            switch (this.primitivo)
            {
                case "int":
                    if (get_primitive(t, tipo).Equals("int"))
                    {
                        return true;
		            } 
                    else if (get_primitive(t, tipo).Equals("float"))
                    {
                        return true;
		            } 
                    else 
                    {
                        return false;
		            }
                    break;
                case "float":
                    if (get_primitive(t, tipo).Equals("int")) 
                    {
                        return true;
		            } 
                    else if (get_primitive(t, tipo).Equals("float")) 
                    {
                        return true;
		            } 
                    else 
                    {
                        return false;
		            }
                    break;
                case "bool":
                    break;
            }

            if (get_primitive(t, tipo).Equals(primitivo)) 
            {
                return true;
	        } 
            else 
            {
                return false;
	        }
        }

        public bool is_operator_correct(string tipo) {
	        if (tipo.Equals("bool")) 
            {
                return isLogicSemantic();
	        } else 
            {
                return !isLogicSemantic();
	        }
        }

        public bool validate_consts(Token t)
        {
            switch (t.tipo)
            {
                case Token.Token_types.TKN_NUM:
                    if (t.lexema.Contains(".") && primitivo.Equals("int")) {
                        writeTable("posible perdida de precision en linea " + t.linea + " lexema " + t.lexema);
                    } 
                    else 
                    {

		            }
                    if (this.primitivo.Equals("bool")) 
                    {
			            if (t.lexema.Equals("1")) 
                        {

			            } 
                        else if (t.lexema.Equals("0")) 
                        {

			            } 
                        else 
                        {
                            isCorrect = false;
                            return false;
			            }
		            }
                    return true;
                    break;
                default:
                    this.isCorrect = false;
                    return false;
                    break;
            }
            this.isCorrect = false;
	        return false;
        }

        public bool isLogicSemantic()
        {
            if (this.token.tipo == Token.Token_types.TKN_AND || this.token.tipo == Token.Token_types.TKN_OR) 
            {
                return true;
	        } 
            else if (this.token.tipo == Token.Token_types.TKN_LESS || this.token.tipo == Token.Token_types.TKN_ELESS) 
            {
                return true;
	        } 
            else if (this.token.tipo == Token.Token_types.TKN_EQUAL || this.token.tipo == Token.Token_types.TKN_NEQUAL) 
            {
                return true;

	        } else if (this.token.tipo == Token.Token_types.TKN_MORE || this.token.tipo == Token.Token_types.TKN_EMORE) 
            {
                return true;
	        } 
            else 
            {
                return false;
	        }
        }

        public bool isLogicSecondOrder()
        {
            if (this.token.tipo == Token.Token_types.TKN_LESS || this.token.tipo == Token.Token_types.TKN_ELESS) 
            {
                return true;
	        } 
            else if (this.token.tipo == Token.Token_types.TKN_EQUAL || this.token.tipo == Token.Token_types.TKN_NEQUAL) 
            {
                return true;
	        } 
            else if (this.token.tipo == Token.Token_types.TKN_MORE || this.token.tipo == Token.Token_types.TKN_EMORE) 
            {
                return true;
	        } 
            else 
            {
                return false;
	        }
        }

    }
}
