using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : EntityMovement
{
    private GameObject target;
    protected override void Start(){
        base.Start();
        GetTarget("Player");
    }
    private void GetTarget(string name){
        target = GameObject.Find(name);
    }
    protected override void FixedUpdate(){
        base.FixedUpdate();
        
    }
    protected override void Update(){
        base.Update();
    }
    protected override void Move()
    {
        move = transform.forward * entityStats.CurrentMoveSpeed;
        move.y -= 4.9f*Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
        RotatePlayer();
    }
    protected void RotatePlayer(){
        float angle = AngleBetweenTwoPoints(transform.position, target.transform.position);
        transform.rotation = Quaternion.Euler(new Vector3(0f,(angle - 90f),0f));
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0f, (angle), 0)), Time.deltaTime);
    }
    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b) { 
        return Mathf.Atan2(a.z - b.z, a.x - b.x) * -Mathf.Rad2Deg;
    }
}
