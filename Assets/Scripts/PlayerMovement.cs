using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : NetworkBehaviour
{
    #region server
    [SerializeField] private NavMeshAgent agent = null;
    private Camera mainCamera;


    [Command]
    public void CmdMove(Vector3 pos) {
        if (!NavMesh.SamplePosition(pos, out NavMeshHit hit, 1f, NavMesh.AllAreas)) { return; }

        agent.SetDestination(hit.position);
    
    
    }

    #endregion

    #region Client


    public override void OnStartAuthority()
    {
        mainCamera = Camera.main;
    }

    [ClientCallback]
    private void Update()
    {
        if(!hasAuthority) { return; }

        if(!Input.GetMouseButtonDown(1)) { return; }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if(!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)){ return; }

        CmdMove(hit.point);
    }

    #endregion
}
