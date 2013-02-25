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

public partial class web_bsearch_bsearch_showpaint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Draw_Click(object sender, EventArgs e)
    {
        if((int)Application["canDraw"] ==0)
            Response.Write("<script>alert('不收敛，无法画图！');</script>");
        else
        {
            Application.Lock();
            string expression = (string)Application["expression"];
            Application.UnLock();
            Application.Lock();
            string init_a = (string)Application["init_a"];
            Application.UnLock();
            Application.Lock();
            string init_b = (string)Application["init_b"];
            Application.UnLock();
         
            Application.Lock();
            string init_count = (string)Application["init_count"];
            Application.UnLock();

            double a = Convert.ToDouble(init_a);
            double b = Convert.ToDouble(init_b);
            int iter_count = Convert.ToInt32(init_count);
            PointF[] Iterative_Point = new PointF[100];

            double midx = 0.0, midy = 0.0;
            for (int i = 0; i < iter_count; i++)
            {
                midx = (a + b) / 2.0;
                midy = exprTree.run(ref expression, midx);
                Iterative_Point[i].X = (float)midx;
                Iterative_Point[i].Y = (float)midy;
                if (exprTree.run(ref expression, a) * midy < 0)
                    b = midx;
                else
                    a = midx;
            }
            DrawCoordinate.draw(expression, iter_count, Iterative_Point, true);
        }
    }
}
