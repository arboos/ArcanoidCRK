using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterMultiply : Booster
{

    public int MultiplierRate;
    protected override void Activate()
    {
        List<Ball> balls = new List<Ball>();
        List<Ball> ballsTemp = new List<Ball>();
        balls = GameManager.Instance.ballsActive;
        
        for (int i = 1; i < MultiplierRate; i++)
        {
            foreach (var ball in balls)
            {
                Ball spawnedBall = Instantiate(GameManager.Instance.ballPrefab);
                spawnedBall.transform.position = ball.transform.position;
                Rigidbody spawnedBallRigidbody = spawnedBall.GetComponent<Rigidbody>();
                spawnedBallRigidbody.isKinematic = false;
                spawnedBall.isLaunched = true;
                Vector3 ballVelocity = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0f);
                ballVelocity.Normalize();
                spawnedBallRigidbody.velocity = ballVelocity * GameManager.Instance.ballSpeed;
                spawnedBall.ChangeColor(ball.isRed);
                ballsTemp.Add(spawnedBall);
            }
        }
        
        foreach (var ballTemp in ballsTemp)
        {
            GameManager.Instance.ballsActive.Add(ballTemp);
        }
    }
}
