using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class SimpleServer {
    static string basePath = @"D:\School Management";
    static UTF8Encoding utf8NoBom = new UTF8Encoding(false);

    static void Main() {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        try {
            listener.Start();
        } catch (Exception ex) {
            Console.WriteLine("Listener failed: " + ex.Message);
            return;
        }

        Console.WriteLine("Server running at http://localhost:8080/");

        while (true) {
            try {
                HttpListenerContext ctx = listener.GetContext();
                ThreadPool.QueueUserWorkItem(ProcessRequest, ctx);
            } catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void ProcessRequest(object state) {
        HttpListenerContext ctx = (HttpListenerContext)state;
        HttpListenerRequest req = ctx.Request;
        HttpListenerResponse res = ctx.Response;

        res.Headers.Add("Access-Control-Allow-Origin", "*");
        res.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
        res.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

        try {
            if (req.HttpMethod == "OPTIONS") {
                res.StatusCode = 200;
                res.Close();
                return;
            }

            string path = req.Url.AbsolutePath;

            if (path == "/" || path == "/index.html") {
                string htmlPath = Path.Combine(basePath, "index.html");
                byte[] buffer = File.ReadAllBytes(htmlPath);
                res.ContentType = "text/html; charset=utf-8";
                res.ContentLength64 = buffer.Length;
                res.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else if (path == "/api/data") {
                string key = req.QueryString["key"];
                if (string.IsNullOrEmpty(key)) key = "schoolExamCandidates";
                
                string safeKey = "";
                foreach (char c in key) {
                    if (char.IsLetterOrDigit(c) || c == '_') safeKey += c;
                }
                string filePath = Path.Combine(basePath, "data_" + safeKey + ".json");

                if (req.HttpMethod == "GET") {
                    string json = "[]";
                    if (File.Exists(filePath)) {
                        json = File.ReadAllText(filePath, utf8NoBom);
                        if (!string.IsNullOrWhiteSpace(json)) {
                            json = json.Trim().Trim('\uFEFF');
                        } else {
                            json = "[]";
                        }
                    }
                    byte[] buffer = utf8NoBom.GetBytes(json);
                    res.ContentType = "application/json; charset=utf-8";
                    res.ContentLength64 = buffer.Length;
                    res.OutputStream.Write(buffer, 0, buffer.Length);
                }
                else if (req.HttpMethod == "POST") {
                    using (var reader = new StreamReader(req.InputStream, utf8NoBom)) {
                        string body = reader.ReadToEnd();
                        body = body.Trim().Trim('\uFEFF');
                        File.WriteAllText(filePath, body, utf8NoBom);
                    }
                    string reply = "{\"status\":\"ok\"}";
                    byte[] buffer = utf8NoBom.GetBytes(reply);
                    res.ContentType = "application/json; charset=utf-8";
                    res.ContentLength64 = buffer.Length;
                    res.OutputStream.Write(buffer, 0, buffer.Length);
                }
            }
            else {
                res.StatusCode = 404;
            }
        } catch (Exception ex) {
            Console.WriteLine("Request error: " + ex.Message);
            res.StatusCode = 500;
        } finally {
            try { res.Close(); } catch {}
        }
    }
}
