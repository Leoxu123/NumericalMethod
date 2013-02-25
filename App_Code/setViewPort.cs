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
/// <summary>
///setViewPort 的摘要说明
/// </summary>
public class setViewPort
{
    const int RATE = 8;
    
	public static void WorldCordToViewCord(PointF[]Pt,PointF[]Pf,float xx,float yy,int num1,int num2,double min_x,double max_x,double min_y,double max_y)
    {
        double x_dis = max_x - min_x;     //世界坐标系x,y的距离差
        double y_dis = max_y - min_y;
        double Width = 200;
        x_dis = max_x - min_x;
        y_dis = max_y - min_y;

        double rate,xrate,yrate;
        double ViewLeft,ViewRight,ViewBottom,ViewTop;
        if (x_dis/3 < y_dis)
        {
            rate = y_dis / x_dis;
            while (Math.Abs(min_y * Width / x_dis * rate )> 700) Width /= 2;
        //    Width = 1000 / rate / rate;
            xrate = Width / x_dis;     //世界坐标系与视口坐标系的比值
            ViewLeft = xrate * min_x;
            ViewRight = xrate * max_x;
            ViewBottom = Math.Max(-400, min_y * xrate * rate);
            ViewTop = Math.Min(800, max_y * xrate * rate);
        }
        else
        {
            rate = x_dis / y_dis;
            while (Math.Abs(min_x * Width / y_dis * rate) > 700) 
                Width /= 2;
            yrate = Width / y_dis;
            ViewBottom = yrate * min_y;
            ViewTop = yrate * max_y;
            ViewLeft = Math.Max(-400, min_x * yrate * rate);
            ViewRight = Math.Min(800, max_x * yrate * rate); ;
        }
        double A = (ViewRight - ViewLeft) / (x_dis);
        double C = ViewLeft - A * min_x;
        double B = (ViewTop - ViewBottom) / (y_dis);
        double D = ViewBottom - B * min_y;
        for(int i=0;i<num1;++i)
        {
            Pt[i].X = (float)A * Pt[i].X  + xx;
            Pt[i].Y = (float)B * Pt[i].Y  + yy;
            Pt[i].Y = (float)(2 * yy) - Pt[i].Y;
        }

        for(int i=0;i<num2;++i)
        {
            Pf[i].X = (float)A * Pf[i].X + xx;
            Pf[i].Y = (float)B * Pf[i].Y + yy;
            Pf[i].Y = (float)(2 * yy) - Pf[i].Y;
        }
        
      
    }
}
