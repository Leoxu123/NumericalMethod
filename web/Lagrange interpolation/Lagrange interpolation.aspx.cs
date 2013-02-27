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
using System.Drawing;

public partial class web_Lagrange_interpolation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected bool judgefunction()
    {
        if (v_Init_isEmpty.IsValid&&v_IsNumber.IsValid)//函数正确并且输入其他数据也正确
            return true;
        else
            return false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        float[]inpoint=new float[200];
        PointF[] Pt = new PointF[100];
        double[] L = new double[100];
        string pointstr = tbInputPoint.Text;
       
        int num = 0;
        GetPointArray.GetPoint(pointstr, ref num, inpoint);
        if (num == 0&&judgefunction())
            Response.Write("<script>alert('请输入点集!');</script>");
        else if (num%2==1)
            Response.Write("<script>alert('请输入成对的点!');</script>");
        else
        {
            int n = 0;
            for(int i=1;i<=num;i+=2)
            {
                Pt[n].X = inpoint[i];
                Pt[n].Y = inpoint[i + 1];
                n++;
            }
            double x = Convert.ToDouble(tbX.Text.Trim());
            double sum = 0.0;
            string Funcstr = "";
            
            for (int i = 0; i < n; ++i)
            {
                double fz = 1, fm = 1;
                string fzstr = "(", fmstr = "(";
                Funcstr += Pt[i].Y.ToString();
                for (int j = 0; j < n; ++j)
                {
                    if (i == j) continue;
                    fz *= (x - Pt[j].X);
                    fzstr += "(x -" + Pt[j].X.ToString() + ")";
                    fm *= (Pt[i].X - Pt[j].X);
                    fmstr += "(" + Pt[i].X.ToString() + " -" + Pt[j].X.ToString() + ")";
                }
                fzstr += ')'; fmstr += ')';
                sum += fz / fm * Pt[i].Y;
                Funcstr = Funcstr + fzstr + "/" + fmstr;
                if (i != n - 1) Funcstr += "  +  ";
            }
            tbResult.Text = sum.ToString();
            tbFuction.Text =  "P(x) = "+Funcstr;
            Pt[n].X = (float)x;
            Pt[n++].Y = (float)sum;

            if (n > 0)
                    DrawCoordinate.draw(Funcstr, n, Pt,false);
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbInputPoint.Text = "";
        tbResult.Text = "";
        tbX.Text = "";
        tbFuction.Text = "";
    }
}
