<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewtonCotes.aspx.cs" Inherits="web_NewtonCotes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1 style="color: #000000; font-size: x-large;">牛顿-柯特斯公式</h1>
        被积函数 f(x) =
        <asp:TextBox ID="tbExpr" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="v_Func_isEmpty" runat="server" 
                    ControlToValidate="tbExpr" ErrorMessage="函数不能为空！"></asp:RequiredFieldValidator>
    
    </div>
    <p style="margin-left: 40px">
&nbsp;&nbsp;&nbsp; 下 限：<asp:TextBox ID="tbLowerBound" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="v_LowerBound_IsEmpty" runat="server" 
                    ControlToValidate="tbLowerBound" Display="Dynamic" 
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="v_LowerBound_IsNumber" runat="server" 
                    ControlToValidate="tbLowerBound" ErrorMessage="必须为数字！" 
                    ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
                </p>
    <p style="margin-left: 40px">
&nbsp;&nbsp; 上 限:&nbsp;&nbsp;
        <asp:TextBox ID="tbUpperBound" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="v_UpperBound_IsEmpty" runat="server" 
                    ControlToValidate="tbLowerBound" Display="Dynamic" 
            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="v_UpperBound_IsNumber" runat="server" 
                    ControlToValidate="tbUpperBound" Display="Dynamic" ErrorMessage="必须为数字！" 
                    ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="cv_GE" runat="server" 
                    ControlToCompare="tbLowerBound" ControlToValidate="tbUpperBound" ErrorMessage="请输入不小于下限的数！" 
                    Operator="GreaterThanEqual"></asp:CompareValidator>
                </p>
    <p style="margin-left: 40px">
        积分公式类型:<asp:DropDownList ID="IntegrationType" runat="server" TabIndex="2">
            <asp:ListItem>梯形公式</asp:ListItem>
            <asp:ListItem>辛普森公式</asp:ListItem>
            <asp:ListItem>柯特斯公式</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="tbCalc" runat="server" onclick="tbCalc_Click" Text="计算" 
            Width="47px" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="重置" />
    </p>
    <p>
        积分结果:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;         <asp:TextBox ID="tbResult" runat="server"></asp:TextBox>
    </p>
    </form>
</body>
</html>
