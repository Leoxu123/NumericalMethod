<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bsearchleft.aspx.cs" Inherits="web_bsearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        #form1
        {
            width: 852px;
            height: 769px;
        }
        .style1
        {
            width: 781px;
            height: 274px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 51%; margin-right: 436px;">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="f(x)= "></asp:Label>
&nbsp;&nbsp;<asp:TextBox ID="txt_function" runat="server" style="margin-bottom: 0px" Width="128px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txt_function" ErrorMessage="函数不能为空！"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="x: from  "></asp:Label>
                <asp:TextBox ID="txt_a" runat="server" style="margin-left: 0px" Width="128px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txt_a" Display="Dynamic" ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txt_a" ErrorMessage="必须为数字！" 
                    ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="to    "></asp:Label>
&nbsp;<asp:TextBox ID="txt_b" runat="server" Width="128px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txt_b" Display="Dynamic" ErrorMessage="必须为数字！" 
                    ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txt_a" ControlToValidate="txt_b" ErrorMessage="请输入比a大的数！" 
                    Operator="GreaterThan"></asp:CompareValidator>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="迭代次数："></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="iteration_count" runat="server" >
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
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                    <asp:ListItem>32</asp:ListItem>
                    <asp:ListItem>33</asp:ListItem>
                    <asp:ListItem>34</asp:ListItem>
                    <asp:ListItem>35</asp:ListItem>
                    <asp:ListItem>36</asp:ListItem>
                    <asp:ListItem>37</asp:ListItem>
                    <asp:ListItem>38</asp:ListItem>
                    <asp:ListItem>39</asp:ListItem>
                    <asp:ListItem>40</asp:ListItem>
                    <asp:ListItem>41</asp:ListItem>
                    <asp:ListItem>42</asp:ListItem>
                    <asp:ListItem>43</asp:ListItem>
                    <asp:ListItem>44</asp:ListItem>
                    <asp:ListItem>45</asp:ListItem>
                    <asp:ListItem>46</asp:ListItem>
                    <asp:ListItem>47</asp:ListItem>
                    <asp:ListItem>48</asp:ListItem>
                    <asp:ListItem>49</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="Label5" runat="server" Text="精度:  "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txt_precision" runat="server" Width="128px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ControlToValidate="txt_precision" ErrorMessage="必须为数字!" 
                    ValidationExpression="^(-?\d+)(\.\d+)?"></asp:RegularExpressionValidator>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Font-Size="Small" ForeColor="Red" 
                    Text="提示：迭代次数和精度可选其一;若都选,则是&lt;br&gt;测试方程迭代所选次数能否满足精度"></asp:Label>
                <br />
                <br />
                &nbsp;
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="测试" 
                    Height="28px" Width="60px" />
            &nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Height="28px" onclick="Button2_Click" 
                    Text="重置" Width="60px" />
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="迭代结果如下："></asp:Label>
            </td>
        </tr>
        </table>
        <div style="overflow-y: scroll; overflow-x: hidden;height: 420px; width: 400px;">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" 
        Width="274px" Height="300px">
                    <br />
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    <br />
                    <br />
                    <br />
                    <br />
                </asp:Panel>
                <br />
                <asp:Label ID="Label9" runat="server" Text="是否满足精度："></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
    </form>
</body>
</html>
