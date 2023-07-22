using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilShooterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject laser;
    public delegate void Shoot(int x);
    static public Shoot sht;
    
    static public int HP = 200;
    public GameObject explode;
    
    


    void Start()
    {
        sht += Shooti;
        StartCoroutine(nameof(Shot));
        
    }

    // Update is called once per frame
    void Update()
    {
        Explode();
    }
    private IEnumerator Shot()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
        this.GetComponent<Animator>().SetTrigger("Shot");
        Instantiate(laser,this.transform.position,Quaternion.identity);
        Instantiate(laser,this.transform.position,Quaternion.Euler(0f,0f,20f));
        Instantiate(laser,this.transform.position,Quaternion.Euler(0f,0f,-20f));
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Animator>().SetTrigger("Idle");
        }
        
        
        
        
    }
    private void Shooti(int x)
    {
        if(x == 0)
        StartCoroutine(nameof(Shot));
        if(x == 1)
        StartCoroutine(nameof(MassShot));
    }
    private IEnumerator MassShot()
    {
        
        this.GetComponent<Animator>().SetTrigger("MassShot");
        for (int i = 0; i < 3; i++)
        {
           Instantiate(laser,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(0.15f); 
        }
        this.GetComponent<Animator>().SetTrigger("Idle");
        StartCoroutine(nameof(Shot));

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
