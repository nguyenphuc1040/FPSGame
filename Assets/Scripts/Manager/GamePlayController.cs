using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public Text txtFps;
    public int fps = 0;
    public PercentBarCanvas playerHealthPercent;
    private void Awake() {
        SetInstance();
    }
    private void Start() {
        StartCoroutine(ShowFPS());
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
}
