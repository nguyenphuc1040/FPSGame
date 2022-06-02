using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIController : MonoBehaviour
{
    public Transform pnlLevelPlay;
    public GameObject levelItem;
    void Start()
    {
        RenderLevelItem();
    }
    private void RenderLevelItem(){
        if (GameManager.instance != null){
            var listLevelStatus = GameManager.instance.GetAllLevelStatus();
            int i = 0;
            foreach (bool item in listLevelStatus){
                GameObject lvlItem = Instantiate(levelItem, pnlLevelPlay);
                lvlItem.GetComponent<ItemLevelPlay>().SetInfoItem(i++, item);
            }
        }
    }
}
