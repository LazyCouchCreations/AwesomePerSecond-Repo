using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	public float delay;
	public float radius;
	private float remainingDelay;
	private bool isExploded = false;
	public float explosionForce;
	public GameObject effect;
	public LayerMask explodable;

	// Use this for initialization
	void Start () {
		remainingDelay = delay;
	}
	
	// Update is called once per frame
	void Update () {
		remainingDelay -= Time.deltaTime;
		if (remainingDelay <= 0 && !isExploded)
		{
			Explode();
			isExploded = true;
		}
	}

	void Explode()
	{
		//instantiate an explosion effect
		Instantiate(effect, transform.position, transform.rotation);

		//get all valid colliders
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, explodable);

		//add force to each collider
		foreach(Collider2D collider in colliders)
		{
			Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
			if(rb != null)
			{
				Vector2 direction = rb.transform.position - transform.position;
				float calc = 1 - (direction.magnitude / radius);
				if (calc <= 0)
				{
					calc = 0;
				}

				rb.AddForce(direction.normalized * explosionForce * calc);
			}
		}

		//destroy the grenade
		Destroy(gameObject);
	}

	public void Throw(float throwForce)
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * throwForce;


	}
}
