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

public partial class web_Aitken_Method : System.Web.UI.Page
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
        Application["expression"] = Application["init_value"] = Application["init_eps"] = "";
        const double MAX = 99999999;
        string expression = tbExpr.Text.Trim();
        Application["expression"] = expression;
        if (judgefunction(expression))
        {
            string init_eps = tbPrecision.Text.Trim();
            Application["init_eps"] = init_eps;
            string init_value = tbInit.Text.Trim();
            Application["init_value"] = init_value;
            List<Output> ans = new List<Output>();
            double x0 = Convert.ToDouble(init_value);
            double eps = Convert.ToDouble(init_eps);
            int kk = 0;
            PointF[] Iterative_Point = new PointF[100];
            Output a = new Output { k = kk++, x = x0 };
            ans.Add(a);
            double x1 = exprTree.run(ref expression, x0);
            double _x1 = exprTree.run(ref expression,x1);
            int pnum = 0;
            Iterative_Point[pnum].X = (float)x0;
            Iterative_Point[pnum++].Y = (float)x1;
            int tms = 1;
            bool isConvergent = true;
            while (Math.Abs(x1 - x0) > eps && tms < 50)
            {
                x0 = _x1-(_x1-x1)*(_x1-x1)/(_x1-2*x1+x0);
                x1 = exprTree.run(ref expression, x0);
                _x1 = exprTree.run(ref expression,x1);
                if (Math.Abs(x1) > MAX)
                {
                    isConvergent = false;
                    break;
                }
                tms++;
                Output t = new Output { k = kk++, x = x0 };
                Iterative_Point[pnum].X = (float)x0;
                Iterative_Point[pnum].Y = (float)x1;
                pnum++;
                ans.Add(t);
            }
            if (tms >= 50 || !isConvergent)
                Response.Write("<script>alert('埃特金迭代法不收敛');</script>");
            GD_Output.DataSource = ans;
            GD_Output.DataBind();
          

        }

    }



    public class Output
    {
        public int k { get; set; }
        public double x { get; set; }
        // public double y { get; set; }
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
