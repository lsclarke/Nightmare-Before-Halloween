using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    //Reference to the bullet spawn point, and the projectile itself
    [Header("Refernce Settings")]
    public RoundManagerScript roundManagerScript;
    public EnemyScript enemyScript;
    [SerializeField] public GameObject[] enemyTypes;
    public Transform[] spawnPoints;

    [Space(2)]
    //Spawn Variables
    [Header("Spawn Settings")]
    public float spawnTime;
    public float spawnRate;
    public bool CanSpawn = true;

    [Space(2)]
    public int currentEnemyNum;
    public int maxEnemyNum;

    public float timeInBetweenRounds;
    public bool roundChanging;


    private void FixedUpdate()
    {
        //Spawn regular enmeies first when the game starts
        SpawnEnemies();
        StartCoroutine(ChangeRound());
    }

    private IEnumerator ChangeRound()
    {
        WaitForSeconds seconds = new WaitForSeconds(timeInBetweenRounds / 2);

        yield return seconds;
        //Add enemies with the tag enemy into a list
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        //if the list is equal to 0 and can't spawn and change rounds perform the code below
        if (totalEnemies.Length == 0 && !CanSpawn && !roundChanging)
        {
            currentEnemyNum = 0;
            maxEnemyNum = maxEnemyNum * 2;
            enemyScript.speed += 0.25f;
            roundChanging = true;

            StartCoroutine(changeBool());
        }
    }

    private IEnumerator changeBool()
    {
        WaitForSeconds seconds = new WaitForSeconds(timeInBetweenRounds / 2);
        yield return seconds;
        if (roundChanging)
        {
            //update round 
            roundManagerScript.AddRound(1);
            CanSpawn = true;
        }
    }
    void SpawnEnemies()
    {
        //When spawning is true and spawntime is less than the current time
        if (CanSpawn && spawnTime < Time.time)
        {
            //Create a list that gets the random enemy objects in the list and random spawn points
            //And spawn enemies of different types randomly at different points
            roundChanging = false;
            var randomEnemy = enemyTypes[Random.Range(0, enemyTypes.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            spawnTime = Time.time + spawnRate;
            currentEnemyNum++;

            //When the max enemy count for the round is reached stop spawning
            if (currentEnemyNum >= maxEnemyNum)
            {
                CanSpawn = false;

            }
        }
    }


}
