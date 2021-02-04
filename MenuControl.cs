using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    //Opens specific scene when specified in the inspector
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void HowToPlay(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Quits the app entirely
    public void QuitGame()
    {
        Application.Quit();
    }
}
