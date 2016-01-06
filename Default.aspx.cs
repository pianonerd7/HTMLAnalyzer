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

            htmlsourcecode.Text = Server.HtmlEncode(analyzer.getHtml());
        }
        //TODO add try catch for invalid url
    }

    protected void tagsummary_rowCommand(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
        string tag = row.Cells[1].Text;
        //htmlsourcecode.Text = tag;

        htmlsourcecode.Text = HighlightKeywords("html", tag);
    }

    public string HighlightKeywords(string input, string keywords)
    {
        if (input == string.Empty || keywords == string.Empty)
        {
            return input;
        }

        string[] sKeywords = keywords.Split(' ');
        foreach (string sKeyword in sKeywords)
        {
            try
            {
                input = Regex.Replace(input, sKeyword, string.Format("<span class=\"hit\">{0}</span>", "$0"), RegexOptions.IgnoreCase);
            }
            catch
            {
                //
            }
        }
        return input;
    }
}