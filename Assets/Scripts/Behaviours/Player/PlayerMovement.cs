using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    [SerializeField]
    private Joystick joystickMove;
    [SerializeField]
    private ScreenDrag dragRotatePlayer;
    private float xRotation = 0f;
    private float yRotation = 0f;
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
        RotatePlayer();
    }
    protected override void GetDirectionMove(){
        // Get Direction Player By Joystick
        if (characterController.isGrounded){
            moveX = joystickMove.Horizontal;
            moveZ = joystickMove.Vertical;
        }
    }
    private void RotatePlayer(){
        xRotation -= dragRotatePlayer.X * Time.deltaTime;
        yRotation -= dragRotatePlayer.Y * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -50f, 50f);
        transform.localRotation = Quaternion.Euler(yRotation, -xRotation,0f);
    }
}
