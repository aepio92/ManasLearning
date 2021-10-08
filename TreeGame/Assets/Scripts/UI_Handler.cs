using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Handler : MonoBehaviour
{
    public GameObject Gameplay;
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject Tutorial;

    [HideInInspector] public int AppleCount=0;
    // Start is called before the first frame update
    void Start()
    {
        Gameplay.SetActive(false);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        MainMenu.SetActive(true);
        AppleCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("SampleScene");
        Gameplay.SetActive(false);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OpenGameOverMenu()
    {
        Gameplay.SetActive(false);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void PuseGame()
    {
        PauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
    }

    public void Play()
    {
        Gameplay.SetActive(false);
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        MainMenu.SetActive(false);
        Tutorial.SetActive(true);
        Invoke("StartGame", 4.8f);
    }

    void StartGame()
    {
        Tutorial.SetActive(false);
        Gameplay.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
