using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNullStage : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector3 FightPos;
    void Start()
    {
        FightPos = new Vector3(0,9.9f,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.position.y > FightPos.y)
        {
            this.transform.position -= this.transform.up;
        }
        else
        {
            
        }
    }
}
