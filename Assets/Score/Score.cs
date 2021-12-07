using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreValue;
    [HideInInspector] public string stringscore;
    public GameObject myscore;

    void Start() 
    {
        scoreValue = GetComponent<Text>();
    }

    void Update()
    {
       stringscore = myscore.GetComponent<Movement>().getcanvalue().ToString();
       scoreValue.text = "Score is :" + stringscore;
    }
}
