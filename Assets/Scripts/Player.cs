using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float SplitScaleDivider = 2f;
    private const int SplitLevelIncrement = 1;

    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CubeSpawner _cubeSpawner;
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
        if (cube is null)
            return;

        var position = cube.transform.position;
        var scale = cube.transform.localScale;
        var level = cube.Level;
        var shouldSplit = RandomUtils.ShouldSplit(level);

        if (shouldSplit)
        {
            SplitCube(position, scale, level);
        }
        else
        {
            ExplodeCube(cube, position, level);
        }

        Destroy(cube.gameObject);
    }

    private void SplitCube(Vector3 position, Vector3 scale, int level)
    {
        var childCount = Random.Range(_minCubeCount, _maxCubeCount + 1);
        var childScale = scale / SplitScaleDivider;
        var childLevel = level + SplitLevelIncrement;

        var newCubes = _cubeSpawner.SpawnCubes(
            position,
            childLevel,
            childScale,
            childCount);

        var rigidBodies = newCubes.Select(newCube => newCube.Rigidbody).ToList();
        _exploder.ExplodeCubes(rigidBodies, position);
    }
    
    private void ExplodeCube(Cube cube, Vector3 position, int level)
    {
        _exploder.CreateExplosion(position, level);
        cube.CreateDestructionEffect();
    }
}
