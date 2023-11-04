using UnityEngine;
using System.Collections;
public class WanderStatus : IActualStatus
{
    private readonly FSMGrandParent fsm;
    private Vector3 targetPosition;

    public WanderStatus (FSMGrandParent fSMGrandParent)
    {
        fsm = fSMGrandParent;
    }
    

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += fsm.transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, 10f, UnityEngine.AI.NavMesh.AllAreas);
        Vector3 finalPosition = hit.position;
        fsm.navMeshAgent.SetDestination(finalPosition);
    }

    public void UpdateStatus()
    {
        if (!fsm.navMeshAgent.pathPending && fsm.navMeshAgent.remainingDistance < 0.5f)
        {
            //SetRandomSpeed();
            SetRandomDestination();
        }
    }

    public void ToWanderStatus(){
        Debug.Log($"NO SE PUEDE IR DESDE EL MISMO ESTADO WANDER - WANDER");

    }
    public void ToRestStatus(){
        fsm.actualStatus = fsm.restStatus;
    }

}