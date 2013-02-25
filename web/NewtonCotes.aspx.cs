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

public partial class web_NewtonCotes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected bool judgefunction(string s)
    {
        if (is_Function.check(s) && v_Func_isEmpty.IsValid && v_LowerBound_IsEmpty.IsValid
            && v_LowerBound_IsNumber.IsValid && v_UpperBound_IsEmpty.IsValid
            && v_UpperBound_IsNumber.IsValid && cv_GE.IsValid)//函数正确并且输入其他数据也正确
            return true;
        else
            return false;
    }
    protected void tbCalc_Click(object sender, EventArgs e)
    {
        string Funcstr = tbExpr.Text.Trim();
        if(judgefunction(Funcstr))
        {
            double a = Convert.ToDouble(tbLowerBound.Text.Trim());
            double b = Convert.ToDouble(tbUpperBound.Text.Trim());
            int selectIndex = IntegrationType.SelectedIndex;
            double ans;
            double[] X=new double[5]{a,a+(b-a)/4,(a+b)/2,a+3*(b-1)/4,b};
            double[] F1 = new double[2];
            double[] F2 = new double[3];
            double[] F3 = new double[5];
            F1[0] = F2[0] = F3[0]=exprTree.run(ref Funcstr, X[0]);
            F1[1] = F2[2] = F3[4]=exprTree.run(ref Funcstr, X[4]);
            F2[1] = F3[2] = exprTree.run(ref Funcstr, X[2]);
            F3[1] = exprTree.run(ref Funcstr, X[1]);
            F3[3] = exprTree.run(ref Funcstr, X[3]);
            if (selectIndex==0)
            {
                ans = (b - a) / 2 * (F1[0] + F1[1]);
            }
            else if(selectIndex==1)
            {
                ans = (b - a) / 6 * (F2[0] + 4*F2[1] + F2[2]);
            }
            else
            {
                ans = (b - a) / 90 * (7 * F3[0] + 32 * F3[1] + 12 * F3[2] + 32 * F3[3] + 7 * F3[4]);
            }

            tbResult.Text = ans.ToString();
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        tbExpr.Text = "";
        tbResult.Text = "";
        tbLowerBound.Text = "";
        tbUpperBound.Text = "";
    }
}
