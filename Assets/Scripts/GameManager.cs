using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Text highestScoreText;
    public Text highestScoreValueText;
    private AudioSource dieSoundEffect;
    public SaveData saveData;
    public int score;
    public int highscore;
    public GameObject resetButton;
    public GameObject title;
    public bool HighscoreReached => (score > highscore);



    private void Awake()
    {
        //load dari savedata
        saveData.Load(out highscore,gameObject.name);
        highestScoreValueText.text = highscore.ToString();
        Application.targetFrameRate = 60;
        dieSoundEffect = GetComponent<AudioSource>();
        
        // ketika game baru mulai maka pause game nya
        Pause();
    }

    public void Play()
    {
        dieSoundEffect = GetComponent<AudioSource>();
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        highestScoreText.gameObject.SetActive(false);
        highestScoreValueText.gameObject.SetActive(false);
        resetButton.SetActive(false);
        title.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        //freezeing game nya
        Time.timeScale = 0f;
        player.enabled = false; 
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        dieSoundEffect.Play();
        playButton.SetActive(true);
        highestScoreText.gameObject.SetActive(true);
        highestScoreValueText.gameObject.SetActive(true);
        highestScoreValueText.text = highscore.ToString();
        saveData.Save(highscore,gameObject.name);
        resetButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (HighscoreReached) highscore = score;
    }
    
    public void ResetHighscore()
    {
        highscore = 0;
        highestScoreValueText.text = "0";
        //save ke saveData
        saveData.Save(highscore,gameObject.name);
    }
}
