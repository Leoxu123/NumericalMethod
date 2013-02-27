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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
/// <summary>
///Paint 的摘要说明
/// </summary>
/// 

public class Paint
{
   public static int Paint_Fill(string s,double a,double b,TextBox txt_precision,DropDownList iteration_count,
       GridView GridView1,TextBox TextBox1)
    {
       double eps, midx, mid0, midy;
       int iterNum = 0;
       if (txt_precision.Text.Trim().Length > 0&&iteration_count.Text=="1")//按精度迭代
       {
           eps = System.Double.Parse(txt_precision.Text.Trim());

           List<Output> ans = new List<Output>();
           int kk = 0;
           midx = (a + b) / 2.0;
           midy = exprTree.run(ref s, midx);
           Output tmp2 = new Output() { k = ++kk, a = a, b = b, x = midx, Fx = '+' };
           if (midy < 0) tmp2.Fx = '-';
           ans.Add(tmp2);
           iterNum++;
           do
           {
               
               if (exprTree.run(ref s, a) * midy < 0)
                   b = midx;
               else a = midx;
               mid0 = midx;
               midx = (a + b) / 2.0;
               midy = exprTree.run(ref s, midx);
               Output tmp = new Output() { k = ++kk, a = a, b = b, x = midx, Fx = '+' };
               if (midy < 0) tmp.Fx = '-';
               ans.Add(tmp);
               iterNum++;
               if (iterNum > 50)
               {
                   System.Web.HttpContext.Current.Response.Write("<script>alert('无法满足精度,不收敛！');</script>");
                   break;
               }
               if (midy == 0.0)
               {
                   System.Web.HttpContext.Current.Response.Write("<script>alert('找到精确值！');</script>");
                   break;
               }
           } while (Math.Abs(midx - mid0) >= eps);
           GridView1.DataSource = ans;
           GridView1.DataBind();

           if (iterNum < 50) TextBox1.Text = "是";
           return iterNum;
       }
       else if (iteration_count.Text != "1" && txt_precision.Text.Trim().Length == 0)//按给定迭代次数进行迭代
       {
           int myCount = Int32.Parse(iteration_count.Text);
           List<Output> ans = new List<Output>();
           int kk = 0;
           for (int i = 0; i < myCount; i++)
           {
               iterNum++;
               midx = (a + b) / 2.0;
               midy = exprTree.run(ref s, midx);
               Output tmp = new Output() { k = ++kk, a = a, b = b, x = midx, Fx = '+' };
               if (midy < 0) tmp.Fx = '-';
               ans.Add(tmp);
               if (exprTree.run(ref s, a) * midy < 0)
                   b = midx;
               else a = midx;
               if (midy == 0.0)
               {
                   System.Web.HttpContext.Current.Response.Write("<script>alert('找到精确值！');</script>");
                   iterNum=i+1;
                   break;
               }
           }
           //System.Web.HttpContext.Current.
           GridView1.DataSource = ans;
           GridView1.DataBind();

           TextBox1.Text = "";
           return iterNum;
       }
       else//按给定迭代次数迭代，并判断是否满足所填精度
       {
           int myCount = Int32.Parse(iteration_count.Text);
           eps = System.Double.Parse(txt_precision.Text.Trim());
           List<Output> ans = new List<Output>();
           int kk = 0;
           double dif=0.0;
           midx = 0.0;
           for (int i = 0; i < myCount; i++)
           {
               
               dif = midx - (a + b) / 2.0;
               midx = (a + b) / 2.0;
               midy = exprTree.run(ref s, midx);
               Output tmp = new Output() { k = ++kk, a = a, b = b, x = midx, Fx = '+' };
               if (midy < 0) tmp.Fx = '-';
               ans.Add(tmp);
               if (exprTree.run(ref s, a) * midy < 0)
                   b = midx;
               else a = midx;
               if (midy == 0.0)
               {
                   System.Web.HttpContext.Current.Response.Write("<script>alert('找到精确值！');</script>");
                   iterNum = i + 1;
                   dif = 0.0;
                   break;
               }
           }
           //System.Web.HttpContext.Current.
           GridView1.DataSource = ans;
           GridView1.DataBind();

           if (Math.Abs(dif) < eps)
           {
               TextBox1.Text = "是";
               // DrawCoordinate.draw(s, iterNum, Iterative_Point, true);
           }
           else
               TextBox1.Text = "否";


           return iterNum;
       }

       
       //绘制坐标
       //绘制函数曲线
       //迭代计算

   }
}
