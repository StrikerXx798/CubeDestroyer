using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 20f;
    [SerializeField] private float _explosionRadius = 200f;

    public static Exploder Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ExplodeCubes(List<Cube> cubes, Vector3 explosionCenter)
    {
        foreach (Cube cube in cubes)
        {
            if (cube && cube.TryGetComponent<Rigidbody>(out var rigidBody))
            {
                rigidBody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
            }
        }
    }
}