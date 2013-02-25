<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Iterative Method.aspx.cs" Inherits="web_Iterative_Method" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
                迭代函数x(k)=&nbsp;&nbsp; <asp:TextBox ID="tbExpr" runat="server" ontextchanged="tbExpr_TextChanged"></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="v_IsFunctionEmpty" runat="server" 
            ControlToValidate="tbExpr" ErrorMessage="请输入函数"></asp:RequiredFieldValidator>
    
    </div>
    <p>
        初始值 X0：&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbInit" runat="server"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="v_Init_IsEmpty" runat="server" 
            ControlToValidate="tbInit" ErrorMessage="请输入初始值"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="v_Init_IsNumber" runat="server" 
            ControlToValidate="tbInit" ErrorMessage="请输入数值" 
            ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
    </p>
    <p>
        请输入迭代精度：<asp:TextBox ID="tbPrecision" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="v_Precision_IsEmpty" runat="server" 
            ControlToValidate="tbPrecision" ErrorMessage="请输入精度"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="v_Precision_IsNumber" runat="server" 
            ControlToValidate="tbPrecision" ErrorMessage="请输入数值" 
            ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCalc" runat="server" onclick="btnCalc_Click" Text="计算" 
            Height="28px" Width="70px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="重置" 
            Height="28px" Width="70px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        迭代结果如下：</p>
    <div style="overflow-y: scroll; overflow-x: hidden;height: 145px; width: 353px;">
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Width="336px" 
            Height="139px">
        <asp:GridView ID="GD_Output" runat="server" Width="253px">
        </asp:GridView>
    </asp:Panel>
    </form>
</body>
</html>

