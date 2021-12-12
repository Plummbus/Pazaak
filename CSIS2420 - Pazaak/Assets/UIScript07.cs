using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript07 : MonoBehaviour
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
    }

    QAClass readQuestionAndAnswer (GameObject questionGroup)
    {
        return null;
    }
}

[System.Serializable]
public class QAClass
{
    public string quesiton = "";
    public string answer = "";
}
