using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviours : MonoBehaviour
{
    protected EntityStats entityStats;
    protected Animator entityAnimator;
    protected AudioSource entityAS;
    protected virtual void Start(){
        InitGetComponent();
    }
    private void InitGetComponent(){
        entityAS = gameObject.GetComponent<AudioSource>();
        entityStats = gameObject.GetComponent<EntityStats>();
        entityAnimator = gameObject.GetComponent<Animator>();
        entityStats.CurrentHealthPoint = entityStats.MaxHealthPoint;
    }
    protected virtual void Update(){

    }
    protected virtual void Death(){
        entityStats.IsAlive = false;
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
