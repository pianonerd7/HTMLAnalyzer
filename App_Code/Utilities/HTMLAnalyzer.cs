using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for HTMLAnalyzer
/// </summary>
public class HTMLAnalyzer
{

    public static string URLToHTML(string url)
    {
        string http = null;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (response.CharacterSet == null)
            {
                readStream = new StreamReader(receiveStream);
            }
            else
            {
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            }
            http = readStream.ReadToEnd();

            response.Close();
            readStream.Close();
        }
        return http;
    }

    public static Dictionary<String, int> GetTags(string http)
    {
        Dictionary<String, int> httpTagMap = new Dictionary<String, int>();

        string[] words = Regex.Split(http, @"\W");
        for (int index = 0; index < words.Length; index++)
        {

        }

        return httpTagMap;
    }
}