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

public partial class web_Iterative_showpaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Draw_Click(object sender, EventArgs e)
    {
        const double MAX = 99999999;
        Application.Lock();
        string expression = (string)Application["expression"];
        Application.UnLock();
        Application.Lock();
        string init_eps = (string)Application["init_eps"];
        Application.UnLock();
        Application.Lock();
        string init_value = (string)Application["init_value"];
        Application.UnLock();

        double x0 = Convert.ToDouble(init_value);
        double eps = Convert.ToDouble(init_eps);
        PointF[] Iterative_Point = new PointF[100];
        double x1 = exprTree.run(ref expression, x0);
        int pnum = 0;
        int tms = 1;
        bool isConvergent = true;
        while (Math.Abs(x1 - x0) > eps && tms < 50)
        {
            double tmpx = x1;
            x1 = exprTree.run(ref expression, x1);
            Iterative_Point[pnum].X = (float)x0;
            Iterative_Point[pnum].Y = (float)x1;
            if (Math.Abs(x1) > MAX)
            {
                isConvergent = false;
                break;
            }
            pnum++;
            x0 = tmpx;
            tms++;
        }
        if (tms < 50 && isConvergent)
            DrawCoordinate.draw(expression,  pnum, Iterative_Point,true);
    }
}
