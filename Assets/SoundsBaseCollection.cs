using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundsBaseCollection : MonoBehaviour
{
    public static SoundsBaseCollection Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource brickSound;
    public AudioSource buttonSound;
    public AudioSource bonusSound;
    public AudioSource damageSound;
    public AudioSource wallSound;
    public AudioSource winSound;
    public AudioSource loseSound;
    public AudioSource soundtrack;

    private void Start()
    {
        soundtrack.Play();
        Button[] buttons = GameObject.FindObjectsOfType<Button>(includeInactive:true);

        foreach (var button in buttons)
        {
            button.onClick.AddListener(delegate { SoundsBaseCollection.Instance.buttonSound.Play();});
            print("ButtonInit");
        }
        
        SceneManager.activeSceneChanged += SetButtonSound;
    }

    private void SetButtonSound(Scene current, Scene next)
    {
        Button[] buttons = GameObject.FindObjectsOfType<Button>(includeInactive:true);

        foreach (var button in buttons)
        {
            button.onClick.AddListener(delegate { SoundsBaseCollection.Instance.buttonSound.Play();});
            print("ButtonInit");
        }
    }
}
