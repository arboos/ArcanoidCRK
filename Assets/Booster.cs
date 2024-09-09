using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, -5f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Activate();
            Destroy(gameObject);
        }
    }

    protected virtual void Activate()
    {
        
    }
}
