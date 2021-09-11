using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasButton;
    [SerializeField] Spaceship player;
    [SerializeField] int numEnemies;

    Animal animal;
    bool gamePaused = false;
    bool levelFinish = false;
    int escena;
    // Start is called before the first frame update
    void Start()
    {
        
        canvas.SetActive(false);
        canvasButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && levelFinish!=true)
        {
            PauseGame();
        }
        
    }
    public void StartGame()
    {
       
        SceneManager.LoadScene(1);
        escena = 1;


    }
    void PauseGame()
    {
        gamePaused = gamePaused ? false : true;
        canvas.SetActive(gamePaused);
        player.gamePaused = gamePaused;
        Time.timeScale = gamePaused ? 0 : 1;
    }
   public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if (numEnemies < 1)
        {
            Ganar();
            
        }
    }
    void Ganar()
    {
        
        canvasButton.SetActive(true);
        player.gamePaused = true;
        levelFinish =! levelFinish;
        Time.timeScale = 0;
    }
    public void SgteNivel(int sgt)
    {

        Debug.Log(escena);
        player.gamePaused = false;
        Time.timeScale = 1;

        SceneManager.LoadScene(sgt);
    }
}
