using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public float miningDuration = 2f;
    
    private NavMeshAgent agent;
    private float miningTimer;
    
    
    private float minerals;
    
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

        // make the mining timer work
        miningTimer -= Time.deltaTime;

    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Station>() != null)
        {
            Station station = otherCollider.gameObject.GetComponent<Station>();

            if (!station.IsActive && minerals >= station.requiredMinerals)
            {
                minerals -= station.requiredMinerals;
                station.Activate();
            }

        }
    }
    void OnTriggerStay (Collider otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Rock>() != null)
        {
            Rock rock = otherCollider.gameObject.GetComponent<Rock>();
            if (miningTimer <= 0 && rock.minerals>0)
            {                            
                miningTimer = miningDuration;                

                minerals++;
                Debug.Log("Player now has " + minerals + " minerals");
                rock.Mine();

            }



        }
    }
}
