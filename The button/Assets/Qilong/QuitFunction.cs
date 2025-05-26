using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitFunction : MonoBehaviour
{
    [SerializeField] string SceneToChange;


    public void SceneChangeFunction()
    {
        SceneManager.LoadScene(SceneToChange);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
