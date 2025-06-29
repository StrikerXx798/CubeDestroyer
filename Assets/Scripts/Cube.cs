using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class Cube : MonoBehaviour
{
    private const float Opacity = 1f;

    private Renderer _renderer;

    public int Level { get; private set; } = 1;
    public Rigidbody Rigidbody { get; private set; }

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
        if (_renderer is null) return;

        var randomColor = new Color(
            Random.value,
            Random.value,
            Random.value,
            Opacity
        );

        _renderer.material.color = randomColor;
    }
}
