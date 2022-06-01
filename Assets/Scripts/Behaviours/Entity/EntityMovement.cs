using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    protected EntityStats entityStats;
    protected EntityBehaviours entityBehaviours;
    protected CharacterController characterController;
    protected Vector3 move;
    protected float moveX, moveY, moveZ;

    protected virtual void Start()
    {
        InitComponent();
    }
    private void InitComponent(){
        characterController = gameObject.GetComponent<CharacterController>();
        entityStats = gameObject.GetComponent<EntityStats>();
        entityBehaviours = gameObject.GetComponent<EntityBehaviours>();
        entityStats.CurrentMoveSpeed = entityStats.MoveSpeed;
    }
    protected virtual void FixedUpdate(){
        if (!entityStats.IsAlive) return;
    }
    protected virtual void Update()
    {
        if (!entityStats.IsAlive) return;
        GetDirectionMoveMoblie();
        GetDirectionMovePC();
        Move();
    }

    protected virtual void Move(){
        
        if (characterController.isGrounded){
            float x = moveX * entityStats.CurrentMoveSpeed; // move left right
            float z = moveZ * entityStats.CurrentMoveSpeed; // move back forward
            move = transform.right*x + transform.forward*z;
            move.y = moveY;
        }
        move.y -= 4.9f*Time.deltaTime; // Gravity acceleration
        characterController.Move(move*Time.deltaTime);
        moveY = 0;
    }

    protected virtual void GetDirectionMoveMoblie(){
        if (characterController.isGrounded) {
            // get x,y,z direction move;
        }
    }
    protected virtual void GetDirectionMovePC(){
        if (characterController.isGrounded) {
            // get x,y,z direction move;
        }
    }
}
