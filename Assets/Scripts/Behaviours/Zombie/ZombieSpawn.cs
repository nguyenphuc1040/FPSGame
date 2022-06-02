using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    [SerializeField]
    private float timeSpawn;
    [SerializeField]
    private GameObject zombie;
    private int level;
    [SerializeField]
    private List<int> timeSpawnLevel = new List<int>();

    private void Start() {
        GetLevel();
    }
    private void GetLevel(){
        if (GameManager.instance != null){
            level = GameManager.instance.Level;
            timeSpawn = timeSpawnLevel[level];
            StartCoroutine(SpawnZombie(timeSpawn));
        }
    }

    IEnumerator SpawnZombie(float time){
        yield return new WaitForSeconds(time);
        if (LevelManager.instance != null){
            if (!LevelManager.instance.CheckZombieMax()) {
                StartCoroutine(SpawnZombie(time));
            } else {
                LevelManager.instance.currentZombie ++;
                Instantiate(zombie, new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);
                if (GamePlayUIController.instance != null) {
                    if (!GamePlayUIController.instance.isGameOver){
                        StartCoroutine(SpawnZombie(time));
                    }
                }
            }
        }
        
    }
}
