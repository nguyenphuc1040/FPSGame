using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviours : EntityBehaviours
{
    private bool canAttack;
    protected override void Start(){
        base.Start();
        StartCoroutine(ReloadAttack());
    }
    protected override void Update(){
        base.Update();
    }
    protected override void Death(){
        base.Death();
    }
    protected override void GetHurt(int damage){
        base.GetHurt(damage);
    }
    public void GotHitByBullet(int damage){
        GetHurt(damage);
    }
    IEnumerator ReloadAttack(){
        canAttack = true;
        yield return new WaitForSeconds(3f);
        StartCoroutine(ReloadAttack());
    }
    private void OnCollisionEnter(Collision other) {
        AttackPlayer(other.gameObject.tag);
    }
    private void OnCollisionStay(Collision other) {
        AttackPlayer(other.gameObject.tag);
    }
    private void AttackPlayer(string tag){
        if (canAttack){
            if (tag == "Player"){
                Debug.Log("dâmge");
            }
        }
    }
}
