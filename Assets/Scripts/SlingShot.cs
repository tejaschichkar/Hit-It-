using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;
    public float speed;

    public GameObject birdPrefab;
    Rigidbody2D bird;
    Collider2D birdCollider;
    public float birdPositionOffset;

    public GameObject bird2Prefab;
    Rigidbody2D bird2;
    Collider2D bird2Collider;
    public float bird2PositionOffset;

    public Vector3 currentPosition;

    public float maxLength;
    public float bottomBoundary;
    public float force;
    public int strike;

    bool isMousedown;
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        CreateBird();
        speed = 5;
    }

    void CreateBird()
    {
        if(strike < 2)
        {
            bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
            birdCollider = bird.GetComponent<Collider2D>();
            birdCollider.enabled = false;
            bird.isKinematic = true;
        }
        if(strike >= 2)
        {
            bird2 = Instantiate(bird2Prefab).GetComponent<Rigidbody2D>();
            bird2Collider = bird2.GetComponent<Collider2D>();
            bird2Collider.enabled = false;
            bird2.isKinematic = true;
        }

        ResetStrips();
    }

    void Update()
    {
        if(isMousedown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition
                - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if(strike < 2)
            {
                if(birdCollider)
                {
                    birdCollider.enabled = true;
                }
            }
            if(strike >= 2)
            {
                if(bird2Collider)
                {
                    bird2Collider.enabled = true;
                }
            }
        }
        else
        {
            ResetStrips();
        }
    }

    private void OnMouseDown()
    {
        isMousedown = true;
    }

    private void OnMouseUp()
    {
        isMousedown = false;
        Shoot();
        strike++;
        if (Input.GetKeyDown(KeyCode.S))
        {
            bird2.velocity = new Vector3 (0, 1f, 0)*speed;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            bird2.velocity = new Vector3 (0, 1f, 0)*0;
        }
    }

    void Shoot()
    {
        if(strike < 2)
        {
            bird.isKinematic = false;
            Vector3 birdForce = (currentPosition - center.position) * force * -1;
            bird.velocity = birdForce;

            bird = null;
            birdCollider = null;
        }
        if(strike >= 2)
        {
            bird2.isKinematic = false;
            Vector3 bird2Force = (currentPosition - center.position) * force * -1;
            bird2.velocity = bird2Force;

            bird2 = null;
            bird2Collider = null;
        }
        if(bird2)
        {
            
        }
        Invoke("CreateBird", 2);
    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if(bird)
        {
            Vector3 dir = position - center.position;
            bird.transform.position = position + dir.normalized * birdPositionOffset;
            bird.transform.right = -dir.normalized;
        }

        if(bird2)
        {
            Vector3 dir = position - center.position;
            bird2.transform.position = position + dir.normalized * birdPositionOffset;
            bird2.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }
}