using UnityEngine;

public class RotateByDegree : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 90f; // 1•b‚Å90‹

    void Update()
    {
        // “xi‹j‚Å‰ñ“]‚³‚¹‚é
        transform.eulerAngles += new Vector3(0, 0, rotateSpeed * Time.deltaTime);
    }
}
