using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool isRed;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (isRed == GameManager.Instance.ball.isRed)
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
        GameManager.Instance.destroyedBricks++;
        Destroy(gameObject, 0.1f);
    }
}
