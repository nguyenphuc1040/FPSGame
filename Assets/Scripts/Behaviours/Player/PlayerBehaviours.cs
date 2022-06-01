using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : EntityBehaviours
{
    public PointerButton eventShoot;
    public PointerButton eventReload;
    public GunControl gunAkControl;
    public Camera mainCamera;
    protected override void Start(){
        base.Start();
    }
    protected override void Update(){
        base.Update();
        EventShooting();
        EventReload();
    }
    protected override void Death(){
        base.Death();
    }
    protected override void GetHurt(int damage)
    {
        base.GetHurt(damage);
        
    }
    public void EventShooting(){
        if (eventShoot.isPressing){
            entityAnimator.SetBool("Shoot", true);
        } else {
            entityAnimator.SetBool("Shoot", false);
        }
    }
    public void EventReload(){
        if (eventReload.isPressing){
            entityAnimator.SetTrigger("Reload");
            gunAkControl.gunAnimator.SetTrigger("Reload");
            eventReload.isPressing = false;
        }
    }
}
