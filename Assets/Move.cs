using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        this.transform.position += new Vector3(1,Mathf.Sin(this.transform.position.x),0) * Time.deltaTime;
    }
}
