using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class IUManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button audioOn;
    [SerializeField] private Button audioOff;
    [SerializeField] private Image carChangeColor;
    [SerializeField] private TextMeshProUGUI carChangeColorTime;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Image gameOverImageBox;
    [SerializeField] private Image highScoreResetBox;
    Material nextMat;
    float nextMatTimer;
    float changingTime;
    TestColor testColor;
    void Start()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.StopGame();
        //HighScoreText
        highScoreText.text = PlayerPrefs.GetInt("highScore", GameManager.Instance.highScore).ToString();
        
        testColor = FindObjectOfType<TestColor>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!GameManager.Instance.gameOver)
        {
            //Next Material Color for UI
            nextMat = FindObjectOfType<TestColor>().nextMaterial;
            carChangeColor.color = nextMat.color;

            //Next Material Timer for UI
            nextMatTimer = testColor.selectTime;
            carChangeColorTime.text = ((int)nextMatTimer + 1).ToString();

            //Score
            scoreText.text = "Score\n" + GameManager.Instance.score.ToString();

            changingTime = testColor.colorChangeTime;
            //HighScore
            highScoreText.text = "Highscore\n" + PlayerPrefs.GetInt("highScore", GameManager.Instance.highScore).ToString();


            gameOverImageBox.gameObject.SetActive(false);

        }
        if (GameManager.Instance.gameOver)
        {
            
            //GameOverUI
            gameOverImageBox.gameObject.SetActive(true);
        }
    }
    #region ButtonScripts

    //Bu kadarına ingilizcem yetmez kanka. Şöyle bir olay var. Buttonlar için public metotlar yazıyoruz. Unity editörü içerisinde, Hierarchy'de, Canvas'tan buttonlara tıkladığında, Inspector panelinde, Button componenti içerisinde, On Click() eventini göreceksin. Bu On Click() eventi Visual studioda ki buttonlara çift tıkladığımızda kodu yazdığımız kısımla aynı. Oranın içerisine bu scriptin componenti olduğu gameObjecti sürükleyip bıraktığın vakit, hemen yanında çıkan kısımda, buraya yazdığımız public metotları görebiliyorsun(privatelar gözükmüyor). Sonra o buton tıklandığında, hangi metodu çalıştırsın istiyorsan, o metodu seçiyorsun. Tıpkı visual studioda bir butonu çift tıkladığımızda, içine yazdığımız kodlar gibi çalışıyor. 

    public void ResumeGame()
    {
        Time.timeScale = 1;
        playButton.gameObject.SetActive(false);
        highScoreResetBox.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        highScoreResetBox.gameObject.SetActive(true);
    }

    public void AudioOn()
    {
        AudioListener.volume = 1;
        audioOn.gameObject.SetActive(false);
        audioOff.gameObject.SetActive(true);
    }

    public void AudioOff()
    {
        AudioListener.volume = 0;
        audioOn.gameObject.SetActive(true);
        audioOff.gameObject.SetActive(false);

    }

    public void Retry()
    {

        SceneManager.LoadScene(0);
        GameManager.Instance.gameOver = false;
        testColor.selectTime = 0;
        Time.timeScale = 1;
        playButton.gameObject.SetActive(false);
    }

    public void HighScoreReset()
    {
        PlayerPrefs.DeleteKey("highScore");
    }

    #endregion
}
