using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Laser;
    static public bool Dying;
    public Transform LEftWing;
    public Transform RightWing;
    public float ShootingSpeed = 1f;
    private int HP = 4;
    float angle;
    private Animator anime;
    public GameObject explosion;
        void Start()
    {
        StartCoroutine(nameof(Shoot));
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = PlayerMive.Player.transform.position - this.transform.position;
         angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(-(angle + 180),Vector3.forward);
        if(HP <= 0)
        {StartCoroutine(nameof(Die));}
       
    }
    private void FixedUpdate() {
        this.transform.position =  Vector3.Lerp(this.transform.position,PlayerMive.Player.transform.position,0.2f * Time.deltaTime);
    }
    private void SpawnShoot()
    {   
        
        Instantiate(Laser,LEftWing.position,Quaternion.AngleAxis(-(angle + 180),Vector3.forward));
        Instantiate(Laser,RightWing.position,Quaternion.AngleAxis(-(angle + 180),Vector3.forward));
         
        
    }
    IEnumerator Shoot()
    {
        for(int i = 0;; i++)
        {
            SpawnShoot();
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
        }
        

    }
    private IEnumerator Die()
    {
        Instantiate(explosion,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
        EnemySpawn.countOfEnem--;
        ScoreScript.scr?.Invoke();
        yield return new WaitForSeconds(0.01f);
        
    }
    
    
    
}
