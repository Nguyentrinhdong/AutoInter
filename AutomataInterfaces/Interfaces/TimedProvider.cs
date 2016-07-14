using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Msagl.Core.Geometry.Curves;
using Microsoft.Msagl.Core.Layout;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Layout.Layered;
using System.Collections.Generic;
using Label = Microsoft.Msagl.Core.Layout.Label;
using Node = Microsoft.Msagl.Drawing.Node;
using Point = Microsoft.Msagl.Core.Geometry.Point;

namespace AutomataInterfaces.Interfaces
{

    internal class TimedProvider
    {
        Boolean kt = true;
        private List<Automata> automatainterface = new List<Automata>();

        #region Cac phuong thuc nhap X,Y va D

        //Phân tách từng thành phần trong một automata
        public Automata AutomataInput(String StrAutomata)
        {
            if (kt)
            {
                Automata autoInter = new Automata();
                String[] strEI = new String[7];
                strEI = strAutomataElementSeparation(StrAutomata);
                autoInter.AutomataID = strEI[0];
                autoInter.Type = TypeInput(strEI[1].Trim());
                autoInter.Var = VarInput(strEI[1].Trim());
                autoInter.Q = LocationInput(strEI[2].Trim());
                autoInter.X = XInputs(strEI[3].Trim(), autoInter);
                autoInter.Y = YInputs(strEI[4].Trim(), autoInter);
                autoInter.q0 = q0Input(strEI[5].Trim(), autoInter.Q);
                autoInter.InitialState = s0Input(strEI[5].Trim());
                autoInter.T = TransitionInput(strEI[6].Trim(), autoInter.Q);
                return autoInter;
            }
            else
                return null;
        }
        //Phân tách phần khai báo biến
        private List<IVar> VarInput(string p)
        {
            List<IVar> _var = new List<IVar>();
            Boolean kt = false;
            String[] strVar = p.Split(';');
            String[] _strVar = new string[2];
            //Chỉ lấy phần khai báo biến
            foreach (string item in strVar)
            {
                kt = false;
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '=')
                    {
                        kt = true;
                        break;
                    }
                }
                if (!kt)
                {
                    _strVar = item.Split(' ');
                    IVar _iVar = new IVar(_strVar[0], _strVar[1]);
                    _var.Add(_iVar);
                }

            }
            return _var;
        }
        private IState s0Input(string p)
        {
            //Nhap location q0
            p = p.Remove(p.Length - 1);
            IState iState = new IState(p);
            return iState;
        }

        //Phân tách phần khai báo kiểu dữ liệu
        private List<IType> TypeInput(string p)
        {
            List<IType> _type = new List<IType>();
            _type.Clear();
            String[] StandardType = { "Int", "Real", "Long", "Float", "Double" };

            Boolean kt = false;
            String[] strVar = p.Split(';');
            String[] _strVar = new string[2];

            foreach (string item in StandardType)
            {
                IType _itype = new IType(item, item);
                _type.Add(_itype);
            }
            //Chi lấy phần định nghĩa kiểu
            foreach (string item in strVar)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i] == '=')
                    {
                        kt = true;
                    }

                    if (kt)
                    {
                        _strVar = item.Split('=');
                        IType _itype = new IType(_strVar[0].Trim(), _strVar[1].Trim());
                        _type.Add(_itype);
                        kt = false;
                        break;
                    }

                }

            }
            return _type;
        }
        private string[] strAutomataElementSeparation(string StrAutomata)
        {
            String[] strEI = new String[7];
            String[] separatestr = { "\n\t", "\n", "\t" };
            String[] strAi = StrAutomata.Split(separatestr, StringSplitOptions.RemoveEmptyEntries);

            String strVar = "";
            String strLocation = "";
            String strInput = "";
            String strOutput = "";
            String strq0 = "";
            String strTransition = "";

            ///Lay ID cho automata
            ///
            String InterfaceID = strAi[0].Trim();

            int k = 1;

            //Xu ly dau cach trống
            for (k = 1; k < strAi.Length; k++)
            {
                strAi[k] = strAi[k].Trim();
            }

            k = 1;
            while (strAi[k] != "Location:")
            {
                strVar += strAi[k];
                k++;
            }


            while (strAi[k] != "Input:")
            {
                strLocation += strAi[k];
                k++;
            }

            while (strAi[k] != "Output:")
            {
                strInput += strAi[k];
                k++;
            }

            while (strAi[k] != "q0:")
            {
                strOutput += strAi[k];
                k++;
            }


            while (strAi[k] != "Transition:")
            {

                strq0 += strAi[k];
                k++;
            }

            while (k < strAi.Length)
            {
                strTransition += strAi[k];
                k++;
            }

            char[] bracket = { '{', '}' };
            strEI[0] = InterfaceID;
            strEI[1] = strVar.Substring(4).Trim();
            strEI[1] = strEI[1].Remove(strEI[1].Length - 1);

            strEI[2] = strLocation.Substring(10);
            strEI[2] = strEI[2].Remove(strEI[2].Length - 2);

            strEI[3] = strInput.Substring(7);
            strEI[3] = strEI[3].Remove(strEI[3].Length - 2);

            strEI[4] = strOutput.Substring(8);
            strEI[4] = strEI[4].Remove(strEI[4].Length - 2);

            strEI[5] = strq0.Substring(4);
            strEI[5] = strEI[5].Remove(strEI[5].Length - 1);

            strEI[6] = strTransition.Substring(12);
            strEI[6] = strEI[6].Remove(strEI[6].Length - 1);
            return strEI;
        }

        private List<ITransitions> TransitionInput(string p, List<ILocation> Q)
        {
            //t1:s1-->s1,(usage = 0);
            List<ITransitions> Trans = new List<ITransitions>();
            char[] splitChar = { ';' };

            //Tách cac transition

            String[] NumberofT = p.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);
            String[] subItem;
            String[] subsubItem;
            String[] subsubsubItem;
            String[] splitStr = { "-->" };

            foreach (String item in NumberofT)
            {
                //Phan tach hai thanh phan trong mot transition
                subItem = item.Split(',');
                subsubItem = subItem[0].Split(':');
                subsubsubItem = subsubItem[1].Split(splitStr, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < Q.Count; i++)
                    if (subsubsubItem[0] == Q[i].LocationID)
                        for (int j = 0; j < Q.Count; j++)
                            if (subsubsubItem[1] == Q[j].LocationID)
                            {
                                var trans = new ITransitions(Q[i], Q[j], subItem[1]);
                                trans.ID = subsubItem[0];
                                Trans.Add(trans);
                            }
            }

            return Trans;
        }

        //Phân tách các Design cho các location
        private List<ILocation> LocationInput(string p)
        {
            List<ILocation> Loc = new List<ILocation>();

            /// xu ly Q
            /// Phan tach dau vao cua Q de nap vao automata
            ///
            String[] LocationList = p.Split(';');

            foreach (String item in LocationList)
            {
                ILocation location = new ILocation(item);
                Loc.Add(location);
            }

            return Loc;
        }

        private ILocation q0Input(string p, List<ILocation> l)
        {
            ILocation iLoc = new ILocation(p.Remove((p.Length - 1)));
            foreach (ILocation item in l)
            {
                if (item.LocationID == iLoc.LocationID)
                {
                    iLoc = item;
                }
            }

            return iLoc;
        }

        //Nhap noi dung tu text file chuyen thanh danh sach automata
        /// <summary>
        /// Create automata Interface List in order to convert to tree and to draw and to pluggable Check
        /// </summary>
        /// <param name="AutomataText"></param>
        public List<Automata> CreateAutomataList(String AutomataText)
        {
            automatainterface.Clear();
            String[] Aut = SeparateAutomataString(AutomataText);

            foreach (String item in Aut)
            {
                Automata a = new Automata();
                a = AutomataInput(item);
                if (a != null)
                {
                    automatainterface.Add(a);
                }
            }
            if (automatainterface.Count >= 1)
            {
                return automatainterface;
            }
            else
                return null;
        }

        public String[] SeparateAutomataString(String strText)
        {
            String[] spr = { "Def:" };
            String[] AutomataString = strText.Split(spr, StringSplitOptions.RemoveEmptyEntries);
            return AutomataString;
        }

        public ITimedDesigned TimedDesign(String DStr)
        {
            ITimedDesigned tmdDesign = new ITimedDesigned();
            char _split = ';'; //Phân chia timed Designs
            char[] __split = { '(', ')' };//Phân chia các thanh phan trong 1 timed Design
            char ___split = ',';
            char ____split = '-';
            string[] _____split = { "=>" };
            String[] Design = DStr.Split(_split);//Tach cac Design

            foreach (String item in Design)
            {
                ITimedDesigned tD = new ITimedDesigned();
                String[] element = item.Split(__split);
                tD.ID = element[0];
                String[] Rhoft = element[1].Split(___split);
                tD.Rho_f = Rhoft[0];
                tD.Rho_t = Rhoft[1];
                string[] preandpost = tD.Rho_f.Split(_____split, StringSplitOptions.RemoveEmptyEntries);
                tD.Precondition = preandpost[0];
                if (preandpost.Length > 1)
                {
                    tD.PostCondition = preandpost[1];
                }
                else
                    tD.PostCondition = "";
                tD.timedIntv = new ITimedIntervals();
                string[] Rhotimed = tD.Rho_t.Split(____split);
                tD.timedIntv.LowerBound = int.Parse(Rhotimed[0]);
                tD.timedIntv.UpperBound = int.Parse(Rhotimed[1]);
                tD.timedIntv.TimeEvent = tD.timedIntv.TimedEventRandom();
                tmdDesign = tD;
            }

            return tmdDesign;
        }

        /// <summary>
        /// Phuong thuc tao InputPorts
        /// </summary>
        /// 

        public Inputs XInputs(string XStr, Automata automata)
        {
            Inputs XX = new Inputs();
            char _split = ';'; //Phân chia các port

            //Lay danh sach cac ports cua X
            String[] Ports = XStr.Split(_split);
            Inputs.PortElement p = new Inputs.PortElement();
            foreach (String item in Ports)
            {
                p.Name = item;
                p.ID = item;
                foreach (IVar itemVar in automata.Var)
                {
                    if (itemVar.Values == p.Name)
                    {
                        foreach (IType itemType in automata.Type)
                        {
                            if (itemVar.VarTypeID == itemType.TypeID)
                            {
                                p.Var = new IVar(itemType.TypeID, itemType.TypeValues);
                                p.Type = new IType(itemType.TypeID, itemType.TypeValues);

                            }
                        }
                    }
                }
                XX.InputElements.Add(p);
            }
            return XX;
        }

        public Outputs YInputs(string YStr, Automata automata)
        {
            Outputs YY = new Outputs();
            char _split = ';'; //Phân chia các port
            String[] Ports = YStr.Split(_split);

            Outputs.PortElement y = new Outputs.PortElement();


            foreach (String item in Ports)
            {
                y.Name = item;
                y.ID = item;
                foreach (IVar itemVar in automata.Var)
                {
                    if (itemVar.Values == y.Name)
                    {
                        foreach (IType itemType in automata.Type)
                        {
                            if (itemVar.VarTypeID == itemType.TypeID)
                            {
                                y.Var = new IVar(itemType.TypeID, itemType.TypeValues);
                                y.Type = new IType(itemType.TypeID, itemType.TypeValues);

                            }
                        }
                    }
                }
                YY.OutputElements.Add(y);
            }

            return YY;
        }

        #endregion Cac phuong thuc nhap X,Y va D

        #region Cheking

        //----------------------------------------------------------------------------------------
        public static void FormatExpression(ref string expression)
        {
            expression = expression.Replace("  ", " ");
            expression = expression.Trim();
        }

        /// <summary>
        /// Chuyển biểu thức toán học từ dạng infix sang dạng prefix
        /// </summary>
        public static string Infix2Prefix(string infix)
        {
            List<string> prefix = new List<string>();
            Stack<string> stack = new Stack<string>();

            FormatExpression(ref infix);

            IEnumerable<string> enumer = infix.Split(' ').Reverse();

            foreach (string s in enumer)
            {

                if (IsOperand(s))
                    prefix.Add(s);
                else if (s == ")")
                {
                    prefix.Add(s);
                    stack.Push(s);
                }
                else if (s == "(")
                {
                    while (stack.Count > 0 && stack.Peek() == ")") stack.Pop();
                    while (stack.Count > 0 && IsOperator(stack.Peek())) prefix.Add(stack.Pop());
                    prefix.Add(s);
                }
                else// if (IsOperator(s))
                {
                    if (stack.Count > 0 && GetPriority(s) <= GetPriority(stack.Peek()))
                        prefix.Add(stack.Pop());

                    stack.Push(s);
                }
            }

            while (stack.Count > 0)
                if (stack.Peek() == ")")
                {
                    stack.Pop();
                }
                else
                    prefix.Add(stack.Pop());

            StringBuilder str = new StringBuilder();

            for (int i = prefix.Count - 1; i >= 0; i--)
            {
                str.Append(prefix[i]).Append(" ");
            }

            str.Replace("&&", "and");
            str.Replace("->", "=>");
            str.Replace("||", "or");
            str.Replace(" T ", " true ");
            str.Replace(" F ", " false ");
            String strFinal = str.ToString();
            String[] temp = strFinal.Split(' ');
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == "!=")
                {
                    temp[i] = "not";
                    temp[i + 1] = "( = " + temp[i + 1];
                    temp[i + 2] = temp[i + 2] + " )";
                }
            }

            strFinal = "";
            for (int i = 0; i < temp.Length; i++)
            {
                strFinal += temp[i] + " ";
            }

            return strFinal;
        }

        //private static bool IsOperator(string str)
        //{
        //    return Regex.Match(str, @"\+|\-|\*|\/|\%").Success;
        //}
        //----------------------------------------------------------------------------------------
        public static bool IsOperand(string str)
        {
            return Regex.Match(str, @"^\w+$|^[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?$|^([a-z][0-9]|[A-Z][0-9])|^([a-z]|[A-Z])$").Success;
        }

        //----------------------------------------------------------------------------------------
        /// <summary>
        /// Chuyển một Automata sang SMT-Z3
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        //public String Automata2Z3Standard(Automata a, String assginment)
        //{
        //    String Z3Str = "";
        //    String SMTResult = "";
        //    //Khai bao cac input Ports
        //    SMTResult = "";
        //    foreach (Inputs.PortElement s in a.X.InputElements)
        //    {
        //        SMTResult += "(declare-const " + s.ID + " " + s.Domain + ") \n";
        //    }
        //    Z3Str = SMTResult;
        //    SMTResult = "";
        //    //Khai bao outputPort
        //    foreach (Outputs.PortElement s in a.Y.OutputElements)
        //    {
        //        SMTResult += "(declare-const " + s.ID + " " + s.Domain + " ) \n";
        //    }
        //    Z3Str += SMTResult;

        //    SMTResult = "";

        //    SMTResult += TimedDesign2Z3fucntion(a, assginment);

        //    Z3Str += SMTResult;
        //    return Z3Str;
        //}

        //----------------------------------------------------------------------------------------
        /// <summary>
        /// chuyển một biểu thức dạng prefix sang dạng SMT-Z3 phần khai báo các biến
        /// </summary> Sinh chuỗi SMT2 cho I,E
        /// <param name="Fol"></param>
        /// <returns></returns>
        public String ConvertTimedDesignToSMT(Automata a, String Fol, String IEDataType)
        {
            ///Khai bao cac cong vao ra cua automata
            ///
            String z3f = IEDataType;

            //Khai bao cac input Ports
            //foreach (IVar s in a.Var)
            //{
            //    z3f += "(declare-const " + s.Values + " " + s.VarTypeID + ") \n";
            //}

            z3f += "(define-fun " + "F" + " ( ";

            z3f += ")" + " Bool \n (if " + Infix2Prefix(Fol) + " \n true \n false\n ))\n"; //
            z3f += "(assert (= " + "F ";

            //Them phep gan gia tri cho Timed Design
            z3f += " true)) \n";
            z3f += "(check-sat) \n \n";
            return z3f;
        }

        //---------------------------------------------------------------------------
        //public String TimedDesign2Z3fucntion(Automata a, String assignment)
        //{
        //    String z3f = "";

        //    if (assignment.Split(' ')[0] == "Int" || assignment.Split(' ')[0] == "Int")
        //    {
        //        foreach (ILocation l in a.Q)
        //        {
        //            z3f += "(define-fun " + l.timedDesign.ID + " ( ";
        //            z3f += ")" + " Bool \n (if " +
        //                Infix2Prefix("( " + l.timedDesign.Precondition.Trim() +
        //                " => " + l.timedDesign.PostCondition.Trim())
        //                + " \n true \n false\n ))\n"; //
        //            z3f += "(assert (= " + l.timedDesign.ID + " ";

        //            //Them phep gan gia tri cho Timed Design
        //            z3f += " true)) \n";
        //            z3f += "(check-sat) \n \n";
        //        }
        //    }
        //    else
        //        foreach (ILocation l in a.Q)
        //        {
        //            z3f += "(define-fun " + l.timedDesign.ID + " (";
        //            string temp = "";
        //            foreach (Inputs.PortElement item in a.X.InputElements)
        //            {
        //                temp += "(" + item.ID + " " + item.Domain + ") ";
        //            }
        //            foreach (Outputs.PortElement item in a.Y.OutputElements)
        //            {
        //                temp += "(" + item.ID + " " + item.Domain + ") ";
        //            }
        //            z3f += temp;
        //            z3f += ")" + " Bool \n (if " +
        //                Infix2Prefix("( " + l.timedDesign.Precondition.Trim() +
        //                " => " + l.timedDesign.PostCondition.Trim())
        //                + " \n true \n false\n ))\n"; //
        //            z3f += "(assert (= ( " + l.timedDesign.ID + " " + assignment;
        //            //Them phep gan gia tri cho Timed Design
        //            z3f += " ) true)) \n";
        //            z3f += "(check-sat)\n \n";
        //        }
        //    return z3f;
        //}

        //---------------------------------------------------------------------------
        private static int GetPriority(string c)
        {
            if (c == "^" || c == "!")
                return 7;
            else if (c == "*" || c == "/")
                return 6;
            else if (c == "+" || c == "-")
                return 5;
            if (c == "<" || c == ">" || c == ">=" || c == "<=" || c == "=" || c == "!=" || c == "not")
                return 4;
            if (c == "||" || c == "&&")
                return 3;
            if (c == "=>" || c == "->")
                return 2;
            if (c == ")" || c == "(")
                return 1;
            else
                return 0;
        }

        //---------------------------------------------------------------------------
        private static bool IsOperator(String c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^" || c == "<" || c == ">" || c == ">=" || c == "<=" || c == "=" || c == "!=" || c == "||" || c == "&&" || c == "=>" || c == "->" || c == "not" || c == "!" || c == "and" || c == "or")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------------------------------------------------------------------------

        #endregion Cheking

        #region Pluggable and Refinement Check

        /// <summary>
        /// This method check if D2 is refinement of D1.
        /// It means that, p'=>p and R => R' and [c,d] \subeq [c',d']
        ///
        /// </summary>
        /// <param name="D1"></param>
        /// <param name="D2"></param>
        /// <returns></returns>
        ///

        ////----------------------------------------------------------------------------------------
        //public String ls(ILocation p)
        //{
        //    String fol = "";

        //    fol = p.timedDesign.Precondition + " => " + p.timedDesign.PostCondition;

        //    return fol;
        //}

        //public ITimedDesigned ls(IState s, ITimedDesigned d)
        //{
        //    ITimedDesigned dTimedDesign = new ITimedDesigned();

        //    return dTimedDesign;
        //}


        //----------------------------------------------------------------------------------------

        ///Kiểm tra hai ls(q) có phải là làm min của ls(q')

        public Boolean lsRefinementChecked(ILocation q, ILocation qPrime, String IEDataType)
        {
            if (q.timedDesign.timedIntv.LowerBound >= qPrime.timedDesign.timedIntv.LowerBound && q.timedDesign.timedIntv.UpperBound <= qPrime.timedDesign.timedIntv.UpperBound)
            {
                if (isRefined(qPrime, q, IEDataType))
                {
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.Print("The precondition of " + q.LocationID
                             + " time-design is not satisfy with " + qPrime.LocationID + ".", "Timed Designs Messages");
                    return false;
                }
            }
            else
            {
                System.Diagnostics.Debug.Print("The time interval of " + q.LocationID
                            + " is not satisfy with " + qPrime.LocationID + ".", "Timed Designs Messages");
                return false;
            }
        }

        //----------------------------------------------------------------------------------------
        public String SmtGenerationfromTimeddesigns(ITimedDesigned dE, ITimedDesigned dI, String IEDataType)
        {
            String z3f = "";


            //Kiem tra p' => p
            z3f += IEDataType;

            z3f += "(define-fun " + "pPrime_p" + " (";

            z3f += " )" + " Bool \n (if " + "( " +
                    Infix2Prefix(dE.Precondition.Trim() + " => " + dI.Precondition.Trim()) +
                    ") \n true \n false\n ))\n";

            //z3f += "(assert (= pPrime_p true)) \n";

            //Kiem tra R=R'
            z3f += "(define-fun " + "R_RPrime" + " (";
            //dI.PostCondition = dI.PostCondition.Substring(0, dI.PostCondition.Length - 1);
            //dE.PostCondition = dE.PostCondition.Substring(0, dE.PostCondition.Length - 1);
            z3f += " )" + " Bool \n (if " + "( " +
                    Infix2Prefix(dI.PostCondition.Trim() + " => " + dE.PostCondition.Trim()) +
                    ") \n true \n false\n ))\n";

            //z3f += "(assert (= R_RPrime true)) \n";
            z3f += "(assert (= " + " ( and pPrime_p  R_RPrime ) ";
            z3f += " true)) \n";

            z3f += "(check-sat)\n";

            return z3f;
        }
        //----------------------------------------------------------------------------------------
        //public String SmtGenerationfromTimeddesignsPrecondition(ITimedDesigned dE, ITimedDesigned dI)
        //{
        //    String z3f = "";
        //    String timedDesignString = dE.Precondition + dE.PostCondition + dI.Precondition + dI.PostCondition;

        //    String[] SeperatePre1 = { "<", ">", ">=", "<=", "=", "!=", "||", "&&", "=>", " ", ")", "(", "!" };
        //    String[] preconditionSaperate = timedDesignString.Split(SeperatePre1, StringSplitOptions.RemoveEmptyEntries);
        //    //int i = 0;
        //    String[] preconditionSaperate1 = preconditionSaperate.Distinct().ToArray();
        //    foreach (string item in preconditionSaperate1)
        //    {
        //        if (item[0] == 'x' || item[0] == 'y')
        //        {
        //            z3f += "(declare-const " + item + " Int) \n";
        //        }
        //    }

        //    z3f += "(define-fun " + dE.ID + dI.ID + " (";

        //    z3f += " )" + " Bool \n (if " +
        //            Infix2Prefix("( " + dE.Precondition.Trim() +
        //            " => " + dI.Precondition.Trim()) +
        //            ") \n true \n false\n ))\n";

        //    z3f += "(assert (= " + dE.ID + dI.ID;
        //    z3f += " true)) \n";
        //    z3f += "(check-sat)\n";

        //    return z3f;
        //}

        //----------------------------------------------------------------------------------------
        //private string SmtGenerationfromTimeddesignsPostCondition(ITimedDesigned dE, ITimedDesigned dI)
        //{
        //    String z3f = "";
        //    String timedDesignString = dI.Precondition + dI.PostCondition + dE.Precondition + dE.PostCondition;

        //    String[] SeperatePre1 = { "<", ">", ">=", "<=", "=", "!=", "||", "&&", "=>", " ", ")", "(", "!" };
        //    String[] preconditionSaperate = timedDesignString.Split(SeperatePre1, StringSplitOptions.RemoveEmptyEntries);
        //    //int i = 0;
        //    String[] preconditionSaperate1 = preconditionSaperate.Distinct().ToArray();
        //    foreach (string item in preconditionSaperate1)
        //    {
        //        if (item[0] == 'x' || item[0] == 'y')
        //        {
        //            z3f += "(declare-const " + item + " Int) \n";
        //        }
        //    }

        //    z3f += "(define-fun " + dE.ID + dI.ID + " (";
        //    dI.PostCondition = dI.PostCondition.Substring(0, dI.PostCondition.Length - 1);
        //    dE.PostCondition = dE.PostCondition.Substring(0, dE.PostCondition.Length - 1);
        //    z3f += " )" + " Bool \n (if " +
        //            Infix2Prefix("( " + dI.PostCondition.Trim() + " => " + dE.PostCondition.Trim()) +
        //            ") \n true \n false\n ))\n";

        //    z3f += "(assert (= " + dE.ID + dI.ID;
        //    z3f += " true)) \n";
        //    z3f += "(check-sat)\n";

        //    return z3f;
        //}

        //----------------------------------------------------------------------------------------
        public Boolean CheckedPluggableIE(Automata I, Automata E, out List<PlugableEI> f_List)
        {

            List<PlugableEI> f = new List<PlugableEI>();

            String IEDataType = GetDataType(I, E);
            PlugableEI pEI = new PlugableEI(E.q0, I.q0); //
            f.Add(pEI);

            while (true)
            {
                PlugableEI current = getUnmarkElement(f);
                if (current == null) // khong co phan tu unmarked
                {
                    f_List = f;
                    return true;
                }
                else
                {
                    //mark(f, current); //danh dau phan tu i.
                    current.Marked = true;
                    //2.kiểm tra cặp trạng thái có trng danh sách F 
                    if (lsRefinementChecked(current.q, current.qPrime, IEDataType) == false)
                    {
                        f_List = f;
                        return false;
                    }
                    else
                    {
                        List<rPrimeList> rPrimeLst = new List<rPrimeList>();
                        rPrimeLst = getReachableE(E, I, current.qPrime, current.q, IEDataType);

                        List<PlugableEI> lst = getReachableI(I, current.q, rPrimeLst, IEDataType);
                        if (lst != null)
                        {
                            foreach (var e in lst)
                                if (ElementNotin_f(e, f))
                                {
                                    f.Add(e);
                                }
                        }
                    }
                }
            }
        }

        private string GetDataType(Automata I, Automata E)
        {
            //(declare - datatypes()((S A B C)))
            //(declare -const x S)
            //(declare -const y S)
            //(declare -const z S)
            //(declare -const u S)
            //String[] typeValue;
            String temp = "";
            String strType = "";

            //Định nghĩa kiểu
            Boolean CheckedType = false;
            IVar Ivartemp = new IVar("","");

            foreach (var item in I.Var)
            {
                CheckedType = true;
                if (Ivartemp.VarTypeID == item.VarTypeID)
                {
                    CheckedType = false;
                }

                for (int j = 5; j < I.Type.Count; j++)
                {
                    if (item.VarTypeID == I.Type[j].TypeID && CheckedType)
                    {
                        temp = I.Type[j].TypeValues;
                        temp = temp.Replace('{', ' ').Trim();
                        temp = temp.Replace('}', ' ').Trim();
                        temp = temp.Replace(',', ' ');
                        strType += "(declare-datatypes () ((" + item.VarTypeID + " " + temp + "))) \n";
                    }
                }
                
                Ivartemp = item;
            }


            CheckedType = false;
            foreach (var item in E.Var)
            {
                CheckedType = true;
                for (int k = 0; k < I.Var.Count; k++)
                {

                    if (item.VarTypeID == I.Var[k].VarTypeID)
                    {
                        CheckedType = false;
                        break;
                    }
                }

                for (int i = 5; i < E.Type.Count; i++)
                {
                    if (CheckedType && item.VarTypeID == E.Type[i].TypeID)

                    {
                        temp = E.Type[i].TypeValues;
                        temp = temp.Replace('{', ' ').Trim();
                        temp = temp.Replace('}', ' ').Trim();
                        temp = temp.Replace(',', ' ');
                        strType += "(declare-datatypes () ((" + item.VarTypeID + " " + temp + "))) \n";
                    }

                }
            }
            //Khai bao các bien

            foreach (var item in I.Var)
            {
                strType += "(declare-const " + item.Values + " " + item.VarTypeID + ") \n";
            }


            CheckedType = false;
            foreach (var item in E.Var)
            {
                CheckedType = true;
                for (int k = 0; k < I.Var.Count; k++)
                {
                    if (item.Values == I.Var[k].Values)
                    {
                        CheckedType = false;
                        break;
                    }
                }

                for (int i = 0; i < E.Var.Count; i++)
                {
                    if (CheckedType && item.Values == E.Var[i].Values)

                    {
                        strType += "(declare-const (" + item.Values + " " + item.VarTypeID + ")) \n";
                    }

                }
            }


            return strType;
        }

        //-------------------------------------------------------------
        private bool ElementNotin_f(PlugableEI e, List<PlugableEI> f)
        {
            bool kt = true;
            foreach (PlugableEI item in f)
            {
                if (e.q.LocationID == item.q.LocationID && e.qPrime.LocationID == item.qPrime.LocationID)
                {
                    kt = false;
                    break;
                }
            }
            return kt;
        }

        //-------------------------------------------------------------
        private PlugableEI getUnmarkElement(List<PlugableEI> f)
        {
            foreach (var e in f)
                if (e.Marked == false)
                    return e;

            return null;
        }

        //------------------------------------------------------------------------------------------------
        private List<PlugableEI> getReachableI(Automata I, ILocation q, List<rPrimeList> rPrimeLst, String IEDataType)
        {
            List<PlugableEI> rList = new List<PlugableEI>();

            foreach (rPrimeList rPrime in rPrimeLst)
            {
                for (int k1 = 0; k1 < I.T.Count; k1++)
                {
                    if (q.LocationID == I.T[k1].StateFrom.LocationID)
                    {
                        String temp = ConvertTimedDesignToSMT(I, "( " + I.T[k1].Fxy + " && " + rPrime.F_rPrime + " )", IEDataType);
                        if (Runz3solver(temp) == "sat")
                        {
                            temp = ConvertTimedDesignToSMT(I, "( " + rPrime.F_rPrime + " => " + I.T[k1].Fxy + " )", IEDataType);

                            if (Runz3solver(temp) == "sat")
                            {
                                PlugableEI p = new PlugableEI(rPrime.rPrime, I.T[k1].StateTo);
                                rList.Add(p);
                            }
                        }
                    }
                }
            }
            return rList;
        }

        //----------------------------------------------------------------------------------
        private List<rPrimeList> getReachableE(Automata E, Automata I, ILocation qPrime, ILocation q, String IEDataType)
        {
            List<rPrimeList> rprimeList = new List<rPrimeList>();
            String F = "";
            for (int k = 0; k < E.T.Count; k++)
            {
                if (qPrime.LocationID == E.T[k].StateFrom.LocationID)
                {
                    F = "( ( " + qPrime.timedDesign.Precondition + " && " + q.timedDesign.PostCondition + " ) && " + E.T[k].Fxy + " )";
                    E.T[k].Mark = true;

                    if (Runz3solver(ConvertTimedDesignToSMT(I, F, IEDataType)) == "sat")
                    {
                        rPrimeList temp = new rPrimeList(E.T[k].StateTo, F);
                        rprimeList.Add(temp);
                    }
                }
            }

            return rprimeList;
        }

        private void mark(List<PlugableEI> f, PlugableEI current)
        {
            current.Marked = true;
        }

        #endregion Pluggable and Refinement Check

        //----------------------------------------------------------------------------------------

        #region Drawing

        public void Automata2Graphic(List<PlugableEI> EI, GViewer gV)
        {
            var graph = new Graph();
            if (EI != null)
            {
                foreach (PlugableEI p in EI)
                {
                    graph.AddEdge(p.q.LocationID, p.qPrime.LocationID);
                }

                graph.CreateGeometryGraph();
                foreach (Node node in graph.Nodes)
                    node.GeometryNode.BoundaryCurve = CreateLabelAndBoundary(node);

                foreach (var edge in graph.Edges)
                {
                    if (edge.Label != null)
                    {
                        var geomEdge = edge.GeometryEdge;
                        double width;
                        double height;

                        StringMeasure.MeasureWithFont(edge.LabelText,
                                                     new Font(edge.Label.FontName, (float)edge.Label.FontSize), out width, out height);

                        edge.Label.GeometryLabel = geomEdge.Label = new Label(width, height, geomEdge);
                    }
                }
                var geomGraph = graph.GeometryGraph;

                var geomGraphComponents = GraphConnectedComponents.CreateComponents(geomGraph.Nodes, geomGraph.Edges);
                var settings = new SugiyamaLayoutSettings();

                foreach (var subgraph in geomGraphComponents)
                {
                    var layout = new LayeredLayout(subgraph, settings);
                    subgraph.Margins = settings.NodeSeparation / 2;
                    layout.Run();
                }

                Microsoft.Msagl.Layout.MDS.MdsGraphLayout.PackGraphs(geomGraphComponents, settings);

                geomGraph.UpdateBoundingBox();
                gV.Size = new System.Drawing.Size(400, 300);
                gV.NeedToCalculateLayout = false;
                gV.Dock = DockStyle.Fill;
                gV.Graph = graph;
            }
            else
                MessageBox.Show("The automata description is not correct. Please, retype in Editor window.", "Missing automata description", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //----------------------------------------------------------------
        public void Automata2Graphic(List<Automata> A, GViewer gV)
        {
            var graph = new Graph();
            if (A != null)
            {
                foreach (Automata a in A)
                {
                    foreach (ITransitions t in a.T)
                    {
                        graph.AddEdge(t.StateFrom.LocationID, t.StateTo.LocationID).LabelText = t.Fxy;
                    }
                }
                graph.CreateGeometryGraph();
                foreach (Node node in graph.Nodes)
                    node.GeometryNode.BoundaryCurve = CreateLabelAndBoundary(node);

                foreach (var edge in graph.Edges)
                {
                    if (edge.Label != null)
                    {
                        var geomEdge = edge.GeometryEdge;
                        double width;
                        double height;

                        StringMeasure.MeasureWithFont(edge.LabelText,
                                                     new Font(edge.Label.FontName, (float)edge.Label.FontSize), out width, out height);

                        edge.Label.GeometryLabel = geomEdge.Label = new Label(width, height, geomEdge);
                    }
                }
                var geomGraph = graph.GeometryGraph;

                var geomGraphComponents = GraphConnectedComponents.CreateComponents(geomGraph.Nodes, geomGraph.Edges);
                var settings = new SugiyamaLayoutSettings();

                foreach (var subgraph in geomGraphComponents)
                {
                    var layout = new LayeredLayout(subgraph, settings);
                    subgraph.Margins = settings.NodeSeparation / 2;
                    layout.Run();
                }

                Microsoft.Msagl.Layout.MDS.MdsGraphLayout.PackGraphs(geomGraphComponents, settings);

                geomGraph.UpdateBoundingBox();
                gV.NeedToCalculateLayout = false;
                gV.Graph = graph;
            }
            else
                MessageBox.Show("The automata description is not correct. Please, retype in Editor window.", "Missing automata description", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //-------------------------------------------------------------------------
        public TreeView Automatatree(List<Automata> a)
        {
            TreeView tree = new TreeView();
            //String str;
            if (a != null)
            {
                foreach (Automata item in a)
                {
                    TreeNode node = new TreeNode(item.AutomataID);

                    TreeNode nodeQ = new TreeNode("Q");

                    String s;
                    //Them cac location cau automata
                    foreach (ILocation l in item.Q)
                    {
                        s = "";
                        s = l.LocationID + " " + l.LocationStatus.ToString() + "---(" + l.timedDesign.Precondition + " => " + l.timedDesign.PostCondition + ")|" + l.timedDesign.Rho_t.ToString();
                        TreeNode t = new TreeNode(s);
                        nodeQ.Nodes.Add(t);
                    }
                    node.Nodes.Add(nodeQ);
                    //int i=0, j=0;

                    //Nhap cac cong input X
                   
                    TreeNode nodeX = new TreeNode("X");
                    foreach (Inputs.PortElement l in item.X.InputElements)
                    {
                        TreeNode t = new TreeNode(l.ID);
                        nodeX.Nodes.Add(t);
                    }
                    node.Nodes.Add(nodeX);

                    //Tao danh sach Output

                    TreeNode nodeY = new TreeNode("Y");
                    foreach (Outputs.PortElement l in item.Y.OutputElements)
                    {
                        TreeNode t = new TreeNode(l.ID);
                        nodeY.Nodes.Add(t);
                    }
                    node.Nodes.Add(nodeY);

                    //Add nut q0

                    TreeNode q0Node = new TreeNode("q0");
                    TreeNode q0Node1 = new TreeNode(item.q0.LocationID);
                    q0Node.Nodes.Add(q0Node1);
                    node.Nodes.Add(q0Node);


                    //Danh sach cac dich chuyen

                    TreeNode nodeT = new TreeNode("T");
                    foreach (ITransitions t in item.T)
                    {
                        s = "";
                        s = t.ID + " " + t.StateFrom.LocationName + "--->" + t.StateTo.LocationName + " " + t.Fxy;

                        nodeT.Nodes.Add(s);
                    }
                    node.Nodes.Add(nodeT);

                    tree.Nodes.Add(node);
                }
                return tree;
            }
            else
                return null;
        }

        //------------------------------------------------------------------------
        public void CopyChildren(TreeNode parent, TreeNode original)
        {
            TreeNode newTn;
            foreach (TreeNode tn in original.Nodes)
            {
                newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                parent.Nodes.Add(newTn);
                CopyChildren(newTn, tn);
            }
        }

        //--------------------------------------------------------------------------
        public void CopyTreeNodes(TreeView treeview1, TreeView treeview2)
        {
            TreeNode newTn;
            if (treeview1 != null && treeview2 != null)
            {
                foreach (TreeNode tn in treeview1.Nodes)
                {
                    newTn = new TreeNode(tn.Text, tn.ImageIndex, tn.SelectedImageIndex);
                    CopyChildren(newTn, tn);
                    treeview2.Nodes.Add(newTn);
                }
            }
        }

        //----------------------------------------------------------------
        private static ICurve CreateLabelAndBoundary(Node node)
        {
            node.Attr.Shape = Shape.TripleOctagon;
            node.Attr.LabelMargin *= 2;
            node.Label.FontSize = 11;
            double width;
            double height;
            StringMeasure.MeasureWithFont(node.Label.Text,
                                          new Font(node.Label.FontName, (float)node.Label.FontSize), out width, out height);
            node.Label.Width = width;
            node.Label.Height = height;
            int r = node.Attr.LabelMargin;
            return CurveFactory.CreateRectangleWithRoundedCorners(width + r * 2, height + r * 2, r, r, new Point());
        }

        #endregion Drawing

        //----------------------------------------------------------------------------------------

        #region Running Z3 Tool to check an smt2 files

        public string Runz3solver(String smt2Str)
        {
            String result = "";
            try
            {
                StreamWriter strWriter = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\temp.smt2");
                strWriter.Write(smt2Str);
                strWriter.Close();
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "z3.exe";
                process.StartInfo.Arguments = "/smt2 temp.smt2";
                //process.StartInfo.Arguments = "/smt2 " + Path.GetDirectoryName(Application.ExecutablePath) + "\\temp.smt2";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                //process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                result = output.Replace("\r\n", "");
                process.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());


            }
            return result;
        }

        #endregion Running Z3 Tool to check an smt2 files

        public void PrecheckedAutomata(List<Automata> A)
        {
            if (A.Count > 1)
            {
                if (A[0].X.InputElements.Count != A[1].X.InputElements.Count || A[0].Y.OutputElements.Count != A[1].Y.OutputElements.Count)
                {
                    MessageBox.Show("Interface is not compatible. Because of invalid input/ouput ports");
                }
            }
        }

        private bool isRefined(ILocation qPrime, ILocation q, String IEDataType)
        {
            String smtString = SmtGenerationfromTimeddesigns(qPrime.timedDesign, q.timedDesign, IEDataType);
            System.Diagnostics.Debug.Print(smtString);

            return (Runz3solver(smtString) == "sat");
        }

    }
}