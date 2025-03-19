using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float detectionRange = 5f;
    public float loseRange = 7f;
    public Transform player;
    private EnemyMovement enemyMovement;

    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (player != null && distanceToPlayer <= detectionRange)
        {
            Debug.Log("Player detected! Chasing...");
            enemyMovement.StartChase(player);
        }
        else if (distanceToPlayer > loseRange)
        {
            Debug.Log("Lost player, resuming patrol.");
            enemyMovement.StopChase();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, loseRange);
    }
}