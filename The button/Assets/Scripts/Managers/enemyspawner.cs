using System.Collections;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject straightenenmy;
    public GameObject bigenenmy;
    public float spawndistance;
    float ranx;
    float rany;
    float minusornot1;
    float minusornot2;
    public float spawnspeed;
    public float enemyspawnspeed;
    public float speedchanger = 0.7f;
    public float enenmyHP;
    public float mintillmorhp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enenmyHP = 1;
        StartCoroutine(spawnspeedchanger());
        StartCoroutine(spawn());
        StartCoroutine(spawnBig());
        speedchanger = 0.7f;
        StartCoroutine(speedchang());
        StartCoroutine(waiting());
    }
    public IEnumerator waiting()
    {
        yield return new WaitForSeconds(mintillmorhp * 60);
        enenmyHP *= 1.5f;
        StartCoroutine(waiting());
    }
    public IEnumerator speedchang()
    {
        yield return new WaitForSeconds(5);
        if (speedchanger < 1.3f)
        {
            speedchanger += 0.01f;
        }
        StartCoroutine(speedchang());
    }
    // Update is called once per frame
    void Update()
    {
        minusornot1 = Random.Range(0, 2);
        if(minusornot1 == 0) 
        {
            minusornot1 = -1;
        }
        minusornot2 = Random.Range(0, 2);
        if (minusornot2 == 0)
        {
            minusornot2 = -1;
        }
        rany = Random.Range(0, spawndistance);
        ranx = Mathf.Pow( Mathf.Pow(spawndistance,2) - Mathf.Pow(rany,2),0.5f);
    }
    public IEnumerator spawn()
    {
        yield return new WaitForSeconds(spawnspeed);
        Instantiate(straightenenmy, new Vector2(ranx * minusornot1, rany * minusornot2), Quaternion.identity);
        StartCoroutine(spawn());
    }
    public IEnumerator spawnBig()
    {
        yield return new WaitForSeconds(spawnspeed*30);
        Instantiate(bigenenmy, new Vector2(ranx * minusornot1, rany * minusornot2), Quaternion.identity);
        StartCoroutine(spawnBig());
    }
    public IEnumerator spawnspeedchanger()
    {
        yield return new WaitForSeconds(1);
        spawnspeed *= enemyspawnspeed;
        StartCoroutine(spawnspeedchanger());
    }
    public IEnumerator spawnSpinningEnemy()
    {
        yield return new WaitForSeconds(spawnspeed);

    }
}
