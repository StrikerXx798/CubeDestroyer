using UnityEngine;

public class Looking : MonoBehaviour
{
    const string MouseX = "Mouse X";
    const string MouseY = "Mouse Y";

    [SerializeField] private float _speed;

    [SerializeField] private Transform _camera;

    [SerializeField] private Transform _body;

    void Update()
    {
        _camera.Rotate(_speed * -Input.GetAxis(MouseY) * Time.deltaTime * Vector3.right);
        _body.Rotate(_speed * Input.GetAxis(MouseX) * Time.deltaTime * Vector3.up);
    }
}
