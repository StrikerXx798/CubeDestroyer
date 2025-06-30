using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    private const float AreaSizeStep = 0.5f;
    private const int InitialCubeLevel = 1;

    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _cubesContainer;
    [SerializeField] private int _initialCubeCount = 5;

    private void Awake()
    {
        CreateCubesContainer();
    }

    private void CreateCubesContainer()
    {
        if (_cubesContainer is null)
        {
            var container = new GameObject("Cubes Container").transform;
            _cubesContainer = container;
        }
    }

    private void Start()
    {
        SpawnInitialCubes();
    }

    private void SpawnInitialCubes()
    {
        for (var i = 0; i < _initialCubeCount; i++)
        {
            var spawnPosition = Vector3.zero;
            SpawnCubes(spawnPosition, InitialCubeLevel, Vector3.one, 1);
        }
    }

    public List<Cube> SpawnCubes(Vector3 position, int level, Vector3 scale, int count)
    {
        var newCubes = new List<Cube>();

        for (var i = 0; i < count; i++)
        {
            var spawnPosition = position + Random.insideUnitSphere * 0.5f;
            var cube = Instantiate(_cubePrefab, spawnPosition, Random.rotation);

            if (_cubesContainer is not null)
            {
                cube.transform.SetParent(_cubesContainer);
            }

            cube.Initialize(level, scale);
            cube.Destroyed += OnCubeDestroyed;
            newCubes.Add(cube);
        }

        return newCubes;
    }

    private void OnCubeDestroyed(Cube cube)
    {
        cube.Destroyed -= OnCubeDestroyed;
        Destroy(cube.gameObject);
    }
}
