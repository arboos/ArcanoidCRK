using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPlus : Booster
{
    public int PlusRate;
    protected override void Activate()
    {
        for (int i = 1; i <= PlusRate; i++)
        {
            Ball spawnedBall = Instantiate(GameManager.Instance.ballPrefab);
            spawnedBall.transform.position = GameManager.Instance.ballsActive[0].transform.position;
            Rigidbody spawnedBallRigidbody = spawnedBall.GetComponent<Rigidbody>();
            spawnedBallRigidbody.isKinematic = false;
            spawnedBall.isLaunched = true;
            Vector3 ballVelocity = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0f);
            ballVelocity.Normalize();
            spawnedBallRigidbody.velocity = ballVelocity * GameManager.Instance.ballSpeed;
            spawnedBall.ChangeColor(GameManager.Instance.ballsActive[0].isRed);
            
            GameManager.Instance.ballsActive.Add(spawnedBall);
        }
    }
}
