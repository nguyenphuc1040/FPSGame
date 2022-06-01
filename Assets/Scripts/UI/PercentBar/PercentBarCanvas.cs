using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentBarCanvas : MonoBehaviour
{
    public Image percentBar;
    private int currentPercent;
    private void Start() {
        percentBar = gameObject.GetComponent<Image>();
    }
    public void SetPercentUI(int percent){
        currentPercent = percent < 0 ? 0 : percent;
        percentBar.fillAmount = currentPercent/100f;
    }
}
