using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMove : MonoBehaviour
{
    [Header ("GameObjects")]
    public GameObject Star;
    public GameObject PowerBuleets;
    public GameObject Shield;
    public Transform Ammo;
    public GameObject cameras;
    [Header ("Other Shit")]
    public GameObject Laser;
    public float ShootingSpeed = 4f;
    private Animator anime;
    
    public GameObject s;
    public GameObject explosion;
    
    
    
    [Header ("Counters")]
    private int HP = 3;
    
    
    void Start()
    {
        
        anime = GetComponent<Animator>();
        
        
        

    }
    private void Update() 
    {
        if(HP <= 0)
        {
            StartCoroutine(nameof(Die));
        }
        
    }

    
    void FixedUpdate()
    {
        this.transform.position += Vector3.down * Time.deltaTime * 5;
        Vector3 DownEdge = Camera.main.ViewportToWorldPoint(Vector3.down);
        if(this.transform.position.y < DownEdge.y )
        {
            
            Destroy(this.gameObject);
            EnemySpawn.countOfSimples--;
        }
       
    }

    

    IEnumerator Shoot()
    {
        for(int i = 0;; i++)
        {
            Instantiate(Laser,Ammo.position,Quaternion.identity);
            yield return new WaitForSeconds(ShootingSpeed);
            
        }
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
            case "simple":
            RandomPos();
            break;
            

        }
        

    }
    
    private IEnumerator Die()
    {
        Instantiate(explosion,this.transform.position,Quaternion.identity);
        this.GetComponent<RandomDrop>().CalculateChance(); 
        Destroy(this.gameObject);
        ScoreScript.scr?.Invoke();
        EnemySpawn.countOfSimples--;
        yield return new WaitForSeconds(0.17f);
        
        
        
        
    }
    private void RandomPos()
    {
        
        float upX = Random.Range(6.14f,-6.14f);
        float upY = Random.Range(22.61f, 16.09f);
        this.transform.position = new Vector3(upX,upY,0f);
    }
     
}
