using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MannequinScript : MonoBehaviour {
    [Header("Value Option"), Space(5)]
    public float lookRadiusDetect = 10f;
    public float lookRadiusAttack = 8f;
    public float lookRadiusCharge = 4f;
    public float speedWalk = 1f;
    public float timeToReset = 1f;
    public float time;
    public bool isAttack;
    public int RandomAnimation = 0;
    public bool isMove = true;

    [Header("Default Option"), Space(5)]
    public Animator animationPlay;
    public GameObject player;
    public HealthManager HealthManager;
    public GameObject AttackCollision;
    public GameManager gameManager;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        isAttack = false;
        AttackCollision.SetActive(false);
        player = GameObject.Find("Player").gameObject;
        HealthManager = player.GetComponent<HealthManager>();
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if(isMove && gameManager.IsWin == false)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            this.gameObject.GetComponent<NavMeshAgent>().enabled = true;

            if (!isAttack && HealthManager.Isdead == false)
            {
                AttackCollision.SetActive(false);
                if (distance <= lookRadiusDetect)
                {
                    speedWalk = 1f;
                    agent.SetDestination(this.gameObject.transform.position);

                    if (distance <= agent.stoppingDistance || distance == agent.stoppingDistance)
                    {
                        isAttack = true;
                    }

                    if (distance <= lookRadiusAttack)
                    {
                        speedWalk = 1.5f;
                        animationPlay.SetFloat("Velocity", 1.0f);
                        animationPlay.SetBool("IsWalk", true);
                        animationPlay.SetInteger("IdleState", 6);
                        agent.SetDestination(target.position);
                        agent.speed = speedWalk;

                        if (distance <= lookRadiusCharge)
                        {
                            animationPlay.SetFloat("Velocity", 1.0f);
                            animationPlay.SetBool("IsWalk", true);
                            animationPlay.SetInteger("IdleState", 6);
                            agent.SetDestination(player.transform.position);
                            agent.speed = speedWalk;
                            speedWalk = 2f;

                            if (distance <= agent.stoppingDistance || distance == agent.stoppingDistance)
                            {
                                isAttack = true;
                            }
                        }

                        if (distance <= agent.stoppingDistance || distance == agent.stoppingDistance)
                        {
                            isAttack = true;
                        }
                    }
                    else
                    {
                        animationPlay.SetFloat("Velocity", 0.0f);
                        animationPlay.SetBool("IsWalk", false);
                        RandomAnimation = Random.Range(0, 6);
                        animationPlay.SetInteger("IdleState", RandomAnimation);

                        if (distance <= agent.stoppingDistance || distance == agent.stoppingDistance)
                        {
                            isAttack = true;
                        }
                    }
                }
                else
                {
                    animationPlay.SetFloat("Velocity", 0.0f);
                    animationPlay.SetBool("IsWalk", false);
                    RandomAnimation = Random.Range(0, 6);
                    animationPlay.SetInteger("IdleState", RandomAnimation);

                    if (distance <= agent.stoppingDistance || distance == agent.stoppingDistance)
                    {
                        isAttack = true;
                    }
                }
            }

            if (isAttack && HealthManager.Isdead == false)
            {
                FaceTarget();

                animationPlay.SetFloat("Velocity", 0.0f);
                animationPlay.SetBool("IsWalk", false);
                animationPlay.SetBool("IsAttack", true);
                AttackCollision.SetActive(true);

                if (distance >= agent.stoppingDistance + 0.1f)
                {
                    isAttack = false;
                    animationPlay.SetBool("IsAttack", false);
                }
            }

            if (HealthManager.Isdead == true && (!isAttack || isAttack))
            {
                animationPlay.SetFloat("Velocity", 0.0f);
                animationPlay.SetBool("IsWalk", false);
                RandomAnimation = Random.Range(0, 6);
                animationPlay.SetInteger("IdleState", RandomAnimation);
            }
        }
        else
        {
            this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            speedWalk = 0f;
            float distance = Vector3.Distance(this.gameObject.transform.position, this.gameObject.transform.position);
            animationPlay.SetFloat("Velocity", 0.0f);
            animationPlay.SetBool("IsWalk", false);
            animationPlay.SetBool("IsAttack", false);
            RandomAnimation = Random.Range(0, 6);
            animationPlay.SetInteger("IdleState", RandomAnimation);
        }

        if(gameManager.IsWin == true)
        {
            this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            speedWalk = 0f;
            float distance = Vector3.Distance(this.gameObject.transform.position, this.gameObject.transform.position);
            animationPlay.SetFloat("Velocity", 0.0f);
            animationPlay.SetBool("IsWalk", false);
            animationPlay.SetBool("IsAttack", false);
            RandomAnimation = Random.Range(0, 6);
            animationPlay.SetInteger("IdleState", RandomAnimation);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AttackPlayer()
    {
        isAttack = true;
    }

    public void IsVisible()
    {
        if(isMove == false)
        {
            animationPlay.SetFloat("Velocity", 0.0f);
            animationPlay.SetBool("IsWalk", false);
            animationPlay.SetBool("IsAttack", false);
            RandomAnimation = Random.Range(0, 6);
            animationPlay.SetInteger("IdleState", RandomAnimation);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "IgnoredCollission")
        {
            Physics.IgnoreCollision(collision.collider, collision.collider);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lookRadiusDetect);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadiusAttack);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lookRadiusCharge);
    }
}
