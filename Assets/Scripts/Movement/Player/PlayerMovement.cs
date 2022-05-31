using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
    protected override void Move(){
        base.Move();
    }
    protected override void GetDirectionMove(){
        // Get Direction Player By Joystick
        if (characterController.isGrounded){
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }
    }
}
