using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviours : EntityBehaviours
{
    public PointerButton eventShoot;
    public PointerButton eventReload;
    public GunControl gunAkControl;
    public Camera mainCamera;
    public AudioClip acHurt, acDeath, acRun;
    protected override void Start(){
        base.Start();
        SetUpUI();
    }
    private void SetUpUI(){
        SetHealthPercentUI();
    }
    private void SetHealthPercentUI(){
        if (GamePlayUIController.instance != null){
            GamePlayUIController.instance.SetPlayerHealthPercent((float)entityStats.CurrentHealthPoint/ (float)entityStats.MaxHealthPoint);
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
        if (GamePlayUIController.instance != null){
            GamePlayUIController.instance.GameOver();
        }
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
            entityStats.CurrentMoveSpeed = entityStats.MoveSpeed/2;
        } else {
            entityAnimator.SetBool("Shoot", false);
            entityStats.CurrentMoveSpeed = entityStats.MoveSpeed;
        }
    }
    public void EventReload(){
        if (eventReload.isPressing){
            eventReload.isPressing = false;
            if (gunAkControl.IsFullBullet()) {
                return;
            }
            entityAnimator.SetTrigger("Reload");
            gunAkControl.gunAnimator.SetTrigger("Reload");
        }
    }
    public void OnHurtByZombie(int damage){
        GetHurt(damage);
        SetHealthPercentUI();
    }
    public void OnRunning(){
        entityAS.PlayOneShot(acRun);
    }
    public void ReceiveBullet(int count){
        if (WeaponManager.instance != null) {
            WeaponManager.instance.ReceiveBullet(count);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "ItemSupport"){
            other.gameObject.SendMessage("ReceiveItem", this.gameObject);
        }
        if (other.gameObject.tag == "Endpoint"){
            if (GamePlayUIController.instance != null){
                GamePlayUIController.instance.GameWin();
            }
        }
    }
}
