using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public GameObject[] shooter;
    public GameObject bullet;
    public GameObject viseur;
    public GameObject particle_game;
    public Text score_text;
    public static float vitality = 500;
    public int score;
    public static bool alive = true;

    private float elapsed_time = 0f;
    private float loop_time = 0.2f;
    public GameObject explosion;

    void Start() {
        vitality = 500;
        score = 0;
    }

    private void Update()
    {
        if (alive)
        {
            if (elapsed_time > 0)
            {
                elapsed_time -= Time.deltaTime;
            }
            SetScoreText();
        }
    }

    public void Shoot()
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
            new_bullet.GetComponent<Rigidbody>().velocity = viseur.transform.position - shooter[i].transform.position;
            Destroy(particle, 2f);
            Destroy(new_bullet, 10f);
        }
    }

    void OnTriggerEnter (Collider col) {
        if (col.gameObject.tag == "Monster_bullets") {
            vitality -= 1;
			Destroy (col.gameObject);
			if (vitality <= 0 && alive) {
				Instantiate (explosion, transform.position, Quaternion.identity);
                //Destroy (gameObject);
                alive = false;
			}
        }
    }

    void SetScoreText()
    {
        score_text.text = "Score : " + score.ToString();
    }
}