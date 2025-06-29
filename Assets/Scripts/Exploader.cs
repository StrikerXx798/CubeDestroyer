using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 20f;
    [SerializeField] private float _explosionRadius = 200f;

    public void ExplodeCubes(List<Rigidbody> rigidBodies, Vector3 explosionCenter)
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
        }
    }
}
