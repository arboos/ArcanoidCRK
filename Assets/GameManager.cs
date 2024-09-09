using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Transform playerTransform;
    public Ball ball;

    public int destroyedBricks;
    public float totalSpeed;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("One more GameManager by name: " + gameObject.name);
        }
    }
    
    
    
}

