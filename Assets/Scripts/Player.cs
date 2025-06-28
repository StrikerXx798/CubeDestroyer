using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private int _minCubeCount = 2;
    [SerializeField] private int _maxCubeCount = 6;

    private void OnValidate()
    {
        if (_minCubeCount > _maxCubeCount)
            _minCubeCount = _maxCubeCount - 1;
    }

    private void OnEnable()
    {
        _rayCaster.OnCubeHit += HandleCubeHit;
    }

    private void OnDisable()
    {
        _rayCaster.OnCubeHit -= HandleCubeHit;
    }

    private void HandleCubeHit(Cube cube)
    {
        if (cube.TryGetComponent<Cube>(out var cubeComponent))
        {
            var level = cubeComponent.Level;
            var shouldSplit = RandomUtils.ShouldSplit(level);

            if (shouldSplit)
            {
                var position = cube.transform.position;
                var scale = cube.transform.localScale;
                var childCount = Random.Range(_minCubeCount, _maxCubeCount + 1);
                var childScale = scale / 2f;
                var childLevel = level + 1;

                var newCubes = CubeSpawner.Instance.SpawnCubes(
                    position,
                    childLevel,
                    childScale,
                    childCount);

                Exploder.Instance.ExplodeCubes(newCubes, position);
            }

            Destroy(cube.gameObject);
        }
    }
}
