using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerControl playerController;
    [SerializeField] private float respawnDelay = 2f;

    private bool isGameEnding = false;
    private bool hasWon = false;
    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public GameObject WinnerUI;

    void Start()
    {
        // Player kontrolcüsünü bul
        playerController = FindAnyObjectByType<PlayerControl>();

        // WinnerUI sahne içinde otomatik atanmadıysa sahnede bul
        if (WinnerUI == null)
            WinnerUI = GameObject.Find("WinnerUI");

        if (WinnerUI != null)
            WinnerUI.SetActive(false);
    }

    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = score.ToString();

        if (score >= 70 && !hasWon)
        {
            hasWon = true;

            if (WinnerUI != null)
            {
                WinnerUI.SetActive(true);
            }
            Invoke("GoToMainMenu", respawnDelay);

            //StartCoroutine(NextLevelAfterDelay());
        }
    }

    public void RespawnPoint()
    {
        if (!isGameEnding)
        {
            isGameEnding = true;
            StartCoroutine(RespawnCoroutine());
        }
    }

    private IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);

        // Oyuncuyu başa al
        playerController.transform.position = playerController.respawnPoint;
        playerController.gameObject.SetActive(true);
        isGameEnding = false;
    }

    public void LevelUp()
    {
        if (WinnerUI != null)
        {
            WinnerUI.SetActive(true);
            winText.text = "Seviye Tamamlandı! Toplam Puan: " + score;
        }

        Invoke("NextLevel", respawnDelay);
    }

    public void NextLevel()
    {

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;



        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Son sahnedesin, başka sahne yok!");
        }
        //SceneManager.LoadScene("SampleScene 2");
    }

    private IEnumerator NextLevelAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        NextLevel();
    }
    private void GoToMainMenu()
    {

        SceneManager.LoadScene(0);
    }
}
