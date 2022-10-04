using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public GameObject enemy;
    private GameObject bird;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bird = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        Destroy(bird, 5);
        if(col.gameObject == bird)
        {
            enemy.SetActive(false);
            /*score.scoreIncrease();*/
        }
    }
}
