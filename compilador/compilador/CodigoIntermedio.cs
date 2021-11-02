using System;
using System.Collections.Generic;
using System.Text;

namespace compilador
{
    class CodigoIntermedio
    {
        public TreeNode t;
        public int t_index;
        public int loop_index;
        public string current_t;

        public CodigoIntermedio(TreeNode t)
        {
            this.t = t;
        }

        public void code_generator()
        {
            Console.WriteLine("Generando código...");
            t_index = 0;
            loop_index = 0;
            current_t = "123";// + strconv.Itoa(123);
            code_assambler(t);
        }

        public void code_assambler(TreeNode t)
        {
            if (t == null)
            {
                return;
            }

            int auxiliar_loop = loop_index;

            switch (t.nodeKind)
            {
                case TreeNode.NodeKind.StmtK:
                    switch (t.kind.stmt)
                    {
                        case TreeNode.StmtKind.ProgramK:
                            Console.WriteLine("Main:");
                            code_assambler(t.branch[0]);
                            break;

                        case TreeNode.StmtKind.Ifk:
                            Console.WriteLine("(if_f, " + viewTree(t.branch[0]) + ", " + auxiliar_loop.ToString() + ", _)");
                            loop_index++;
                            int aux_if = loop_index;
                            code_assambler(t.branch[1]);
                            Console.WriteLine("(_, _, loop" + aux_if.ToString() + ", _)");
                            Console.WriteLine("(lab, " + auxiliar_loop.ToString() + ", _, _)");
                            code_assambler(t.branch[2]);
                            Console.WriteLine("(lab, loop" + aux_if.ToString() + ", _, _)");
                            break;

                        case TreeNode.StmtKind.WriteK:
                            viewTree(t.branch[0]);
                            Console.WriteLine("(wr, " + t_index.ToString() + ", _, _)");
                            break;

                        case TreeNode.StmtKind.ReadK:
                            Console.WriteLine("(rd, " + t.branch[0].token.lexema + ", _, _)");
                            break;

                        case TreeNode.StmtKind.AssignK:
                            Console.WriteLine("(asn, " + t.branch[0].token.lexema + ", _, " + viewTree(t.branch[1]) + ")");
                            break;

                        case TreeNode.StmtKind.DeclK:
                            break;

                        case TreeNode.StmtKind.Dok:
                            Console.WriteLine("(lab, loop" + loop_index.ToString() + "_, _)");
                            loop_index++;
                            code_assambler(t.branch[0]);
                            Console.WriteLine("(if_f, " + viewTree(t.branch[1]) + ", loop" + auxiliar_loop.ToString() + ", _)");
                            break;

                        case TreeNode.StmtKind.UntilK:
                            break;

                        case TreeNode.StmtKind.WhileK:
                            viewTree(t.branch[0]);
                            code_assambler(t.branch[1]);
                            break;

                        default:
                            break;
                    }
                    break;

                case TreeNode.NodeKind.Expk:
                    break;
            }
            code_assambler(t.sibling);
        }

        public string viewTree(TreeNode t)
        {
            if (t == null)
            {
                return "";
            }

            switch (t.kind.exp) {
                case TreeNode.ExpKind.OpK:
                    string r1 = viewTree(t.branch[0]);
                    string r2 = viewTree(t.branch[1]);
                    t_index++;
                    string r3 = "__t" + t_index.ToString();
                    make_4(t, r1, r2, r3);
                    return r3;

                case TreeNode.ExpKind.IdK:
                    return t.token.lexema;

                case TreeNode.ExpKind.ConstK:
                    return t.token.lexema;
            }
            return "";
        }

        public void make_4(TreeNode t, string r1, string r2, string r3) {
	        if (t.token.lexema == "+") {
                Console.WriteLine("(add, " + r1 + ", " + r2 + ", " + r3 + ")");
	        } else if (t.token.lexema == "-") {
                Console.WriteLine("(sub, " + r1 + ", " + r2 + ", " + r3 + ")");
	        } else if (t.token.lexema == "*") {
                Console.WriteLine("(mul, " + r1 + ", " + r2 + ", " + r3 + ")");
	        } else if (t.token.lexema == "/") {
                Console.WriteLine("(div, " + r1 + ", " + r2 + ", " + r3 + ")");
	        } else {
                Console.WriteLine("(cmp, " + r1 + ", " + r2 + ", " + r3 + ")");
	        }
        }
    }
}
