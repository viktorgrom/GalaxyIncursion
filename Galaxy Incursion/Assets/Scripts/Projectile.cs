using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private string _myType = "";
    private AudioSource audioSource;

    private UniRxStats uniRxStats;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Destroy(gameObject, 3f);
        uniRxStats = GameObject.FindGameObjectWithTag("UI").GetComponent<UniRxStats>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SpaceUnit>() != null && collision.gameObject.tag != _myType)
        {
            collision.gameObject.GetComponent<SpaceUnit>().TakeDamage(_damage);
            uniRxStats.AddScore(10);
            Destroy(gameObject);
        }
    }



}
