using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBody : MonoBehaviour
{

	float gravity = -9.81f;
	public Vector3 velocity = new Vector3(0, 0, 0);
	public float mass;
	public Vector3 force = new Vector3(0, 0, 0);
	Vector3 calculateForce()
	{
		return new Vector3( 0, mass * gravity, 0);
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = calculateForce();
		Vector3 acceleration = new Vector3(force.x / mass, force.y / mass, force.z / mass);
		velocity += acceleration * Time.deltaTime;
		transform.Translate(velocity * Time.deltaTime);
	}
}
