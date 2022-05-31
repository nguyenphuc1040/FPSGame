using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenDrag : MonoBehaviour, IDragHandler
{
    private float x;
    private float y;
    public float X { get{ return x; } }
    public float Y { get{ return y; } }
    public RectTransform rectTransform;
    public void OnDrag(PointerEventData eventData){
        x = eventData.delta.x;
        y = eventData.delta.y;
    }
}