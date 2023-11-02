using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public List<Transform> waypoints; // Lista de los objetos que representan los waypoints
    private int currentWaypointIndex = 0; // Índice del waypoint actual
    private NavMeshAgent agent; // Componente NavMeshAgent del agente
     private float minSpeed = 5f; // Velocidad mínima del agente
    private float maxSpeed = 15f; // Velocidad máxima del agente

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        currentWaypointIndex = Random.Range(0, waypoints.Count-1); 
        SetRandomSpeed();
        SetDestination();
        
    }
    void SetRandomSpeed(){
        agent.speed = Random.Range(minSpeed, maxSpeed); 

    }

    void SetDestination()
    {
        if (waypoints.Count == 0) return; 
        agent.SetDestination(waypoints[currentWaypointIndex].position); 
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count; 
            SetDestination(); 
            
        }
    }
     void SetRandomRotation()
    {
        float randomYRotation = Random.Range(0, 180); 
        transform.rotation = Quaternion.Euler(0, randomYRotation, 0); 
    }
}
