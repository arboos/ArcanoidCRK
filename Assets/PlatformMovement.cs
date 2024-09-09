using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformMovement : MonoBehaviour
{
    [Range(5f, 20f), SerializeField] private float speed;
    
    
    public float deltaMovement;
    public bool movedYet = false;

    public bool mouseWasDown = false;
    
    public Vector3 currentMousePos;

    public Ball ballStart;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mouseWasDown = true;
            print("Mouse0");
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(Mathf.Clamp(currentMousePos.x, -15f, 15f), 0f, 0f);
        }
        else
        {
            if (ballStart != null && mouseWasDown && deltaMovement == 0 && !ballStart.isLaunched)
            {
                ballStart.Launch();
            }
        }
        //Movement
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + deltaMovement * Time.deltaTime * speed, -15f, 15f),
            0f, 
            0f);
        
        //Check if need to launch the ball
        
        if (ballStart != null && movedYet && deltaMovement == 0 && !ballStart.isLaunched)
        {
            ballStart.Launch();
        }
    }
    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        deltaMovement = ctx.ReadValue<float>();
        movedYet = true;
    }
    
}


