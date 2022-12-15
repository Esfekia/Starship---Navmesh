using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // perform raycast, if it hits something store it in hit
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

        }
    }

    void OnTriggerStay (Collider otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Rock>() != null)
        {
            Rock rock = otherCollider.gameObject.GetComponent<Rock>();
            Debug.Log("Mine");            
        }
    }
}
