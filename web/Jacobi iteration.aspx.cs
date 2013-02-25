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
using System.Collections.Generic;

public partial class web_Jacobi_iteration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int num = Int32.Parse(DropDownList1.Text);
        string equ = allfunction.produceEquation(num);
        TextBox1.Text = equ;
        GridView1.Visible = true;
        List<Headtitle> ans = new List<Headtitle>();
        Headtitle init = new Headtitle() { k = 0, X1 = 0, X2 = 0, X3 = 0 };
        ans.Add(init);
        GridView1.DataSource = ans;
        GridView1.DataBind();

        string mylabeltxt = "（有效观测参数：无！）";
        mylabel.Text = mylabeltxt;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s1 = txt_eps.Text.Trim();
        double eps = System.Double.Parse(s1);
        if (eps > 1.0 || eps <= 0)
            Response.Write("<script>alert('请输入合法精度！');</script>");
        else
        {
            string s2 = txt_count.Text.Trim();
            int maxiter = System.Int32.Parse(s2);//获得最大迭代次数
            //获取矩阵
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
                Response.Write("<script>alert('系数矩阵不满足非奇异的性质或对角线不全为零，请重新输入!');</script>");
            else
            {
                List<Headtitle> ans = new List<Headtitle>();
                Headtitle init = new Headtitle() { k = 0, X1 = 0, X2 = 0, X3 = 0 };
                ans.Add(init);

                int count = 0;
                double[] x = new double[num + 1];
                for (int i = 0; i <= num; i++)
                    x[i] = 0;
                double[] y = new double[num + 1];
                y = x;
                do
                {
                    x = y;
                    y = allfunction.computeJacobi(a, b, x, num);
                    count++;
                    Headtitle midData = new Headtitle() { k = count, X1 = y[1], X2 = y[2], X3 = y[3] };
                    if (count > maxiter) { break; }
                    ans.Add(midData);
                } while (!allfunction.meetDemand(x, y, num, eps));
                if (allfunction.meetDemand(x, y, num, eps)) txt_ismeeteps.Text = " 是";
                else txt_ismeeteps.Text = " 否";
                txt_actaltcount.Text = count.ToString();
                GridView1.DataSource = ans;
                GridView1.DataBind();

                string mylabeltxt = "(有效观测参数：k、X1——X" + num.ToString() + ")";
                mylabel.Text = mylabeltxt;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string s = "1";
        DropDownList1.Text = s;
        TextBox1.Text = "";
        txt_eps.Text = "";
        txt_count.Text = "";
        GridView1.Visible = false;
        txt_actaltcount.Text = "";
        txt_ismeeteps.Text = "";
        mylabel.Text = "";
    }
}
