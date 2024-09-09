using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour
{
    public bool isRed;

    private void Start()
    {
        GameManager.Instance.bricksCount++;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (isRed == other.gameObject.GetComponent<Ball>().isRed)
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
        SoundsBaseCollection.Instance.brickSound.Play();
        if (Random.value >= 0.8)
        {
            GameObject spawnedBooster = Instantiate(
                GameManager.Instance.boosterPrefabs[Random.Range(0, GameManager.Instance.boosterPrefabs.Length)]);
            spawnedBooster.transform.position = transform.position;
            SoundsBaseCollection.Instance.bonusSound.Play();
        }
        GameManager.Instance.destroyedBricks++;

        if (GameManager.Instance.destroyedBricks == GameManager.Instance.bricksCount)
        {
            GameManager.Instance.Win();
        }
        
        Destroy(gameObject, 0.1f);
    }
}
