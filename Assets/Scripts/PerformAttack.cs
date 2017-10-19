using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformAttack : MonoBehaviour {

    public float range = 100.0f;
    public float cooldown = 0.5f; 
    public float cooldownRemaining = 0;
    public GameObject debrisPrefab;

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
        cooldownRemaining -= Time.deltaTime;

		if(Input.GetMouseButton(0) && cooldownRemaining <= 0)
        {
            cooldownRemaining = cooldown;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, range))
            {
                Vector3 hitPoint = hitInfo.point;
                Debug.Log("Hit Point: " + hitPoint);
                GameObject go = hitInfo.collider.gameObject;
                Debug.Log("Game object: " + go);
                if (debrisPrefab != null)
                {
                    Instantiate(debrisPrefab, hitPoint, hitInfo.transform.rotation);
                }
            }
        }
	}
}
