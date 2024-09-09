using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
    public bool isRed; 
    private bool destroyed = false;

    private void Start()
    {
        GameManager.Instance.bricksCount++;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (isRed == other.gameObject.GetComponent<Ball>().isRed && !destroyed)
            {
                DestroyBrick();
            }
            else
            {
                
            }
        }
    }

    private void DestroyBrick()
    {
        destroyed = true;
        SoundsBaseCollection.Instance.brickSound.Play();
        if (Random.value >= 0.8)
        {
            GameObject spawnedBooster = Instantiate(
                GameManager.Instance.boosterPrefabs[Random.Range(0, GameManager.Instance.boosterPrefabs.Length)]);
            spawnedBooster.transform.position = transform.position;
            SoundsBaseCollection.Instance.bonusSound.Play();
        }
        
        GameManager.Instance.destroyedBricks++;

        GameManager.Instance.bricksText.text = "Блоков уничтожено: " + GameManager.Instance.destroyedBricks.ToString();
        GameManager.Instance.ballSpeed += 0.07f;
        GameManager.Instance.ballSpeed = Mathf.Clamp(GameManager.Instance.ballSpeed, 15f, 25f);
        
        if (GameManager.Instance.destroyedBricks >= GameManager.Instance.bricksCount)
        {
            GameManager.Instance.Win();
        }
        
        Destroy(gameObject, 0.1f);
    }
}
