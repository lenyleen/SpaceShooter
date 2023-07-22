using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private static  int Score = 0;
    static public int _Score{get{return Score;}}
    public delegate void ScoreInsc();
    static public ScoreInsc scr;
    void Start()
    {
        scr += ScoreInscrease;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = $"Score: {Score}";
    }
    public void ScoreInscrease()
    {
        Score += 25;
    }
}
