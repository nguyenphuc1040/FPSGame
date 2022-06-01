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
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        BulletPath();
    }

    private void BulletPath(){
        prevPosition = transform.position;
        transform.Translate(Vector3.forward*speed* Time.deltaTime);
        transform.Translate(Vector3.up*-4.9f*Time.deltaTime);
        RaycastOne();
    }
    private void RaycastAll(){
        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPosition,(transform.position-prevPosition).normalized),(transform.position-prevPosition).magnitude);
        for (int i=0; i<hits.Length; i++){
        }
    }
    private void RaycastOne(){
        RaycastHit hit; 
        if (Physics.Raycast(prevPosition, (transform.position-prevPosition).normalized, out hit, (transform.position-prevPosition).magnitude)){
            if (hit.collider.gameObject.tag=="Zombie"){
                GameObject bloodSpawn = Instantiate(blood,hit.point,Quaternion.LookRotation(hit.normal));
                hit.collider.gameObject.SendMessage("GotHitByBullet",damage);
                Destroy(gameObject);
                Destroy(bloodSpawn, 2f);
            }
            if (hit.collider.gameObject.tag=="Metal"){
                GameObject metanSpawn = Instantiate(metalImpact,hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(gameObject);
                Destroy(metanSpawn,3f);
            }
        }
    }
}
