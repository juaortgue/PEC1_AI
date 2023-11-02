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
        SetDestination();
        agent.speed = Random.Range(minSpeed, maxSpeed); 
        SetRandomRotation();
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
            agent.speed = Random.Range(minSpeed, maxSpeed);
            Debug.Log("velocidad = "+agent.speed);
            SetDestination(); 
            SetRandomRotation();
        }
    }
     void SetRandomRotation()
    {
        float randomYRotation = Random.Range(0, 360); // Generar un ángulo aleatorio en el eje Y (vertical)
        transform.rotation = Quaternion.Euler(50, randomYRotation, 40); // Aplicar la rotación aleatoria al agente
        Debug.Log("rotacion = "+transform.rotation);
    }
}
