using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private Transform _cubesContainer;

    public static CubeSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CreateCubesContainer();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateCubesContainer()
    {
        if (_cubesContainer == null)
        {
            GameObject container = new GameObject("Cubes Container");
            _cubesContainer = container.transform;
        }
    }

    public List<Cube> SpawnCubes(Vector3 position, int level, Vector3 scale, int count)
    {
        List<Cube> newCubes = new List<Cube>();

        for (var i = 0; i < count; i++)
        {
            Vector3 spawnPosition = position + Random.insideUnitSphere * 0.5f;
            GameObject cubeObject = Instantiate(_cubePrefab, spawnPosition, Random.rotation);

            if (_cubesContainer is not null)
            {
                cubeObject.transform.SetParent(_cubesContainer);
            }

            if (cubeObject.TryGetComponent<Cube>(out Cube cubeComponent))
            {
                cubeComponent.Initialize(level, scale);
                newCubes.Add(cubeComponent);
            }
        }

        return newCubes;
    }
}
