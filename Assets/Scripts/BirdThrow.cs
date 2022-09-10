using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdThrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpringJoint2D sj;
    public bool streach;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(streach)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void OnMouseDown()
    {
        rb.isKinematic = true;
        streach = true;
    }
    private void OnMouseUp()
    {
        rb.isKinematic = false;
        streach = false;
        StartCoroutine(Release());
    }
    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        sj.enabled = false;
    }
}
