using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class GamePlayUIController : MonoBehaviour
{
    public static GamePlayUIController instance;
    public Text txtFps, txtBulletGun, txtBulletStore, titleGameOver, txtMissionContent;
    public int fps = 0;
    public PercentBarCanvas playerHealthPercent;
    private AudioSource asGameCtrl;
    public AudioClip acHeadShot, acVictory;
    public Transform tfAlert;
    public GameObject alertHeadShot, alertText;
    public GameObject pnlGameOver, pnlGameWin, pnlMission;
    public Image pnlScreenWarningDamage;
    private Color32 colorDamageScreen;
    private int damageScreen;
    public bool isGameOver = false;
    private void Awake() {
        SetInstance();
    }
    private void Start() {
        InitGetComponent();
        StartCoroutine(ShowFPS());
        StartCoroutine(DecreaseDamageScreen());
    }
    private void FixedUpdate() {
        ScreenWarningDamage();
    }
    private void InitGetComponent(){
        asGameCtrl = gameObject.GetComponent<AudioSource>();     
        colorDamageScreen = pnlScreenWarningDamage.color;
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
    public void AlertText(string content, float timing){
        GameObject alert = Instantiate(alertText, tfAlert);
        TextAlert alertCpn = alert.GetComponent<TextAlert>();
        alertCpn.SetContent(content);
        Destroy(alert,timing);
    }
    public void SetMissionInfo(int level, string time, int kill){
        txtMissionContent.text = @$"
            LEVEL {level + 1}
            Hãy nhìn xung quanh bầu trời, sẽ có 1 tia sáng chiếu lên và đó là đích đến của bạn
            Nhiệm vụ của bạn là tiêu diệt ít nhất {kill} Zombie và đến đích thành công trong vòng {time} / Phút:Giây
            Trên đường đi có những chòm sáng xanh, đó là nơi bạn có thể lấy thêm đạn cho súng
        ";
        MissionShow(true);
    }
    public void MissionShow(bool b){
        if (b) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
        pnlMission.SetActive(b);
    }
    public void GameWin(){
        pnlGameWin.SetActive(true);
        asGameCtrl.PlayOneShot(acVictory);
        Time.timeScale = 0;
    }
    public void GameOver(string content){
        if (isGameOver) return;
        isGameOver = true;
        titleGameOver.text = content;
        pnlGameOver.SetActive(true);
    }
    private void ScreenWarningDamage(){
        pnlScreenWarningDamage.color = new Color32(
            colorDamageScreen.r,
            colorDamageScreen.g,
            colorDamageScreen.b,
            (byte)damageScreen
        );
    }
    public void SetScreenDamage(int value){
        damageScreen = value;
    }
    IEnumerator DecreaseDamageScreen(){
        yield return new WaitForSeconds(0.1f);
        damageScreen = damageScreen - 15 < 0 ? 0 : damageScreen - 15;
        StartCoroutine(DecreaseDamageScreen());
    }
    public void PlayAgain(){
        if (GameManager.instance != null) {
            GameManager.instance.LoadScene(2);
        }

    }
}
