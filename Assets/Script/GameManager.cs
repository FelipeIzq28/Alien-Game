using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePaused = false;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject nextlevel;
    [SerializeField] Spaceship player;
    [SerializeField] int numEnemies;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        SceneManager.GetActiveScene();
        Debug.Log(SceneManager.GetActiveScene());
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
        Time.timeScale = 0;
        player.gamePaused = true;
    }
    void SgteNivel()
    {
        SceneManager.GetActiveScene();
        Debug.Log(SceneManager.GetActiveScene());
        //if (SceneManager.sceneCount()==1)
        {

        }
    }
}
