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
        EventZombieSpawn();
    }
    private void EventZombieSpawn(){
        if (LevelManager.instance != null){
            if (LevelManager.instance.currentZombie % 7 == 0){
                entityStats.CurrentMoveSpeed *= 1.5f;
                entityAnimator.SetFloat("Walk",entityStats.CurrentMoveSpeed);
            }
        }
    }
    protected override void Update(){
        base.Update();
    }
    protected override void Death(){
        base.Death();
        entityAS.mute = true;
        if (GamePlayUIController.instance != null) {
            GamePlayUIController.instance.AlertText("<color=#cf3636>KILLED</color> <color=#fff>1+ ZOMBIE</color>",2.5f);
        }
        if (LevelManager.instance != null) {
            LevelManager.instance.currentZombie --;
            LevelManager.instance.IncreaseKilledCount(1);
        }
        Destroy(gameObject, 10f);
    }
    protected override void GetHurt(int damage){
        base.GetHurt(damage);
    }
    public void GotHitByBullet(int damage){
        GetHurt(damage);
    }
    IEnumerator ReloadAttack(){
        yield return new WaitForSeconds(0.3f);
        canAttack = true;
    }
    private void OnCollisionStay(Collision other) {
        AttackPlayer(other.gameObject);
    }
    private void OnTriggerStay(Collider other) {
        AttackPlayer(other.gameObject);
    }
    private void AttackPlayer(GameObject target){
        if (!entityStats.IsAlive) return;
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
