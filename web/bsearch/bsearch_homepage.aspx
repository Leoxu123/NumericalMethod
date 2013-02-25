<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bsearch_homepage.aspx.cs" Inherits="web_bsearch_bsearch_homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1 style="color: #000000; font-size: x-large;">二分法</h1>
    <table border="0" width="100%" cellpadding="0" class="main-table">
        <tr>
            <td align="Left"  style="width:20%">   
                <iframe id="bsearchleft" name="bsearchleft" src="bsearchleft.aspx" class="inset-table" width="300" height="700"></iframe>                                                                                                                                                                                        
            </td> 
            
            <td align="left" style="width:75%">
               <iframe id="bsearch_showpaint" name="bsearch_showpaint" src="bsearch_showpaint.aspx" class="outset-table" width="100%" height=700"   align="middle"></iframe>
            </td>                                                                                                                                                                                     
        </tr>                                                                                                                                                                                           
    </table>    
    </div>
    </form>
</body>
</html>
