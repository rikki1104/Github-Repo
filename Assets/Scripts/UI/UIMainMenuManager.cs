﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Maze_Game.UI
{
    public class UIMainMenuManager : MonoBehaviour
    {  
        [SerializeField] GameObject settingsMenu;
        [SerializeField] GameObject mainMenu;


        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

         public void OpenSettings()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void OpenMainMenu()
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }

}