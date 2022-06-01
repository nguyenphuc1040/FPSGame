using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    public float speed = 20f;
    void Update()
    {
        transform.Rotate(transform.up * speed * Time.deltaTime);
    }
}
