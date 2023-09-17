using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

using System.Text.RegularExpressions;


class Program {
    static void Main(string[] args) {
        Console.WriteLine("Starting");
        HTTPDodwnload ht = new HTTPDodwnload("https://baidu.com/");
        string file = ht.getFile();
        List<string> regexResult = ht.getFullInfo(file);
        ht.changeHTMLFile(ref file,regexResult);

        try{
            File.WriteAllText("result.html",file);
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
        }

    }

    class HTTPDodwnload{
        private string url = "";
        public HTTPDodwnload(string url){
            //Console.WriteLine(url.Substring(url.Length - 1,1));
            if(url.Substring(url.Length - 1,1) == "/"){
                this.url = url;
            }else{
                this.url = url + "/";
            }
            //Console.WriteLine(this.url);
        }

    public string getFile(){
        using var client = new HttpClient();
    
        // 发送 GET 请求以获取指定 URL 的响应
        HttpResponseMessage response = client.GetAsync(url).Result;

        // 读取响应内容作为字符串
        string responseBody = response.Content.ReadAsStringAsync().Result;
    
        // 输出响应内容
        return responseBody;
    }

    public string changeDir(string relativePath){ 
        //Console.WriteLine(relativePath);
        if(Uri.IsWellFormedUriString(relativePath, UriKind.Absolute)){
            //System.Console.WriteLine(111111);
            return relativePath;
        }
        Uri baseUri = new Uri(url);
        Uri absoluteUri = new Uri(baseUri, relativePath);
        string absolutePath = absoluteUri.AbsoluteUri;
        return absolutePath;
    }

    public List<string> getFullInfo(string text){
        // System.Console.WriteLine(text);
        List<string> allMatch = new List<string>();

        System.Console.WriteLine(" (?:src|href)=['\"](.*?)['\"]");
        

        Regex regex = new Regex(" (?:src|href)=['\"](.*?)['\"]"); // 【 (?:src|href)=["'](.*?)["']】记得前面有个空格～提高准确率
        MatchCollection matchCollection = regex.Matches(text);
        //List<string> allMatch = new List<string>(regex.Count(text));


        foreach(Match single_match in matchCollection){
            allMatch.Add(single_match.Value);
        }

        return allMatch;
    }

    public void changeHTMLFile(ref string theFile, List<string> RegexResult){
        Regex regex = new Regex("[\"'](.*?)[\"']"); //["'](.*?)["']
        foreach(var single_result in RegexResult){
            //["'](.*?)["']
            theFile = theFile.Replace(regex.Match(single_result).Value, changeDir(regex.Match(single_result).Value));
        }
    }

    }
}
