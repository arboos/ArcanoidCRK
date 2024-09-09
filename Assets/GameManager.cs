using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game")]
    public Transform playerTransform;
    public Ball ballPrefab;
    public List<Ball> ballsActive;

    public int currentHealth;

    public int destroyedBricks;
    public int bricksCount;
    
    public int ballActiveCount;
    public float totalSpeed;

    public float ballSpeed;

    public GameObject[] boosterPrefabs;

    [SerializeField] private TextMeshPro healthText;
    public TextMeshPro bricksText;



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

    private void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        Ball ballSpawned = Instantiate(ballPrefab);
        ballSpawned.gameObject.transform.position = new Vector3(0f, -18f, 0f);
        playerTransform.GetComponent<PlatformMovement>().ballStart = ballSpawned;
        ballsActive.Add(ballSpawned);

        playerTransform.GetComponent<PlatformMovement>().movedYet = false;
        playerTransform.GetComponent<PlatformMovement>().mouseWasDown = false;
        playerTransform.GetComponent<PlatformMovement>().deltaMovement = 0;
    }

    public void TakeHealth(int count)
    {
        currentHealth -= count;
        healthText.text = "Жизни: " + currentHealth.ToString();
        SoundsBaseCollection.Instance.damageSound.Play();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
        else
        {
            SpawnBall();
        }
    }

    public void Death()
    {
        UIManager.Instance.LoseWindow.SetActive(true);
        SoundsBaseCollection.Instance.loseSound.Play();
    }

    public async void Win()
    {
        foreach (var ball in ballsActive)
        {
            ball.gameObject.SetActive(false);
        }
        
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        
        UIManager.Instance.WinWindow.SetActive(true);
        SoundsBaseCollection.Instance.soundtrack.Pause();
        SoundsBaseCollection.Instance.winSound.Play();
    }
}

