using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public List<Transform> waypoints; // Lista de los objetos que representan los waypoints
    private int currentWaypointIndex = 0; // Índice del waypoint actual
    private NavMeshAgent agent; // Componente NavMeshAgent del agente

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Obtener el componente NavMeshAgent del agente
        SetDestination(); // Establecer el destino inicial
    }

    void SetDestination()
    {
        if (waypoints.Count == 0) return; // Si no hay waypoints, salir
        agent.SetDestination(waypoints[currentWaypointIndex].position); // Establecer el destino al waypoint actual
    }

    void Update()
    {
        // Si el agente está cerca del waypoint actual, pasar al siguiente
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count; // Avanzar al siguiente waypoint
            SetDestination(); // Establecer el nuevo destino
        }
    }
}
