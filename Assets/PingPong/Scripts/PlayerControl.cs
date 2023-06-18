using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private string _keyUp;
    private string _keyDown;

    public InputAction Input { get; private set; }

    private void Start()
    {
        _keyUp = "uparrow";
        _keyDown = "downarrow";

        Input = new InputAction();

        Input.AddCompositeBinding("Axis")
            .With("Positive", $"<keyboard>/{_keyUp}")
            .With("Negative", $"<keyboard>/{_keyDown}");
        Input.AddCompositeBinding("Axis(whichSideWins=1)");

        Input.Enable();
    }
}
