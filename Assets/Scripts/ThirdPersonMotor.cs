using UnityEngine;

public class ThirdPersonMotor : MonoBehaviour
{
    public static ThirdPersonMotor Instance;
    public float MoveSpeed = 10f;
    public Vector3 MoveVector { get; set; }

    void Awake()
    {
        Instance = this;
    }

    void UpdateMotor()
    {
        SnapAlignCharacterWithCamera();
        ProcessMotion();
    }

    void ProcessMotion()
    {
        // Transform MoveVector to World Space
        MoveVector = transform.TransformDirection(MoveVector);

        // Normalize MoveVector if Magnitude > 1
        if (MoveVector.magnitude > 1)
            MoveVector.Normalize();

        // Multiply MoveVector by MoveSpeed
        MoveVector *= MoveSpeed;

        // Multiply MoveVector with Time.deltaTime
        MoveVector *= Time.deltaTime;

        // Move the Character in World Space
        ThirdPersonController.CharacterController.Move(MoveVector);
    }

    void SnapAlignCharacterWithCamera()
    {
        if(MoveVector.x != 0 || MoveVector.z != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
