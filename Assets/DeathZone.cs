using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.ballsActive.Remove(other.GetComponent<Ball>());
            Destroy(other.gameObject);

            if (GameManager.Instance.ballsActive.Count == 0)
            {
                GameManager.Instance.TakeHealth(1);
            }
        }
    }
}
