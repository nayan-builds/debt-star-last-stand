using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public Buildable SelectedBuildable = Buildable.Block;
    public int Money = 0;
    public TextMeshProUGUI MoneyText;
    public BuildablePrefabs BuildablePrefabs;
    public Prices Prices;

    public void SetSelectedBuildable(string buildable)
    {
        if (buildable == "Block")
        {
            SelectedBuildable = Buildable.Block;
        }
        else if (buildable == "Turret")
        {
            SelectedBuildable = Buildable.Turret;
        }
    }

    public bool Build(Vector3 position, Vector3 up, Quaternion rotation)
    {
        //Returns true if build was successful
        //Returns false if build was unsuccessful
        switch (SelectedBuildable)
        {
            case Buildable.Block:
                if (Money >= Prices.Block)
                {
                    Money -= Prices.Block;
                    Instantiate(BuildablePrefabs.Block, position + up * 1.5f, Quaternion.identity);
                    return true;
                }
                break;
            case Buildable.Turret:
                if (Money >= Prices.Turret)
                {
                    Money -= Prices.Turret;
                    Instantiate(BuildablePrefabs.Turret, position, rotation);
                    return true;
                }
                break;
        }
        return false;
    }

    public void UpdateMoneyText()
    {
        MoneyText.text = "$" + Money;
    }
}

//Get object to show in inspector
//https://forum.unity.com/threads/can-i-make-collapsible-groups-within-the-inspector.828231/
[System.Serializable]
public class BuildablePrefabs
{
    public GameObject Block;
    public GameObject Turret;

}


[System.Serializable]
public class Prices
{
    public int Block = 10;
    public int Turret = 50;
}
public enum Buildable
{
    Block,
    Turret
}
