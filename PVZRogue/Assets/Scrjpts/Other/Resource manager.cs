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
        Debug.DrawRay(Input.mousePosition / 100, Vector3.forward * 1000, Color.red);
        if(Input.GetMouseButton(0) && Physics.Raycast(gameCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit)){
            
            if(hit.collider.GetComponent<GridSpace>())
                print("Hit the grid");
        }

    }
}


