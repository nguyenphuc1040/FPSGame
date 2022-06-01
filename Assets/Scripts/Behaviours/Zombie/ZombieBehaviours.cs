using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviours : EntityBehaviours
{
    [SerializeField]
    private int damageAttack;
    private bool canAttack = true;
    protected override void Start(){
        base.Start();
    }
    protected override void Update(){
        base.Update();
    }
    protected override void Death(){
        base.Death();
        entityAS.mute = true;
        if (GamePlayController.instance != null) {
            GamePlayController.instance.AlertText("<color=#cf3636>KILLED</color> <color=#fff>1+ ZOMBIE</color>");
        }
    }
    protected override void GetHurt(int damage){
        base.GetHurt(damage);
    }
    public void GotHitByBullet(int damage){
        GetHurt(damage);
    }
    IEnumerator ReloadAttack(){
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
    // private void OnCollisionEnter(Collision other) {
    //     AttackPlayer(other.gameObject);
    // }
    private void OnCollisionStay(Collision other) {
        AttackPlayer(other.gameObject);
    }
    private void AttackPlayer(GameObject target){
        if (canAttack){
            if (target.tag == "Player"){
                canAttack = false;
                StartCoroutine(ReloadAttack());
                target.SendMessage("OnHurtByZombie",damageAttack);
            }
        }
    }
    public bool GetAlive(){
        return entityStats.IsAlive;
    }
}
