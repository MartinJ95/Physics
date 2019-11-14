using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeCollider : MonoBehaviour
{
	public void sphereCollision(sphereCollider sphere, rigidBody body, Transform transform)
	{
		float distance = Vector3.Dot((transform.position - this.transform.position), this.GetComponent<MeshFilter>().mesh.normals[0]);
		if (distance < sphere.radius)
		{
			body.velocity = -body.velocity;
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
