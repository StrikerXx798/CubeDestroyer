using UnityEngine;

[RequireComponent(typeof(Rigidbody))] public class Cube : MonoBehaviour
{
    private const float Opacity = 1f;
    [SerializeField] private int _level = 1;

    private Renderer _renderer;

    public int Level => _level;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(int level, Vector3 scale)
    {
        _level = level;
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
