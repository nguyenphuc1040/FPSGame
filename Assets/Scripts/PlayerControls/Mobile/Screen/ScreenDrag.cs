using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenDrag : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private float x;
    private float y;
    public float X { get{ return x; } }
    public float Y { get{ return y; } }

    public void OnPointerDown(PointerEventData eventData){
        
    }
    public void OnDrag(PointerEventData eventData){
        x = eventData.delta.x;
        y = eventData.delta.y;
    }
    public void OnPointerUp(PointerEventData eventData){
        x = 0;
        y = 0;
    }
}