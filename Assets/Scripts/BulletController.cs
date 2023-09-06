using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    private const float distanceFromCenterOfGame = 50f;
    
    [SerializeField] private float bulletSpeed = 20f;
    private Rigidbody bulletRigidbody;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }
    private void Update()
    {
        if (distanceFromCenterOfGame < Mathf.Abs(transform.position.x) || distanceFromCenterOfGame < Mathf.Abs(transform.position.y) || distanceFromCenterOfGame < Mathf.Abs(transform.position.z)) 
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); 
    }
}
