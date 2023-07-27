using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObject : MonoBehaviour
{
    private NavMeshAgent _agent;

    public GameObject moveToObject;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) //The Left Click Button
        {
            MoveAgentToPoint(true);
        }

        if (Input.GetMouseButton(1)) //The Right Click Button
            MoveAgentToPoint(false);

        if (moveToObject != null)
        {
            _agent.destination = moveToObject.transform.position;
        }
    }


    void MoveAgentToPoint(bool isFollowMouse)
    {

        //Create The Ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //tracks the mouse click position for the ray to be cast

        //Information about the collider for the ray cast hit
        RaycastHit hitinfo;

        //Run the raycast
        if (Physics.Raycast(ray.origin, ray.direction, out hitinfo))
        {
            if (isFollowMouse)
            {
                //Go To Mouse Position
                _agent.destination = hitinfo.point;
            }
            else
            {
                //follow the gameobject
                moveToObject = hitinfo.transform.gameObject;
            }
        }
    }
}

