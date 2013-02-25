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
///is_function 的摘要说明
/// </summary>
public class is_Function
{
    //
    //TODO: 在此处添加构造函数逻辑
    //
    public static bool check(string s)//检测表达式是否是关于x的函数
    {
        int flag = 0;
        for (int i = 0; i < s.Length; i++)
            if (s[i] == 'x')
            {
                flag = 1;
                break;
            }
        if (flag==0)
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('请输入正确的函数');</script>");
            return false;
        }
        double x = 1.0; 
        string st = exprTree.check(ref s, x);
        if (st.Length > 0)
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + st + "');</script>");
            flag=0;
        }
        if (flag==1) return true;
        else
            return false;
    }
}
