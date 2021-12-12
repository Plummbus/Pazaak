using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] questionGroupArr;
    public QAClass[] qaArr;
    public GameObject answerPanel;

    // Start is called before the first frame update
    void Start()
    {
        qaArr = new QAClass[questionGroupArr.Length];
    }

    public void submitAnswer()
    {
        for (int i = 0; i < qaArr.Length; i++)
        {
            qaArr[i] = readQuestionAndAnswer(questionGroupArr[i]);
        }
        displayResult();
    }

    QAClass readQuestionAndAnswer(GameObject questionGroup)
    {
        QAClass result = new QAClass();

        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;

        result.quesiton = q.GetComponent<TMPro.TextMeshProUGUI>().text;  //might have to do <TMPText> instead

        //radio button answer
        if (a.GetComponent<ToggleGroup>() !=  null)
        {
            for (int i = 0; i < a.transform.childCount; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    result.answer = a.transform.GetChild(i).Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text;    //might also need TMP here
                    break;
                }
            }
        } 
        //textbox answer
        else if (a.GetComponent<TMPro.TMP_InputField>() != null)
        {
            /*
            Debug.Log("a: " + a);
            Debug.Log("a.transform: " + a.transform);
            Debug.Log("a.transform.Find(Question): " + a.transform.Find("Question"));
            if (a.transform.Find("Answer") != null)
            {
                result.answer = a.transform.Find("Answer").GetComponent<TMPro.TMP_InputField>().text;
                Debug.Log(result.answer);
            } else
            {
                Debug.Log("Object Answer does not exist!");
            }
            */
            result.answer = a.transform.GetComponent<TMPro.TMP_InputField>().text;


        }
        //
        else if (a.GetComponent<ToggleGroup>() == null && a.GetComponent<InputField>() == null)
        {
            string s = "";
            int counter = 0;
            for (int i = 0; i < a.transform.childCount - 1; i++)
            {
                if (a.transform.GetChild(i).GetComponent<Toggle>().isOn)
                {
                    if (counter != 0)
                    {
                        s = s + ", ";   //formatting for options after first option
                    }
                    s = s + a.transform.GetChild(i).Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text;
                    counter++;
                }
            }
            result.answer = s;
        }
        return result;
    }

    public void displayResult()
    {
        answerPanel.SetActive(true);
        string s = "";
        for (int i = 0; i < qaArr.Length; i++)
        {
            s = s + qaArr[i].quesiton + "\n";
            s = s + qaArr[i].answer + "\n\n";
        }

        answerPanel.transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>().text = s;
    }

    public void QuitGame()
    {
        Debug.Log("quit!");
        Application.Quit();
    }

}

[System.Serializable]
public class QAClass
{
    public string quesiton = "";
    public string answer = "";
}
