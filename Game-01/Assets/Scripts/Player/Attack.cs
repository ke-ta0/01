using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float AttackRange = 0.5f;
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private int Damage = 10;
    [SerializeField] private float AttackCooldown = 0.3f;

    private float lastAttackTime = 0f;

    // 攻撃中だけ Gizmo を出す
    private bool isAttacking = false;

    void Update()
    {
        // プレイヤーの向きに合わせて AttackPoint を左右に移動
        float dir = transform.localScale.x; // 1 or -1
        AttackPoint.localPosition = new Vector3(0.5f * dir, AttackPoint.localPosition.y, 0);

        bool canAttack = Time.time >= lastAttackTime + AttackCooldown;

        if (Input.GetKeyDown(KeyCode.V) && canAttack)
        {
            StartCoroutine(AttackCoroutine());
            lastAttackTime = Time.time;
        }
    }

    IEnumerator AttackCoroutine()
    {
        // 攻撃開始
        isAttacking = true;

        // 実際の攻撃処理
        Attack();

        // 攻撃判定を出す時間（0.1秒）
        yield return new WaitForSeconds(0.3f);

        // 攻撃終了
        isAttacking = false;
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            AttackPoint.position,
            AttackRange,
            EnemyLayer
        );

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
        // 攻撃中だけ Gizmo を表示
        if (AttackPoint != null && isAttacking)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
        }
    }
}
