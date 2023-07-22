using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    public GameObject Sparcle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LeftEdge = Camera.main.ViewportToWorldPoint(Vector3.left);
        Vector3 RightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        Vector3 UpperEdge = Camera.main.ViewportToWorldPoint(Vector3.up);
        Vector3 DownEdge = Camera.main.ViewportToWorldPoint(Vector3.down);
        if(this.transform.position.x < LeftEdge.x |this.transform.position.x > RightEdge.x | this.transform.position.y > UpperEdge.y | this.transform.position.y < DownEdge.y )
            Destroy(this.gameObject);
        
    }
    private void FixedUpdate() {
        this.transform.position -= this.transform.up * Time.deltaTime * 10f;
        
    }
     private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" | other.tag == "shield")
        {
            Destroy(this.gameObject);
            Instantiate(Sparcle,this.transform.position,Quaternion.identity);
        }
    }

}
