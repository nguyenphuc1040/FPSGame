using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    private int bullet;
    private void Awake() {
        bullet = 300;
        SetInstance();
    }
    private void SetInstance(){
        if (instance == null) {
            instance = this;
        }
    }
    public int ReloadBullet(int maxBullet, int currentBullet){
        int count = maxBullet - currentBullet;
        if (bullet <= 0) {
            if (GamePlayUIController.instance != null) {
                GamePlayUIController.instance.AlertText("NO MORE BULLET",3);
            }
            return 0;
        }
        int result = 0;
        if (bullet - count < 0) {
            result = bullet;
            bullet = 0;
        } else {
            result = count;
            bullet -= count;
        }
        if (GamePlayUIController.instance != null){
            GamePlayUIController.instance.SetBulletStore(bullet);
        }
        return result;
    }
    public void ReceiveBullet(int count){
        bullet += count;
        if (GamePlayUIController.instance != null){
            GamePlayUIController.instance.AlertText($"<color=#00e06c>+{count} Bullet</color>",3);
            GamePlayUIController.instance.SetBulletStore(bullet);
        }
    }
}
