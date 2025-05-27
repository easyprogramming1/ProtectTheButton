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
    }
    public void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Destroy(gameObject);

            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "bullet")
        {
            Destroy(gameObject);
        }
        if(collision.transform.tag == "Button")
        {
            Destroy(gameObject);
        }
    }

}
