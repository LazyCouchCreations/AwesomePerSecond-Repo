using UnityEngine;

public class OrbEater : MonoBehaviour {

	public Animator anim;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Orb")
		{
			anim.SetTrigger("Eat");
			Destroy(collision.gameObject);
		}
	}
}
