using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Execute_Analyze_Command_Click(object sender, EventArgs e)
    {
        string url = urlpath.Value;
        summarylabel.Text = "HTML Tag Summary";
        htmlcodelabel.Text = "HTML Source Code";

        HTMLAnalyzer analyzer = new HTMLAnalyzer(url);
        htmltagsummary.Text = analyzer.DictionaryToString(analyzer.CountTags(url));
        htmlsourcecode.Text = Server.HtmlEncode(analyzer.getHtml());
    }
}