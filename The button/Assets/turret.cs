using System.Collections;
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
        GameObject closestEnemy = GetClosestEnemy();
        if (closestEnemy != null)
        {
            enemyPos = closestEnemy.transform.position;
            enenmytargeting = true;
        }
        else
        {
            Debug.Log("noEnemy");
            enenmytargeting = false;
        }


        mousePos = enemyPos;

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }
    public IEnumerator shoot()
    {
        yield return new WaitForSeconds(1);
        if (enenmytargeting)
        {
            Instantiate(bullet, shootpoint.transform.position,Quaternion.Euler(rotationer));
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
