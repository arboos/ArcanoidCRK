using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDefaultFunctions : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadScene(int index)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(index);
    }
    
    public void NextScene()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
