using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static PPKey.Setting;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int sceneLoadId;
    public int SceneLoadId {get {return sceneLoadId;}}
    private void Awake() {
        SetInstance();
        TheFirstTimeInstall();
    }
    private void TheFirstTimeInstall(){
        if (!PlayerPrefs.HasKey("TheFirstTimeInstall")){
            PlayerPrefs.SetInt("TheFirstTimeInstall", 0);
            PlayerPrefs.SetFloat(CAMERAVIEW_ROTATE_SPEED, 0.5f);
            PlayerPrefs.SetFloat(SHOOT_ROTATE_SPEED, 0.5f);
        }
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
}
