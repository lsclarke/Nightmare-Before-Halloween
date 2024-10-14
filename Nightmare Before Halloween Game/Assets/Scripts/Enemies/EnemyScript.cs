using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    //Variables

    //Reference Variables - Access Character Script and obtain variable data
    [Header("Refernce Settings")]
    public GameObject player;

    public float health;
    public Slider HealthBar;

    public float speed = 0.75f;
    public float attackPower;

    public ParticleSystem hitParticle;
    private bool hit = false;

    public GameObject scoreManagerScript;

    //Set health variable, and get the value of the newly set health variable
    public void setHealth(float hp) => health = hp;
    public float getHealth() => health;

    //Set Speed variable, and get the value of the newly set Speed variable
    public void setSpeed(float spd) => speed = spd;
    public float getSpeed() => speed;

    //Set Attack variable, and get the value of the newly set Attack variable
    public void setAttack(float atk) => attackPower = atk;
    public float getAttack() => attackPower;
    void Start()
    {
        health = 1f;
        speed = 0.75f;
        player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform);
    }
    //Move Towards specified position
    public void Hunt(Transform otherPosition)
    {
        transform.LookAt(player.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void Update()
    {
        scoreManagerScript = GameObject.FindWithTag("Score");
        scoreManagerScript.GetComponent<ScoreManagerScript>();

        HealthBar.value = health;
        Hunt(player.transform);

        if (hit)
        {
            StartCoroutine(StopHitParticle());
        }
    }

   private IEnumerator StopHitParticle()
    {
        yield return new WaitForSeconds(1f);
        hit = false;
        hitParticle.gameObject.SetActive(false);
        hitParticle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hit = true;
            health -= .15f;

            if (hit)
            {
                hitParticle.gameObject.SetActive(true);
                hitParticle.Play();

                if (health <= 0f)
                {
                    scoreManagerScript.GetComponent<ScoreManagerScript>().AddKill(1);
                    scoreManagerScript.GetComponent<ScoreManagerScript>().AddScore(15);
                    Destroy(this.gameObject);
                }
            }
        }

        if (other.gameObject.tag == "Rocket")
        {
            hit = true;
            health -= .50f;

            if (hit)
            {
                hitParticle.gameObject.SetActive(true);
                hitParticle.Play();

                if (health <= 0f)
                {
                    scoreManagerScript.GetComponent<ScoreManagerScript>().AddKill(1);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}

