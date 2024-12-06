//Joy Schulze
//December 3rd
//Controls gold and which defence you currently have selected.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int gold = 0;
    public GameObject selectedDefense;
    RaycastHit hit;

    public Camera gameCamera;
    

    void Update(){

        if(Input.GetMouseButtonDown(0) && Physics.Raycast(gameCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit)){
            
            if(hit.collider.GetComponent<GridSpace>().empty && selectedDefense != null){
                Instantiate(selectedDefense, hit.collider.transform.position, hit.collider.transform.rotation);
                gold -= selectedDefense.GetComponent<DefenseUnit>().cost;
                hit.collider.GetComponent<GridSpace>().empty = false;
                selectedDefense = null;
            }
            else if(selectedDefense == null)
                print("No defense selected.");
            else if(!hit.collider.GetComponent<GridSpace>().empty)
                print("There is already a unit on that square.");
            
        }

    }
}


