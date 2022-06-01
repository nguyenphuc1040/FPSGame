using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAlert : MonoBehaviour
{
    public Text txtContent;
    public void SetContent(string content){
        txtContent.text = content;
    }
}
