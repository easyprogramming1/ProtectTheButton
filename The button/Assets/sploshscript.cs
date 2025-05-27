using System.Collections;
using UnityEngine;

public class sploshscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
