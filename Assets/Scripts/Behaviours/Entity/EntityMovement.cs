using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField]
    protected EntityStats entityStats;
    [SerializeField]
    protected CharacterController characterController;
    protected Vector3 move;
    protected float moveX, moveY, moveZ;

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        Move();
        GetDirectionMove();
    }

    protected virtual void Move(){
        
        if (characterController.isGrounded){
            float x = moveX * entityStats.MoveSpeed; // move left right
            float z = moveZ * entityStats.MoveSpeed; // move back forward
            move = transform.right*x + transform.forward*z;
            move.y = moveY;
        }
        move.y -= 4.9f*Time.deltaTime; // Gravity acceleration
        characterController.Move(move*Time.deltaTime);
        moveY = 0;
    }

    protected virtual void GetDirectionMove(){
        if (characterController.isGrounded) {
            // get x,y,z direction move;
        }
    }
}
