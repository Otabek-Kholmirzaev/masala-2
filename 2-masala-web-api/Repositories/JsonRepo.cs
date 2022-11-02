using _2_masala_web_api.Models;
using Newtonsoft.Json;
using System;
using System.Xml.Linq;

namespace _2_masala_web_api.Repositories;

public class JsonRepo
{
    private readonly string path = Path
        .Combine(Directory.GetCurrentDirectory(), "Data", "JsonData.json");

    public void SaveDataToJson(Log log)
    {
        var data = File.ReadAllText(path);
            
        var list = JsonConvert.DeserializeObject<List<Log>>(data);
        list ??= new List<Log>();
        list.Add(log);
        
        string jsonData = JsonConvert.SerializeObject(list);
        File.WriteAllText(path, jsonData);
    }

    public string GetDataInJsonFile()
    {
        var data = File.ReadAllText(path);
        return data;
    }
}
