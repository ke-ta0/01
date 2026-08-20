using UnityEngine;

public class AngleChanger : MonoBehaviour
{
    [SerializeField] private Transform GunPoint;
    [SerializeField] private float angle = 0f;
    [SerializeField] private float AngleSpeed = 90f;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private LineRenderer line;   // LineRenderer を参照

    void Update()
    {
        Change();
        GunPoint.localEulerAngles = new Vector3(0, 0, angle);

        DrawLine(); // 角度の線を描く

        if (Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }
    }

    void Change()
    {
        if (Input.GetKey(KeyCode.W))
        {
            angle += AngleSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            angle -= AngleSpeed * Time.deltaTime;
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, GunPoint.position, GunPoint.rotation);
    }

    // 角度の線を描く
    void DrawLine()
    {
        if (GunPoint == null || line == null)
            return;

        // GunPoint の向き（右方向）
        Vector3 dir = GunPoint.right;

        // LineRenderer の始点と終点を設定
        line.SetPosition(0, GunPoint.position);
        line.SetPosition(1, GunPoint.position + dir * 2f);
    }
}
