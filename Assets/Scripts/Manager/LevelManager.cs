using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TimeUtils.TimeConvert;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Text txtKilled, txtTiming;
    public int killedCount, timeCount;
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
        timeCount = 1000;
        StartCoroutine(TimeCountDown());
    }
    private void SetUpStatsLevel(){
        killedCount = 0;
        txtKilled.text = killedCount + "";
    }
    void Update()
    {
        
    }
    IEnumerator TimeCountDown(){
        yield return new WaitForSeconds(1f);
        if (timeCount <= 0) {
            // GameOver
        } else {
            timeCount--;
            txtTiming.text = IntToTime(timeCount) + "";
            StartCoroutine(TimeCountDown());
        }
    }
    public void IncreaseKilledCount(int count){
        killedCount += count;
        txtKilled.text = killedCount + "";
    }
    
}
