using UnityEngine;
using System;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private const float Opacity = 1f;
    private const float MinHue = 0f;
    private const float MaxHue = 1f;
    private const float MinSaturation = 0.7f;
    private const float MaxSaturation = 1f;
    private const float MinBrightness = 0.7f;
    private const float MaxBrightness = 1f;
    private const float ExplodeEffectDuration = 1f;

    [SerializeField] private ExplosionEffect _explosionEffectPrefab;
    private Renderer _renderer;

    public event Action<Cube> Destroyed;

    public int Level { get; private set; } = 1;
    public Rigidbody Rigidbody { get; private set; }
    public Color Color { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(int level, Vector3 scale)
    {
        Level = level;
        transform.localScale = scale;
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        if (_renderer is null)
			return;

        Color = Random.ColorHSV(
            MinHue,
            MaxHue,
            MinSaturation,
            MaxSaturation,
            MinBrightness,
            MaxBrightness,
            Opacity,
            Opacity
        );

        _renderer.material.color = Color;
    }

    public void DestroyCube()
    {
        Destroyed?.Invoke(this);
    }

    public void CreateDestructionEffect(Vector3 position)
    {
        _explosionEffectPrefab.Play(position);
    }
}
