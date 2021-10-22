using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : ShootableSpaceUnit
{
    private float _timer;
    [SerializeField] private float tilt;   

    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;       
        _uniRxStats.UpdateHp(_currentHealth);
        if (_currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Update()
    {
        Move();

        if (_timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                _timer = _reloadTime;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }

    }
    protected override void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rigidbody.velocity = direction.normalized * _movementSpeed;
        _rigidbody.position = new Vector3(
            Mathf.Clamp(_rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(_rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        _rigidbody.rotation = Quaternion.Euler(
            0.0f,
            0.0f,
            _rigidbody.velocity.x * -tilt
        );
    }

}
