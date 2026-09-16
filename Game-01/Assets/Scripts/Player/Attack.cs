using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float AttackRange;
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private int Damage;
    [SerializeField] private float AttackCooldown;
    private float lastAttackTime = 0f;

    void Update()
    {
        bool canAttack = Time.time >= lastAttackTime + AttackCooldown;

        if(Input.GetKeyDown(KeyCode.V) && canAttack)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            var health = enemy.GetComponent<Enemy>();
            if (health != null)
            {
                health.TakeDamage(Damage, 1.5f);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
        }
    }
}
