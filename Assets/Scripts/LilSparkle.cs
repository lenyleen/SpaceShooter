using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilSparkle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
        Destroy(this.gameObject);
    }
}
