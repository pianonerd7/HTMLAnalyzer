using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        allValidationMsg.Text = "Original text";
    }

    protected void Execute_Analyze_Command_Click(object sender, EventArgs e)
    {
        string url = urlpath.Value;
        string http = HTMLAnalyzer.URLToHTML(url);
        allValidationMsg.Text = Server.HtmlEncode(http);
    }
}