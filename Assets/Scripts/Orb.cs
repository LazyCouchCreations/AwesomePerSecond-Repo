using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Orb : MonoBehaviour {

	private Transform orbEater;
	private Rigidbody2D rb;
	public float speed;
	//private bool isSummoned = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		orbEater = GameObject.FindGameObjectWithTag("OrbEater").transform;
	}
	
	// Update is called once per frame
	void Update () {
		//if (isSummoned)
		//{
			transform.right = orbEater.position - transform.position;
			rb.velocity = transform.right * speed;
		//}
	}

	//public void SummonOrb()
	//{
	//	isSummoned = true;
	//}
}
