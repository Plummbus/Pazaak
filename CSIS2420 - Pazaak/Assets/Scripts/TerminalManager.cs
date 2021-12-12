using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;
    public InputField terminalInput;    //NOT TMP
    public GameObject userInputLine;
    public ScrollRect sr;
    public GameObject msgList;

    private Interpreter interpreter;

    private void Start()
    {
        interpreter = GetComponent<Interpreter>();

    }

    private void OnGUI()
    {
        if (terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            //Store what the user typed
            string userInput = terminalInput.text;

            //Clear input field
            ClearInputField();

            //Instantiate a gmaeobject with a directory prefix
            AddDirectoryline(userInput);

            //add interpretation lines
            int lines = AddInterpreterLines(interpreter.Interpret(userInput));

            //Scroll to bottom of all the lines
            ScrollToBottom(lines);

            //Move user input line to end
            userInputLine.transform.SetAsLastSibling();

            //Refocus input field, so you dont have to reselect after ENTER
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    private void ClearInputField()
    {
        terminalInput.text = "";
    }

    private void AddDirectoryline(string userInput)
    {
        //got to scale scrollrect to fit new lines
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 35.0f);    //only growing vertically

        //Instantiate directory line
        GameObject msg = Instantiate(directoryLine, msgList.transform);

        //Set child index
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);    //pushing previous line behind this one

        //Set the text of this new gameobject
        msg.GetComponentsInChildren<Text>()[1].text = userInput;
    }

    private int AddInterpreterLines(List<string> interpretation)
    {
        for (int i = 0; i < interpretation.Count; i++)
        {
            //Instantiate response line
            GameObject response = Instantiate(responseLine, msgList.transform);

            //Set to end of all messages
            response.transform.SetAsLastSibling();

            //get size of message list
            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 35.0f);

            //set text of response line to be whatever is in the interpreter string
            response.GetComponentInChildren<Text>().text = interpretation[i];
        }

        return interpretation.Count;
    }

    private void ScrollToBottom(int lines)
    {
        if (lines > 4)
        {
            sr.velocity = new Vector2(0, 450);  //smooth scrolling if theres a bunch of lines
        }
        else
        {
            sr.verticalNormalizedPosition = 0;  //jumps to bottom with 3 or less new lines
        }
    }

 
}
