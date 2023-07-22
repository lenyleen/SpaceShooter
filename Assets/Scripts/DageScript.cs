using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DageScript : MonoBehaviour
{
    public List<Sprite> dameGe = new List<Sprite>();
    public SpriteRenderer Spr;
    private Sprite defaultSprite;
    void Start()
    {
        Spr = this.GetComponent<SpriteRenderer>();
        defaultSprite = Spr.sprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMive.HP < 75)
        {
            Spr.sprite = dameGe[0];
        }
        if(PlayerMive.HP < 40)
        {
            Spr.sprite = dameGe[1];
        }
        if(PlayerMive.HP < 25)
        {
            Spr.sprite = dameGe[2];
        }
        else
        {
            Spr.sprite = defaultSprite;
        }
    }
}
