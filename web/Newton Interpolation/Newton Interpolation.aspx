<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Newton Interpolation.aspx.cs" Inherits="web_Newton_Interpolation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        输入点集：<br />
        <br />
        <asp:TextBox ID="tbInputPoint" runat="server" BorderStyle="Solid" 
            Height="131px" TextMode="MultiLine" Width="152px"></asp:TextBox>
        <br />
        <br />
        x=<asp:TextBox ID="tbX" runat="server" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="v_Init_isEmpty" runat="server" 
            ControlToValidate="tbX" ErrorMessage="请输入x的值"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="v_IsNumber" runat="server" 
            ControlToValidate="tbX" ErrorMessage="请输入数值" 
            ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
    
    </div>
    <p>
    &nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="计算" 
            Height="28px" Width="70px" />
    &nbsp;
        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="重置" 
            Height="28px" Width="70px" />
    </p>
    <p>
        <asp:TextBox ID="tbResult" runat="server" Width="138px"></asp:TextBox>
    </p>
    <asp:TextBox ID="tbFuction" runat="server" ForeColor="Red" Height="113px" 
        ReadOnly="True" TextMode="MultiLine" Width="167px"></asp:TextBox>
    </form>
</body>
</html>

