using UnityEngine;
using System;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Camera _mainCamera;

    public event Action<Cube> CubeHit;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.PrimaryActionPerformed += PerformRaycast;
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.PrimaryActionPerformed -= PerformRaycast;
        }
    }

    private void PerformRaycast()
    {
        if (_mainCamera is null)
            return;

        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                CubeHit?.Invoke(cube);
            }
        }
    }
}