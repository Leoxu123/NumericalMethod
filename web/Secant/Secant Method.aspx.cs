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

public partial class web_Secant_Method : System.Web.UI.Page
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
            && v_Init_IsNumber.IsValid && v_Init2_IsEmpty.IsValid
            && v_Init2_IsNumber.IsValid&&v_Precision_IsEmpty.IsValid
             && v_Precision_IsNumber.IsValid)
            return true;
        else
            return false;
    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        ViewState["count"] = Convert.ToInt32(ViewState["count"]) + 1;
        string expression = tbExpr.Text.Trim();
        

        if (judgefunction(expression))
        {
            string init_eps = tbPrecision.Text.Trim();
            Application["init_eps"] = init_eps;
            Application["expression"] = expression;
            string init_value = tbInit.Text.Trim();
            Application["init_value"] = init_value;
            string init_value2 = tbInit2.Text.Trim();
            Application["init_value2"] = init_value2;
            if (init_eps.Length == 0 || !Is_Number.judge(init_value))
                Response.Write("<script>alert('请输入合法精度');</script>");
            else
            {
                List<Output> ans = new List<Output>();
                const double MAX = 99999999;
                double x0 = Convert.ToDouble(init_value);
                double x1 = Convert.ToDouble(init_value2);
                double eps = Convert.ToDouble(init_eps);
                int kk = 0;
                PointF[] Iterative_Point = new PointF[100];
                Output a0 = new Output { k = kk++, x = x0 };
                ans.Add(a0);
                double y0 = exprTree.run(ref expression, x0);
                int pnum = 0;
                Iterative_Point[pnum].X = (float)x0;
                Iterative_Point[pnum].Y = (float)y0;
                pnum++;
                int tms = 1;
                bool isConvergent = true;
                while (Math.Abs(x1 - x0) > eps&&tms<50)
                {
                    double temp_x = x0;
                    x0 = x1;

                    double y1 = exprTree.run(ref expression, x1);
                    Iterative_Point[pnum].X = (float)x1;
                    Iterative_Point[pnum].Y = (float)y1;
                    if (Math.Abs(y1) > MAX)
                    {
                        isConvergent = false;
                        break;
                    }
                    Output t = new Output { k = kk++, x = x1 };
                    ans.Add(t);
                    pnum++;
                    x1 = x1 - y1*(x1 - temp_x)/(y1-y0);
                    y0 = y1;
                    
                }
                if (tms >= 50 || !isConvergent)
                    Response.Write("<script>alert('弦截法不收敛');</script>");
                GD_Output.DataSource = ans;
                GD_Output.DataBind();

                Response.Write("<script language=javascript>");
                Response.Write("parent.right.location.href='showpaint.aspx'");
                Response.Write("</script>");

            }

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
        tbInit2.Text = "";
        tbPrecision.Text = "";
    }
}
