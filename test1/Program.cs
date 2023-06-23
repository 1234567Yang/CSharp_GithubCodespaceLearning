using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Starting");
        HT ht = new HT();
        Console.WriteLine(ht.get("https://example.com/"));
    }

    class HT{
    public string get(string url){
        using var client = new HttpClient();
    
        // 发送 GET 请求以获取指定 URL 的响应
        HttpResponseMessage response = client.GetAsync(url).Result;

        // 读取响应内容作为字符串
        string responseBody = response.Content.ReadAsStringAsync().Result;
    
        // 输出响应内容
        return responseBody;
    }
    }
}
