<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Search Highlight</title>
    <style type="text/css">
        SPAN.searchword {
            background-color: yellow;
        }
    </style>
    <script src="http://www.tedpavlic.com/links/js/searchhi_slim.js" type="text/javascript"></script>
</head>
<body onload="highlightText()">
    <form id="form1" runat="server">
        <script type="text/javascript">
            function highlightText() {
                var textBox = document.getElementById('<%=searchText.ClientID%>');
                if (textBox.value.length > 1) {
                    localSearchHighlight("<" + textBox.value);
                }
            }
        </script>
        <div>
            <p>Please enter the URL</p>
            <input type="text" placeholder="eg. https://slack.com" id="urlpath" runat="server" />
            <asp:Button Text="Go!" OnClick="Execute_Analyze_Command_Click" runat="server" />
        </div>
        <div>
            <p></p>
            <asp:Label ID="summarylabel" runat="server" />
            <p></p>
            <asp:GridView ID="tagsummary" runat="server">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Highlight All Tags" OnClick="tagsummary_rowCommand" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <hr />
            <asp:Label ID="htmlcodelabel" runat="server" />
            <p></p>
            <asp:TextBox ID="searchText" runat="server" />
            <p></p>
            <asp:Literal ID="htmlsourcecode" runat="server" />
        </div>
    </form>
</body>
</html>
