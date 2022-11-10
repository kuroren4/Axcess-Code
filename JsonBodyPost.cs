using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class JsonBodyPost
{
    public List<codes> codes { get; set; }

    public JsonBodyPost()
    {
    
    }

}

public class codes
{
    
    public string code { get; set; }

    public string captured_at { get; set; }
    public string devise_id { get; set; }

    public string dni { get; set; }

    public codes()
    {

    }

}
