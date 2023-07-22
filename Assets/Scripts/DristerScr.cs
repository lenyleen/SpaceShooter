using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DristerScr : MonoBehaviour
{
     
    
    private bool isRotated = true;
    private Vector3 SpawnPos;
    public GameObject explosion;
    
    float x;
    Animator anime;
    private int HP = 6;
    public void Start()
    {
        
        StartCoroutine(nameof(RotIsFalse));
        SpawnPos = this.transform.position;
        x = Random.Range(-4,4);
        anime = GetComponent<Animator>();
        
    }
    private void Update() 
    {
        if(HP <= 0)
        {
            StartCoroutine(nameof(Die));
        }
        
    }
    private void FixedUpdate()
    {

        this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(x, this.transform.position.y, 0),Time.deltaTime);
       
        if(isRotated == false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x * 10,this.transform.position.y, 0f),Time.deltaTime);
            Vector3 leftX = Camera.main.ViewportToWorldPoint(Vector3.left);
            if(this.transform.position.x < leftX.x | this.transform.position.x > -leftX.x)
            {
                Destroy(this.gameObject);
                EnemySpawn.counofDrister--;
            }
        }
        

    }

    
    IEnumerator RotIsFalse()
    {
        yield return new WaitForSeconds(20f);
        isRotated = false;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        switch (other.tag)
        {
            case "Bullet":
            HP--;
            anime.Play("enemyFlashing");
            break;
            case "Player":
            StartCoroutine(nameof(Die));
            break;
            

        }
    }
     private IEnumerator Die()
    {
        Instantiate(explosion,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        EnemySpawn.counofDrister--;
        ScoreScript.scr?.Invoke();
        yield return new WaitForSeconds(0.17f);
    }
    
}

