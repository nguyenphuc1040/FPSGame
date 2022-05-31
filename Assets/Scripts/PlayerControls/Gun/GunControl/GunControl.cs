using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Animator gunAnimator;
    public AudioSource asGun;
    public AudioClip acShoot, acReload;
    public PointerButton eventShoot;
    void Start()
    {
        
    }
    void Update()
    {
        EventShooting();   
    }
    public void EventShooting(){
        if (eventShoot.isPressing){
            gunAnimator.SetBool("Shoot", true);
        } else {
            gunAnimator.SetBool("Shoot", false);
        }
    }
    public void Shoot(){
        asGun.PlayOneShot(acShoot);
    }
}
