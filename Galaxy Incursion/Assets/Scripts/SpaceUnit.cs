using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public abstract class SpaceUnit : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 30;
    [SerializeField] protected float _movementSpeed = 15f;
    [SerializeField] protected Boundary boundary;
    [SerializeField] private int _points = 0;
    
    protected UniRxStats _uniRxStats;
    protected Rigidbody _rigidbody;
    protected int _currentHealth;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody = GetComponent<Rigidbody>();       
        _uniRxStats = GameObject.FindGameObjectWithTag("UI").GetComponent<UniRxStats>();
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Stats.Score += 10;           
            Destroy(gameObject);
        }
        print(_currentHealth);
       
    }

    protected abstract void Move();
   
}
