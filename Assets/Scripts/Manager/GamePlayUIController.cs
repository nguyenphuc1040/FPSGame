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
    public GameObject pnlGameOver, pnlGameWin, pnlMission, btnNextLevel;
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
            <size=105>LEVEL {level + 1}</size>
            Hãy nhìn xung quanh bầu trời, sẽ có <color=#a83232>1 tia sáng chiếu lên</color> và đó là đích đến của bạn
            Nhiệm vụ của bạn là tiêu diệt ít nhất <color=#a83232>{kill} Zombie </color> và đến đích thành công trong vòng {time} phút
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
    public void GameWin(int level){
        pnlGameWin.SetActive(true);
        asGameCtrl.PlayOneShot(acVictory);
        if (GameManager.instance != null){
            if (level < GameManager.instance.maxLevel){
                GameManager.instance.SetLevelUnlock(level+1,true);
            } else {
                btnNextLevel.SetActive(false);
            }
        }
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
    public void NextLevel(){
        if (GameManager.instance != null){
            GameManager.instance.NextLevel();
        }
    }
}
