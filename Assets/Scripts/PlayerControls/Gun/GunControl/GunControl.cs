using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Animator gunAnimator;
    public AudioSource asGun;
    public AudioClip acShoot, acReload;
    public PointerButton eventShoot;
    public Transform tfBarrel;
    public GameObject bullet;
    public bool canPress = true;
    void Start()
    {
        
    }
    void Update()
    {
        if (!canPress) return;
        EventShooting();   
        Raycast();
    }
    public void Raycast(){
    }
    public void EventShooting(){
        if (eventShoot.isPressing){
            gunAnimator.SetBool("Shoot", true);
        } else {
            gunAnimator.SetBool("Shoot", false);
        }
    }
    public void Shoot(){
        if (!canPress) return;
        asGun.PlayOneShot(acShoot);
        Instantiate(bullet, tfBarrel.position, tfBarrel.rotation);
    }
    public void Reload(){
        if (!canPress) return;
        asGun.PlayOneShot(acReload);
    }
}
