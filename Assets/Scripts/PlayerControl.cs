using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameObject PlayerBulletGO;
	public GameObject BulletPosition01;
	public GameObject corgi_parachute;

	
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) 
		{
			GameObject bullet01 = (GameObject)Instantiate (PlayerBulletGO);
			bullet01.transform.position = BulletPosition01.transform.position;
		}
				
		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");

		Vector2 direction = new Vector2 (x, y).normalized;

		Move (direction);
	}
	void Move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1)); 

		max.x = max.x - 1.775f;
		min.x = min.x + 1.775f;

		max.y = max.y - 1.775f;
		min.y = min.y + 1.775f;

		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime; 
		
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
		{
			PlayExplosion ();
			Destroy (gameObject);
		}
	}
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (corgi_parachute);

		explosion.transform.position = transform.position;
}
}

	