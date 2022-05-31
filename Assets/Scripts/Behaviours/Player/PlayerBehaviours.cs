using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : EntityBehaviours
{
    public PointerButton eventShoot;
    public Camera mainCamera;
    protected override void Start(){
        base.Start();
    }
    protected override void Update(){
        base.Update();
        EventShooting();
    }
    protected override void Death(){
        base.Death();
    }
    public void EventShooting(){
        if (eventShoot.isPressing){
            entityAnimator.SetBool("Shoot", true);
        } else {
            entityAnimator.SetBool("Shoot", false);
        }
    }
}
