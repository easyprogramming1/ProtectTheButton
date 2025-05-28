using UnityEngine;

public class upgrader : MonoBehaviour
{
    public bool upgrading;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void gofree()
    {
        if (upgrading)
        {
            upgrading = true;
        }
        else
        {
            upgrading = false;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0) && collision.tag == "turret")
        {
            if(collision.name == "turret(Copy)")
            {
                collision.GetComponent<turret>().damageMultiplayer += 0.5f;
                GameObject.Find("The Button").GetComponent<theButtonScript>().coins -= 100;
            }
        }
    }
}
