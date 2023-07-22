using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosScript : MonoBehaviour
{
    public bool IsSitting = false;
    private Vector3 CurrentPos;
    private delegate void Back();
    private Back turnBack;
    float angle;
    public delegate void strt();
    static public strt str;
    public GameObject player;
    
    public GameObject Missle;
    private int HP = 300;
    public GameObject explosion;
    
    public enum Boss_state
    {
        start,
        RotateShot,
        Bite,
        explode
    }
    public static Boss_state _boss_state;
    void Start()
    {
        CurrentPos = this.transform.position;
        str += StrtCour;
        StartCoroutine(nameof(Startuem));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        
        
        switch(_boss_state)
        {
            case Boss_state.start:
            this.transform.position = Vector3.Lerp(this.transform.position, BossFirstStage.FightPos,1 * Time.deltaTime);
            break;
            case Boss_state.RotateShot:
            Rotate();
            break;
            case Boss_state.explode:
            StopAllCoroutines();
            Invoke(nameof(CreateExplosion), .2f);
            Invoke(nameof(CreateExplosion), .5f);
            Invoke(nameof(CreateExplosion), .7f);
            if(this.transform.localScale.x >= 0.3f)
            {
                this.transform.localScale = Vector3.Lerp(this.transform.localScale,new Vector3(0f,0f,0f), .3f * Time.deltaTime);
                this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(this.transform.position.x,this.transform.position.y - 10, 0f), .3f * Time.deltaTime);
            }
            else
            {
                PlayerMive.la_finaleXD?.Invoke();
                Destroy(this.gameObject);
            }
            break;
        }
        if(this.transform.position.y >= CurrentPos.y)
        turnBack -= BackToCur;
        ShittingOnMe();
        turnBack?.Invoke();
        if(HP <= 0)
        {_boss_state = Boss_state.explode;}
    }
    private void ShittingOnMe()
    {
        if(IsSitting)
        {
            this.transform.position -= this.transform.up * Time.deltaTime * 12;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "MainCamera")
        {
            IsSitting = false;
            turnBack = BackToCur;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Bullet" |other.tag == "Player") 
        {
            HP -= 15;
            this.GetComponent<Animator>().Play("Flashing");
        }  
    }
    private void BackToCur()
    {
        this.transform.position += this.transform.up * Time.deltaTime * 5;
    }
    private void Rotate()
    {
        Vector3 dir = PlayerMive.Player.transform.position - this.transform.position;
            angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(-(angle + 180),Vector3.forward);
    }
    
    private void StrtCour()
    {
        StartCoroutine(nameof(Startuem));
    }
    private IEnumerator Startuem()
    {
        while(true)

        {
            yield return new WaitForSeconds(3f);
            _boss_state = Boss_state.RotateShot;
            yield return new WaitForSeconds(2f);
            _boss_state = Boss_state.Bite;
            this.GetComponent<Animator>().SetTrigger("Start");
            yield return new WaitForSeconds(3f);
            IsSitting = true;
            yield return new WaitForSeconds(1f);
            this.GetComponent<Animator>().SetTrigger("Idle");
            yield return new WaitForSeconds(7.5f);
            _boss_state = Boss_state.RotateShot;

            
        }
    }
    void CreateExplosion()
    {
        float x = Random.Range(this.GetComponent<BoxCollider2D>().bounds.min.x,this.GetComponent<BoxCollider2D>().bounds.max.x);
        float y = Random.Range(this.GetComponent<BoxCollider2D>().bounds.min.y,this.GetComponent<BoxCollider2D>().bounds.max.y);
        Instantiate(explosion, new Vector3(x,y,0f),Quaternion.identity);
    }
    
    
    
}
