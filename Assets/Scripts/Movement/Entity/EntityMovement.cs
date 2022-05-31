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
            float x = moveX * entityStats.MoveSpeed;
            float z = moveZ * entityStats.MoveSpeed;
            move = transform.right*x + transform.forward*z;
            if (Input.GetKeyDown(KeyCode.Space)){
                move.y = 4.5f;
            }
        }
        move.y -= 9.8f*Time.deltaTime;      
        characterController.Move(move*Time.deltaTime);
    }

    protected virtual void GetDirectionMove(){
        if (characterController.isGrounded) {
            // get x,y,z direction move;
        }
    }
}
