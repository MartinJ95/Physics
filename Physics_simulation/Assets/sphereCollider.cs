using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereCollider : MonoBehaviour
{
	public float radius;

	public void sphereCollision(sphereCollider sphere, rigidBody body, Transform transform)
	{
		float distance = Vector3.Distance(transform.position, this.transform.position);
		if (distance < radius + sphere.radius)
		{
			Vector3 normal = Vector3.Normalize(transform.position - this.transform.position);

            //float restitution = this.GetComponent<material>().elasticity + body.GetComponentInParent<material>.elasticity

			rigidBody b = this.GetComponent<rigidBody>();

			float ai = Vector3.Dot(body.velocity, normal);
			float a2 = Vector3.Dot(b.velocity, normal);

			float p = ((2 - (this.GetComponent<material>().elasticity + body.GetComponentInParent<material>().elasticity)) * (ai - a2) / (body.mass + b.mass));

			Vector3 v1 = body.velocity - p * b.mass * normal;
			Vector3 v2 = b.velocity + p * body.mass * normal;

			body.velocity = v1;
			b.velocity = v2;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(this.transform.position, radius);
	}

	// Update is called once per frame
	void Update()
    {
		
    }
}
