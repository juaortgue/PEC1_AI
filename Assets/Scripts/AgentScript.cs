using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public NavMeshAgent agent;
    void Start()
    {
         
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray camRay =
            Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camRay, out hit, 100)){
                agent.destination = hit.point;
            }
        }
    }
}
