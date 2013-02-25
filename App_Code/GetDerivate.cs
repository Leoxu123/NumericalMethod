using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
///GetDerivate 的摘要说明
/// </summary>
public class GetDerivate
{
    const double PRECISION_D = 0.00001;
	public static double getans(string s,double x)
    {
        double f1 = exprTree.run(ref s, x - PRECISION_D / 2.0);
        double f2 = exprTree.run(ref s, x + PRECISION_D / 2.0);
        double ans = (f2 - f1) / PRECISION_D;
        return ans;

    }
}
