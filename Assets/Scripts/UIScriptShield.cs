using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScriptShield : MonoBehaviour
{
    
    public static Image ShieldBar;
    GameObject sh;
    void Start()
    {
        ShieldBar = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ShieldBar.fillAmount = ShieldSct.hpPercent;
        
        
    }
   
}
