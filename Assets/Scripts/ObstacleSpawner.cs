using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle;

    [SerializeField]
    private float _yOffsetMin = -1f, _yOffsetMax = 1f;

    [SerializeField]
    private PlayerController _player;

    private float _spawnFrequency = 3f;

    private float _timetTillNextSpawn = 0f;

    void Update()
    {
        if(_timetTillNextSpawn <= 0f && _player.IsAlive)
        {
            Vector3 newPosition = new Vector3(transform.position.x, Random.Range(_yOffsetMin, _yOffsetMax));
            Instantiate(_obstacle, newPosition, transform.rotation);
            _timetTillNextSpawn = _spawnFrequency;
        }
        else
        {
             _timetTillNextSpawn -= Time.deltaTime;
        }
    }
}
