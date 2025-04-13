using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    
    public List<GameObject> menuObjects;
    private bool isMenuOpen = false;
    private GameObject Messenger;
    private GameObject Camera;
    private GameObject Gallery;
    private GameObject Map;
    private GameObject Menu;


    void Start()
    {
        if (menuObjects.Count == 5)
        {
            Messenger = menuObjects[0];
            Camera = menuObjects[1];
            Gallery = menuObjects[2];
            Map = menuObjects[3];
            Menu = menuObjects[4];
            
        }
    }

    private void ToggleMenu(GameObject menuToActivate)
    {
        foreach (GameObject menuObject in menuObjects)
        {
            if (menuObject != null)
            {
                menuObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("A menu object is null and cannot be deactivated.");
            }
        }
        
        if (menuToActivate != null)
        {
            menuToActivate.SetActive(true);
        }
        else
        {
            Debug.LogError("menuToActivate is null!");
        }
    }

    public void OpenMessenger()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            Debug.Log("Opening Messenger");
            ToggleMenu(Messenger);  // Only activate the Messenger
        }
        else
        {
            Debug.Log("Closing Messenger, opening Menu");
            ToggleMenu(Menu); // Activate the main menu when closing
        }
    }

    public void OpenCamera()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Camera);  // Only activate the Camera
        }
        else
        {
            ToggleMenu(Menu); // Activate the main menu when closing
        }
    }
    
    public void OpenGallery()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Gallery);  // Only activate the Camera
        }
        else
        {
            ToggleMenu(Menu); // Activate the main menu when closing
        }
    }

    public void OpenMap()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Map);  // Only activate the Map
        }
        else
        {
            ToggleMenu(Menu); // Activate the main menu when closing
        }
    }

    public void OpenMenu()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            Debug.Log("Opening Menu: ");
            ToggleMenu(Menu);  // Only activate the Main Menu
        }
        else
        {
            Debug.Log("Closing Menu");
            ToggleMenu(null);  // Optionally handle menu closing behavior
        }
    }
}
