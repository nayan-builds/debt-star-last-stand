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
        //OnClick handlers don't like enums
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
        Vector3 middle = position + up * 1.5f;
        switch (SelectedBuildable)
        {
            case Buildable.Block:
                if (Money >= Prices.Block)
                {
                    Money -= Prices.Block;
                    UpdateMoneyText();
                    FireRaycasts(middle);
                    Instantiate(BuildablePrefabs.Block, middle, Quaternion.identity);
                    return true;
                }
                break;
            case Buildable.Turret:
                if (Money >= Prices.Turret)
                {
                    Money -= Prices.Turret;
                    UpdateMoneyText();
                    FireRaycasts(middle);
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

    void FireRaycasts(Vector3 middle)
    {
        //Removes block faces that should no longer exist
        Vector3[] directions = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right, Vector3.up, Vector3.down };
        foreach (Vector3 direction in directions)
        {
            RaycastHit hit;
            if (Physics.Raycast(middle, direction, out hit, 1.5f))
            {
                if (hit.transform.CompareTag("BlockFace"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
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
