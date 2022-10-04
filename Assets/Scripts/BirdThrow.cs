using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdThrow : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }
}
