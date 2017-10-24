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
    }

    void GetLocomotionInput()
    {

    }
}
