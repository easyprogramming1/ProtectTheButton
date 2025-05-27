using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class theButtonScript : MonoBehaviour
{
    public bool click;
    public GameObject plott1;
    public GameObject plott2;
    public GameObject plott3;
    public GameObject plott4;
    public float coins;
    public bool holdingPot;
    public bool holdingturret;
    public bool holdingmorter;
    public Vector2 placepoint;
    public GameObject turretGa;
    public GameObject morterGa;
    public GameObject pot;
    public Transform potart;
    public Transform morterart;
    public Transform turretart;
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
        potholding();
        turretholding();
    }
    public void AddCoin()
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
            Instantiate(turretGa, placepoint, Quaternion.identity);
            holdingturret = false;
        }
    }

    public IEnumerator DoSomething()
    {
        click = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        click = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void potholding()
    {
        if (!holdingPot && coins >= 50)
        {
            holdingPot = true;
            coins -= 50;
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
        if (!holdingturret && coins >= 100)
        {
            holdingturret = true;
            coins -= 100;
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
}
