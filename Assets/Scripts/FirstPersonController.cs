using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{    
    public float movementSpeed = 10.0f;
    public float mouseSensitivity = 10.0f;
    public float verticalAngleLimit = 60.0f;
    public float jumpSpeed = 5.0f;

    private CharacterController _characterController;
    private float verticalRotation;
    private bool lockCursor;

    private Vector3 _velocity = Vector3.zero;

    public float angle;

    // Use this for initialization
    void Start () {        
        _characterController = GetComponent<CharacterController>();        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;            
        }


        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);            
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }


        //var pos = Input.mousePosition;
        //pos.z = 5.23f;
        //var obj = Camera.main.WorldToScreenPoint(transform.position);
        //pos.x = pos.x - obj.x;
        //pos.y = pos.y - obj.y;
        //angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, -angle+90, 0));
        //Debug.Log(pos);

        // Rotation
        //float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        //transform.Rotate(0.0f, horizontalRotation, 0.0f);

        // verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        // verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);        
        // Camera.main.transform.localRotation= Quaternion.Euler(verticalRotation, 0.0f, 0.0f);

        // Movement
        _velocity.x = Input.GetAxis("Horizontal") * movementSpeed; // Forward speed
        _velocity.y += (Physics.gravity.y * 2) * Time.deltaTime; // Fall speed
        _velocity.z = Input.GetAxis("Vertical") * movementSpeed; // Side speed
        

        if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            _velocity.y = jumpSpeed;
        }

        if(!_characterController.isGrounded)
        {            
            _velocity.x /= 2;
        }       
         
        _characterController.Move(_velocity * Time.deltaTime);        
    }

    private void OnGUI()
    {        
        if (lockCursor)
        {
            Debug.Log("locked");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
