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
            body.velocity = body.velocity * (1 - body.GetComponentInParent<material>().elasticity);
			transform.position += normal * (sphere.radius - distance);
		}
	}

	public void AABBCollision(AABB boundingBox, rigidBody body, Transform transform)
	{
		normal = this.transform.TransformDirection(Vector3.up);


		Vector3 E = (new Vector3(boundingBox.transform.position.x + boundingBox.width / 2,
			boundingBox.transform.position.y + boundingBox.height / 2,
			boundingBox.transform.position.z + boundingBox.depth/2) - new Vector3(boundingBox.transform.position.x - boundingBox.width / 2,
			boundingBox.transform.position.y - boundingBox.height / 2,
			boundingBox.transform.position.z - boundingBox.depth / 2)) / 2;

		float fradius = Mathf.Abs(normal.x * E.x) + Mathf.Abs(normal.y * E.y) + Mathf.Abs(normal.z * E.z);

		sphereCollider newSphere = new sphereCollider
		{
			radius = fradius
		};

		sphereCollision(newSphere, body, transform);
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
