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
    public GameObject Menu;
    private GameObject Messenger;
    private GameObject Camera;
    private GameObject Gallery;
    private GameObject Map;
    private GameObject Bank;
    private GameObject Notes;
    private GameObject Phone;
    private GameObject Spotify;
    private GameObject Tinder;


    void Start()
    {
        if (menuObjects.Count == 9)
        {
            Bank = menuObjects[0];
            Camera = menuObjects[1];
            Gallery = menuObjects[2];
            Map = menuObjects[3];
            Messenger = menuObjects[4];
            Notes = menuObjects[5];
            Phone = menuObjects[6];
            Spotify = menuObjects[7];
            Tinder = menuObjects[8];
            
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
            Menu.SetActive(false);
        }
        else
        {
            Debug.LogError("menuToActivate is null!");
        }
        
    }
    
    public void OpenBank()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Bank);  
        }
        
    }
    
    public void OpenCamera()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Camera);
        }
        
    }
    
    public void OpenGallery()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Gallery); 
        }
        
    }

    public void OpenMaps()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Map);  
        }
        
    }
    
    public void OpenMessenger()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            Debug.Log("Opening Messenger");
            ToggleMenu(Messenger); 
        }
       
    }

    public void OpenNotes()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Notes);  
        }
        
    }
    
    public void OpenPhone()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Phone); 
        }
        
    }
    
    public void OpenSpotify()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Spotify); 
        }
        
    }

    public void OpenTinder()
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            ToggleMenu(Tinder);  
        }
        
    }
}
