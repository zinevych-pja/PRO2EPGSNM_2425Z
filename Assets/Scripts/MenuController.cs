using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public Movement playerMovement;




    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            menuPanel.SetActive(!menuPanel.activeSelf);

            //check if save exists DataSerializer.AnySave()
            //If exists Activate continue button
            //Else deactivate continue button
        }
    }


    public void NewGame()
    {
        new SaveData();
    }

    public void Save()
    {
        //Fill save data
        playerMovement.Save();
        DataSerializer.Save();
    }

    public void Continue() 
    {
        
    }

    public void Exit() 
    {
    
    }

    
}
