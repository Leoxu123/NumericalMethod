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
using System.Text.RegularExpressions;
using System.Xml.Linq;

/// <summary>
///Is_Number 的摘要说明
/// </summary>
public class Is_Number
{
	public static bool judge(string s)
    {
        int i;
        for (i = 0; i < s.Length; ++i)
            if (!(char.IsDigit(s[i]) || (s[i] == '.' && i != 0 && i != s.Length)))
                break;
        if (i == s.Length) return true;
        else return false;
    }
}
