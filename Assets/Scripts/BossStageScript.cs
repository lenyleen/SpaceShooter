using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageScript : MonoBehaviour
{
    public delegate void strt();
    static public strt str;
    public GameObject player;
    
    private void Start() 
    {
        str += StrtCour;
        
    }

    private void StrtCour()
    {
        StartCoroutine(nameof(Startuem));
    }
    private IEnumerator Startuem()
    {
        
        yield return new WaitForSeconds(15f);
        this.GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(6f);
        this.GetComponent<Animator>().SetTrigger("Idle");
        EnemySpawn._spawnBos?.Invoke();
        
    }

    
}
