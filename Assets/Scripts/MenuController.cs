using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject panel;
    public Button loadButton;

    public CollectibleController _collectibleController;
    public Movement _movement;
    
    public void Awake()
    {
        if (!DataSerializer.AnySaves())
        {
            loadButton.interactable = false;
        }
        else
        {
            loadButton.interactable = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeSelf);
            if (!DataSerializer.AnySaves())
            {
                loadButton.interactable = false;
            }
            else
            {
                loadButton.interactable = true;
            }
        }
    }

    public void NewGame()
    {
        
    }

    public void LoadGame()
    {
        DataSerializer.Load();
        _movement.Load();
        _collectibleController.Load();
    }

    public void SaveGame()
    {
        new SaveData();
        _movement.Save();
        _collectibleController.Save();
        DataSerializer.Save();
    }
}
