using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    [SerializeField] public bool PausthingsTrue;
    public GameObject Pausthings;

    private void Start()
    {
        PausthingsTrue = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PausthingsTrue == false)
        {
            //Time.timeScale = 0f;
            StartCoroutine(OpenToClose());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && PausthingsTrue == true)
        {
            //Time.timeScale = 1f;
            Pausthings.SetActive(false);
            PausthingsTrue = false;
            Time.timeScale = 1;
        }

    }

    public IEnumerator OpenToClose()
    {
        Time.timeScale = 0;
        Debug.Log("Leo");
        Pausthings.SetActive(true);
        yield return new WaitForSecondsRealtime(0.00000000000000000000001f);
        PausthingsTrue = true;

    }

}
