using UnityEngine;
using System.Collections;

public class residentMovement : MonoBehaviour {

    //add arrays for each rooms waypoint Tags
    public GameObject[] kitchenWPs;
    public GameObject[] lobbyWPs;

    private string[] roomNames = new string[] { "kitchen", "lobby" };

    //agent determines destination, speed, stopping distance etc.
    [HideInInspector]public NavMeshAgent agent;

    [HideInInspector]public string targetRoom;

    float searchingTurnSpeed = 120f;
    private float searchDuration = 4f;
    private float searchTimer = 0;

    public string currentState;
    Vector3 currentInvestigation;



    void Start () {
        agent = GetComponent<NavMeshAgent>();
        
        // fill the arrays with all objects with corresponding Tag
        kitchenWPs = GameObject.FindGameObjectsWithTag("KitchenWP");
        lobbyWPs = GameObject.FindGameObjectsWithTag("LobbyWP");

        // Room the resident will 'roam' in
        targetRoom = "kitchen";
        // change current behaviour state 
        currentState = "roaming";
    }
	

	void Update () {
        if (currentState == "roaming")
        {
            roaming();
        }
        if(currentState == "investigate")
        {
            investigate(currentInvestigation);
        }

    }



    public void roaming()
    {
        currentState = "roaming";
        Vector3 roamTarget;
        Vector3 oldTarget = new Vector3(1000,0,0);

        

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (targetRoom == "kitchen")
            {
                roamTarget = kitchenWPs[Random.Range(0, kitchenWPs.Length)].transform.position;
                if (agent.destination != oldTarget)
                {
                    agent.SetDestination(roamTarget);
                    oldTarget = roamTarget;
                }

            }
            if (targetRoom == "lobby")
            {
                roamTarget = lobbyWPs[Random.Range(0, lobbyWPs.Length)].transform.position;
                if (agent.destination != oldTarget)
                {
                    agent.SetDestination(roamTarget);
                    oldTarget = roamTarget;
                }

            }
        }
    }

    public void investigate(Vector3 targetPosition)
    {
        currentInvestigation = targetPosition;
        currentState = "investigate";

        agent.SetDestination(targetPosition);
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            this.transform.Rotate(0, searchingTurnSpeed * Time.deltaTime ,0);
            searchTimer += Time.deltaTime;

            if (searchTimer >= searchDuration)
            {
               currentState = "roaming";
               roaming();
                searchTimer = 0f;
            }
        }
    }



    public void goToTarget(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }

    
}
