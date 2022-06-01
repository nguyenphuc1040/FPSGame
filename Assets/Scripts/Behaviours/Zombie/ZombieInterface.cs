using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInterface : MonoBehaviour
{
    public List<GameObject> listInterface = new List<GameObject>();
    void Start()
    {
        RandomInterface();
    }
    private void RandomInterface(){
        int r = Random.Range(0,listInterface.Count);
        listInterface[r].SetActive(true);
    }
}
