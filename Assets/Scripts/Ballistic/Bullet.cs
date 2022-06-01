using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage, speed;
    public GameObject blood, metalImpact;
    private Vector3 prevPosition;
    void Start()
    {
        Destroy(gameObject, 10f);
    }
    void Update()
    {
        BulletPath();
    }

    private void BulletPath(){
        prevPosition = transform.position;
        transform.Translate(Vector3.forward*speed* Time.deltaTime);
        transform.Translate(Vector3.up*-4.9f*Time.deltaTime);
        Raycast();
    }
    private void Raycast(){
        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPosition,(transform.position-prevPosition).normalized),(transform.position-prevPosition).magnitude);
        for (int i=0; i<hits.Length; i++){
            if (hits[i].collider.gameObject.tag=="Zombie"){
                GameObject bloodSpawn = Instantiate(blood,hits[i].point,Quaternion.LookRotation(hits[i].normal));
                hits[i].collider.gameObject.SendMessage("GotHitByBullet",damage);
                Destroy(gameObject);
                Destroy(bloodSpawn, 2f);
            }
            if (hits[i].collider.gameObject.tag=="Metal"){
                GameObject metanSpawn = Instantiate(metalImpact,hits[i].point, Quaternion.LookRotation(hits[i].normal));
                Destroy(gameObject);
                Destroy(metanSpawn,3f);
            }
            
        }
    }
}
