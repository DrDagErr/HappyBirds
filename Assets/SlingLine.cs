using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingLine : MonoBehaviour
{
    public  GameObject ball;
    public  GameObject posF;
    public  GameObject posB; 

    public  LineRenderer lf;
    
    public  LineRenderer lb; 
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3[] positionsF = new Vector3[2];
        positionsF[0] = posF.transform.position;
        positionsF[1] = ball.transform.position;
        lf.SetPositions(positionsF);

        Vector3[] positionsB = new Vector3[2];
        positionsB[0] = posB.transform.position;
        positionsB[1] = ball.transform.position;
        lb.SetPositions(positionsB);
    }
}
