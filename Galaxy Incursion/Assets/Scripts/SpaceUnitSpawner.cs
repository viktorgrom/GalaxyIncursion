using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceUnitSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spaceUnits;
    [SerializeField] private List<Transform> _spawnPints;
    [SerializeField] private float _spawnTime = 4f;

    void Start()
    {
        StartCoroutine(SpawnUnit());
    }

    IEnumerator SpawnUnit()
    {
        while (true)
        {
            int limit;
            if (Stats.Level > _spaceUnits.Count)
                limit = Stats.Level;
            else
                limit = _spaceUnits.Count;
            Instantiate(_spaceUnits[Random.Range(0, Stats.Level)], _spawnPints[Random.Range(0, _spawnPints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
