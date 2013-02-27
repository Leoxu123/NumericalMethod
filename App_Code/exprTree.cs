using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public class exprTree
{
    public enum Token_value
    {
        NAME, NUMBER, END,
        PLUS = '+', MINUS = '-', MUL = '*',
        DIV = '/', PRINT = ';', ASSIGN = '=',
        LP = '(', RP = ')', EXPO = '^',
        MOD = '%', SIN = -1, COS = -2,
        TAN = -3, LN = -4
    }
    public static string str = new string(new char[101]);
    public static int id;
    public const double EPS = 1e-5;
    public static Token_value curr_tok = Token_value.PRINT;
    public static double number_value;
    public static string string_value;
    public static System.Collections.Generic.Dictionary<string, double> table = new Dictionary<string, double>();
    public static int no_of_errors;
    public static string error_string;
    public static double ans;

    public static void init(string s, double x)
    {
        table["pi"] = 3.14159265;
        table["e"] = 2.71828;
        table["x"] = x;
        id = 0;
        no_of_errors = 0;
        str = s;
        error_string = "";
    }

    public static double expr(bool get)
    {
        double left = term(get);
        for (; ; )
            switch (curr_tok)
            {
                case Token_value.PLUS:
                    left += term(true);
                    break;
                case Token_value.MINUS:
                    left -= term(true);
                    break;
                default:
                    return left;
            }
    }


    public static double error(string s)
    {
        no_of_errors++;
        error_string += s;
        s += "  ";
        //error_string += '\n';
        return 1;
    }

    public static void To_lower(string s)
    {
        for (int i = 0; i < s.Length; ++i)
            char.ToLower(s[i]);
    }

    public static double get_num()
    {
        double sum = 0;
        int p = -1;
        while (id < str.Length && (char.IsDigit(str[id]) || str[id] == '.'))
        {
            if (str[id] == '.')
            {
                p = id;
                id++;
                continue;
            }
            sum = sum * 10 + str[id] - '0';
            id++;
        }
        id--;
        if (p != -1)
            sum = sum / Math.Pow(10, (id - p));
        return sum;
    }
    public static Token_value get_token()
    {
        char ch;
        while (id < str.Length && (str[id] != '\n' && char.IsWhiteSpace(str[id])))
        {
            id++;
        }
        if (id == str.Length)
            return curr_tok = Token_value.END;
        ch = str[id];
        switch (ch)
        {
            case '\n':
                return curr_tok = Token_value.PRINT;
            case ';':
            case '*':
            case '/':
            case '+':
            case '-':
            case '(':
            case ')':
            case '=':
            case '%':
            case '^':
                id++;
                return curr_tok = (Token_value)ch;
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
            case '.':
                number_value = get_num();
                id++;
                return curr_tok = Token_value.NUMBER;

            default:
                if (Char.IsLetter(ch))
                {
                    string_value = "";
                    string_value += str[id++];
                    while (id != str.Length && Char.IsLetter(str[id]))
                    {
                        string_value += str[id];
                        id++;
                    }
                    string temp = string_value.ToLower();
                    if (temp == "sin")
                        return curr_tok = Token_value.SIN;
                    if (temp == "cos")
                        return curr_tok = Token_value.COS;
                    if (temp == "tan")
                        return curr_tok = Token_value.TAN;
                    if (temp == "ln")
                        return curr_tok = Token_value.LN;
                    return curr_tok = Token_value.NAME;
                }
                error("bad token: ");
                return curr_tok = Token_value.PRINT;
        }
    }
    public static double prim(bool get)
    {
        if (get)
            get_token();
        switch (curr_tok)
        {
            case Token_value.NUMBER:
                {
                    double v = number_value;
                    get_token();
                    return v;
                }
            case Token_value.NAME:
                {

                    double v = table[string_value.ToLower()];
                    if (get_token() == Token_value.ASSIGN)
                        v = expr(true);
                    return v;
                }
            case Token_value.MINUS:
                return -prim(true);
            case Token_value.SIN:
                return Math.Sin(prim(true));
            case Token_value.COS:
                return Math.Cos(prim(true));
            case Token_value.TAN:
                return Math.Tan(prim(true));
            case Token_value.LN:
                return Math.Log(prim(true));
            case Token_value.LP:
                {
                    double e = expr(true);
                    if (curr_tok != Token_value.RP)
                        return error(") expected");
                    get_token();
                    return e;
                }
            default:
                return error("primary expected");
        }
    }

    public static double next_term(bool get)
    {
        double left = prim(get);
        switch (curr_tok)
        {
            case Token_value.EXPO:
                return Math.Pow(left, prim(true));
            default:
                return left;
        }
    }
    public static double term(bool get)
    {
        double left = next_term(get);
        for (; ; )
            switch (curr_tok)
            {
                case Token_value.MUL:
                    left *= next_term(true);
                    break;
                case Token_value.DIV:
                    double d = next_term(true);
                    if (Convert.ToBoolean(d))       //转化为bool型
                    {
                        left /= d;
                        break;
                    }
                    return error("divide by 0");
                case Token_value.MOD:
                    d = next_term(true);
                    if (Convert.ToBoolean(d))
                    {
                        if (Math.Abs((int)d - d) < EPS && Math.Abs((int)left - left) < EPS)
                            left = (int)left % (int)d;
                        else
                            return error("Mod operation only apply to integers");
                    }
                    break;

                default:
                    return left;
            }
    }
    public static void modify(ref string s)
    {
        for (int i = 0; i < s.Length - 1; ++i)
        {
            if ((char.IsDigit(s[i]) && (char.IsLetter(s[i + 1]) || s[i + 1] == '(')) ||
                   (s[i] == ')' && char.IsDigit(s[i + 1])) || s[i] == ')' && s[i + 1] == '(')
            {
                string s2 = s.Insert(i + 1, "*");
                s = s2;
                i += 2;
            }

        }
    }
    public static string check(ref string s, double x)
    {
        modify(ref s);
        init(s, x);
        get_token();
        ans = expr(false);
        if (no_of_errors > 0)
            return error_string;
        else return "";
    }
    public static double run(ref string s, double x)
    {
        modify(ref s);
        init(s, x);
        get_token();
        ans = expr(false);
        return ans;
    }

}
