using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.LogError("One more SoundsBaseCollection by name: " + gameObject.name);
        }
    }

    public AudioSource brickSound;
    public AudioSource buttonSound;
    public AudioSource bonusSound;
    public AudioSource damageSound;
    public AudioSource winSound;
    public AudioSource loseSound;
}
