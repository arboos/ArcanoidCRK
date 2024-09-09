using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformMovement : MonoBehaviour
{
    [Range(5f, 20f), SerializeField] private float speed;
    
    
    private float deltaMovement;
    private bool movedYet = false;

    private bool mouseWasDown = false;

    public Vector3 lastMousePos;
    public Vector3 currentMousePos;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mouseWasDown = true;
            print("Mouse0");
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = new Vector3(Mathf.Clamp(currentMousePos.x, -15f, 15f), 0f, 0f);
            // if (lastMousePos == Vector3.zero)
            // {
            //     lastMousePos = currentMousePos;
            // }
            // else
            // {
            //     deltaMovement = currentMousePos.x - lastMousePos.x;
            // }
            //
            // lastMousePos = currentMousePos;
        }
        else
        {
            lastMousePos = Vector3.zero;
            if (mouseWasDown && deltaMovement == 0 && !GameManager.Instance.ball.isLaunched)
            {
                GameManager.Instance.ball.Launch();
            }
        }
        //Movement
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + deltaMovement * Time.deltaTime * speed, -15f, 15f),
            0f, 
            0f);
        
        //Check if need to launch the ball
        if (movedYet && deltaMovement == 0 && !GameManager.Instance.ball.isLaunched)
        {
            GameManager.Instance.ball.Launch();
        }
    }
    
    public void OnMove(InputAction.CallbackContext ctx)
    {
        deltaMovement = ctx.ReadValue<float>();
        movedYet = true;
    }
    
}


