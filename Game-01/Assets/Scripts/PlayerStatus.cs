using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // HP
    [SerializeField] private float HP = 100;
    // 攻撃力
    [SerializeField] private float Power = 10;
    // 防御力
    [SerializeField] private float Defense = 5;
    // 移動速度
    [SerializeField] private float MoveSpeed = 5;
    // ジャンプ力
    [SerializeField] private float JumpPower = 10;
    // ジャンプするためのbool
    private bool isGround = false;
    // Rigidbody2D
    private Rigidbody2D rb2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 移動処理
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x * MoveSpeed * Time.deltaTime, 0, 0);

        // ジャンプ処理
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                isGround = false;
                Debug.Log("ジャンプしました");
            }
        }
        // ジャンプ中の処理
        else if (!isGround)
        {
            Debug.Log("ジャンプ中");
        }
    }
    // ダメージ処理
    public void Damage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    // 地面にいるとき
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("ジャンプできます");
        }
    }
    // 地面から離れたとき
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
            Debug.Log("ジャンプできません");
        }
    }


}
