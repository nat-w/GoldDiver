using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{

    public void OnPlayButtonClicked()
    {
        GetComponent<GameManager>().restartGame();
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
