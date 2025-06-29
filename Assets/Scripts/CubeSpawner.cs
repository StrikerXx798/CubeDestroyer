using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Transform _cubesContainer;

    private void Awake()
    {
        CreateCubesContainer();
    }

    private void CreateCubesContainer()
    {
        if (_cubesContainer is null)
        {
            var container = new GameObject("Cubes Container");
            _cubesContainer = container.transform;
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
            newCubes.Add(cube);
        }

        return newCubes;
    }
}
