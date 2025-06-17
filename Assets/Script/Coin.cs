using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreValue;
    public AudioSource CoinSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CoinSound == null)
        CoinSound = GetComponent<AudioSource>();
        if (CoinSound == null)
        {
            GameObject soundObj = GameObject.Find("CoinSound");
            if (soundObj != null)
            {
                CoinSound = soundObj.GetComponent<AudioSource>();
            }
        }
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(scoreValue);
            if (CoinSound != null)
            {
                CoinSound.Play();
            }

            Destroy(this.gameObject);
        }
        
    }
}
