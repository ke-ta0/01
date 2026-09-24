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
    [SerializeField] private float health = 3.0f;
    [SerializeField] private float Range = 5.0f;
    [SerializeField] private float Speed = 3.0f;
    private float currentHP;
    private float AttackRange = 1.5f;
    private bool isAttacking = false;
    // Œ»İ‚Ìs“®
    private Act state;
    // F
    private SpriteRenderer sr;
    void Start()
    {
        currentHP = health;
        sr = GetComponent<SpriteRenderer>();
        // Å‰‚Ìs“®‚ğWalk‚Éİ’è
        state = Act.Walk;
    }
    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, Target.position);

        if (dist <= Range)
        {
            state = Act.fight;
        }

        else if (currentHP <= 1)
        {
            state = Act.escape;
        }
        else
        {
            state = Act.Walk; ;
        }

        switch (state)
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

    public void TakeDamage(int damage, float attackDir)
    {
        currentHP -= damage;
        StartCoroutine(FlashRed());
        KnockBack(1.5f, attackDir);
        Debug.Log("ƒ_ƒ[ƒWó‚¯\‚µ‚½");
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("‚â‚ç‚ê‚½");
        }
    }
    IEnumerator FlashRed()
    {
        Color original = sr.color;

        sr.color = Color.red;          // Ô‚­‚·‚é
        yield return new WaitForSeconds(0.1f); // 0.1•b‘Ò‚Â
        sr.color = original;           // Œ³‚É–ß‚·
    }
    void KnockBack(float knockPower, float attackDir)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(attackDir * knockPower, 0), ForceMode2D.Impulse);
    }


    void Walk()
        {
            //transform.Translate(Vector2.left * Speed * Time.deltaTime);
            Debug.Log("•à‚¢‚Ä‚Ü‚·");
        }

    void fight()
    {
        float dist = Vector2.Distance(transform.position, Target.position);

        // š‹——£‚ª0.5–¢–‚È‚ç~‚Ü‚Á‚ÄUŒ‚
        if (dist <= 0.5f)
        {
            if (!isAttacking)
            {
                StartCoroutine(Attack());
            }
            return; // š~‚Ü‚é
        }

        // šUŒ‚’†‚Í“®‚©‚È‚¢
        if (isAttacking) return;

        // š¶‰E•ûŒü‚¾‚¯‚Å•ûŒü‚ğŒˆ‚ß‚é
        float dir = Mathf.Sign(Target.position.x - transform.position.x);
        Vector2 move = new Vector2(dir, 0);

        transform.position += (Vector3)(move * Speed * Time.deltaTime);

        // UŒ‚‹——£‚É“ü‚Á‚½‚çUŒ‚
        if (dist <= AttackRange)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        Debug.Log("UŒ‚’†");

        // UŒ‚ƒAƒjƒ[ƒVƒ‡ƒ“‚âˆ—
        yield return new WaitForSeconds(1f);

        isAttacking = false;
    }


    void escape()
        {
            Vector2 dist2 = (transform.position - Target.position).normalized;
            // ã‰ºˆÚ“®‚µ‚È‚¢
            dist2.y = 0;
            transform.position += (Vector3)(dist2 * Speed * Time.deltaTime);
        }
    
}

