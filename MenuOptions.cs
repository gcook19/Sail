using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    public GameObject Start_menu;
    public GameObject Options_menu; 

    public void options_menu_open()
    {
        Start_menu.SetActive(false);
        Options_menu.SetActive(true); 
    }

    public void main_menu_open()
    {
        Start_menu.SetActive(true);
        Options_menu.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit(); 
    }
}
