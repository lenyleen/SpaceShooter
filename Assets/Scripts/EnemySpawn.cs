using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Objects")]
    public GameObject Enemy;
    public GameObject Drister; 
    public GameObject SimpleEnemy;
    
    public GameObject Boss;
    GameObject Enem;
    [Header ("Spawn Boxes")]
    public BoxCollider2D bordersLeft;
    public BoxCollider2D bordersRight;
    public BoxCollider2D UpperBorder;
    public BoxCollider2D DownBound;
    [Header ("Positions of Spawn")]
    private float rightX;
    private float righty;
    private float leftX;
    private float leftY;
    private float upX;
    private float upY;
    private float downX;
    private float downY;
    [Header ("Counters")]
    static public  int countOfEnem = 0;
    static public  int countOfSimples = 0;
    static public int counofDrister = 0;
    static public int countOfStars = 0;
    static public int countOfPowBul = 0;
    static public int countOfShields = 0;
    private float speedofSpawn = 2;

    [Header ("Booler")]
    
    private bool _enemySpawn = true;
    private bool _dristeSpawn =  true;
    
    public delegate void SpawnBos();
    public static SpawnBos _spawnBos;
    public void Start()
    {
        
        
        StartCoroutine(nameof(SpawnOfEnemy));
        StartCoroutine(nameof(SpawnDrist));
        StartCoroutine(nameof(SpawnOfSimpleEnemy));
        _spawnBos = Instant;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMive.BulletsCount > 3)
        {
            speedofSpawn = 1f;
        }
        if(ScoreScript._Score >= 1250)
        {
            StopAllCoroutines();
            if(_enemySpawn)
            {
            BossStageScript.str?.Invoke();
            _enemySpawn = false;
            }
        }

    }

    

    private IEnumerator SpawnDrist()
    {
        while(_dristeSpawn == true)
        {
            Bounds rightBounds = this.bordersRight.bounds;
            Bounds leftBounds = this.bordersLeft.bounds;
            rightX = Random.Range(rightBounds.max.x, rightBounds.min.x);
            righty = Random.Range(rightBounds.max.y, rightBounds.min.y);
            leftX = Random.Range(leftBounds.max.x, leftBounds.min.x);
            leftY = Random.Range(leftBounds.max.y, leftBounds.min.y);
            int rnd = Random.Range(0, 10);
            if(rnd < 5)
            {
                Instantiate(Drister,new Vector3(leftX,leftY,0f),Quaternion.identity);
            }
            if(rnd >= 5)
            {
                Instantiate(Drister,new Vector3(rightX,righty,0f),Quaternion.identity);
            }
            counofDrister++;
            yield return new WaitForSeconds(15f);
        }   
        
    }
    private IEnumerator SpawnOfSimpleEnemy()
    {
        
            while(true)
        {
            Bounds upBounds = UpperBorder.bounds;
            upX = Random.Range(upBounds.max.x,upBounds.min.x);
            upY = Random.Range(upBounds.max.y, upBounds.min.y);
            Instantiate(SimpleEnemy, new Vector3(upX,upY,0f),Quaternion.identity);
            countOfSimples++;
            yield return new WaitForSeconds(speedofSpawn);
        }
        
    }
    private IEnumerator SpawnOfEnemy()
    {
        float Secondss;
        if(countOfEnem >= 2)
        {
            Secondss = 6f;
        }
        else
        {
            Secondss = 2f;
        }
         while(true)
        
        {
            Bounds rightBounds = this.bordersRight.bounds;
            Bounds leftBounds = this.bordersLeft.bounds;
            Bounds upBounds = this.UpperBorder.bounds;
        
            rightX = Random.Range(rightBounds.max.x, rightBounds.min.x);
            righty = Random.Range(rightBounds.max.y * 2, rightBounds.min.y * 2);
            leftX = Random.Range(leftBounds.max.x, leftBounds.min.x);
            leftY = Random.Range(leftBounds.max.y * 2, leftBounds.min.y * 2);
            upX = Random.Range(upBounds.max.x,upBounds.min.x);
            upY = Random.Range(upBounds.max.y, upBounds.min.y);
            downX = -Random.Range(upBounds.max.x,upBounds.min.x);
            downY = -Random.Range(upBounds.max.y,upBounds.min.x);
            int rnd = Random.Range(0,3);
            yield return new WaitForSeconds(2f);
            switch(rnd)
            {
                case 0:
                Instantiate(Enemy, new Vector3(upX,upY,0f),Quaternion.identity);
                break;
                case 1:
                Instantiate(Enemy,new Vector3(rightX,righty,0f),Quaternion.identity);
                break;
                case 2:
                Instantiate(Enemy,new Vector3(leftX,leftY,0f),Quaternion.identity);
                break;
                case 3:
                Instantiate(Enemy,new Vector3(downX,downY,0f),Quaternion.identity);
                break;
            }
            countOfEnem++;
            yield return new WaitForSeconds(Secondss);
        }
       
        
    }
    
    void Instant()
    {
        Instantiate(Boss,UpperBorder.transform.position,Quaternion.identity);
    }
    
    
}
