<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Please enter the URL</p>
        <input type="text" placeholder="eg. https://slack.com" id="urlpath" runat="server"/>
        <asp:Button Text="Go!" OnClick="Execute_Analyze_Command_Click" runat="server"/>
    </div>
        <p></p>
         <asp:label id="allValidationMsg" runat="server" height="22px" />
    </form>
</body>
</html>
