using System.Collections;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject straightenenmy;
    public GameObject spinenenmy;
    public float spawndistance;
    float ranx;
    float rany;
    float minusornot1;
    float minusornot2;
    public float spawnspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawn());
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
}
