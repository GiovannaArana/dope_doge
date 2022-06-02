using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HUD;

    public void Play(){

    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit(){

    	Debug.Log("Quit");
		Application.Quit();
    }

    public void PetPet(){

    	HUD.SetActive(true);
    }
}
