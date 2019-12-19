using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
{
	public float width;
	public float height;
	public float depth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	Vector3 clampedVector(Vector3 target)
	{
		return new Vector3(
			Mathf.Max(this.transform.position.x - width / 2, Mathf.Min(this.transform.position.x + width / 2, target.x)),
			Mathf.Max(this.transform.position.y - height / 2, Mathf.Min(this.transform.position.y + height / 2, target.y)),
			Mathf.Max(this.transform.position.z - depth / 2, Mathf.Min(this.transform.position.z + depth / 2, target.z))
			);
	}

	public void sphereCollision(sphereCollider sphere, rigidBody body, Transform transform)
	{
		Vector3 difference = transform.position - this.transform.position;

		Vector3 closest = clampedVector(transform.position);

		//print(closest);

		//Vector3 closest = this.transform.position + clamped;

		difference = closest - transform.position;
		//print(difference);
		if (difference.magnitude < sphere.radius)
		{
			//print("hit");
			Vector3[] compass = new Vector3[]
			{
				Vector3.up,
				Vector3.down,
				Vector3.left,
				Vector3.right,
				Vector3.forward,
				Vector3.back
			};

			float max = 0.0f;
			Vector3 normal = new Vector3(0, 0, 0);

			foreach (Vector3 v in compass)
			{
				float dot = Vector3.Dot(-difference.normalized, v);
				if (dot > max)
				{
					max = dot;
					normal = v;
				}
			}

			print(normal);
			if (normal != new Vector3(0, 0, 0))
			{
				body.velocity = Vector3.Reflect(body.velocity, normal);
				body.velocity = body.velocity * (1 - body.GetComponentInParent<material>().elasticity);
				transform.position += normal * (sphere.radius - difference.magnitude);
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height, depth));
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
