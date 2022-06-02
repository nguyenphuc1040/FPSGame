using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TimeUtils.TimeConvert;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField]
    private List<int> timeCountLevel = new List<int>();
    [SerializeField]
    private List<int> killCountLevel = new List<int>();
    public Text txtKilled, txtTiming, txtKillMission;
    public int level, killedCount, timeCount, killCountMission;
    private AudioSource audioSource;
    public AudioClip acWarning;
    public int maxZombie = 30, currentZombie = 0;
    [SerializeField]
    private List<Transform> listEndPoint = new List<Transform>();
    [SerializeField]
    private GameObject endPoint;
    private void Awake() {
        SetInstance();
    }
    private void SetInstance(){
        if (instance == null){
            instance = this;
        }
    }
    void Start()
    {
        GetInfoLevel();
        InitComponent();
        StartCoroutine(TimeCountDown());
    }
    private void GetInfoLevel(){
        if (GameManager.instance != null) {
            level = GameManager.instance.Level;
            timeCount = timeCountLevel[level];
            killCountMission = killCountLevel[level];
            txtKillMission.text = $"KILL AT LEAST {killCountMission} ZOMBIES";
            Instantiate(endPoint, listEndPoint[level].position, Quaternion.identity);
        }
        if (GamePlayUIController.instance != null){
            GamePlayUIController.instance.SetMissionInfo(level, IntToTime(timeCountLevel[level]), killCountLevel[level]);
        }
    }
    private void InitComponent(){
        audioSource = GetComponent<AudioSource>();
    }
    private void SetUpStatsLevel(){
        killedCount = 0;
        txtKilled.text = killedCount + "";
    }
    IEnumerator TimeCountDown(){
        yield return new WaitForSeconds(1f);
        if (timeCount <= 0) {
            if (GamePlayUIController.instance != null){
                GamePlayUIController.instance.GameOver("YOU LOST BY TIME OUT");
            }
        } else {
            timeCount--;
            txtTiming.text = IntToTime(timeCount) + "";
            if (timeCount <= 10) {
                if (GamePlayUIController.instance != null) {
                    audioSource.PlayOneShot(acWarning);
                    GamePlayUIController.instance.SetScreenDamage(150);
                }
            }
            StartCoroutine(TimeCountDown());
        }
    }
    public void IncreaseKilledCount(int count){
        killedCount += count;
        txtKilled.text = killedCount + "";
    }
    public void TakeEndpoint(){
        if (GamePlayUIController.instance != null){
            if (killedCount < killCountMission){
                GamePlayUIController.instance.AlertText($"<color=#c41818>KILL AT LEAST {killCountMission} ZOMBIES</color>",4f);
            } else {
                GamePlayUIController.instance.GameWin(level);
            }
        }
    }
    public bool CheckZombieMax(){
        return currentZombie < maxZombie;
    }
}
