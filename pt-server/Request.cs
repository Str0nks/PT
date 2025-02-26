using System.Text;

class Request{
    public enum Method
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public Method GetMethod(){
        return method;
    }
    private string path = "";
    private string pathHttp = "";
    private Dictionary<string,string> headers = new Dictionary<string, string>();
    private Method method;
    public Request(string request){
        if(String.IsNullOrEmpty(request))
            return;
        string[] parts = request.Split("\r\n");
        ParseRequest(parts);
    }
    
    private void ParseRequest(string[] request){
        string[] method_split = request[0].Split(' ');
        
        switch (method_split[0])
        {
            case "GET":
            method = Method.GET;
            break;
            case "PUT":
            method = Method.PUT;
            break;
            case "POST":
            method = Method.POST;
            break;
            case "DELETE":
            method = Method.DELETE;
            break;
            default:
            break;
        }
        path = method_split[1];
        pathHttp = method_split[2];
        for (int i = 1; i < request.Length; i++)
        {
            if(String.IsNullOrEmpty(request[i]))
                break;
            var line = request[i].Split(": ");
            headers.Add(line[0],line[1]);
        }
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Method = ").Append(method).AppendLine();
        sb.Append("Path = ").Append(path).AppendLine();
        sb.Append("HTTP = ").Append(pathHttp).AppendLine();
        foreach (var item in headers)
        {
            sb.Append(item.Key).Append(": ").Append(item.Value).AppendLine();
        }
        return sb.ToString();
    }
    
}