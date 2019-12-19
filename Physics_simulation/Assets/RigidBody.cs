using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidBody : MonoBehaviour
{
	public bool usesRotation = false;
	float inertia;
	Vector3 angularVelocity;
	float gravity = -9.81f;
	public Vector3 velocity = new Vector3(0, 0, 0);
	public float mass;
	public Vector3 force = new Vector3(0, 0, 0);
	Vector3 calculateForce()
	{
		return new Vector3( 0, mass * gravity, 0) + force;
	}



	void addForce(Vector3 newForce)
	{
		force += newForce;
	}

    // Start is called before the first frame update
    void Start()
    {
		if (GetComponent<AABB>())
		{
			AABB boundingBox = GetComponent<AABB>();
			//inertia = 
		}
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = calculateForce();
		Vector3 acceleration = new Vector3(force.x / mass, force.y / mass, force.z / mass);
		velocity += acceleration * Time.deltaTime;
		transform.Translate(velocity * Time.deltaTime);

		if (usesRotation)
		{

		}

		Object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
		if (this.GetComponent<sphereCollider>() != null)
		{
			foreach (GameObject o in obj)
			{
				if (o.GetComponent<sphereCollider>() != null)
				{
					sphereCollider col = o.GetComponent<sphereCollider>();
					sphereCollider bounds = this.GetComponent<sphereCollider>();
					col.sphereCollision(bounds, this.GetComponent<rigidBody>(), this.transform);
				}
				else if (o.GetComponent<planeCollider>() != null)
				{
					planeCollider col = o.GetComponent<planeCollider>();
					sphereCollider bounds = this.GetComponent<sphereCollider>();
					col.sphereCollision(bounds, this.GetComponent<rigidBody>(), this.transform);
				}
				else if (o.GetComponent<AABB>() != null)
				{
					AABB col = o.GetComponent<AABB>();
					sphereCollider bounds = this.GetComponent<sphereCollider>();
					col.sphereCollision(bounds, this.GetComponent<rigidBody>(), this.transform);
				}
			}
		}
		else if(this.GetComponent<AABB>() != null)
		{
			foreach (GameObject o in obj)
			{
				if (o.GetComponent<planeCollider>() != null)
				{
					planeCollider col = o.GetComponent<planeCollider>();
					AABB bounds = this.GetComponent<AABB>();
					col.AABBCollision(bounds, this.GetComponent<rigidBody>(), this.transform);
				}
			}
		}
	}
}
