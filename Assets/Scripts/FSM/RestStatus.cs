using UnityEngine;
using System.Collections;
public class RestStatus : IActualStatus
{
    private readonly FSMGrandParent fsm;
    public RestStatus (FSMGrandParent fSMGrandParent)
    {
        fsm = fSMGrandParent;
    }
    public void UpdateStatus(){
        Debug.Log($"UPDATE STATUS DESDE REST STATUS");
    }
    public void ToWanderStatus(){
        fsm.actualStatus = fsm.wanderStatus;

    }
    public void ToRestStatus(){
        Debug.Log($"NO SE PUEDE IR DESDE EL MISMO ESTADO rest - rest");

    }

}