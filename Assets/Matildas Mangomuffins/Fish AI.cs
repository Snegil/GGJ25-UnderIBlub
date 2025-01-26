using UnityEngine;

public class FishAI : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    [SerializeField] int currentWayPoint;
    [SerializeField] float speed;
    [SerializeField] float reachedWayPoint = 0.1f;
    [SerializeField] GameObject player;

    [SerializeField] float aggroRange;
    [SerializeField] Vector3 directionToWayPoint;
    void Start()
    {
        currentWayPoint = 0;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        transform.right = transform.position - wayPoints[currentWayPoint].position;
        CheckForPlayer();
    }

    void Patrol()
    {
        transform.position =Vector3.MoveTowards(transform.position, wayPoints[currentWayPoint].position, speed * Time.deltaTime);
        float distanceToWayPoint = Vector3.Distance(transform.position,wayPoints[currentWayPoint].position);
        directionToWayPoint = transform.position - wayPoints[currentWayPoint].position;
        directionToWayPoint.Normalize();


        if(distanceToWayPoint <= reachedWayPoint)
        {
           
            currentWayPoint++;
        }
        if(currentWayPoint >= wayPoints.Length)
        {
            currentWayPoint = 0;
        }

    }

    void CheckForPlayer()
    {
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, aggroRange);       
        for (int i = 0; i < nearbyObjects.Length; i++)
        {
            if (nearbyObjects[i].tag == "Player")
            {
                Debug.Log("Player detected");
                transform.localScale += new Vector3(2,2,2);
                
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
