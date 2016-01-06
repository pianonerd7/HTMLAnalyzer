using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;


public class HTMLAnalyzer
{
    private string _url;
    HtmlDocument html;

    public HTMLAnalyzer(string url)
    {
        this._url = url;
        this.html = new HtmlDocument();
        html.LoadHtml(new WebClient().DownloadString(_url));
    }


    public string getHtml()
    {
        return html.DocumentNode.OuterHtml;
    }

    public Dictionary<string, int> CountTags()
    {
        Dictionary<string, int> numTags = new Dictionary<string, int>();

        var root = html.DocumentNode;
        IEnumerable<HtmlNode> nodes = root.Descendants();

        foreach (HtmlNode node in nodes)
        {
            if (numTags.ContainsKey(node.Name))
            {
                numTags[node.Name]++;
            }
            else
            {
                if (!node.Name.Equals("#text") && !node.Name.Equals("#comment"))
                {
                    numTags.Add(node.Name, 1);
                }
            }
        }
        return numTags;
    }
}