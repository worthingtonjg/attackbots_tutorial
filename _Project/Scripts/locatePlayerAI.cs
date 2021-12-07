using UnityEngine;
using System.Collections;

public class locatePlayerAI : MonoBehaviour {

    public bool inRange;
    public GameObject target;
    public Vector3 lastSeenAt;
    public Vector3 originalPosition;

    private UnityEngine.AI.NavMeshAgent nav;
    private bool movingToLastSeen;

    
	// Use this for initialization
	void Start () {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        originalPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update() {
        bool canSee = false;
        if (inRange)
        {
            Vector3 direction = target.transform.position - transform.position;
            RaycastHit hit;
            Debug.DrawRay(transform.position, direction, Color.green);

            if (Physics.Raycast(transform.position, direction, out hit))
            {
                if (hit.collider.gameObject == target)
                {
                    Debug.DrawRay(transform.position, direction, Color.red);
                    //Debug.DrawLine(gameObject.transform.position + Vector3.up, target.transform.position, Color.red);
                    transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
                    SendMessageUpwards("Shoot");
                    lastSeenAt = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
                    canSee = true;
                }
                else
                {
                    Debug.DrawRay(transform.position, direction, Color.blue);
                    //Debug.DrawLine(gameObject.transform.position + Vector3.up, target.transform.position, Color.blue);
                }

                Debug.Log("Ray hit: " + hit.collider.name);
            }
        }

        Move(canSee);
    }

    private void Move(bool canSee)
    {
        if(!inRange)
        {
            nav.SetDestination(originalPosition);
            Debug.Log("Going back to original position");
            return;
        }

        if (canSee) return;
        
        if (lastSeenAt.x == 0 && lastSeenAt.y == 0 && lastSeenAt.z == 0) return;

        nav.SetDestination(new Vector3(lastSeenAt.x, gameObject.transform.position.y, lastSeenAt.z));
        Debug.Log("Moving to Last Seen");

    }

    public void PlayerInRange(object other)
    {
        target = (GameObject)other;
        Debug.Log("Player in range");
        inRange = true;
    }

    public void PlayerOutOfRange(object lastLocation)
    {
        target = null;
        Debug.Log("Player out of range");
        inRange = false;
    }
}
