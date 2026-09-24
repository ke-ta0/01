using UnityEngine;

public class Collect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        var pickup = col.GetComponent<Item>();
        if (pickup != null)
        {
            Hotbar.instance.AddItem(pickup.data);
            Destroy(col.gameObject);
        }
    }

}
