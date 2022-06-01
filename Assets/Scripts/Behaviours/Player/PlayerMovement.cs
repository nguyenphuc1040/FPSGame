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
    private PlayerBehaviours playerBehaviours;
    protected override void Start()
    {
        base.Start();
        InitComponent();
        StartCoroutine(FootFake());
    }
    private void InitComponent(){
        playerBehaviours = gameObject.GetComponent<PlayerBehaviours>();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void Move(){
        base.Move();
        RotatePlayer();
    }
    IEnumerator FootFake(){
        yield return new WaitForSeconds(0.3f * entityStats.MoveSpeed/entityStats.CurrentMoveSpeed);
        if (moveX != 0 || moveZ != 0){
            if (characterController.isGrounded){
                playerBehaviours.OnRunning();       
            }
        }
        StartCoroutine(FootFake());
    }
    protected override void GetDirectionMoveMoblie(){
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
    protected override void GetDirectionMovePC()
    {
        // return; // disable move in pc
        if (characterController.isGrounded){
            Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            move.Normalize();
            moveX = move.x;
            moveZ = move.y;
            if (Input.GetKeyDown(KeyCode.Space)){
                moveY = entityStats.JumpForce;
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
