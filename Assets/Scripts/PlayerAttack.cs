using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private AudioSource audioSource;

	public GameObject grenadePrefab;
	public AudioClip throwReleaseAudioClip;
	
	public float maxThrowTimer;
	public float minThrowTimer;
	public float throwTimer;
	public float throwForceBase;
	public float throwForce;
	public Transform grenadeSpawn;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			throwTimer = 0;
		}

		if (Input.GetButton("Fire1"))
		{
			throwTimer += Time.deltaTime;
			if (throwTimer > maxThrowTimer)
			{
				throwTimer = maxThrowTimer;
			}
		}

		if (Input.GetButtonUp("Fire1"))
		{
			if(throwTimer < minThrowTimer)
			{
				throwTimer = minThrowTimer;
			}

			throwForce = throwForceBase * throwTimer;
			//Debug.Log(throwForce.ToString());
			Throw();
		}
	}

	public void Throw()
	{
		GameObject grenade = Instantiate(grenadePrefab, grenadeSpawn.position, grenadeSpawn.rotation);
		grenade.GetComponent<Grenade>().Throw(throwForce);
		audioSource.PlayOneShot(throwReleaseAudioClip);
	}


}
