using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodionStr : MonoBehaviour
{
    public GameObject explode;
    void Start()
    {
        StartCoroutine(nameof(Die));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(this.gameObject);
        
    }
}
