using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 30f;

    private Vector3 _moveDirection;

    private void OnEnable()
    {
        InputReader.Instance.OnMovementInput += HandleMovementInput;
    }

    private void OnDisable()
    {
        InputReader.Instance.OnMovementInput -= HandleMovementInput;
    }

    private void HandleMovementInput(Vector3 movementInput)
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
