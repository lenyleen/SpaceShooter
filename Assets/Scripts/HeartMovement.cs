using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject parent;
    Rigidbody2D rb;
    float Timer;
    Vector3 pointOfPlayer;
    Vector3 startPos;
    public Animator anime;
    bool AnotherState = false;
    public GameObject PossiblePlayer;
    GameObject PossiblePlayerPref;
    public GameObject explosion;

    
    
    
    public enum Missle_state
    {
        launched,
        fly,
        explode
    }
    public Missle_state missle_state_c;
    void Start()
    {
        startPos = this.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        if(this.transform.position.x > 0)
        {
        rb.velocity = new Vector2(4,8);
        }
        else
        {
           rb.velocity = new Vector2(-4,8); 
        }
        StartCoroutine(nameof(Timerio));
        
    }
    private void Update() 
    {
        Timer = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        switch(missle_state_c)
        {
            case Missle_state.launched:
                LockAt(new Vector3(rb.velocity.x * 10,rb.velocity.y * 10,0));
                if(AnotherState == true)
                {
                    pointOfPlayer = parent.transform.position;
                    missle_state_c = Missle_state.fly;
                }
            break;
            case Missle_state.fly:
                anime.SetTrigger("Fly");
                if(PossiblePlayerPref == null)
                {
                   PossiblePlayerPref = Instantiate(PossiblePlayer,pointOfPlayer,Quaternion.identity); 
                }
                rb.bodyType = RigidbodyType2D.Static;
                LockAt(pointOfPlayer);
                this.transform.position += this.transform.up * Time.deltaTime * 10 ; 
                if(rb.IsTouching(PossiblePlayerPref.GetComponent<BoxCollider2D>()))
                {
                    missle_state_c = Missle_state.explode;
                }
            break;
            case Missle_state.explode:
                Destroy(PossiblePlayerPref);
                Destroy(this.gameObject);
                Instantiate(explosion,this.transform.position,Quaternion.identity);
            break;
        }
    }

    
    void LockAt(Vector3 position)
    {
        Vector3 dir = position - this.transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(-(angle),Vector3.forward);
    }
    float LockAtRet(Vector3 position)
    {
        Vector3 dir = position - this.transform.position;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        return angle;
    }
    IEnumerator Timerio()
    {
        yield return new WaitForSeconds(1.7f);
        AnotherState = true;
    }
    void Instantiates()
    {
        PossiblePlayerPref = Instantiate(PossiblePlayer,pointOfPlayer,Quaternion.identity);
    }
}
