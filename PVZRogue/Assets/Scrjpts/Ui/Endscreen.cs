using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Matthew Borrelli
/// Date Updated: 12/10/24
/// Purpose: Lets player navigate menu's
/// </summary>
public class Endscreen : MonoBehaviour
{
    //Switches Scenes when needed
 public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    //Closes the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
