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
using System.Drawing;

public partial class web_Iterative_Method : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ViewState["count"] = 0;
        }
      
    }
    protected bool judgefunction(string s)
    {
        if (is_Function.check(s) && v_IsFunctionEmpty.IsValid && v_Init_IsEmpty.IsValid
            && v_Init_IsNumber.IsValid && v_Precision_IsEmpty.IsValid
             && v_Precision_IsNumber.IsValid)//函数正确并且输入其他数据也正确
            return true;
        else
            return false;
    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        ViewState["count"] = Convert.ToInt32(ViewState["count"]) + 1;
        const double MAX=99999999;
        string expression = tbExpr.Text.Trim();
       
        if (judgefunction(expression))
        {
            string init_eps = tbPrecision.Text.Trim();
           
            string init_value = tbInit.Text.Trim();
          

            List<Output> ans = new List<Output>();
            double x0 = Convert.ToDouble(init_value);
            double eps = Convert.ToDouble(init_eps);
            int kk = 0;
            PointF[] Iterative_Point = new PointF[100];
            int pnum = 0;
            Output a = new Output { Iterative_Times = kk++, Value_X = x0 };
            ans.Add(a);
            
            double x1 = exprTree.run(ref expression, x0);
            Output a0 = new Output { Iterative_Times = kk++, Value_X = x1 };
            ans.Add(a0);
            
            int tms = 1;
            bool isConvergent = true;
            while (Math.Abs(x1 - x0) > eps&&tms<50)
            {
                double tmpx = x1; 
                Iterative_Point[pnum].X = (float)x0;
                Iterative_Point[pnum].Y = (float)x1;
                x1 = exprTree.run(ref expression, x1);
                
                if (Math.Abs(x1) > MAX)
                {
                    isConvergent = false;
                    break;
                }
                pnum++;
                x0 = tmpx;
                tms++;
                Output t = new Output { Iterative_Times = kk++, Value_X = x1 };
                ans.Add(t);
            }
            Iterative_Point[pnum].X = (float)x0;
            Iterative_Point[pnum++].Y = (float)x1;

            Iterative_Point[pnum].X = (float)x1;
            Iterative_Point[pnum++].Y = (float)exprTree.run(ref expression, x1);

            if (tms >= 50||!isConvergent)
                Response.Write("<script>alert('迭代法不收敛');</script>");
            GD_Output.DataSource = ans;
            GD_Output.DataBind();
            if (tms < 50 && isConvergent)
                DrawCoordinate.draw(expression, pnum, Iterative_Point, true);

        }

    }


    public class Output
    {
        public int Iterative_Times { get; set; }
        public double Value_X { get; set; }
        //public double y { get; set; }
    }

    protected void tbExpr_TextChanged(object sender, EventArgs e)
    {
        ViewState["count"] = 0;
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbExpr.Text = "";
        tbInit.Text = "";
        tbPrecision.Text = "";
    }
}
