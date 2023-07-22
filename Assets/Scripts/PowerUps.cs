using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform palyer;
    private CircleCollider2D circle;
    float Distance;
    private Vector3 BetveenPlMe;
    void Start()
    {
        circle = palyer.gameObject.GetComponent<CircleCollider2D>();
        Distance = circle.radius;
        StartCoroutine(nameof(Die));
        
    }

    // Update is called once per frame
    private void Update() {
        BetveenPlMe = PlayerMive.Player.transform.position - this.transform.position;
        Debug.Log(PlayerMive.Player.transform.position);
    }
    void FixedUpdate()
    {
        
        
        if(BetveenPlMe.magnitude <= Distance)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, PlayerMive.Player.transform.position, Time.deltaTime * 1f);
        }
        else 
        {
             this.transform.position += Vector3.down * Time.deltaTime * 2f;
        }
    }
    IEnumerator Die()
    {
       yield return new WaitForSeconds(10f);
       Destroy(this.gameObject);
       
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        Destroy(this.gameObject);
    }
}
