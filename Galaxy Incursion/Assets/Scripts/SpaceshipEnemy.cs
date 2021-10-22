using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipEnemy : ShootableSpaceUnit
{  
    private float _timer;  

    protected override void Start()
    {
        base.Start();       
        Destroy(gameObject, 15f);
    }

    protected override void Move()
    {
        transform.Translate(Vector3.back * _movementSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void Update()
    {
        Move();

        if (_timer <= 0)
        {
            Shoot();
            _timer = _reloadTime;
        }
        else
        {
            _timer -= Time.deltaTime;
        }


    }
}
