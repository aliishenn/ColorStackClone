using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.SceneManagement;





public class ClickyButton : MonoBehaviour


{
   public void MainMenu()
   {
      SceneManager.LoadScene(0);
   }

   public void PlayGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void QuitGame()
   {
      Application.Quit();
   }

   public void ReloadLevel()
   {
      
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   

   
}
