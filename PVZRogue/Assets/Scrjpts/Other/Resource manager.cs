//Joy Schulze
//December 3rd
//Controls gold and which defence you currently have selected.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int gold = 0;
    public GameObject selectedDefense;
    RaycastHit hit;

    public Camera gameCamera;

    public TMP_Text goldText;

    ///Whenever you press down your mouse, it checks to see if you've clicked on gold or a grid space and acts accordingly
    void Update(){

        if(Input.GetMouseButtonDown(0) && Physics.Raycast(gameCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit)){
            //Clicked on gold, gains gold
            if(hit.collider.GetComponent<Gold>()){
                gold += hit.collider.GetComponent<Gold>().value;
                Destroy(hit.collider.GetComponent<Gold>().gameObject);
            }
            //Clicked on an epty grid space with a unit selected, places the unit, pays for the unit, and empties your selected unit
            else if(hit.collider.GetComponent<GridSpace>().empty && selectedDefense != null){
                selectedDefense.GetComponent<DefenseUnit>().gridSpace = hit.collider.GetComponent<GridSpace>();
                Instantiate(selectedDefense, hit.collider.transform.position, hit.collider.transform.rotation);
                gold -= selectedDefense.GetComponent<DefenseUnit>().cost;
                selectedDefense = null;
            }
            //If you click on an empty grid space without a selected unit, does nothing
            else if(selectedDefense == null)
                print("No defense selected.");
            //If you click on a grid space that already has a unit on it, does nothing
            else if(!hit.collider.GetComponent<GridSpace>().empty)
                print("There is already a unit on that square.");
            
        }
        goldText.text = "Gold: " + gold;

    }
}


