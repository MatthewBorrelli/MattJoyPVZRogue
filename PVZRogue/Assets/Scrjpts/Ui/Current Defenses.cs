//Joy Schulze
//December 3rd
//The on click event for the buttons to select the current defense unit
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentDefenses : MonoBehaviour
{
    public GameObject[] defences = new GameObject[6];
    public ResourceManager reMan;



    public void BuyUnit(int index){
        DefenseUnit unit = defences[index].GetComponent<DefenseUnit>();
        if(unit.cost <= reMan.gold){
            reMan.selectedDefense = defences[index];
        }
        else{
            print("Not enough gold.");
        }
    }
}
