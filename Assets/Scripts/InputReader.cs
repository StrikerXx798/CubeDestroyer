using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    const string Horizontal = "Horizontal";
    const string Vertical = "Vertical";
    const string MouseX = "Mouse X";
    const string MouseY = "Mouse Y";

    public event Action<Vector3> OnMovementInput;
    public event Action<Vector3> OnLookInput;
    public event Action OnLeftClickInput;

    private void Update()
    {
        ReadMovementInput();
        ReadLookInput();
        ReadLeftClickInput();
    }

    private void ReadMovementInput()
    {
        var movement = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
        OnMovementInput?.Invoke(movement);
    }

    private void ReadLookInput()
    {
        var look = new Vector3(Input.GetAxis(MouseX), Input.GetAxis(MouseY), 0f);
        OnLookInput?.Invoke(look);
    }

    private void ReadLeftClickInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftClickInput?.Invoke();
        }
    }
}
