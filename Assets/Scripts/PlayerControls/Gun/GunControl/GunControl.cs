using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Animator gunAnimator;
    public AudioSource asGun;
    public AudioClip acShoot, acReload, acNoMoreBullet;
    public PointerButton eventShoot;
    public Transform tfBarrel;
    public GameObject bullet;
    public bool canPress = true;
    [SerializeField]
    private int maxBulletCount;
    private int bulletCount;
    void Start()
    {
        InitGun();
    }
    private void InitGun(){
        bulletCount = maxBulletCount;
        SetGunUI();
    }
    private void FixedUpdate() {
        if (!canPress) return;
        EventShooting();   
    }
    void Update()
    {
        if (!canPress) return;
    }
    public void EventShooting(){
        if (eventShoot.isPressing){
            if (bulletCount <= 0) {
                gunAnimator.SetBool("Shoot", false);
                eventShoot.isPressing = false;
                asGun.PlayOneShot(acNoMoreBullet);
                return;
            }
            gunAnimator.SetBool("Shoot", true);
        } else {
            gunAnimator.SetBool("Shoot", false);
        }
    }
    private void SetGunUI(){
        if (GamePlayUIController.instance != null) {        
            GamePlayUIController.instance.SetBulletGun($"{bulletCount}/{maxBulletCount}");
        }
    }
    public void Shoot(){
        if (!canPress) return;
        if (bulletCount <= 0) return;
        asGun.PlayOneShot(acShoot);
        bulletCount--;
        SetGunUI();
        Instantiate(bullet, tfBarrel.position, tfBarrel.rotation);
    }
    public void Reload(){
        if (!canPress) return;
        if (WeaponManager.instance != null){
            int res = WeaponManager.instance.ReloadBullet(maxBulletCount, bulletCount);
            bulletCount += res;
            SetGunUI();
            asGun.PlayOneShot(acReload);
        }
    }
}
