﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Aitken mainpage.aspx.cs" Inherits="web_Aitken_Aitken_mainpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>无标题页</title>
</head>

  <body>
    <form id="form1" runat="server">
    <div>
    <h1 style="color: #000000; font-size: x-large;">埃特金迭代法</h1>
    <table border="0" width="100%" cellpadding="0" class="main-table">
        <tr>
            <td align="Left"  style="width:20%">   
                <iframe id="Iterative" name="Aitken Method" src="Aitken Method.aspx" class="inset-table" width="400" height="500"></iframe>                                                                                                                                                                                        
            </td> 
            
            <td align="left" style="width:75%">
               <iframe id="showpaint" name="showpaint" src="showpaint.aspx" class="outset-table" width="100%" height="500"   align="middle"></iframe>
            </td>                                                                                                                                                                                     
        </tr>                                                                                                                                                                                           
    </table>    
    </div>
    </form>
</body>

 </html>
