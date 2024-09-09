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
        }
        else
        {
            Debug.LogError("One more SoundsBaseCollection by name: " + gameObject.name);
        }
    }

    public AudioSource brickBrokeSound;
}
