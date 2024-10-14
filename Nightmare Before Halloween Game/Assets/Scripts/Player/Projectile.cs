using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    [Range(0, 10)]
    public float speed;
    public Rigidbody physics;

    private Vector3 startPosition;
    public float maxDistance;
    private float conquaredDistance = 0;
    
    private ScoreManagerScript scoreManagerScript;
    public void Init(Vector3 direction)
    {
        startPosition = transform.position;
        physics.velocity = direction * speed;
    }

    private void Update()
    {
        scoreManagerScript = new ScoreManagerScript();
        scoreManagerScript.GetComponent<ScoreManagerScript>();
        conquaredDistance = Vector3.Distance(transform.position, startPosition);
        if (conquaredDistance >= maxDistance)
        {
            print("Disable Object");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            scoreManagerScript.AddScore(5);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}

