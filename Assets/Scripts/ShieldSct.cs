using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldSct : MonoBehaviour
{
    // Start is called before the first frame update
    static public int HP {get; private set;}
    static public float hpPercent {get; private set;}
    private SpriteRenderer sprite;
    public Sprite[] difsprites = new Sprite[3];
    static public GameObject shield;
    
    
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        shield = this.gameObject;
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = PlayerMive.Player.transform.position;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            PlayerMive.ShieldCiount = 0;
            PlayerMive.ShieldIsActive = false;
        }
        switch(PlayerMive.ShieldCiount)
        {
            case 1:
            sprite.sprite = difsprites[0];
            break;
            case 2:
            sprite.sprite = difsprites[1];
            break;
            case 3:
            sprite.sprite = difsprites[2];
            break;
        }

        hpPercent = (float)HP/100f;
        UIScriptShield.ShieldBar.fillAmount = hpPercent;
        if(PlayerMive.ShieldIsActive == true)
        {
            UIScriptShield.ShieldBar.enabled = true;
        }
        else
        {
            UIScriptShield.ShieldBar.enabled =false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Simple" | other.tag == "Laser" | other.tag == "BossLaser")
        {
            HP -= 20;
        }
        
    }
}
