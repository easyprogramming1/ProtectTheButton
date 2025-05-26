using System.Collections;
using UnityEngine;

public class morterScript : MonoBehaviour
{
    public Vector2 enemyPos;
    public string enemyTag = "Enemy";
    public Camera mainCam;
    public Vector3 mousePos;
    public GameObject explotion;
    public bool enenmytargeting;
    public Transform shootpoint;
    public Vector3 rotationer;
    public float shootspeed = 3;
    public Transform aim;

    public void Start()
    {
        StartCoroutine(shoot());
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        GameObject closestEnemy = GetClosestEnemy();
        if (closestEnemy != null)
        {
            enemyPos = closestEnemy.transform.position;
            enenmytargeting = true;
            aim.transform.position = enemyPos;
        }
        else
        {
            Debug.Log("noEnemy");
            enenmytargeting = false;
            aim.transform.position = new Vector3(1000, 100, 0);
        }
    }
    public IEnumerator shoot()
    {
        yield return new WaitForSeconds(shootspeed);
        if (enenmytargeting)
        {
            Instantiate(explotion, enemyPos, Quaternion.Euler(rotationer));
        }
        StartCoroutine(shoot());
    }

    GameObject GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 myPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, myPosition);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
}
