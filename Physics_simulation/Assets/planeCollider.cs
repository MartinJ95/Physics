using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeCollider : MonoBehaviour
{
	Vector3 normal;
	Vector3 reflect(Vector3 velocity, Vector3 normal)
	{
		return 2 * (Vector3.Dot(normal, velocity)) * normal - velocity;
	}

    public void sphereCollision(sphereCollider sphere, rigidBody body, Transform transform)
	{
		normal = this.transform.TransformDirection(Vector3.up);
		float distance = Vector3.Dot((transform.position - this.transform.position), normal);
		if (distance < sphere.radius)
		{
			body.velocity = reflect(-body.velocity, normal);
			transform.position += normal * (sphere.radius - distance);
		}
	}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
