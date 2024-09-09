using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [Header("Ball stats")]
    public float Speed;

    [Header("Other")] 
    [SerializeField] private Material RedMaterial; 
    [SerializeField] private Material BlueMaterial;
    
    [HideInInspector] public bool isRed;
    [HideInInspector] public bool isLaunched;

    private Rigidbody ballRigidbody;
    private MeshRenderer ballMeshRenderer;

    private void Start()
    {
        ballMeshRenderer = GetComponent<MeshRenderer>();
        
        ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = true;
    }

    private void Update()
    {
        if (!isLaunched)
        {
            transform.position = new Vector3(GameManager.Instance.playerTransform.position.x, transform.position.y, transform.position.z);
        }
        print(Mathf.Sqrt(ballRigidbody.velocity.x * ballRigidbody.velocity.x + ballRigidbody.velocity.y * ballRigidbody.velocity.y));
    }

    public void Launch()
    {
        ballRigidbody.isKinematic = false;
        Vector3 startVector = new Vector3(Random.Range(-3f, 3f), 1f, 0f);
        startVector.Normalize();
        ballRigidbody.velocity = (startVector * Speed);
        isLaunched = true;
        print("launch()");
    }
    
    public void ChangeColor()
    {
        isRed = !isRed;
        ballMeshRenderer.material = isRed ? RedMaterial : BlueMaterial;
    }
    
    public void ChangeColor(bool isRedColor)
    {
        isRed = isRedColor;
        ballMeshRenderer.material = isRed ? RedMaterial : BlueMaterial;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if(other.gameObject.name == "Platform_Top") ChangeColor(false);
            else ChangeColor(true);
            ballRigidbody.velocity = ((transform.position - other.transform.position).normalized * Speed);
        }
    }
}
