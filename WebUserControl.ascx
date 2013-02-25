<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>
<asp:TreeView ID="TreeView1" runat="server" Font-Names="楷体" Font-Size="Large" 
    ShowLines="True" Width="257px">
    <HoverNodeStyle BackColor="#00FF99" />
    <Nodes>
        <asp:TreeNode Expanded="True" SelectAction="Expand" Text="一元非线性方程的解法" 
            Value="一元非线性方程的解法">
            <asp:TreeNode Text="二分法" Value="二分法"
               NavigateUrl="~/Web/bsearch/bsearch_homepage.aspx" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Iterative/Iterative mainpage.aspx" Text="迭代法" Value="迭代法" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Newton's Iterative/Newton's Iterative mainpage.aspx" Text="牛顿迭代法" Value="牛顿迭代法" Target="RightMain">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Secant/Secant mainpage.aspx" Text="弦截法（割线法）" Value="弦截法（割线法）" Target="RightMain">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Aitken/Aitken mainpage.aspx" Text="埃特金迭代法" Value="埃特金迭代法" Target="RightMain">
            </asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Expanded="True" SelectAction="Expand" Text="线性代数方程组的解法" 
            Value="线性代数方程组的解法">
            <asp:TreeNode NavigateUrl="~/Web/Jacobi iteration.aspx" Text="雅可比迭代法" Value="雅可比迭代法" Target="RightMain">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Gauss-Seidel iteration.aspx" Text="高斯-赛德尔迭代法" 
                Value="高斯-赛德尔迭代法" Target="RightMain">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/SOR iteration.aspx" Text=" 超松弛迭代法" Value=" 超松弛迭代法" Target="RightMain">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Sequential Gaussian Elimination.aspx" Text="顺序高斯消去法" Value="顺序高斯消去法" Target="RightMain">
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Column Gaussian Elimination.aspx" Text="列主元消去法" Value="列主元消去法" 
                Target="RightMain">
            </asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="矩阵特征值与特征向量的计算" 
            Value="矩阵特征值与特征向量的计算">
            <asp:TreeNode Text="幂法" Value="幂法" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="反幂法" Value="反幂法" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="QR方法" Value="QR方法" Target="RightMain"></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="插值法和曲线拟合" 
            Value="插值法和曲线拟合">
            <asp:TreeNode NavigateUrl="~/Web/Lagrange interpolation/mainpage.aspx" Text="拉格朗日插值多项式" Value="拉格朗日插值多项式" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/Web/Newton interpolation/mainpage.aspx" Text="牛顿均差插值多项式" Value="牛顿均差插值多项式" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="三次Hermite插值" Value="三次Hermite插值" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="三次样条插值" Value="三次样条插值" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="B样条曲线" Value="B样条曲线" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="曲线拟合的最小二乘法" Value="曲线拟合的最小二乘法" Target="RightMain"></asp:TreeNode>
        </asp:TreeNode>
        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="数值积分" Value="数值积分">
            <asp:TreeNode NavigateUrl="~/Web/NewtonCotes.aspx" Text="牛顿-柯特斯求积公式" Value="牛顿-柯特斯求积公式" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="复合求积公式" Value="复合求积公式" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="龙贝格求积法" Value="龙贝格求积法" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="高斯求积公式" Value="高斯求积公式" Target="RightMain"></asp:TreeNode>
            <asp:TreeNode Text="数值微分" Value="数值微分" Target="RightMain"></asp:TreeNode>
        </asp:TreeNode>
    </Nodes>
</asp:TreeView>
