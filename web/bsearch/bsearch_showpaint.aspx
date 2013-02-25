<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bsearch_showpaint.aspx.cs" Inherits="web_bsearch_bsearch_showpaint" %>

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
                    <span style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">
                    这个模块演示求解一维非线性方程<span class="Apple-converted-space">&nbsp;</span></span><nobr 
                        style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;"><i>f</i>(<i>x</i>) 
                    = 0</nobr><span 
                        style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">的区间二分法. 
                    首先找到一个初始的区间, 使得在它的两个端点处</span><nobr 
                        style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px;"><i>f</i>(<i>x</i>)</nobr><span 
                        style="color: rgb(0, 0, 0); font-family: Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">的函数值符号相反, 
                    然后不断地对区间二等分, 直到方程的解被隔离在很小的范围内, 达到要求的准确度.</span></td>
            </tr>
        </table>
    
        <asp:Button ID="Draw" runat="server" onclick="Draw_Click" Text="绘图" />
    
    </div>
    </form>
</body>
</html>
