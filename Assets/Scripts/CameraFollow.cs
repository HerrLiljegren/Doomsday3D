using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Camera cam;
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;
    public Vector3 velocity;
    public float velocityf;

    void Start()
    {
        velocity = Vector3.zero;
        velocityf = 0f;
        offset = new Vector3(0, 15.0f, -5.0f);
        smoothSpeed = 25f;
        cam = GetComponent<Camera>();

        //offset = target.transform.position - transform.position;
    }
    void LateUpdate()
    {
        //float currentAngle = transform.eulerAngles.y;
        //float desiredAngle = target.eulerAngles.y;
        //float angle = Mathf.SmoothDampAngle(currentAngle, desiredAngle, ref velocityf, smoothSpeed * Time.deltaTime);
        //Quaternion rotation = Quaternion.Euler(0, angle, 0);
        //transform.position = target.position - (rotation * offset);

        //Vector3 point = cam.WorldToViewportPoint(target.position);
        //Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        //Vector3 destination = transform.position + delta;
        //transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);


        Vector3 desiredPosition = target.position + offset;
        // Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed * Time.deltaTime);
        transform.position = desiredPosition; // smoothedPosition;

        transform.LookAt(target);


        //float currentAngle = transform.eulerAngles.y;
        //float desiredAngle = target.transform.eulerAngles.y;
        //float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * smoothSpeed);

        //Quaternion rotation = Quaternion.Euler(0, angle, 0);
        //transform.position = target.transform.position - (rotation * offset);

        //transform.LookAt(target.transform);

        //float horizontal = Input.GetAxis("Mouse X") * 5;
        //target.transform.Rotate(0, horizontal, 0);

        //float desiredAngle = target.transform.eulerAngles.y;
        //Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        //transform.position = target.transform.position - (rotation * offset);

        //transform.LookAt(target.transform);
        //Debug.Log("Horizontal: " + horizontal + ", desiredAngle: " + desiredAngle);
    }
}
