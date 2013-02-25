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
///GetPointArray 的摘要说明
/// </summary>
public class GetPointArray
{
	public static void GetPoint(string pointstr,ref int num,float[]inpoint)
    {
        for (int i = 0; i < pointstr.Length; ++i)
        {

            if (char.IsDigit(pointstr[i]) || pointstr[i] == '-')
            {
                int j;
                bool positive = true;
                if (pointstr[i] == '-')
                {
                    i++;
                    positive = false;
                }
                string temp = "";
                for (j = i; j < pointstr.Length && (char.IsDigit(pointstr[j]) || pointstr[j] == '.'); j++)
                {
                    temp += pointstr[j];
                }
                if (positive)
                    inpoint[++num] = (float)Convert.ToDouble(temp);
                else inpoint[++num] = -(float)Convert.ToDouble(temp);
                i = j;

            }

        }
    }
}
