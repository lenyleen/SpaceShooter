using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    [SerializeField]
    public List<Sprite> Number = new List<Sprite>();
    Sprite s;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       this.GetComponent<Image>().sprite = Number[PlayerMive.Lifr];
    }
}
