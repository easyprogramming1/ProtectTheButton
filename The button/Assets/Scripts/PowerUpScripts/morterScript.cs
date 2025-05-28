using System.Collections;
using UnityEngine;

public class morterScript : MonoBehaviour
{
    public Animator ani;
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
    public AudioSource ad;
    public float damagemultiplayer;

    public void Start()
    {
        damagemultiplayer = 1;
        ad = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        StartCoroutine(shoot());
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        StartCoroutine(anima());
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
            GameObject theexplo = Instantiate(explotion, enemyPos, Quaternion.Euler(rotationer));
            theexplo.GetComponent<morterexplotionScript>().damage = damagemultiplayer;
            ani.SetBool("shootinge", true);
        ad.Play();
        }
        StartCoroutine(shoot());
    }
    public IEnumerator anima()
    {
        yield return new WaitForSeconds(0.2f);
            ani.SetBool("shootinge", false);
        
        StartCoroutine(anima());
    }
    public void damUpgrade()
    {
        if(GameObject.Find("The Button").GetComponent<theButtonScript>().coins > 150)
        {
            GameObject.Find("The Button").GetComponent<theButtonScript>().coins -= 150;
            damagemultiplayer += 0.5f;
        }
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
