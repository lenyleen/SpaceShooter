using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.forward * Time.deltaTime,Space.World);
    }
}
