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

/// <summary>
///allfunction 的摘要说明
/// </summary>
public class allfunction
{
    public allfunction()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    public static double[] computeJacobi(double[,] a, double[] b, double[] x, int n)
    {
        double[] y = new double[n + 1];
        for (int i = 1; i <= n; i++)
        {
            double total = 0.0;
            for (int j = 1; j <= n; j++)
            {
                total += a[i,j] * x[j];
            }
            total -= a[i,i] * x[i];
            y[i] = (b[i] - total) / a[i,i];
        }
        return y;
    }
    public static bool meetDemand(double[] x, double[] y, int n, double eps)//判断迭代的中间结果是否满足精度
    {
        for (int i = 1; i <= n; i++)
        {
            if (Math.Abs(x[i] - y[i]) > eps) return false;
        }
        return true;
    }
    public static double[] computeGauss(double[,] a, double[] b, double[] x, int n)
    {
        double[] y = new double[n + 1];
        for (int i = 1; i <= n; i++)
        {
            double total = 0.0;
            for (int j = 1; j <= i - 1; j++)
            {
                total += a[i,j] * y[j];
            }
            for (int j = i + 1; j <= n; j++)
            {
                total += a[i,j] * x[j];
            }
            y[i] = (b[i] - total) / a[i,i];
        }
        return y;
    }
    public static double[] computeSOR(double[,] a, double[] b, double[] x, int n, double w)
    {
        double[] y = new double[n + 1];
        for (int i = 1; i <= n; i++)
        {
            double total = 0.0;
            for (int j = 1; j <= i - 1; j++)
            {
                total += a[i,j] * y[j];
            }
            for (int j = i + 1; j <= n; j++)
            {
                total += a[i,j] * x[j];
            }
            y[i] = (1-w)*x[i]+(b[i] - total)*w / a[i,i];
        }
        return y;
    }
    public static string produceEquation(int num)//在文本框中产生表达式
    {
        string s = "";
        for (int i = 1; i <= num; i++)
        {
            s += "【" + i.ToString() + "】";
            s += "()X1";
            for (int j = 2; j <= num; j++)
            {
                s += " + ()X" + j.ToString();
            }
            s += " = ()\r\n";
        }
        return s;
    }

    public static bool getdata(string s, ref int i, double[,] a, double[] b, int p, int q, int choice)//此函数用于提取一对括号中的数据
    {//i 代表指向的位置 ,a[p][q]=data,choice==1 给a赋值  ==0 给b赋值
        string tmp="";
        while (i<s.Length && s[i] != '(')//扫描进了括号
            i++;
        if (i >= s.Length) { a[0, 0] = 4; return false; }
        while (i<s.Length && s[++i] != ')' )
            tmp += s[i];
        if (i>=s.Length) { a[0, 0] = 4; return false; }
        tmp = tmp.Trim();//去除首尾的空格
        if (tmp.Length == 0)
        {
            if (choice==1) a[p, q] = 0;
            else b[p] = 0;
            return true;
        }
        //处理tmp
        int h=0;
        if(tmp[0]=='-')h++;
        for(;h<tmp.Length;h++)
            if(!((tmp[h]>='0'&&tmp[h]<='9')||tmp[h]=='.'))
            {
                a[0,0]=4;
                return false;
            }
        double num = System.Double.Parse(tmp);
        if (choice==1)
            a[p, q] = num;
        else
            b[p] = num;
        return true;
    }

    public static double[,] getMatrix(string s,double[] b, int n)//s是文本框的所有函数，n是函数的个数
    {//【1】()X1 + ()X2 + ()X3 + ()X4 = ()
        double [,]a=new double [n+1,n+1];
        int tmp,num=0;
        for(int i=0;i<=n;i++)
            a[i,0]=0;
        for (int i = 0; i < s.Length; )
        {
            if (s[i++] == '【')
            {
                tmp = i - 1;
                num++;
                while (s[i++] != '】')
                {
                    if (i - tmp > 2)//【】之间元素长度不会大于2，最大为10
                    {
                        a[0, 0] = 1;//将a[0][0]设为错误标志位，0表示正常，1代表【】不对应，2代表或 3代表方程数缺少 4代表数字错误或（）不对应（）丢失
                        return a;
                    }
                }
                //提取括号中的数据
                for (int j = 1; j <= n; j++)
                {
                    if(!getdata(s, ref i,a,b, num, j,1))//出现错误直接返回让用户检查并修改
                        return a;
                }
                if(!getdata(s, ref i, a, b, num, 0, 0))
                    return a;
            }
        }
        if (num < n) a[0, 0] = 3;
        return a;
    }
    //以下是高斯消去法的函数
    public static void elimination(double[,] a, int n, int k)//消元过程,第k次行变换,a是增广矩阵
    {
        //这里直接通过对增广矩阵进行变换
        for (int i = k + 1; i <= n; i++)//选择行
        {
            double l = a[i, k] / a[k, k];
            for (int j = k; j <= n+1; j++)
                a[i, j] = a[i, j] - a[k, j] * l;
        }
    }
    public static string tranToString(double[,] a, int n)//将矩阵转换为字符串
    {
        int max = 0;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n + 1; j++)
                if (a[i, j].ToString().Length > max)
                    max = a[i, j].ToString().Length;
        }
        string s = "";
        int dif;
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n + 1; j++)
            {
                s += a[i, j].ToString() + " ";
                dif = max - a[i, j].ToString().Length;
                while ((dif--)>0)
                    s += " ";
            }
            s += "\r\n";
        }
        return s;
    }
    public static void backSubstitution(double[,] a, double[] x, int n)//回代求x[]
    {
        double sum;
        for (int k = n; k >= 1; k--)
        {
            sum = 0;
            for (int i = k + 1; i <= n; i++)
                sum += a[k, i] * x[i];
            x[k] = (a[k,n+1] - sum) / a[k, k];
        }
    }

    public static void swapRow(double[,] a, int n, int p, int q)//交换增广矩阵a的第p和q行
    {
        double tmp;
        for (int i = 1; i <= n+1; i++)
        {
            tmp = a[p, i];
            a[p, i] = a[q, i];
            a[q, i] = tmp;
        }
    }

    //以下四个函数是跟判断系数矩阵是否合法 有关
    public static double getValueMatrix(double[,] b, int n)//消元过程并计算行列式的值
    {
        
        for (int k = 1; k < n; k++)
        {
            for (int i = k + 1; i <= n; i++)
            {
                double l = b[i, k] / b[k, k];
                for(int j=k;j<=n;j++)
                    b[i, j] = b[i, j] - b[k, j] * l;
            }
        }
        double mul = 1.0;
        for (int i = 1; i <= n; i++)
        {
            mul *= b[i, i];
        }
        return mul;
    }

    public static bool isNonsingular(double[,] a, int n)//判断系 数矩阵是否为奇异矩阵
    {
        double sum = getValueMatrix(a, n);
        double mineps=0.001;
        if (Math.Abs(sum) < mineps)//行列式值为零
            return false;
        return true;
    }

    public static bool judgeDiagonal(double[,] a, int n)//判断对角线是否都为零
    {
        for (int i = 1; i <= n; i++)
            if (a[i, i] == 0) return false;
        return true;
    }

    public static bool judgeMatrix(double[,] a, int n)//判断输入的系数矩阵是否合法
    {
        double[,] b = new double[n + 1, n + 1];//必须重新定义
        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= n; j++)
                b[i, j] = a[i, j];
                if (judgeDiagonal(b, n) && isNonsingular(b, n))
                    return true;
        return false;
    }
}
