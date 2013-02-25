<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Column Gaussian Elimination.aspx.cs" Inherits="web_Column_Gaussian_Elimination" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 510px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 style="color: #000000; font-size: x-large;">列主元消元法</h1>
    
    </div>
    <table style="width:100%;" align="left" bgcolor="White" frame="above">
        <tr>
            <td class="style1">
    
                <br />
    
        <asp:Label ID="Label1" runat="server" Text="方程的个数：  "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="50px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" >
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
        style= "overflow: scroll;" Width="388px" Height="232px" BorderColor="White" 
                    BorderStyle="Solid">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Height="450px" 
    Width="450px" TextMode="MultiLine" Font-Size="Large"></asp:TextBox>
        <br />
        <br />
    </asp:Panel>
                <asp:Label ID="Label8" runat="server" Font-Size="Small" ForeColor="Red" 
                    Text="提示：请在括号中填上系数，不填默认为0"></asp:Label>
                <br />
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
        <asp:Button ID="Button1" runat="server" Height="33px" Text="计 算" Width="79px" onclick="Button1_Click" 
                     />
                &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="33px" Text="重 置 " 
            Width="76px" onclick="Button2_Click" />
                </td>
            <td>
                <br />
                <asp:Label ID="Label9" runat="server" Text="增广矩阵消元过程："></asp:Label>
                <br />
                <br />
                <asp:Panel ID="Panel2" runat="server" Height="157px" ScrollBars="Both" 
                    Width="350px">
                    <asp:TextBox ID="TextBox3" runat="server" Height="157px" ReadOnly="True" 
                    TextMode="MultiLine" Width="600px" Font-Size="Large" 
                    ></asp:TextBox>
                </asp:Panel>
                <br />
                <br />
                <asp:Label ID="Label10" runat="server" Text="回代求得的解："></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="TextBox5" runat="server" Height="116px" ReadOnly="True" 
                    TextMode="MultiLine" Width="350px" Font-Size="Large"></asp:TextBox>
            </td>
        </tr>
        </table>
    </form>
</body>
</html>

