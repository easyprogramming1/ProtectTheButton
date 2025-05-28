using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private theButtonScript theButtonScript;
    [SerializeField] private PauseScript PauseScript;

    [SerializeField] int TurretCost;
    [SerializeField] int PlotCost;
    [SerializeField] int MorterCost;
    [SerializeField] int LaserCost;
    [SerializeField] GameObject Shop;
    [SerializeField] bool ShopTrue;

    void Start()
    {
        theButtonScript = GameObject.Find("The Button").GetComponent<theButtonScript>();
        PauseScript = GameObject.Find("GameUI").GetComponent<PauseScript>();

        ShopTrue = false;
    }

    void Update()
    {
        
        if (PauseScript.PausthingsTrue == true)
        {
            Shop.SetActive(false);
            Time.timeScale = 0;
        }
        else if(ShopTrue && PauseScript.PausthingsTrue == false)
        {
            Time.timeScale = 0;
            Shop.SetActive(true);
        }
        else if (!ShopTrue && PauseScript.PausthingsTrue == false)
        {
            Time.timeScale = 1;
            Shop.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && GameObject.Find("The Button").GetComponent<theButtonScript>().holdinglazar || Input.GetMouseButtonDown(0) && GameObject.Find("The Button").GetComponent<theButtonScript>().holdingmorter|| Input.GetMouseButtonDown(0) && GameObject.Find("The Button").GetComponent<theButtonScript>().holdingPot|| Input.GetMouseButtonDown(0) && GameObject.Find("The Button").GetComponent<theButtonScript>().holdingturret)
        {
            Shop.SetActive(false);
            ShopTrue = false;
        }




    }


    public void SetShoopActiv()
    {
        //ShopTrue = true;
        
        if (ShopTrue == false)
        {
            ShopTrue = true;
        }
        else
        {
            ShopTrue = false;
        }



    }
    public void print()
    {
        Debug.Log("leo");
    }
}
