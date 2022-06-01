using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCollider : MonoBehaviour
{
    [SerializeField]
    private ZombieBehaviours zombieBehaviours;
    [SerializeField]
    private int percentDamge;
    public void GotHitByBullet(int damage){
        if (!zombieBehaviours.GetAlive()) return;
        if (percentDamge >= 100) {
            if (GamePlayController.instance != null){
                GamePlayController.instance.AlertHeadShot();
            }
        }
        zombieBehaviours.GotHitByBullet(damage * percentDamge/100);
    }
}
