
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private CapsuleCollider trigger;
    public GameObject player;
    private float speed;
    public Text timer;
    public float countdown = 90;

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
        countdown -= Time.deltaTime;
        timer.text= countdown.ToString();
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
        Animator anim = GameObject.Find("Casual1").GetComponent<Animator>();
        anim.CrossFadeInFixedTime("DAMAGED00", 0.1f);
        agent.speed = 0f;

        yield return new WaitForSeconds(3);

        agent.speed = speed;
    }
}
