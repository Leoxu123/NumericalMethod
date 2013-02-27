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
            iter.ptdata.Add(temp);
        }

        string jsonString = Jsonhelper.JsonSerializer<IterPoint>(iter);
        StreamWriter wr = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/saveFile.json"), false, System.Text.Encoding.Default);
        wr.Write(jsonString);
        wr.Close();
       
    }
}
