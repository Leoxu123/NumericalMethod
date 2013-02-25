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

public partial class web_Newton_Interpolation_showpaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("       本模块演示牛顿插值。对一个有序的节点集 (ti, yi),"+"<br>");
        Response.Write("i = 1,…,n， j 阶牛顿基函数为πj (t) = (t − t1) · · · (t − tj−1)。"+"<br>");
        Response.Write("由于牛顿基矩阵的三角特性，牛顿插值可以随着插值节点的增多进行增量式计算。"+"<br>");
        Response.Write("最终的插值多项式与插值节点的选取顺序无关。)"+"<br>");
    }
    protected void btnDraw_Click(object sender, EventArgs e)
    {
        string Funcstr = (string)Application["Funcstr"];
        string pointstr = (string)Application["pointstr"];
        float[] inpoint = new float[200];
        PointF[] Pt = new PointF[100];
        int num = 0;
        GetPointArray.GetPoint(pointstr, ref num, inpoint);
        int n = 0;
        for (int i = 1; i <= num; i += 2)
        {
            Pt[n].X = inpoint[i];
            Pt[n].Y = inpoint[i + 1];
            n++;
        }
        if (n > 0)
            DrawCoordinate.draw(Funcstr, n, Pt, false);
    }
}
