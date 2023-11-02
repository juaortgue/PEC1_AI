using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BansheeGz.BGSpline.Curve;

public class AgentScript : MonoBehaviour
{
     public BGCurve curve;
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private float minSpeed = 5f; 
    private float maxSpeed = 15f; 
    private List<Vector3> pointsOnCurve; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        
        if (curve == null) return;
        pointsOnCurve = new List<Vector3>();
        for (int i = 0; i < curve.PointsCount; i++)
        {
            BGCurvePointI point = curve[i];
            pointsOnCurve.Add(point.PositionWorld);
        }
        currentWaypointIndex = Random.Range(0, pointsOnCurve.Count-1); 

        SetRandomSpeed();
        SetDestination();
        
    }
     
    void SetRandomSpeed(){
        agent.speed = Random.Range(minSpeed, maxSpeed); 

    }

    void SetDestination()
    {
        if (pointsOnCurve.Count == 0) return; 
        agent.SetDestination(pointsOnCurve[currentWaypointIndex]); 
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % pointsOnCurve.Count; 
            SetDestination(); 
           
        }
    }
     void SetRandomRotation()
    {
        float randomYRotation = Random.Range(0, 180); 
        transform.rotation = Quaternion.Euler(0, randomYRotation, 0); 
    }
}
