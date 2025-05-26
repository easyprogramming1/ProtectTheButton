using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

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
