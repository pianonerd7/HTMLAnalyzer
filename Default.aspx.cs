using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string _tag;
    public string _html;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Execute_Analyze_Command_Click(object sender, EventArgs e)
    {
        string url = urlpath.Value;

        if (url.Length > 0)
        {
            summarylabel.Text = "HTML Tag Summary";
            htmlcodelabel.Text = "HTML Source Code";

            HTMLAnalyzer analyzer = new HTMLAnalyzer(url);

            tagsummary.DataSource = analyzer.CountTags();
            tagsummary.DataBind();

            _html = Server.HtmlEncode(analyzer.getHtml());
            htmlsourcecode.Text = _html;
        }
    }

    protected void tagsummary_rowCommand(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
        string tag = row.Cells[1].Text;
        searchText.Text = tag; 
    }
}