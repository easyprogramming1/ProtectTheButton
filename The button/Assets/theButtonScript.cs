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
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("Clicked with new input system: " + gameObject.name);
                StartCoroutine(DoSomething());
            }
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
}
