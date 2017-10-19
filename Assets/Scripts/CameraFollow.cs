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
        smoothSpeed = 0.15f;
        cam = GetComponent<Camera>();
    }
    void LateUpdate()
    {
        //float currentAngle = transform.eulerAngles.y;
        //float desiredAngle = target.eulerAngles.y;
        //float angle = Mathf.SmoothDampAngle(currentAngle, desiredAngle, ref velocityf, smoothSpeed * Time.deltaTime);
        //Quaternion rotation = Quaternion.Euler(0, angle, 0);
        //transform.position = target.position - (rotation * offset);

        Vector3 point = cam.WorldToViewportPoint(target.position);
        Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        //transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
