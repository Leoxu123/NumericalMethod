<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gauss-Seidel iteration.aspx.cs" Inherits="web_Gauss_Seidel_iteration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 457px;
            height: 524px;
        }
        .style2
        {
            height: 524px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 style="color: #000000; font-size: x-large;">Gauss-Seidel 迭代法</h1>
    
    </div>
    <table style="width:100%;" align="left" bgcolor="White" frame="above">
        <tr style="border: thin double #0000FF;">
            <td class="style1">
    
        <asp:Label ID="Label1" runat="server" Text="方程的个数：  "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="50px" 
                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
                <br />
                <br />
    <asp:Label ID="Label2" runat="server" Text="线性方程组为："></asp:Label>
                <br />
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" 
        style= "overflow: scroll;" Width="375px" Height="191px" BorderColor="White" 
                    BorderStyle="Solid">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="450px" 
    Width="650px" TextMode="MultiLine" Font-Size="Large"></asp:TextBox>
        <br />
        <br />
    </asp:Panel>
                <asp:Label ID="Label8" runat="server" Font-Size="Small" ForeColor="Red" 
                    Text="提示：请在括号中填上系数，不填默认为0"></asp:Label>
                <br />
                <br />
                <br />
        <asp:Label ID="Label3" runat="server" Text=" 精 度 ： "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_eps" runat="server" style="margin-left: 0px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txt_eps" ErrorMessage="必须为数字！" 
                    ValidationExpression="^(-?\d+)(\.\d+)?" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_eps" ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="最大迭代次数："></asp:Label>
                <asp:TextBox ID="txt_count" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txt_count" Display="Dynamic" ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txt_count" ErrorMessage="必须为数字！" 
                    ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
                <br />
                <br />
        &nbsp;
        <asp:Button ID="Button1" runat="server" Height="33px" Text="计 算" Width="79px" 
                    onclick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="33px" Text="重 置 " 
            Width="76px" onclick="Button2_Click" />
                <br />
                <br />
                <br />
            </td>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="迭代结果如下表： "></asp:Label>
                <asp:Label ID="mylabel" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Panel ID="Panel2" runat="server" Height="306px" ScrollBars="Auto" 
                    Width="500px" BorderColor="#CCCCCC" BorderStyle="Solid" Font-Bold="False">
                    <asp:GridView ID="GridView1" runat="server" Height="281px" Width="550px" 
                        HorizontalAlign="Left">
                    </asp:GridView>
                </asp:Panel>
                <br />
                <asp:Label ID="Label6" runat="server" Text="实际迭代次数："></asp:Label>
                <asp:TextBox ID="txt_actaltcount" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="是否满足精度："></asp:Label>
                <asp:TextBox ID="txt_ismeeteps" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</html>
