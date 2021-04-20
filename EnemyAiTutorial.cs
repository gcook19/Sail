using UnityEngine;
using UnityEngine.AI;
using System.Collections; 
public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    public Animator animator; 
    public float health;
    public float damage; 

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, deadBool;


    private void Awake()
    {
        //player = GameObject.Find("CenterEyeAnchor").transform;
        //Debug.Log("Name of Player according to AI: " + player.gameObject.name); 
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        //Debug.Log("Animator:" + animator);
        deadBool = false; 
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (deadBool == false)
        {
            if (!playerInSightRange && !playerInAttackRange)
            {
                //animator.SetBool("Die", false);
                //animator.SetBool("Walk", true);
                //animator.SetBool("Attack", false);
                Patroling();
                //animator.SetTrigger("Walk"); 
            }

            if (playerInSightRange && !playerInAttackRange)
            {
                //animator.SetBool("Die", false);
                //animator.SetBool("Walk", true);
                //animator.SetBool("Attack", false);
                ChasePlayer();
                //animator.SetTrigger("Walk");
            }
            if (playerInAttackRange && playerInSightRange)
            {
                //animator.SetBool("Die", false);
                //animator.SetBool("Walk", false);
                //animator.SetBool("Attack", true);
                animator.SetTrigger("Attack"); 
                AttackPlayer();
                //animator.SetTrigger("Attack"); 
                //Debug.Log("Attack Called"); 
            }
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //animator.SetTrigger("Walk");
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        //animator.SetTrigger("Walk"); 
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        //transform.LookAt(player, Vector3.up);

        if (!alreadyAttacked)
        {
            ///Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            //animator.SetTrigger("Attack"); 
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        deadBool = true;
        //animator.SetBool("Die", true);
        //animator.SetBool("Walk", false);
        //animator.SetBool("Attack", false);
        animator.SetTrigger("Die"); 
        Debug.Log("Death called");
        Collider col = GetComponent<Collider>();
        col.enabled = false;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
        StartCoroutine(destoryGO()); 
    }
    
    private IEnumerator destoryGO()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void enemryHit()
    {
        health -= damage; 

        if(health <= 0)
        {
            DestroyEnemy();
            Debug.Log("Death called");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collider enter on Enemry:" + collision.gameObject.tag);
        //Debug.Log("Tag Compare:" + collision.gameObject.tag);

        if(collision.gameObject.CompareTag("Sword"))
        {
            //animator.SetBool("Hit", true);
            //animator.SetBool("Walk", false);
            //animator.SetBool("Attack", false);
            animator.SetTrigger("Hit"); 
            Debug.Log("Hit called");
            enemryHit(); 
        }
        else
        {
            //Debug.Log("Not called");
        }
    }
}
