using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Vector2 enemyPos;
    public string enemyTag = "Enemy"; // Make sure enemies are tagged "Enemy"
    public Camera mainCam;
    public Vector3 mousePos;
    public GameObject bullet;
    public bool enenmytargeting;
    public Transform shootpoint;
    public Vector3 rotationer;
    public float shootspeed;
    public float side;
    public List<GameObject> theList;


    public Transform fromObject;
    public Transform toObject;
    public string targetTag = "Wall";
    public void Start()
    {
        StartCoroutine(shoot());
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        rotationer.x = transform.rotation.eulerAngles.x;
        rotationer.y = transform.rotation.eulerAngles.y;
        rotationer.z = transform.rotation.eulerAngles.z - 90;
        GameObject closest = GetClosestEnemy();
        if (closest != null)
        {
            enemyPos = closest.transform.position;
            enenmytargeting = true;
            Vector2 direction = closest.transform.position - transform.position;
            float distance = direction.magnitude;
        }
        else
        {
            enenmytargeting = false;
        }


        mousePos = enemyPos;

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);



       
    }
    public IEnumerator shoot()
    {
        yield return new WaitForSeconds(shootspeed);
        if (enenmytargeting)
        {
            Instantiate(bullet, shootpoint.transform.position,Quaternion.Euler(rotationer));
        }
        StartCoroutine(shoot());
    }

    GameObject GetClosestEnemy()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        List<GameObject> e1 = new List<GameObject>();
        List<GameObject> e2 = new List<GameObject>();
        List<GameObject> e3 = new List<GameObject>();
        List<GameObject> e4 = new List<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "1e")
            {
                e1.Add(obj);
            }
        }
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "2e")
            {
                e2.Add(obj);
            }
        }
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "3e")
            {
                e3.Add(obj);
            }
        }
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "4e")
            {
                e4.Add(obj);
            }
        }
        if(side == 1)
        {
            e3.AddRange(e4);
            theList = e3;
        }
        if (side == 2)
        {
            e4.AddRange(e1);
            theList = e4;
        }
        if (side == 3)
        {
            e1.AddRange(e2);
            theList = e1;
        }
        if (side == 4)
        {
            e3.AddRange(e2);
            theList = e3;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 myPosition = transform.position;

        foreach (GameObject enemy in theList)
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
