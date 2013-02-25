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

public partial class web_bsearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Output> list = new List<Output>();
        Output tmp = new Output() { k = 0, a = 0, b = 0, x = 0, Fx = '+' };
        list.Add(tmp);
        GridView1.DataSource = list;
        GridView1.DataBind();
    }
   
    protected bool judgefunction(string s)
    {
        if (is_Function.check(s) && RequiredFieldValidator3.IsValid && RequiredFieldValidator1.IsValid
            && RegularExpressionValidator1.IsValid && RegularExpressionValidator2.IsValid
            && RegularExpressionValidator3.IsValid && CompareValidator1.IsValid)//函数正确并且输入其他数据也正确
            return true;
        else
            return false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = txt_function.Text.Trim();//获取输入的函数

        if (judgefunction(s))
        {
            double a, b;
            a = System.Double.Parse(txt_a.Text.Trim());
            b = System.Double.Parse(txt_b.Text.Trim());
            Application["expression"] = s;
            Application["init_a"] = txt_a.Text.Trim();
            Application["init_b"] = txt_b.Text.Trim();
            //Application["init_eps"] = txt_precision.Text.Trim() ;
           
            int myCount=Paint.Paint_Fill(s, a, b, txt_precision, iteration_count, GridView1,TextBox1);
            Application["init_count"] = myCount.ToString();
            if (TextBox1.Text == "" || TextBox1.Text == "是")
                Application["canDraw"] = 1;
            else
                Application["canDraw"] = 0;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        txt_function.Text = "";
        txt_a.Text = "";
        txt_b.Text = "";
        txt_precision.Text = "";
        iteration_count.Text = "";
        TextBox1.Text = "";
    }
}
