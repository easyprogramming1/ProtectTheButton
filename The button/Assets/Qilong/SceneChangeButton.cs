using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public bool click;
    [SerializeField] string SceneToChange;


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Gay");
            StartCoroutine(DoSomething());
            SceneManager.LoadScene(SceneToChange);
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
