using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;

public class Lang : Singleton<Lang>
{
    private Dictionary<string, string> _gameTexts;

    public string this[string key]
    {
        get { return GetText(key); }
    }

    public string[] this[string[] keys]
    {
        get { return GetText(keys); }
    }

    void Awake()
    {
        string lang = Application.systemLanguage.ToString();
        string jsonString = string.Empty;
	
        if (lang == "French")
            jsonString = Resources.Load<TextAsset>("lang.fr").text;
        else
            jsonString = Resources.Load<TextAsset>("lang.en").text;

        JSONNode json = JSON.Parse(jsonString);
        int size = json.Count;
       
        _gameTexts = new Dictionary<string, string>(size);

        JSONArray array;
        for (int i = 0; i < size; i++)
        {
            array = json[i].AsArray;
            _gameTexts.Add(array[0].Value, array[1].Value);
        }
    }

    public static string Get(string key)
    {
        return Instance.GetText(key);
    }

    public static string[] Get(string[] keys)
    {
        return Instance.GetText(keys);
    }

    public string GetText(string key)
    {
        if (_gameTexts.ContainsKey(key))
            return _gameTexts[key];

        return key;
    }
    
    public string[] GetText(string[] keys)
    {
    	int size = keys.Length;
    	string[] results = new string[size];
    	
    	for (int i = 0; i < size; i++)
    		results[i] = GetText(keys[i]);
    	
    	return results;
    }
}

