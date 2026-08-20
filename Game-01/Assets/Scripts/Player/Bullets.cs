using System;
using System.Collections;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 10f;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DestroyTime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * BulletSpeed * Time.deltaTime;
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
