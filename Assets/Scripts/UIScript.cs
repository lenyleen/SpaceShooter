using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Image HpBar;
    
    
    void Start()
    {
        
        HpBar = GetComponent<Image>(); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
       HpBar.fillAmount = PlayerMive.hpPercent;
       
        
    }
}
