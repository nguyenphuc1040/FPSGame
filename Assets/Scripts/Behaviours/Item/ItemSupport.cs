using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSupport : MonoBehaviour
{
    [SerializeField]
    private int count;
    [SerializeField]
    private string keyFunc;
    [SerializeField]
    private GameObject Item;
    private BoxCollider collider;
    private void Start() {
        collider = gameObject.GetComponent<BoxCollider>();
    }
    public void ReceiveItem(GameObject entity){
        entity.SendMessage(keyFunc, count);
        StartCoroutine(ReloadItem(30));
    }
    IEnumerator ReloadItem(float time){
        Item.SetActive(false);
        collider.enabled = false;
        yield return new WaitForSeconds(time);
        collider.enabled = true;
        Item.SetActive(true);
    }
}
