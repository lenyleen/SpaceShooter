using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    [System.Serializable]
    public class DropItems
    {
        public string name;
        public GameObject item;
        public int dropRate;
    }
    public List<DropItems> items = new List<DropItems>();
    public int DropChance;
    
    
    private void Start() {
        
    }
    public void CalculateChance()
    {
        
        int calc_chance = Random.Range(0,101);
        if(calc_chance > DropChance)
        {
            return;
        }
        if(calc_chance <= DropChance)
        {
            int ItemWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                ItemWeight += items[i].dropRate;
            }
            int randomValue = Random.Range(0, ItemWeight);
            for (int j = 0; j < items.Count; j++)
            {
                if(randomValue <= items[j].dropRate)
                {
                    Instantiate(items[j].item,this.transform.position,Quaternion.identity);
                    return;
                }
                randomValue -= items[j].dropRate;
            }
        }
        
    }
    
}
