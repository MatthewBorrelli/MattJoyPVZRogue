//Joy Schulze
//December 3rd
//The on click event for the buttons to select the current defense unit
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentDefenses : MonoBehaviour
{
    public GameObject[] defences;
    public GameObject[] buttons;
    public ResourceManager reMan;

    ///Gives the buttons the icon of their respective unit
    void Start(){
        for(int i = 0; i < defences.Length; i++){
            buttons[i].GetComponent<Image>().sprite = defences[i].GetComponent<DefenseUnit>().iconSprite;
            buttons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "Cost " + defences[i].GetComponent<DefenseUnit>().cost;
        }
    }
    ///Allows you to buy a plant if you have the gold
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
