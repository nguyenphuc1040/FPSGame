using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviours : MonoBehaviour
{
    protected EntityStats entityStats;
    protected Animator entityAnimator;
    
    protected virtual void Start(){
        entityStats = gameObject.GetComponent<EntityStats>();
        entityAnimator = gameObject.GetComponent<Animator>();
        entityStats.CurrentHealthPoint = entityStats.MaxHealthPoint;
    }
    protected virtual void Update(){

    }
    protected virtual void Death(){
        entityAnimator.SetTrigger("Death");
    }
    protected virtual void GetHurt(int damage){
        if (entityStats.CurrentHealthPoint <= 0) return;
        entityStats.CurrentHealthPoint -= damage;
        if (entityStats.CurrentHealthPoint <= 0) {
            Death();
        }
    }
}
