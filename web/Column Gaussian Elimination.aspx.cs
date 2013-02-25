using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
public partial class web_Column_Gaussian_Elimination : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int num = Int32.Parse(DropDownList1.Text);
        string equ = allfunction.produceEquation(num);
        TextBox1.Text = equ;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int num = Int32.Parse(DropDownList1.Text);
        double[,] a = new double[num + 1, num + 1];
        double[] b = new double[num + 1];
        string textMatrix = TextBox1.Text;
        a = allfunction.getMatrix(textMatrix, b, num);
        if (a[0, 0] == 4)
            Response.Write("<script>alert('系数错误或括号丢失！');</script>");
        else if (a[0, 0] == 1)
            Response.Write("<script>alert('【】不对应！');</script>");
        else if (a[0, 0] == 3)
            Response.Write("<script>alert('方程数缺少!');</script>");
        else if (!allfunction.judgeMatrix(a, num))
            Response.Write("<script>alert('系数矩阵不满足非奇异的性质或者对角线元素不全为零，请重新输入!');</script>");
        else
        {
            double[,] c = new double[num + 1, num + 2];//存放增广矩阵
            for (int i = 1; i <= num; i++)
                for (int j = 1; j <= num; j++)
                    c[i, j] = a[i, j];
            for (int i = 1; i <= num; i++)
                c[i, num + 1] = b[i];
            string result = "";
            result += "初始增广矩阵为：\r\n";
            result += allfunction.tranToString(c, num) + "\r\n";
            // 选主元和消元过程
            for (int k = 1; k < num; k++)
            {
                double maxMember = c[k, k];
                int row = k;
                for (int i = k + 1; i <= num; i++)
                {
                    if (c[i, k] > maxMember)
                    {
                        row = i;
                        maxMember = c[i, k];
                    }
                }
                result += "第 "+k.ToString()+" 次:\r\n";
                result += "选取主元为：" + maxMember.ToString() + "\r\n";
                if (row != k)//需要交换行
                {
                    result += "交换第 " + k.ToString() + " 行和第 " + row.ToString() + " 行\r\n行变换结果为：\r\n";
                    allfunction.swapRow(c, num, row, k);
                    result += allfunction.tranToString(c, num);
                }
                else
                {
                    result += "不需交换行！\r\n";
                }
                allfunction.elimination(c, num, k);//消元
                result += " 消元计算结果为：\r\n";
                result += allfunction.tranToString(c, num)+"\r\n";
            }
            result += "消元过程结束！\r\n";
            TextBox3.Text = result;
            //回代过程
            double []x=new double [num+1];
            allfunction.backSubstitution(c,x, num);
            result = "";
            for (int i = 1; i <= num; i++)
            {
                result += "x"+i.ToString() + "=";
                result += x[i].ToString()+"\r\n";
            }
            TextBox5.Text = result;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DropDownList1.Text = "1";
        TextBox1.Text = "";
        TextBox3.Text = "";
        TextBox5.Text = "";
    }
}
