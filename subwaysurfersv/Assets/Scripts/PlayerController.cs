using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private UnityEngine.Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    public float laneDistance = 4;
    public float JumpForce;
    public float Gravity= -20;
    private Touch touch;
    private UnityEngine.Vector2 initPos;
    private UnityEngine.Vector2 endPos;
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        direction.z = forwardSpeed;
        direction.y += Gravity * Time.deltaTime;

        
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        } 

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        ////////////////////////////    TOUUUUUUUUUUUCH 
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                initPos = touch.position;


            }
            if (touch.phase == TouchPhase.Moved)
            {
                endPos = touch.position;

            }
            if (touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;
                if ((endPos.y - initPos.y) > 300)
                {
                    Debug.Log("jump");
                    Jump();
                }
                if ((endPos.x - initPos.x) > 100)
                {
                    Debug.Log("right");
                    desiredLane++;
                    if (desiredLane == 3)
                        desiredLane = 2;
                }
                if((initPos.x - endPos.x) > 100)
                {
                    Debug.Log("left");
                    desiredLane--;
                    if (desiredLane == -1)
                        desiredLane = 0;
                }
            }
        }

        UnityEngine.Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0) 
            targetPosition += UnityEngine.Vector3.left * laneDistance;
        
        else if  (desiredLane == 2)
            targetPosition += UnityEngine.Vector3.right * laneDistance;
        
        transform.position = targetPosition;
        controller.center = controller.center;
    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = JumpForce;

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "obstacle")
        {
            PlayerManager.gameOver = true;
        }


    }
}