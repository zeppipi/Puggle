using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamesManager : MonoBehaviour
{
    //Check how many balls there are in the scene
    private GameObject[] ballsScene;

    //Get information about the score
    private GameObject scoreManagerGameObject;
    private Score scoreManagerScript;

    //Choose how many lives the player can have
    [SerializeField]
    private int lives;

    //Variables for lives calculations
    private int currentBalls;
    private int lastUpdateBalls;

    //Display Game Over text, lives, and game over buttons
    [SerializeField]
    private TextMeshProUGUI gameOver;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TextMeshProUGUI livesText;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject mainMenuButton;

    //Bool to show if the game has ended or not
    private bool gamePlaying;
    
    //For cases where the gameover needs to be overwrite (true for ignore gameover, false for let gameover happen)
    private bool overwriteGameover;

    //Play audio for when a ball is lost and when game over is reached
    [SerializeField]
    private AudioSource ballLostSound;

    //Start is called before the first frame update
    void Start()
    {
        //Annouce the game is playing
        gamePlaying = true;
        
        //Start the last update
        lastUpdateBalls = 0;
        
        //Get info on the amount of balls currently
        ballsScene = GameObject.FindGameObjectsWithTag("Ball");
        currentBalls = ballsScene.Length;
        
        //Get info of the score
        scoreManagerGameObject = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManagerGameObject.GetComponent<Score>();
    }
    
    //Update is called once per frame
    void Update()
    {
        //Hide game over text and game over buttons
        gameOver.enabled = !gamePlaying;
        gameOverPanel.SetActive(!gamePlaying);
        restartButton.SetActive(!gamePlaying);
        mainMenuButton.SetActive(!gamePlaying);
        
        //Display the lives count
        livesText.text = lives + "x";
        
        //Get info on the amount of balls currently
        ballsScene = GameObject.FindGameObjectsWithTag("Ball");
        currentBalls = ballsScene.Length;

        //A change in the amount of balls has been detected
        if(lastUpdateBalls != currentBalls)
        {
            //A ball was lost
            if(currentBalls < lastUpdateBalls)
            {
                if(lives >= 0)  //Just so the lives doesn't continously get reduced
                {
                    ballLostSound.Play();
                    lives -= 1;
                    Debug.Log("Lives: " + lives);
                    lastUpdateBalls = currentBalls;
                }
            }
            //A ball was added
            else
            {
                lastUpdateBalls = currentBalls;
            }
        }
        
        //Game Over
        if(lives == 0 || currentBalls == 0)
        {
            if(overwriteGameover == false)
            {
                Debug.Log("Game Over! Your final score is " + scoreManagerScript.scoreGetter());
                gamePlaying = false;
            }

        }

        //Check game over
        if(!gamePlaying)
        {
            endPlay();
        }
    }

    //Script plays all the nessecary things for a game over
    void endPlay()
    {   
        //Make time go back to normal
        Time.timeScale = 1;
        
        //turn the game palying status to false
        gamePlaying = false;
        
        //Deletes all balls in the scene
        for(int index = 0; index < currentBalls; index++)
        {
            if(ballsScene[index] != null)
            {
                Destroy(ballsScene[index].GetComponent<Pointer>().pointerGetter());
                Destroy(ballsScene[index]);
            }
        }
        //Show gameover
        gameOver.enabled = !gamePlaying;
        gameOverPanel.SetActive(!gamePlaying);
        restartButton.SetActive(!gamePlaying);
        mainMenuButton.SetActive(!gamePlaying);

        //Make lives show 0
        lives = 0;
    }
    
    //Script to reset the scene
    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Script to go to the main menu
    public void exitLevel()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    //Script to go to the game
    public void enterLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    //Sets out the info of how many lives the player has
    public void liveSetter(int number)
    {
        lives = number;
    }

    //Gives out the info of how many lives the player has
    public int liveGetter()
    {
        return lives;
    }

    //Gives out the info if the game is playing
    public bool gamePlayingGetter()
    {
        return gamePlaying;
    }

    //Let other scripts overwrite the gameover status
    public void overwriteGameoverSetter(bool res)
    {
        this.overwriteGameover = res;
    }
}
