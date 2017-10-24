using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public static CharacterController CharacterController;
    public static ThirdPersonController Instance;

    void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        Instance = this;
    }

    void Update()
    {
        if (Camera.main == null)
            return;

        GetLocomotionInput();
        ThirdPersonMotor.Instance.UpdateMotor();
    }

    void GetLocomotionInput()
    {
        var deadzone = 0.1f;

        ThirdPersonMotor.Instance.MoveVector = Vector3.zero;

        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        if (v > deadzone || v < -deadzone)
            ThirdPersonMotor.Instance.MoveVector += new Vector3(0, 0, v);

        if (h > deadzone || h < -deadzone)
            ThirdPersonMotor.Instance.MoveVector += new Vector3(h, 0, 0);
    }
}
