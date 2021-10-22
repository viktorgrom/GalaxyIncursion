using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSpaceUnits : SpaceUnit
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _rotate = 5;
    private Rigidbody rb;
   

    protected override void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Move();
    }


    protected override void Move()
    {
        rb.angularVelocity = Random.insideUnitSphere * _rotate;
        rb.velocity = Vector3.back * _movementSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            other.gameObject.GetComponent<Player>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

}
