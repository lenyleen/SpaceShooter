using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirstStage : MonoBehaviour
{
    private int FirstHP;
    private Vector3 direction;  
    public GameObject me;
    public static Vector3 FightPos;
    
    BosScript script;
    private void Start() 
    {
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        this.GetComponent<Rigidbody2D>().simulated = false;
        FightPos = new Vector3(0f,9.9f,0f);
        direction = Vector3.right;
        
        script = me.GetComponent<BosScript>();
    }
    private void FixedUpdate() 
    {
        if(this.transform.position.y > FightPos.y)
        {
            this.transform.position -= this.transform.up * Time.deltaTime;
        }
        else
        {
            this.transform.position += direction * Time.deltaTime;
            Move();
            FirstHP = RightShoter.HP + ShoterScript.HP + LilShooterScript.HP + LeftLilShooterScript.HP;
            SecondStage();
        }
    }
    private void Update()
    {
        
    }

    private void Move()
    {
        if (direction == Vector3.right & this.transform.position.x >= 3.63f)
        {
            direction *= -1;
        }
        if (direction == Vector3.left & this.transform.position.x <= -3.63f)
        {
            direction *= -1;
        }
    }
    void SecondStage()
    {
        if(FirstHP <= 0)
        {
            this.GetComponent<Rigidbody2D>().simulated = true;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
            this.enabled = false;
            script.enabled = true;
        }
    }
}
