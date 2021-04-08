using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public delegate void HorizontalMove(HorizontalType type);
    public static HorizontalMove _HorizontalMove;

    public delegate void VerticallMove(VerticalType type);
    public static VerticallMove _VerticallMove;

    public delegate void MouseWheel(VerticalType type);
    public static MouseWheel _MouseWheel;

    public delegate void MouseButton();
    public static MouseButton _MouseButton;

    public enum VerticalType
    {
        Up = 0,
        Down
    }

    public enum HorizontalType
    {
        Left = 0,
        Right = 1
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        if (Input.GetMouseButtonDown(0)) _MouseButton?.Invoke();

        if (Input.GetKey(KeyCode.W)) _VerticallMove?.Invoke(VerticalType.Up);
        else if (Input.GetKey(KeyCode.S)) _VerticallMove?.Invoke(VerticalType.Down);

        if (Input.GetKey(KeyCode.A)) _HorizontalMove?.Invoke(HorizontalType.Left);
        else if (Input.GetKey(KeyCode.D)) _HorizontalMove?.Invoke(HorizontalType.Right);

        float mouseScrollWheel = GetScrollWheel();

        if (mouseScrollWheel != 0)
        {
            if (mouseScrollWheel > 0) _MouseWheel?.Invoke(VerticalType.Up);
            else _MouseWheel?.Invoke(VerticalType.Down);
        }
    }

    private float GetScrollWheel()
    {
        return Input.GetAxis("Mouse ScrollWheel");
    }
}
