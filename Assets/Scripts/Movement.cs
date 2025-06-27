using UnityEngine;

public class Movement : MonoBehaviour
{
    const string Horizontal = "Horizontal";
    const string Vertical = "Vertical";

    [SerializeField] private float _speed;

    void Update()
    {
        var direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));

        transform.Translate(direction * (_speed * Time.deltaTime));
    }
}
