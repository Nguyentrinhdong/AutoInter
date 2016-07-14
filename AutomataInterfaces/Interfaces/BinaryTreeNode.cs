using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;

namespace AutomataInterfaces.Interfaces
{
    class BinaryTreeNode
    {

        public BinaryTreeNode LeftChild;
        public BinaryTreeNode RightChild;
        public string Value;
        

        public bool IsLeaf
        {
            get { return this.LeftChild == null && this.RightChild == null; }
        }

        public BinaryTreeNode(string value)
        {
            Value = value;
        }

        public static bool IsOperand(string str)
        {
            return Regex.Match(str, @"^\d+$|^([a-z][0-9]|[A-Z][0-9])$").Success;
        }

        public static void FormatExpression(ref string expression)
        {
            //expression = expression.Replace(" ", "");
            // expression = Regex.Replace(expression, @"\+|\-|\*|\/|\%|\^|\)|\(", delegate(Match match)
            // {
            //     return " " + match.Value + " ";
            // });
            expression = expression.Replace("  ", " ");
            expression = expression.Trim();
        }

        static int GetPriority(string c)
        {
            if (c == "^" || c == "!")
                return 6;
            else if (c == "*" || c == "/")
                return 5;
            else if (c == "+" || c == "-")
                return 4;
            if (c == "<" || c == ">" || c == ">=" || c == "<=" || c == "=" || c == "!=")
                return 3;
            if (c == "||" || c == "&&")
                return 2;
            if (c == "=>")
                return 1;
            else
                return 0;
        }

        static bool IsOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^" || c == "<" || c == ">" || c == ">=" || c == "<=" || c == "=" || c == "!=" || c == "||" || c == "&&" || c == "=>")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CreateSubTree(Stack<BinaryTreeNode> opStack, Stack<BinaryTreeNode> nodeStack)
        {
            BinaryTreeNode node = opStack.Pop();
            node.RightChild = nodeStack.Pop();
            node.LeftChild = nodeStack.Pop();
            nodeStack.Push(node);
        }

        public  BinaryTreeNode Infix2ExpressionTree(string infixExpression)
        {
            //List<> prefix = new List();
            Stack<BinaryTreeNode> operatorStack = new Stack<BinaryTreeNode>();
            Stack<BinaryTreeNode> nodeStack = new Stack<BinaryTreeNode>();

            FormatExpression(ref infixExpression);

            IEnumerable enumer = infixExpression.Split(' ');

            foreach (string s in enumer)
            {
                if (IsOperand(s))
                    nodeStack.Push(new BinaryTreeNode(s));
                else if (s == "(")
                    operatorStack.Push(new BinaryTreeNode(s));
                else if (s == ")")
                {
                    while (operatorStack.Peek().Value != "(")
                        CreateSubTree(operatorStack, nodeStack);
                    operatorStack.Pop();
                }
                else if (IsOperator(s))
                {
                    while (operatorStack.Count > 0 && GetPriority(operatorStack.Peek().Value) >= GetPriority(s))
                        CreateSubTree(operatorStack, nodeStack);

                    operatorStack.Push(new BinaryTreeNode(s));
                }

            }

            while (operatorStack.Count > 0)
                CreateSubTree(operatorStack, nodeStack);

            return nodeStack.Peek();
        }

    }
}
