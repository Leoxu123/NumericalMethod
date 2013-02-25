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

public partial class web_Lagrange_interpolation_showpaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDraw_Click(object sender, EventArgs e)
    {
        string Funcstr=(string)Application["Funcstr"];
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
        if(n>0)
            DrawCoordinate.draw(Funcstr, n, Pt, false);
    }
}
