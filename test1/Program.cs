using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Starting");
        HTTPDodwnload ht = new HTTPDodwnload("https://example.com/");

        //Console.WriteLine(ht.changeDir("/e/1.txt"));
        //Console.WriteLine(ht.getFile());
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
            Console.WriteLine(this.url);
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
        Uri baseUri = new Uri(url);
        Uri absoluteUri = new Uri(baseUri, relativePath);
        string absolutePath = absoluteUri.AbsoluteUri;
        return absolutePath;

    }
    }
}
