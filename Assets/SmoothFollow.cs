using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public float cameraSpeed = 15;
    public Vector3 offset = new Vector3(0, 15f, -5f);
    public bool smoothFollow = true;
    public Vector3 velocity;

	// Update is called once per frame
	void Update () {
		if(target)
        {
            Vector3 newPosition = transform.position + offset;

            if(!smoothFollow)
            {
                transform.position = newPosition;
            } else
            {
                transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, cameraSpeed * Time.deltaTime);
            }
        }
	}
}
