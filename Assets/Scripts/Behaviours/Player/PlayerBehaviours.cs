using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : EntityBehaviours
{
    public PointerButton eventShoot;
    public PointerButton eventReload;
    public GunControl gunAkControl;
    public Camera mainCamera;
    public AudioClip acHurt, acDeath;
    protected override void Start(){
        base.Start();
        SetUpUI();
    }
    private void SetUpUI(){
        SetHealthPercentUI();
    }
    private void SetHealthPercentUI(){
        if (GamePlayController.instance != null){
            GamePlayController.instance.SetPlayerHealthPercent((float)entityStats.CurrentHealthPoint/ (float)entityStats.MaxHealthPoint);
        }
    }
    protected override void Update(){
        base.Update();
        EventShooting();
        EventReload();
    }
    protected override void Death(){
        if (!entityStats.IsAlive) return;
        base.Death();
        entityAS.PlayOneShot(acDeath);
        // disable Gun Shoot and Change CameraView
        gunAkControl.canPress = false;
        gunAkControl.gunAnimator.SetTrigger("Death");
    }
    protected override void GetHurt(int damage)
    {
        if (!entityStats.IsAlive) return;
        base.GetHurt(damage);
        entityAS.PlayOneShot(acHurt);
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
    public void OnHurtByZombie(int damage){
        GetHurt(damage);
        SetHealthPercentUI();
    }
}
