using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DristerLsers : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isRotated = true;
    public GameObject circle;
    void Start()
    {
        StartCoroutine(nameof(RotIsFalse));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRotated == false)
        {
            this.transform.position += this.transform.up * Time.deltaTime * 10f;
        }
        if(isRotated)
        {
            Rotation();
        }
    }
    private void Rotation()
    {
        
           this.transform.RotateAround(circle.transform.position, Vector3.forward, 1f);
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator RotIsFalse()
    {
        yield return new WaitForSeconds(10f);
        isRotated = false;
        
    }
}
