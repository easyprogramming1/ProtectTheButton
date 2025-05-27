using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class StraightEnemyScript : MonoBehaviour
{
    public Transform button;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GameObject.Find("The Button").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, button.transform.position, speed * Time.deltaTime);
        if((button.transform.position.x - transform.position.x) < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                button.BroadcastMessage("AddCoin");
                Destroy(gameObject);

            }
        }
        GameObject closestEnemy = VoidClosestEnemy();
        if (closestEnemy != null)
        {
            transform.name = closestEnemy.transform.name + "e";
        }
       
    }
    GameObject VoidClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("point");
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "bullet")
        {
            button.BroadcastMessage("AddCoin");
            Destroy(gameObject);
        }
        if (collision.transform.tag == "lazer")
        {
            button.BroadcastMessage("AddCoin");
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Button")
        {
            Destroy(gameObject);
        }

    }

}
