using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PercentBarCanvas : MonoBehaviour
{
    public Image percentBar;
    private float currentPercent;
    private void Start() {
        percentBar = gameObject.GetComponent<Image>();
    }
    public void SetPercentUI(float percent){
        currentPercent = percent < 0 ? 0 : percent;
        percentBar.fillAmount = currentPercent;
    }
}
