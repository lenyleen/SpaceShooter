using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoterScript : MonoBehaviour
{
    public GameObject laser;
    static public int HP = 200;
    public GameObject explode;
    private void Start() 
    {
        StartCoroutine(nameof(Shoting));
    }
    void Update()
    {
        Explode(); 
    }
    private IEnumerator Shoting()
    {
        while(true)
        {
        this.GetComponent<Animator>().SetTrigger("Shot");
         for (int i = 0; i < 3; i++)
        {
            Instantiate(laser,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.15f); 
        }
        this.GetComponent<Animator>().SetTrigger("Idle");
        yield return new WaitForSeconds(2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Bullet")
        {
            HP -= 10;
            this.GetComponent<Animator>().Play("Flashing");
        }   
    }
    private void Explode()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(explode,this.transform.position - new Vector3(0,0.20f,0), Quaternion.identity);
        }
    }
}
