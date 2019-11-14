using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereCollider : MonoBehaviour
{
	public float radius;
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
