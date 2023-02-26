using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EvenManager : MonoBehaviour
{
    //[SerializeField] Text score;
    // Start is called before the first frame update
   public void PlayGame()
    {
        SceneManager.LoadScene("ScenePlay");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
