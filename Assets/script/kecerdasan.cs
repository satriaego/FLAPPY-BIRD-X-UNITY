using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kecerdasan : MonoBehaviour
{
    public static bool hasStartedBefore = false;
    public aronaScript arona; // Drag and assign in the Inspector
    public GameObject gameUI;
    public static bool isGameStarted = false;
    public Text highScoretx; // Add this in Inspector to show high score UI
    private int highScore;
    public int aronaScore;
    public GameObject gameOverScreen;
    public Text aronaScoretx;

    [ContextMenu("score add test")]
    public void addScore(int addScore)
    {
        aronaScore = aronaScore + addScore;
        aronaScoretx.text = aronaScore.ToString();

        if (aronaScore > highScore)
        {
            highScore = aronaScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoretx.text = "High Score: " + highScore;
        }
    }

    public void restartGame()
    {
        codeRintangan.globalSpeed = 13;
        SceneManager.LoadScene(1);
        isGameStarted = true; // Start the game logic

    }

    void Start()
    {   
        // Pause the game on start to prevent auto-play
        if (!hasStartedBefore)
        {
            gameUI.SetActive(true); // Tampilkan UI hanya saat pertama kali
            hasStartedBefore = true;
        }
        else
        {
            gameUI.SetActive(false); // Kalau sudah pernah mulai, sembunyikan UI
        }
        // gameUI.SetActive(true);  // Show the game UI (main menu or pre-game UI)
        gameOverScreen.SetActive(false);  // Hide the Game Over screen

        // Get the high score from PlayerPrefs and show it on UI
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoretx.text = "High Score: " + highScore;
        arona = GameObject.FindGameObjectWithTag("arona"). GetComponent<aronaScript>();
        
    }

    public void gameOver()
    {
        // Show the Game Over screen
        gameOverScreen.SetActive(true);
    }

    // This method will be called when the Start button is clicked
    public void STARTUI()
    {
        gameUI.SetActive(false);  // Hide the Game UI (start screen)
        isGameStarted = true; // Start the game logic
        arona.aronaRigidbody.gravityScale = 2; // Prevent falling before game starts
    }
}
