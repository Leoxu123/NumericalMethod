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

public partial class web_Newton_s_Iterative_showpaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       Response.Write("本模块演示用牛顿法求解一维非线性方程f(x) = 0. 对于一个已知的近似解x" + "<br>");
       Response.Write("基于当前点处的局部线性化(一维空间的切线), 牛顿法计算x − f(x)⁄ f′(x)得到一个新的近似解.");
       Response.Write("这个过程重复进行，通常很快就能收敛." + "<br>");



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
        if (expression != "" && init_eps != "" && init_value!="")
        {
            double x0 = Convert.ToDouble(init_value);
            double eps = Convert.ToDouble(init_eps);
            Response.Write(expression + init_eps);

            PointF[] Iterative_Point = new PointF[100];
            int pnum = 0;
            double y0 = exprTree.run(ref expression, x0);
            Iterative_Point[pnum].X = (float)x0;
            Iterative_Point[pnum].Y = (float)y0;
            pnum++;
            double x1 = x0 + 100;

            int tms = 0;
            bool isConvergent = true;
            while (Math.Abs(x1 - x0) > eps && tms < 50)
            {
                x1 = x0;

                if (Math.Abs(y0) > MAX)
                {
                    isConvergent = false;
                    break;
                }


                x0 = x0 - y0 / GetDerivate.getans(expression, x0);
                y0 = exprTree.run(ref expression, x0);
                Iterative_Point[pnum].X = (float)x0;
                Iterative_Point[pnum].Y = (float)y0;
                pnum++;
                tms++;
            }

            if (tms < 50 && isConvergent)
                DrawCoordinate.draw(expression, pnum, Iterative_Point, true);
        }
        Application["expression"] = Application["init_value"] = Application["init_eps"] = "";
    }
}
   
