using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    [Header("UI")]
    public GameObject WinWindow;
    public GameObject LoseWindow;
    public GameObject PauseWindow;
    
    public GameObject PauseButton;
    
    public static UIManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("One more UIManager by name: " + gameObject.name);
        }
    }
    
    
    public void Pause()
    {
        if (PauseWindow.activeSelf)
        {
            PauseButton.SetActive(true);
            PauseWindow.SetActive(false);
            
            Time.timeScale = 1;
            SoundsBaseCollection.Instance.soundtrack.Play();
        }
        else
        {
            PauseButton.SetActive(false);
            PauseWindow.SetActive(true);

            Time.timeScale = 0f;
            SoundsBaseCollection.Instance.soundtrack.Pause();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SoundsBaseCollection.Instance.soundtrack.Play();
        SoundsBaseCollection.Instance.winSound.Stop();
        SoundsBaseCollection.Instance.loseSound.Stop();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadScene(int index)
    {
        Time.timeScale = 1;
        SoundsBaseCollection.Instance.soundtrack.Play();
        SoundsBaseCollection.Instance.winSound.Stop();
        SoundsBaseCollection.Instance.loseSound.Stop();

        SceneManager.LoadScene(index);
    }
    
    public void NextScene()
    {
        Time.timeScale = 1;
        SoundsBaseCollection.Instance.soundtrack.Play();
        SoundsBaseCollection.Instance.winSound.Stop();
        SoundsBaseCollection.Instance.loseSound.Stop();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
