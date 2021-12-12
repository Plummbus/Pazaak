using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpreter : MonoBehaviour {

    Dictionary<string, string> colors = new Dictionary<string, string>()
    {
        {"minus", "#ED0DD9"},
        {"neutral", "#FFFD01"},
        {"plus", "#47C072"},
        {"option", "#B9CC81"},
        {"white", "#FFFFE4"}
    };

    List<string> response = new List<string>();

    public GameObject player;
    public bool playOn;

    private void Start()
    {
        playOn = true;
    }

    public void playGame()
    {
        ListEntry("something something", "lasdlmalsdblasd");
    }

    public List<string> Interpret(string userInput)
    {
        response.Clear();   //clear list whenever we get a new response

        string[] args = userInput.Split();

        if (args[0] == "help")
        {
            //return some info/tutorial
            ListEntry("help", "explanation on how to play the game");
            ListEntry("exit", "exit back to main menu anytime");

            return response;
        } else if (args[0] == "pazzak.exe")
        {
            playGame();
        }
        else
        {
            response.Add("COMMAND NOT RECOGNIZED");

            return response;
        }

        
    }

    //for use with Rich Text option
    public string ColorString(string s, string color)
    {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color>";
        return leftTag + s + rightTag;
    }

    public void ListEntry(string a, string b)
    {
        response.Add(ColorString(a, colors["option"]) + ": " + ColorString(b, colors["white"]));
    }

    public void AddToLine(string s)
    {
        response.Add(s);
    }

    

    
}
