using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PPKey.Setting;
using static PPKey.GameLevel;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int sceneLoadId;
    public int SceneLoadId {get {return sceneLoadId;}}
    private int level = 0;
    public int Level {get {return level;}}
    public int maxLevel;
    private void Awake() {
        SetInstance();
        TheFirstTimeInstall();
    }
    private void TheFirstTimeInstall(){
        if (!PlayerPrefs.HasKey("TheFirstTimeInstall4")){
            PlayerPrefs.SetInt(GAME_FPS_LIMIT, 30);
            PlayerPrefs.SetInt("TheFirstTimeInstall4", 0);
            PlayerPrefs.SetFloat(CAMERAVIEW_ROTATE_SPEED, 0.5f);
            PlayerPrefs.SetFloat(SHOOT_ROTATE_SPEED, 0.5f);
            for (int i=0; i<maxLevel; i++){
                PlayerPrefs.SetInt($"{GAME_LEVEL}{i}", 0);
            }
            PlayerPrefs.SetInt($"{GAME_LEVEL}{0}", 1);
        }
    }
    public void SetLevelUnlock(int i, bool b){
        PlayerPrefs.SetInt($"{GAME_LEVEL}{i}",b ? 1 : 0);
    }
    public bool GetLevelStatus(int i){
        return PlayerPrefs.GetInt($"{GAME_LEVEL}{i}") == 0 ? false : true;
    }
    public List<bool> GetAllLevelStatus(){
        List<bool> resArr = new List<bool>();
        for (int i=0; i<maxLevel; i++){
            resArr.Add(GetLevelStatus(i));
        }
        return resArr;
    }
    private void SetInstance(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    public void LoadScene(int idScene){
        sceneLoadId = idScene;
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadScene(string nameScene){
        SceneManager.LoadSceneAsync(1);
    }
    public void NextLevel(){
        level ++;
        LoadScene(2);
    }
    public void LoadLevel(int level){
        this.level = level;
        LoadScene(2);
    }
}
