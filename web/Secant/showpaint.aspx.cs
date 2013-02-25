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

public partial class web_Secant_showpaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
    }
    protected void Draw_Click(object sender, EventArgs e)
    {

        Application.Lock();
        string expression = (string)Application["expression"];
        Application.UnLock();
        Application.Lock();
        string init_eps = (string)Application["init_eps"];
        Application.UnLock();
        Application.Lock();
        string init_value = (string)Application["init_value"];
        Application.UnLock();
        Application.Lock();
        string init_value2 = (string)Application["init_value2"];
        Application.UnLock();

        if (expression.Length > 0 && init_eps.Length > 0 && init_value.Length > 0 && init_value2.Length > 0)
        {
            const double MAX = 99999999;
            double x0 = Convert.ToDouble(init_value);
            double x1 = Convert.ToDouble(init_value2);
            double eps = Convert.ToDouble(init_eps);
            PointF[] Iterative_Point = new PointF[100];

            double y0 = exprTree.run(ref expression, x0);
            int pnum = 0;
            Iterative_Point[pnum].X = (float)x0;
            Iterative_Point[pnum].Y = (float)y0;
            pnum++;
            int tms = 1;
            bool isConvergent = true;
            double y1;
            while (Math.Abs(x1 - x0) > eps && tms < 50)
            {
                double temp_x = x0;
                x0 = x1;
                y1 = exprTree.run(ref expression, x1);
                Iterative_Point[pnum].X = (float)x1;
                Iterative_Point[pnum].Y = (float)y1;
                if (Math.Abs(y1) > MAX)
                {
                    isConvergent = false;
                    break;
                }
                pnum++;
                x1 = x1 - y1 * (x1 - temp_x) / (y1 - y0);
                y0 = y1;

            }
            y1 = exprTree.run(ref expression, x1);
            Iterative_Point[pnum].X = (float)x1;
            Iterative_Point[pnum].Y = (float)y1;
            pnum++;
            if (tms < 50 && isConvergent)
                DrawCoordinate.draw(expression,  pnum, Iterative_Point,true);


        }
    }
}
