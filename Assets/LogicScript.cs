using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public bool _isGameStart = false;
    public int playerScore;
    public Text scoreText, countertxt;
    public Text IngameSttxt, IngameGvtxt;
    public GameObject gameOverScreen,PauseScreen, Helpscreen,MainScreen;
    public int Timer = 3;
    public bool _startCounter = false;
   
    public InputField Speed, gravity;
    public bool birdIsAlive = true;
    public float Ystrength = 10;
    public float gravityer = -9.81f;
    [ContextMenu("Increase Score")]
    private void Start()
    {

    }
    private void Update()
    {
        /* We are using Escape Key to go to option menu rather than pressing
        button to save user time, i.e make it user friendly system */

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            ActiveObj(PauseScreen,Helpscreen);
        }
        /* H key can be used from keyboard so the user can understand how to control 
         * the bird, how to score and how to avoid the pipes*/

        if (Input.GetKeyDown(KeyCode.H) == true)
        {
            PauseGamebt();
        }

       /*
        if (!_startCounter) return;


        if (currentTime <= 0f)
        {
            Counterftn(false);

        }
        else
        {
            countertxt.text = currentTime.ToString("0");
            currentTime -= Time.deltaTime;
        }
*/

    }
    public void startGame()
    {
        /* it gives counter time to play the game coroutine helps to have a sync 
         function called rather than waiting to execute, its parallel processing*/
        StartCoroutine(InGamestart());
    }

    IEnumerator InGamestart()
    {
      countertxt.gameObject.SetActive(true);
        while (Timer > 0)
        {
            yield return new WaitForSeconds(1f);
            Timer -= 1;
            countertxt.text = Timer.ToString("0");
            
        }
        Timer = 3;
        Counterftn(false);
        countertxt.text = Timer.ToString("0");
       

    }
    public void valuesUpdate()
    {
        Ystrength = float.Parse(Speed.text);
        gravityer = float.Parse(gravity.text);
        IngameSttxt.text =  Speed.text;
        IngameGvtxt.text = gravity.text;
    }
    public void PauseGamebt()
    {
        ActiveObj(Helpscreen, PauseScreen);

    }
    public void Escapebt()
    {
        if (!MainScreen.active)
        {
            startGame();
        }
        valuesUpdate();

    }

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void quitgame () { 
     Application.Quit();
    
    }

    private void ActiveObj(GameObject Active, GameObject DisActive)
    {
        if (Active.activeInHierarchy)
        {
            Active.SetActive(false);
            Counterftn(true);
          //  startGame();
        }
        else
        {
            Active.SetActive(true);
            DisActive.SetActive(false);
            _isGameStart = false;          
            GameObject.FindAnyObjectByType<BirdController>().birdPhysics(false);
        }
    }

    public void Counterftn(bool startCounter)
    {

      
        scoreText.text = playerScore.ToString();
        _startCounter = startCounter;
        _isGameStart = !startCounter;
        countertxt.gameObject.SetActive(startCounter);
        valuesUpdate();
        if (!startCounter)
        {
            GameObject.FindAnyObjectByType<BirdController>().Gamestart();
        }
       
    }
}