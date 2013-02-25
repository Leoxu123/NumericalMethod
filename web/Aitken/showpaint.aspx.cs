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

public partial class web_Aitken_showpaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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

        if (expression != "" && init_eps != "" && init_value != "")
        {
            double x0 = Convert.ToDouble(init_value);
            double eps = Convert.ToDouble(init_eps);

            PointF[] Iterative_Point = new PointF[100];

            double x1 = exprTree.run(ref expression, x0);
            double _x1 = exprTree.run(ref expression, x1);
            int pnum = 0;
            Iterative_Point[pnum].X = (float)x0;
            Iterative_Point[pnum++].Y = (float)x1;
            int tms = 1;
            bool isConvergent = true;
            while (Math.Abs(x1 - x0) > eps && tms < 50)
            {
                x0 = _x1 - (_x1 - x1) * (_x1 - x1) / (_x1 - 2 * x1 + x0);
                x1 = exprTree.run(ref expression, x0);
                _x1 = exprTree.run(ref expression, x1);
                if (Math.Abs(x1) > MAX)
                {
                    isConvergent = false;
                    break;
                }
                tms++;
                Iterative_Point[pnum].X = (float)x0;
                Iterative_Point[pnum].Y = (float)x1;
                pnum++;

            }
            if (tms < 50 && isConvergent)
                DrawCoordinate.draw(expression, pnum, Iterative_Point, true);
        }
        Application["expression"] = Application["init_value"] = Application["init_eps"] = "";
    }
}
