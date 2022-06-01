using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        SetInstance();
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
        SceneManager.LoadSceneAsync(idScene);
    }
    public void LoadScene(string nameScene){
        SceneManager.LoadSceneAsync(nameScene);
    }
}
