using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformAttack : MonoBehaviour {

    public float range = 100.0f;
    public float cooldown = 0f; 
    public float cooldownRemaining = 10;
    public GameObject debrisPrefab;
    public GameObject muzzle;

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
        cooldownRemaining -= Time.deltaTime;

		if(Input.GetMouseButton(0) && cooldownRemaining <= 0)
        {
            cooldownRemaining = cooldown;
            Ray ray = new Ray(muzzle.transform.position, muzzle.transform.forward);
            
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, range))
            {
                Vector3 hitPoint = hitInfo.point;
                // Debug.Log("Hit Point: " + hitPoint);
                GameObject go = hitInfo.collider.gameObject;
                // Debug.Log("Game object: " + go);
                if (debrisPrefab != null)
                {
                    var direction = (muzzle.transform.position - hitInfo.point).normalized;
                    var lookRotation = Quaternion.LookRotation(hitInfo.normal);
                    Instantiate(debrisPrefab, hitPoint, lookRotation);
                }

                Debug.DrawLine(ray.origin, hitPoint, Color.red);
                Debug.Log("Origin: " + ray.origin + ", Hitpoint: " + hitPoint);
            }
        }
	}
}
