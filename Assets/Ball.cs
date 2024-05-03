using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool IsPressed;
    public SlingLine sling;


    private float releaseDalay;
    private float maxDragDigstance = 4f; 

    private Rigidbody2D rb;
    private SpringJoint2D sj;
    private Rigidbody2D slingRB;
    private LineRenderer lr;
    private TrailRenderer tr; 

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        slingRB = sj.connectedBody;
        lr = GetComponent<LineRenderer>();
        tr = GetComponent<TrailRenderer>(); 

        lr.enabled = false;
        tr.enabled = false; 
        

        releaseDalay = 1 / (sj.frequency * 4); 
    }

    void Update()
    {
        if (IsPressed)
        {
            DragBall(); 
        }
    }
    private void DragBall()
    {
        SettLineRendererPosition();     

        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   
        float distance = Vector2.Distance(MousePosition, slingRB.position); 

        if(distance > maxDragDigstance)
        {
            Vector2 direction = (MousePosition - slingRB.position).normalized;
            rb.position = slingRB.position + direction * maxDragDigstance; 
        }
        else
        {
            rb.position = MousePosition;
        }
    }

    private void SettLineRendererPosition()
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = rb.position;
        positions[1] = slingRB.position;
        lr.SetPositions(positions); 
    }
    private void OnMouseDown()
    {
        IsPressed = true;
        rb.isKinematic = true;
        //lr.enabled = true; 
    }
    private void OnMouseUp()
    {
        IsPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release()); 
    }
    private IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseDalay);
        sj.enabled = false;
        sling.lb.enabled = false;
        sling.lf.enabled = false; 
        lr.enabled = false;
        tr.enabled = true; 
    }

    
}
