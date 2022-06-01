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
    private void Start() {
        int i = 0;
        foreach(Slider item in listSlider){
            item.value = PlayerPrefs.GetFloat(keySlider[i++]);
        }
    }
    public void OnShowPanel(bool x) {
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