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

public partial class web_Newton_Interpolation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected bool judgefunction()
    {
        if (v_Init_isEmpty.IsValid && v_IsNumber.IsValid)//函数正确并且输入其他数据也正确
            return true;
        else
            return false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        float[] inpoint = new float[200];
        PointF[] Pt = new PointF[100];
        string pointstr = tbInputPoint.Text;
       
        int num = 0;
        GetPointArray.GetPoint(pointstr, ref num, inpoint);
        if (num == 0 && judgefunction())
            Response.Write("<script>alert('请输入点集!');</script>");
        else if (num % 2 == 1)
            Response.Write("<script>alert('请输入成对的点!');</script>");
        else
        {
            int n = 0;
            for (int i = 1; i <= num; i += 2)
            {
                Pt[n].X = inpoint[i];
                Pt[n].Y = inpoint[i + 1];
                n++;
            }
            double[,] F = new double[n+1, n+1];
            for (int j = 0; j < n; ++j)
            {
                F[j,0] = Pt[j].Y;
            }
            for (int j = 1; j < n; ++j)
            {
                for (int i = j; i < n; ++i)
                {
                    F[i,j] = (F[i,j - 1] - F[i - 1,j - 1]) / (Pt[i].X - Pt[i - j].X);
                }
            }
            double sum = Pt[0].Y;
            double mul = 1.0;
            string mulstr="";
            string Funcstr =Pt[0].Y.ToString()+"  +  ";
            double x = Convert.ToDouble(tbX.Text.Trim());
            for (int i = 1; i < n; ++i)
            {
                mul *= (x - Pt[i - 1].X);
                sum+=mul*F[i,i];
                mulstr+="(x -"+Pt[i-1].X.ToString()+")";
                if (F[i, i] != 0)
                {
                    Funcstr += F[i, i].ToString() + mulstr;
                    if (i != n - 1&&F[i+1,i+1]!=0) Funcstr += "  +  ";
                }
            }

            tbResult.Text = sum.ToString();
            tbFuction.Text = "N(x) = " + Funcstr;
            Pt[n].X = (float)x;
            Pt[n++].Y = (float)sum;
            if (n > 0)
                DrawCoordinate.draw(Funcstr, n, Pt, false);
           
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
