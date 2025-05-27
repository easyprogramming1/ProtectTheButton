using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] private theButtonScript theButtonScript;

    [SerializeField] int TurretCost;
    [SerializeField] int PlotCost;
    [SerializeField] int MorterCost;
    [SerializeField] int LaserCost;


    void Start()
    {
        theButtonScript = GameObject.Find("The Button").GetComponent<theButtonScript>();
    }

    public void BuyTurret()
    {
        if (theButtonScript.coins >= TurretCost)
        {
            Debug.Log("Leo");
            theButtonScript.coins -= TurretCost;
        }
        
    }

    public void BuyPlot()
    {
        if (theButtonScript.coins >= PlotCost)
        {
            Debug.Log("Leo");
            theButtonScript.coins -= PlotCost;
        }

    }

    public void BuyMorter()
    {
        if (theButtonScript.coins >= MorterCost)
        {
            Debug.Log("Leo");
            theButtonScript.coins -= MorterCost;
        }

    }

    public void BuyLaser()
    {
        if (theButtonScript.coins >= LaserCost)
        {
            Debug.Log("Leo");
            theButtonScript.coins -= LaserCost;
        }

    }
}
