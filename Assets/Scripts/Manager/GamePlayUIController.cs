using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    public static GamePlayUIController instance;
    public Text txtFps, txtBulletGun, txtBulletStore;
    public int fps = 0;
    public PercentBarCanvas playerHealthPercent;
    private AudioSource asGameCtrl;
    public AudioClip acHeadShot;
    public Transform tfAlert;
    public GameObject alertHeadShot, alertText;
    private void Awake() {
        SetInstance();
    }
    private void Start() {
        InitGetComponent();
        StartCoroutine(ShowFPS());
    }
    private void InitGetComponent(){
        asGameCtrl = gameObject.GetComponent<AudioSource>();        
    }
    private void SetInstance(){
        instance = this;
    }
    IEnumerator ShowFPS(){
        fps = (int)(1 / Time.smoothDeltaTime);
        txtFps.text = "FPS: " + fps;
        yield return new WaitForSeconds(1f);
        StartCoroutine(ShowFPS());
    }
    public void SetPlayerHealthPercent(float percent){
        playerHealthPercent.SetPercentUI(percent);
    }
    public void SetBulletStore(int count){
        txtBulletStore.text = count + "";
    }
    public void SetBulletGun(string content){
        txtBulletGun.text = content;
    }
    public void AlertHeadShot(){
        GameObject alert = Instantiate(alertHeadShot, tfAlert);
        Destroy(alert,2.5f);
        asGameCtrl.PlayOneShot(acHeadShot);
    }
    public void AlertText(string content){
        GameObject alert = Instantiate(alertText, tfAlert);
        TextAlert alertCpn = alert.GetComponent<TextAlert>();
        alertCpn.SetContent(content);
        Destroy(alert,2.5f);
    }
}
