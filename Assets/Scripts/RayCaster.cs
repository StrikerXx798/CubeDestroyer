using UnityEngine;
using System;

public class RayCaster : MonoBehaviour
{
    public event Action<Cube> OnCubeHit;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        if (InputReader.Instance != null)
        {
            InputReader.Instance.OnLeftClickInput += HandleLeftClickInput;
        }
    }

    private void OnDisable()
    {
        if (InputReader.Instance != null)
        {
            InputReader.Instance.OnLeftClickInput -= HandleLeftClickInput;
        }
    }

    private void HandleLeftClickInput()
    {
        PerformRaycast();
    }

    private void PerformRaycast()
    {
        if (!_mainCamera) return;

        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                OnCubeHit?.Invoke(cube);
            }
        }
    }
}