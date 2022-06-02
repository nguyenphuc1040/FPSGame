using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PPKey.Setting;
public class SettingManager : MonoBehaviour
{
    public List<Slider> listSlider = new List<Slider>();
    private List<string> keySlider = new List<string>(){CAMERAVIEW_ROTATE_SPEED,SHOOT_ROTATE_SPEED};
    public GameObject pnlSetting;
    public Switch fpsSwitch;
    private void Start() {
        InitSliderValue();
        InitFpsValue();
    }
    private void InitSliderValue(){
        int i = 0;
        foreach(Slider item in listSlider){
            item.value = PlayerPrefs.GetFloat(keySlider[i++]);
        }
    }
    private void InitFpsValue(){
        int fps = PlayerPrefs.GetInt(GAME_FPS_LIMIT);
        if (fps == 30) {
            fpsSwitch.OnChangeStatus(0);
        } else {
            fpsSwitch.OnChangeStatus(1);
        }
    }
    private void Update() {
        LimitFPS();
    }
    private void LimitFPS(){
        PlayerPrefs.SetInt(GAME_FPS_LIMIT, fpsSwitch.Index == 0 ? 30 : 60);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = PlayerPrefs.GetInt(GAME_FPS_LIMIT);
    }
    public void OnShowPanel(bool x) {
        Time.timeScale = x ? 0 : 1;
        pnlSetting.SetActive(x);
    }
    public void OnChangeValue(int i){
        PlayerPrefs.SetFloat(keySlider[i],listSlider[i].value);
    }
    public void GoToMenu(){
        if (GameManager.instance != null) {
            GameManager.instance.LoadScene(0);
        }
    }
}