using System.Collections;
using System.IO;
using UnityEditorInternal;
using UnityEngine;


enum Act
{
    Walk,
    fight,
    escape
};
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject AttackObj;
    [SerializeField] private Transform Target;
    [SerializeField] private float HP = 3.0f;
    [SerializeField] private float Range = 5.0f;
    [SerializeField] private float Speed = 3.0f;
    private float currentHP;
    private float AttackRange = 1.5f;
    private bool isAttacking = false;
    // 現在の行動
    private Act state;
    
    void Start()
    {
        currentHP = HP;
        // 最初の行動をWalkに設定
        state = Act.Walk;
    }
    　　// Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, Target.position);

        if(dist <= Range)
        {
            state = Act.fight;
        }

        else if(currentHP <= 1)
        {
            state = Act.escape;
        }
        else
        {
            state = Act.Walk; ;
        }

        switch(state)
        {
            case Act.Walk:
                Walk();
                break;

            case Act.fight:
                fight();
                break;

            case Act.escape:
                escape();
                break;
        }
    }
    void Walk()
    {
        //transform.Translate(Vector2.left * Speed * Time.deltaTime);
        Debug.Log("歩いてます");
    }

    void fight()
    {
        float dist = Vector2.Distance(transform.position, Target.position);
        if(isAttacking)
        {
            return;
        }

        Vector2 dist2 = (Target.position - transform.position).normalized;
        // 上下移動しない
        dist2.y = 0;
        transform.position += (Vector3)(dist2 * Speed * Time.deltaTime);
        if (dist <= AttackRange)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        isAttacking = true;   // 攻撃開始
        Debug.Log("攻撃中");

        // 攻撃アニメーションや処理
        yield return new WaitForSeconds(1f);

        isAttacking = false;  // 攻撃終了

    }

    void escape()
    {
        Vector2 dist2 = (transform.position - Target.position).normalized;
        // 上下移動しない
        dist2.y = 0;
        transform.position += (Vector3)(dist2 * Speed * Time.deltaTime);
    }
}

