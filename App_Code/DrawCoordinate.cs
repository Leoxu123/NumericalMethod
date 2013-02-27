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
using System.IO;
using System.Collections.Generic;

public class DrawCoordinate
{
    /*The parametres are represented for the funtion expression , the number of iterative points 
      the iterative points' coordinate and whether we want to do iteration graph operations
      respectively */
    public static void draw(string s, int num, PointF[] Pt,bool iters)
    {             
       

        float min_x=Pt[0].X;
        float max_x=Pt[0].X;
        for (int i = 1; i < num;++i )
        {
            if (Pt[i].X < min_x) min_x = Pt[i].X;
            if (Pt[i].X > max_x) max_x = Pt[i].X;
        }

        IterPoint iter = new IterPoint();

        //***********************
        iter.ptdata = new List<List<float>>();
        iter.Iterdata = new List<List<float>>();

        for (int i = 0; i < num;++i )
        {
            List<float> temp = new List<float>();
            temp.Add(Pt[i].X);
            temp.Add(Pt[i].Y);
            iter.Iterdata.Add(temp);
        }
        float dis=(max_x-min_x)/60;
        for (float x = min_x-dis; x <= max_x+2*dis;x+=dis)
        {
            List<float> temp = new List<float>();
            temp.Add(x);
            temp.Add((float)exprTree.run(ref s,(double)x));
            //***********************
            iter.ptdata.Add(temp);
        }

        string jsonString = Jsonhelper.JsonSerializer<IterPoint>(iter);
        StreamWriter wr = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/saveFile.json"), false, System.Text.Encoding.Default);
        try
        {
            wr.Write(jsonString);
            wr.Close();
            // Response.Write("<script>alert('文件写入成功');</script>");
        }
        catch
        {
            // Response.Write("<script>alert('文件写入失败');</script>");
        }



//         int width = 1000, height = 600;
//         Bitmap bitmap = new Bitmap(width, height);
//         Graphics g = Graphics.FromImage(bitmap);
//         g.Clear(Color.White);
//         Pen myPen1 = new Pen(Color.Black, 2);
//         float wd = (float)0.8;
//         Pen myPen2 = new Pen(Color.Red, wd);
//         float min_x = Pt[0].X, max_x = Pt[0].X, min_y = Pt[0].Y, max_y = Pt[0].Y;
//         for (int i = 1; i < num; ++i)
//         {
//             if (Pt[i].X < min_x) min_x = Pt[i].X;
//             if (Pt[i].X > max_x) max_x = Pt[i].X;
//             if (Pt[i].Y < min_y) min_y = Pt[i].Y;
//             if (Pt[i].Y > max_y) max_y = Pt[i].Y;
//         }
// 
//         float x_dis = max_x - min_x;
//         float y_dis = max_y - min_y;
//         PointF[] m_Point = new PointF[205];
//         PointF[] IterPoint = new PointF[num+1];
//         for (int i = 0; i < num; ++i)
//             IterPoint[i] = Pt[i];
//         int pnum = 0;
//         double minx = min_x, miny = min_y;
//         
// 
//         double mx1 = minx-1, mx2 = max_x+2;
//         double xdis=mx2-mx1;
//         double tmx1 = mx1;
//         double miy = exprTree.run(ref s, mx1), mxy = exprTree.run(ref s, mx1);
//         while(mx1<mx2)
//         {
//            m_Point[pnum].X = (float)mx1;
//            m_Point[pnum].Y = (float)exprTree.run(ref s, (double)mx1);
//            if (m_Point[pnum].Y < miy) miy = m_Point[pnum].Y;
//            if (m_Point[pnum].Y > mxy) mxy = m_Point[pnum].Y;
//            pnum++;
//            mx1 +=xdis/200 ;
//         }
//         float x0=300, y0=300;
//       
//        setViewPort.WorldCordToViewCord(m_Point, Pt,x0,y0, pnum,num, tmx1, mx2, miy,mxy);
//         SolidBrush brush = new SolidBrush(Color.Red);						//定义画刷
//        // PointF P = new PointF(100, 100);								//实例化PointF类
//         Font font = new Font("宋体", 12);
//         //Font font = new Font("宋体", 12);
//         g.DrawLine(myPen1, x0-250, y0, x0+250,y0);
//         g.DrawString("x", font, brush,x0+250,y0+10);
//         g.DrawLine(myPen1, x0, y0-250, x0, y0+250);
//         g.DrawString(" y ", font, brush, x0+10 ,y0 -250);
//         for (int i = 0; i < pnum - 1; ++i)
//         {
//             g.DrawLine(myPen1, m_Point[i], m_Point[i + 1]);
//            // if (i % 10 == 0) g.DrawString(i.ToString(),font,brush,m_Point[i]);
//         }
//         if (iter)
//         {
//             for (int i = 0; i < num; ++i)
//             {
//                 int positive = 1;
//                 if (Pt[i].Y < y0) positive = -1;      //坐标小于x轴
//                 int cnt = 0;
//                 string output = i.ToString();
//                 g.DrawString(output, font, brush, Pt[i]);
//                 while (Math.Abs(y0 - (Pt[i].Y - cnt * positive)) > 2)
//                 {
//                     g.DrawLine(myPen2, Pt[i].X, Pt[i].Y - cnt * positive, Pt[i].X, Pt[i].Y - (cnt + 1) * positive);
// 
//                     cnt += 4;
//                 }
// 
//             }
//         }
//         else
//         {
//            // Pen myDotPen = new Pen(Color.Red, 2);
//             for(int i=0;i<num;++i)
//             {
//                 g.FillEllipse(brush,Pt[i].X,Pt[i].Y,5,5);
//             }
//         }
//         System.IO.MemoryStream ms = new System.IO.MemoryStream();
//         bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
//         System.Web.HttpContext.Current.Response.ClearContent();
//         System.Web.HttpContext.Current.Response.ContentType = "image/Gif";
//         System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
    }
}
