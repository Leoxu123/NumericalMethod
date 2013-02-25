<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showpaint.aspx.cs" Inherits="web_Iterative_showpaint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td>
                    <span style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none; ">
                    这个模块演示寻找一维非线性函数</span><nobr 
                        style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; "><i>g</i>(<i>x</i>)</nobr><span 
                        style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none; ">的不动点的迭代过程. 
                    首先在一个选定的初始点计算该函数, 然后反复将它的计算结果作为输入带入函数, 直到函数输入值与输出结果的差小到满意的程度.</span></td>
            </tr>
        </table>
    
        <asp:Button ID="Draw" runat="server" onclick="Draw_Click" Text="绘图" />
    
    </div>
    </form>
</body>
</html>
