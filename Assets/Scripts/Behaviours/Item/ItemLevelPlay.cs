using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLevelPlay : MonoBehaviour
{
    public Text txtLevel, txtLock;
    private int level;
    public void SetInfoItem(int level, bool unlock){
        this.level = level;
        txtLevel.text = $"LEVEL {level+1}";
        txtLock.text = unlock ? "<color=#fff>UNLOCKED</color>" : "<color=#c93232>LOCKED</color>";
        this.gameObject.GetComponent<Button>().interactable = unlock;
    }
    public void OnPressItem(){
        if (GameManager.instance != null){
            GameManager.instance.LoadLevel(level);
        }
    }
}
