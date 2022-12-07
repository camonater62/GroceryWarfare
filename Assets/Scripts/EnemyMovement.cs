
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private CapsuleCollider trigger;
    public GameObject player;
    private float speed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        trigger = GetComponents<CapsuleCollider>()[1];
        speed = agent.speed;
    }

    void GotoNextPoint()
    {
        if (points.Length == 0) return;
        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 15f)
        {
            agent.destination = player.transform.position;
        }
        else if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            GotoNextPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FlyingCart")
        {
            StartCoroutine(GetHit());
        }
        else if(other.name == "Player")
        {
            Debug.Log("Game Over Bitch!");
        }
    }

    IEnumerator GetHit()
    {
        agent.speed = 0f;

        yield return new WaitForSeconds(3);

        agent.speed = speed;
    }
}
