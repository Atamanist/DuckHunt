using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Display : MonoBehaviour
{
    private Text _text;

    public void PrintStats(Dictionary<string,int> i)
    {
        _text = GetComponent<Text>();
        _text.text = $"" +
            $"{i.ElementAt(0).Key}: {i.ElementAt(0).Value}" +
            $"\n{i.ElementAt(1).Key}: {i.ElementAt(1).Value}" +
            $"\n{i.ElementAt(2).Key}: {i.ElementAt(2).Value}" +
            $"\n{i.ElementAt(3).Key}: {i.ElementAt(3).Value}" +
            $"\n{i.ElementAt(4).Key}: {i.ElementAt(4).Value}";
    }

    public void PrintRule(Dictionary<string, int> i)
    {
        _text = GetComponent<Text>();
        _text.text = $"One from" +
            $"\n{i.ElementAt(0).Key} more: {i.ElementAt(0).Value}" +
            $"\n{i.ElementAt(1).Key} more: {i.ElementAt(1).Value}" +
            $"\n{i.ElementAt(2).Key} more: {i.ElementAt(2).Value}";
    }


}
