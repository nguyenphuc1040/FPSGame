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
        zombieBehaviours.GotHitByBullet(damage * percentDamge/100);
    }
}
