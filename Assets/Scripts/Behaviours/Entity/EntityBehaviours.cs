using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviours : MonoBehaviour
{
    [SerializeField]
    protected Animator entityAnimator;
    
    protected virtual void Start(){

    }
    protected virtual void Update(){

    }
    protected virtual void Death(){
        entityAnimator.SetTrigger("Died");
    }
}
