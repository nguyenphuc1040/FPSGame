using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public List<Image> listBtn = new List<Image>();
    private int index;
    public int Index {get{return index;}}
    public void OnChangeStatus(int index){
        this.index = index;
        int i = 0;
        foreach (var item in listBtn){
            if (i == index) {
                item.color = new Color32(99, 9, 0, 255);
            } else {
                item.color = new Color32(35,35,35,255);
            }
            i++;
        }
    }
}
