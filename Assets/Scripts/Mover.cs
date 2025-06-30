using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 30f;
    [SerializeField] private InputReader _inputReader;

    private Vector3 _moveDirection;

    private void OnEnable()
    {
        if (_inputReader != null)
            _inputReader.MovementInputReceived += OnMovementInputReceived;
    }

    private void OnDisable()
    {
        if (_inputReader != null)
            _inputReader.MovementInputReceived -= OnMovementInputReceived;
    }

    private void OnMovementInputReceived(Vector3 movementInput)
    {
        _moveDirection = movementInput;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_moveDirection * (_speed * Time.deltaTime));
    }
}
