using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMive : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Numbers")]
    public float ShootingSpeed = 2f;
    static public int HP{get; private set;}
    static public float hpPercent {get; private set;}
    
    static private int lifeCount = 3;
    static public int Lifr{get{return lifeCount;} private set{if(value > 9) lifeCount = 9; else lifeCount = value;} }
    static public bool ShieldIsActive = false;
    static public int BulletsCount {get; private set;}
    static public int ShieldCiount;
    public static bool bossKilled = false;
    
    
    [Header("Objects")]
    public GameObject ShieldPref;
    static public GameObject Shield;
    public GameObject Bullet;
    public Transform Wings;
    static public  GameObject Player;
    public Animator death;
    public delegate void FinalMove();
    public GameObject sceneChanger;
    public static FinalMove la_finaleXD;
    
    

    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(nameof(Shoot));
        Player = this.gameObject;
        HP = 100;
        ShieldCiount = 0;
        BulletsCount = 2;
        lifeCount = 3;
        death = this.GetComponent<Animator>();
        la_finaleXD = BossKilled;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hpPercent);
        hpPercent = (float)HP / 100f;
        
   }

    private void Move()
    {
        Vector3 RightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
        Vector3 LeftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0.0f);
        
        
        this.transform.position = mousePos;
        if (mousePos.x >= RightEdge.x)
        {
            this.transform.position = new Vector3(7.5f, this.transform.position.y, 0.0f);
        }

        else if (mousePos.x <= LeftEdge.x)
        {
            this.transform.position = new Vector3(-7.5f, this.transform.position.y, 0.0f);
        }
        else
            this.transform.position = mousePos;
    }
    private void FixedUpdate() 
    {
        if(bossKilled == false)
        { 
            Move();
        }
        else
        {
            this.transform.position += this.transform.up * Time.deltaTime * 7;
            Invoke(nameof(GameOver), 4f);
        }
        IfLifeMin();
    }
    private void SpawnShoot()
    {   
        
        Instantiate(Bullet,Wings.position + new Vector3(0.84f,0,0),Quaternion.identity);
        Instantiate(Bullet,Wings.position + new Vector3(-0.84f,0,0),Quaternion.identity);
        if(BulletsCount == 3)
        {
            Instantiate(Bullet,Wings.position + new Vector3(0,1.040707f,0),Quaternion.identity);
        }
        if(BulletsCount == 4)
        {
            Instantiate(Bullet,Wings.position + new Vector3(-0.45f,0,0),Quaternion.identity);
            Instantiate(Bullet,Wings.position + new Vector3(0.45f,0,0),Quaternion.identity);
        }
        if(BulletsCount >= 5)
        {
            Instantiate(Bullet,Wings.position + new Vector3(0,1.040707f,0),Quaternion.identity);
            Instantiate(Bullet,Wings.position + new Vector3(-0.45f,0,0),Quaternion.identity);
            Instantiate(Bullet,Wings.position + new Vector3(0.45f,0,0),Quaternion.identity);
        }
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
            case "Star":
            lifeCount++;
            break;
            case "Shield":
            ShieldCiount++;
            if(ShieldIsActive == false)
            StartCoroutine(nameof(DestroyShield));
            break;
            case "BulletPow":
            BulletsCount++;
            break;
            case "Laser":
            HP -= 5;
            break;
            case "Simple":
            HP -= 10;
            break;
            case "BossLaser":
            HP -= 15;
            break;
        }


    }
    IEnumerator DestroyShield()
    {
        ShieldIsActive = true;
        Shield = Instantiate(ShieldPref,this.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(45f);
        Destroy(Shield);
        ShieldCiount = 0;
        ShieldIsActive = false;
    }
    public void IfLifeMin()
    {
        if(HP <= 0)
        {
            HP = 100;
            lifeCount--;
            this.GetComponent<Rigidbody2D>().simulated = false;
           StartCoroutine(nameof(MoveBack));
        }
    }
    public IEnumerator MoveBack()
    {
        this.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        this.GetComponent<Animator>().SetTrigger("Idle");
        this.GetComponent<Rigidbody2D>().simulated = true;
        
    }
    void BossKilled()
    {
        Invoke(nameof(StopAllCoroutines), 2f);
        bossKilled = true;
    }
    void GameOver()
    {
        sceneChanger.GetComponent<PlayButtonScript>().GameOver();
    }
}
