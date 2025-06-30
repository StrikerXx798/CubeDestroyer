using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    const string Horizontal = "Horizontal";
    const string Vertical = "Vertical";
    const string MouseX = "Mouse X";
    const string MouseY = "Mouse Y";
    private const int PrimaryActionMouseButton = 0; // заменили магическое число

    public event Action<Vector3> MovementInputReceived;
    public event Action<Vector3> LookInputReceived;
    public event Action PrimaryActionPerformed;

    private void Update()
    {
        ReadMovementInput();
        ReadLookInput();
        ReadPrimaryActionInput();
    }

    private void ReadMovementInput()
    {
        var movement = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));
        MovementInputReceived?.Invoke(movement);
    }

    private void ReadLookInput()
    {
        var look = new Vector3(Input.GetAxis(MouseX), Input.GetAxis(MouseY), 0f);
        LookInputReceived?.Invoke(look);
    }

    private void ReadPrimaryActionInput()
    {
        if (Input.GetMouseButtonDown(PrimaryActionMouseButton))
        {
            PrimaryActionPerformed?.Invoke();
        }
    }
}
