using System;
using System.Collections.Generic;
using System.Text;

namespace compilador
{
    class TreeNode
    {
        public enum NodeKind
        {
            StmtK,
            Expk
        }

        public enum StmtKind
        {
            ProgramK,
            Ifk,
            WriteK,
            ReadK,
            DeclK,
            AssignK,
            Dok,
            UntilK,
            WhileK
        }

        public enum ExpKind
        {
            OpK,
            ConstK,
            IdK
        }

        public enum ExpType
        {
            Void,
            Integer,
            Boolean
        }

        public struct Kind
        {
            public StmtKind stmt { get; set; }
            public ExpKind exp { get; set; }
        }

        public struct Attr
        {
            public Token.Token_types op { get; set; }
            public string tipe { get; set; }
            public double val { get; set; }
            public string name { get; set; }
        }

        public Token token { get; set; }
        public int precedence { get; set; }
        public TreeNode sibling { get; set; }
        public NodeKind nodeKind { get; set; }
        public Kind kind;
        public Attr attr;
        public ExpType tipe { get; set; }
        public TreeNode[] branch { get; set; }

        public TreeNode() {
            this.branch = new TreeNode[3];
        }

    }
}
