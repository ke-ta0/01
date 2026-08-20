using UnityEngine;

public class Example_Rad : MonoBehaviour
{
    [SerializeField] float angle = 45f;
    [SerializeField] float speed = 3f;

    void Update()
    {
        float rad = angle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }
}
