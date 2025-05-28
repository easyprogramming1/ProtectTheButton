using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class theButtonScript : MonoBehaviour
{
    public GameObject hammerCursor;
    public bool click;
    public GameObject plott1;
    public GameObject plott2;
    public GameObject plott3;
    public GameObject plott4;
    public float coins;
    public bool holdingPot;
    public bool holdingturret;
    public bool holdingmorter;
    public bool holdinglazar;
    public Vector2 placepoint;
    public GameObject turretGa;
    public GameObject morterGa;
    public GameObject lazarGa;
    public GameObject pot;
    public Transform potart;
    public Transform morterart;
    public Transform turretart;
    public Transform lazarart;
    public bool potBuy;
    public bool morterBuy;
    public bool turretBuy;
    public bool emtyPot;
    public bool lazarBuy;
    public GameObject theplotes;
    public AudioSource buys;
    public Transform enemyspawner;
    public AudioSource deads;
    public GameObject erea1;
    public GameObject erea2;
    public GameObject erea3;
    public GameObject erea4;
    private void Start()
    {
        deads = GetComponent<AudioSource>();
        buys = enemyspawner.GetComponent<AudioSource>();
        StartCoroutine(bruh());
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                StartCoroutine(DoSomething());
            }
        }
        
            turretholding();
        
        
            potholding();
        morterholding();
        lazarholding();
        
        emtyPot = false;
        morterBuy = false;
        turretBuy = false;
        potBuy = false;
        lazarBuy = false;
        if (holdingPot||holdingturret||holdinglazar) 
        {
            GameObject closestEnemy = VoidClosestEnemy();
            if (closestEnemy != null)
            {
                if (closestEnemy.name == "plott 1")
                {
                    erea1.SetActive(true);
                    erea2.SetActive(false);
                    erea3.SetActive(false);
                    erea4.SetActive(false);
                }
                if (closestEnemy.name == "plott 2")
                {
                    erea2.SetActive(true);
                    erea1.SetActive(false);
                    erea3.SetActive(false);
                    erea4.SetActive(false);
                }
                if (closestEnemy.name == "plott 3")
                {
                    erea3.SetActive(true);
                    erea2.SetActive(false);
                    erea1.SetActive(false);
                    erea4.SetActive(false);
                }
                if (closestEnemy.name == "plott 4")
                {
                    erea4.SetActive(true);
                    erea2.SetActive(false);
                    erea3.SetActive(false);
                    erea1.SetActive(false);
                }
            }
        }
        else
        {
            erea1.SetActive(false);
            erea2.SetActive(false);
            erea3.SetActive(false);
            erea4.SetActive(false);
        }
    }
    GameObject VoidClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Bplott");
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        Vector3 mos = Input.mousePosition;
        Vector3 myPosition = Camera.main.ScreenToWorldPoint(mos);

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
    public IEnumerator bruh()
    {
        buys.mute = true;
        yield return new WaitForSeconds(1);
        buys.mute = false;
    }
    public void buyPot()
    {
        potBuy = true;
    }
    public void buyLazar()
    {
        lazarBuy = true;
    }
    public void buyMorter()
    {
        morterBuy = true;
    }
    public void buyturret()
    {
        turretBuy = true;
    }
    public void IEXIST()
    {
        emtyPot = true;
    }
    public void AddCoin()
    {
        coins += 5;
    }
    public void AddCoinBig()
    {
        coins += 10;
    }
    public void placeingPot()
    {
        if (potart.GetComponent<potartscript>().nottuching)
        {
            Instantiate(pot, placepoint, Quaternion.identity);
            holdingPot = false;
        }
    }
    public void placingTurret()
    {
        if (turretart.GetComponent<turretartscript>().nottuching)
        {
            Instantiate(turretGa, turretart.GetComponent<turretartscript>().potpoint, Quaternion.identity);
            holdingturret = false;
            theplotes.name = "donepot";
        }
    }
    public void placingMorter()
    {
        if (morterart.GetComponent<turretartscript>().nottuching)
        {
            Instantiate(morterGa, morterart.GetComponent<turretartscript>().potpoint, Quaternion.identity);
            holdingmorter = false;
            theplotes.name = "donepot";
        }
    }
    public void placinglazar()
    {
        if (lazarart.GetComponent<turretartscript>().nottuching)
        {
            Instantiate(lazarGa, lazarart.GetComponent<turretartscript>().potpoint, Quaternion.identity);
            holdinglazar = false;
            theplotes.name = "donepot";
        }
    }

    public IEnumerator DoSomething()
    {
        hammerCursor.GetComponent<HammerCursorManager>()._SwitchToHammer = false;
        click = true;
        deads.Play();
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        click = false;
        GetComponent<SpriteRenderer>().color = Color.white;
        
        SceneManager.LoadScene("GameOverScene");

    }
    public void potholding()
    {
        if (!holdingPot && coins >= 50 && potBuy)
        {
            holdingPot = true;
            coins -= 50;
            buys.Play();
        }
        if (holdingPot && Input.GetMouseButtonDown(0))
        {
            Vector2 mous = Input.mousePosition;
            placepoint = Camera.main.ScreenToWorldPoint(mous);
            placeingPot();
        }
        if (holdingPot)
        {
            Vector3 mus = Input.mousePosition;
            potart.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mus).x, Camera.main.ScreenToWorldPoint(mus).y, 0);
        }
        else
        {
            potart.transform.position = new Vector3(10000, 0, 0);
        }
    }
    public void turretholding()
    {
        if (!holdingturret && coins >= 100 && turretBuy && emtyPot == true)
        {
            holdingturret = true;
            coins -= 100;

            buys.Play();
        }
        if (holdingturret && Input.GetMouseButtonDown(0))
        {
            Vector2 mous = Input.mousePosition;
            placepoint = Camera.main.ScreenToWorldPoint(mous);
            placingTurret();
        }
        if (holdingturret)
        {
            Vector3 mus = Input.mousePosition;
            turretart.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mus).x, Camera.main.ScreenToWorldPoint(mus).y, 0);
        }
        else
        {
            turretart.transform.position = new Vector3(10000, 0, 0);
        }
    }
    public void morterholding()
    {
        if (!holdingmorter && coins >= 150 && morterBuy && emtyPot == true)
        {
            holdingmorter = true;
            coins -= 150;
            buys.Play();
        }
        if (holdingmorter && Input.GetMouseButtonDown(0))
        {
            Vector2 mous = Input.mousePosition;
            placepoint = Camera.main.ScreenToWorldPoint(mous);
            placingMorter();
        }
        if (holdingmorter)
        {
            Vector3 mus = Input.mousePosition;
            morterart.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mus).x, Camera.main.ScreenToWorldPoint(mus).y, 0);
        }
        else
        {
            morterart.transform.position = new Vector3(10000, 0, 0);
        }
    }
    public void lazarholding()
    {
        if (!holdinglazar && coins >= 150 && lazarBuy && emtyPot == true)
        {
            holdinglazar = true;
            coins -= 150;
            buys.Play();
        }
        if (holdinglazar && Input.GetMouseButtonDown(0))
        {
            Vector2 mous = Input.mousePosition;
            placepoint = Camera.main.ScreenToWorldPoint(mous);
            placinglazar();
        }
        if (holdinglazar)
        {
            Vector3 mus = Input.mousePosition;
            lazarart.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mus).x, Camera.main.ScreenToWorldPoint(mus).y, 0);
        }
        else
        {
            lazarart.transform.position = new Vector3(10000, 0, 0);
        }
    }
    public void dead()
    {
        
        StartCoroutine(DoSomething());
    }
}
