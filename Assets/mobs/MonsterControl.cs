using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
	[Range(50f, 200f)] [SerializeField] public float lowest = 100f;

	private Rigidbody rb;
	private Transform transmob;
	private GameObject target;
	private float moveSpeed;
	private Vector3 directionToTarget;
	private readonly AudioSource source;
	[SerializeField] private AudioClip clip;

	public GameObject[] explosion;
	private GameObject particle;
	private int vitality;
	private bool dead = true;
	[SerializeField] private Material src;
	public Material mat;
	[SerializeField] public float fading = 1f;
	public GameObject[] shooter;
	public GameObject bullet;
	public GameObject particle_game;
	float elapsed_time = 0f;
	float loop_time = 0.2f;
	private Ship ship;
	//public GameObject explosion;

	// Use this for initialization
	void Start()
	{
		src = GetComponent<Renderer>().material;
		lowest = 80f;
		target = GameObject.Find("Player");
		rb = GetComponent<Rigidbody>();
		transmob = GetComponent<Transform>();
		moveSpeed = Random.Range(10f, 15f);
		ship = GameObject.Find("Player").GetComponent<Ship>();
		vitality = 5;
	}

	// Update is called once per frame
	void Update()
	{
        if (Ship.alive)
        {
            if (elapsed_time > 0)
            {
                elapsed_time -= Time.deltaTime;
            }
            src.SetFloat("Vector1_1BAD4674", fading);
            MoveMonster();
        }
	}
	void Die()
	{
		Destroy(gameObject);
		for (int i = 0; i < explosion.Length; i++)
		{
			particle = Instantiate(explosion[i], transform.position + new Vector3(Random.Range(-5, 5), Random.Range(-1, 2), Random.Range(-5, 6)), Quaternion.identity);
			Destroy(particle, 5f);
		}
		dead = false;
	}
	
	void OnTriggerEnter(Collider col)
	{
		switch (col.gameObject.tag)
		{
			case "Bullet":
			vitality -= 1;
			Destroy(col.gameObject);
			if (vitality <= 0 && dead)
			{
				ship.score += 1;
				Die();
			}
			break;
		}
	}

	private void Shoot()
	{
		if (elapsed_time > 0)
			return;
        AudioSource audio = shooter[0].GetComponent<AudioSource>();
		audio.Play();
		for (int i = 0; i < shooter.Length; i++)
		{
			elapsed_time = loop_time;
			GameObject particle = Instantiate(particle_game, shooter[i].gameObject.transform.position, Quaternion.identity);
			GameObject new_bullet = Instantiate(bullet, shooter[i].gameObject.transform.position, Quaternion.identity);
			new_bullet.GetComponent<Rigidbody>().velocity = target.transform.position - shooter[i].transform.position;
			Destroy(particle, 2f);
			Destroy(new_bullet, 10f);
		}
	}

	void MoveMonster()
	{
		if (target != null)
		{
			transmob.LookAt(target.transform);
			float radius = Mathf.Pow(transmob.position.x, 2) + Mathf.Pow(transmob.position.z, 2);
			if (moveSpeed > 0 && Mathf.Sqrt(radius) <= lowest)
			{
				if (moveSpeed < 0.1f)
					moveSpeed = 0;
				else
					moveSpeed -= 0.1f;
			}
			if (moveSpeed == 0)
				Shoot();
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb.velocity = new Vector3(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed, directionToTarget.z * moveSpeed);
		}
		else
		{
			rb.velocity = Vector3.zero;
		}
	}
}