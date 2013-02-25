<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="MainWeb.aspx.cs" Inherits="_Default" %>

<%@ Register src="WebUserControl.ascx" tagname="WebUserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>计算方法</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <a href="MainWeb.aspx">
    <img src="picture/校徽.jpg" 
            style="height: 65px; width: 65px; vertical-align: middle;"></a><span class ="maintitle" 
            style="color: #3366FF; font-size: 55px; vertical-align: middle;"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        《计算方法》演示网站</span>
   
    <table border="0" width="100%" cellpadding="0" class="main-table">
        <tr>
            <td align="Left"  style="width:15%">   
                <iframe id="LeftTree" name="LeftTree" src="LeftTree.aspx" class="inset-table" width="230" height="600"></iframe>                                                                                                                                                                                        
            </td> 
            
            <td align="left" style="width:80%">
               <iframe id="RightMain" name="RightMain" src="RightMain.aspx" class="outset-table" width="100%" height="600"   align="middle"></iframe>
            </td>                                                                                                                                                                                     
        </tr>                                                                                                                                                                                           
    </table>    
    </div>
    </form>
</body>
</html>
