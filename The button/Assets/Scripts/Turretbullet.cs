using UnityEngine;

public class Turretbullet : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.linearVelocity = transform.up * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
