using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleShoterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Missle;
    bool started;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BosScript._boss_state == BosScript.Boss_state.RotateShot & !started)
        {
            StartCoroutine(nameof(MissleShot));
        }
    }
    IEnumerator MissleShot()
    {
        started = true;
           
              yield return new WaitForSeconds(2.5f);
             Instantiate(Missle, this.transform.position,Quaternion.identity);
        started = false;
        
       
    }
}
