using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    [SerializeField]
    private Joystick joystickMove;
    [SerializeField]
    private ScreenDrag dragRotatePlayer;
    [SerializeField]
    private ScreenDrag dragRotateGunShot;
    [SerializeField]
    private PointerButton pointerJump;
    [SerializeField]
    private PointerButton pointerShoot;
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
            Vector2 move = new Vector2(joystickMove.Horizontal, joystickMove.Vertical);
            move.Normalize();
            moveX = move.x;
            moveZ = move.y;
            if (pointerJump.isPressing){
                moveY = entityStats.JumpForce;
                pointerJump.isPressing = false;
            }
        }
    }
    private void RotatePlayer(){
        // Prioritize rotating according to the fire button
        if (pointerShoot.isPressing){
            // Rotate character by drag button shoot
            xRotation -= dragRotateGunShot.X * Time.deltaTime * 5f;
            yRotation -= dragRotateGunShot.Y * Time.deltaTime * 5f;
        } else {
            // Rotate character by drag screen
            xRotation -= dragRotatePlayer.X * Time.deltaTime;
            yRotation -= dragRotatePlayer.Y * Time.deltaTime;
        }
        
        
        
        yRotation = Mathf.Clamp(yRotation, -50f, 50f);
        transform.localRotation = Quaternion.Euler(yRotation, -xRotation,0f);
    }
}
