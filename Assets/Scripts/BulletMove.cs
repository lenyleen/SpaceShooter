using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject Sparcle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += Vector3.up;
    }

    private void Update() 
    {
        Vector3 LeftEdge = Camera.main.ViewportToWorldPoint(Vector3.up);
        if(this.transform.position.y > LeftEdge.y)
            Destroy(this.gameObject);
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Laser" &   other.tag != "Bullet" & other.tag != "Player" & other.tag !="Shield" & other.tag !="shield" & other.tag != "MainCamera" & other.tag != "BossLaser" & other.tag != "MainCamera")
            {
                Destroy(this.gameObject);
                Instantiate(Sparcle,this.transform.position,Quaternion.identity);
            }
    }
}
