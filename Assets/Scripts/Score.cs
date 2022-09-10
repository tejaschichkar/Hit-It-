using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void scoreIncrease()
    {
        scoretxt.text = "Score : " + score;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
