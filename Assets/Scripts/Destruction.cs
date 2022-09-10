using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject Bird1;
    public Score scr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        Destroy(Bird1, 5);
        col.gameObject.SetActive(false);
        gameObject.SetActive(true);
        if(col.gameObject.name == "darkWood")
        {
            scr.score += 5;
            scr.scoreIncrease();
        }
        if(col.gameObject.name == "Enemy")
        {
            scr.score += 10;
            scr.scoreIncrease();
        }
    }
}
