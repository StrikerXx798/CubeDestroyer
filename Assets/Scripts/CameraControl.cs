using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _speed = 50f;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;
    [SerializeField] private InputReader _inputReader;

    private Vector3 _lookInput;

    private void OnEnable()
    {
        _inputReader.LookInputReceived += OnLookInputReceived;
    }

    private void OnDisable()
    {
        _inputReader.LookInputReceived -= OnLookInputReceived;
    }

    private void OnLookInputReceived(Vector3 lookInput)
    {
        _lookInput = lookInput;
    }

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        _camera.Rotate(_speed * -_lookInput.y * Time.deltaTime * Vector3.right);
        _body.Rotate(_speed * _lookInput.x * Time.deltaTime * Vector3.up);
    }
}
