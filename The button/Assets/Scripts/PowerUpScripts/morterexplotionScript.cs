using System.Collections;
using UnityEngine;

public class morterexplotionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(explo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator explo()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            Debug.Log("kill");
            Destroy(collision.gameObject);
        }
    }
}
