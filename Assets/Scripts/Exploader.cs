using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _baseExplosionRadius = 10f;
    [SerializeField] private float _baseExplosionForce = 5f;

    public void ExplodeCubes(List<Rigidbody> rigidBodies, Vector3 explosionCenter)
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.AddExplosionForce(_baseExplosionForce, explosionCenter, _baseExplosionRadius);
        }
    }

    public void CreateExplosion(Vector3 explosionCenter, int level)
    {
        var explosionRadius = _baseExplosionRadius * level;
        var explosionForce = _baseExplosionForce * level;

        var colliders = Physics.OverlapSphere(explosionCenter, explosionRadius);

        var processedRigidbodies = new HashSet<Rigidbody>();

        foreach (var includesCollider in colliders)
        {
            var rigidBody = includesCollider.attachedRigidbody;

            if (!rigidBody)
                continue;

            if (processedRigidbodies.Contains(rigidBody))
                continue;

            processedRigidbodies.Add(rigidBody);
            rigidBody.AddExplosionForce(
                explosionForce,
                explosionCenter,
                explosionRadius,
                1.0f,
                ForceMode.Impulse
            );
        }
    }
}
