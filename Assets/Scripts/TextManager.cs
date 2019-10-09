using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public bool score;
    public bool level;
    
    private Text text;
    private GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        
        updateScore();
    }

    private void Update()
    {
        updateScore();
    }

    private void updateScore()
    {
        if (score)
        {
            text.text = "Score: " + gm.getScore();
        }
        else if (level)
        {
            text.text = "Level: " + gm.getLevel();
        }
    }
}
