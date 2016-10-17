using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject corgi_parachute;

	float speed; 

	// Use this for initialization
	void Start () {
		speed = 2f;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position; 

		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

		transform.position = position; 

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		if (transform.position.y < min.y) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag")) {

			PlayExplosion ();

			Destroy (gameObject);
		}
	}
	void PlayExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate (corgi_parachute);
		explosion.transform.position = transform.position;
	}
}
