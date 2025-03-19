using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private TextMeshPro bunkerTimerText;
    [SerializeField] private AudioSource explosion;
    [SerializeField] private GameObject level;
    [SerializeField] private TextMeshPro bunkerLossText;
    [SerializeField] private GameObject bunkerCeiling;
    private bool hasLost;
    private bool hasWon;
    private bool gameStarted;
    private bool playedSoundEffect;
    private float timerMultiplier;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 120f;
        timerMultiplier = 1;
        hasLost = false;
        hasWon = false;
        gameStarted = false;
        playedSoundEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted && !hasLost && !playedSoundEffect)
        {
            timer -= Time.deltaTime * timerMultiplier;
        }

        timerText.SetText(timer.ToString("F0"));
        bunkerTimerText.SetText(timerText.text);

        if (timer <= 0 && !(hasLost || hasWon))
        {
            timer = 0;
            ResetGame();
        }
        else if(timer <= 0 && !playedSoundEffect && hasWon)
        {
            ExplosionEffect();
        }
    }

    public float GetTimer()
    {
        return timer;
    }

    public void MultiplyTimer()
    {
        timerMultiplier = 20;
        GetComponent<AudioSource>().Play();
    }

    public void ResetGame()
    {
        hasLost = true;
        bunkerLossText.gameObject.SetActive(true);
        explosion.Play();
        Destroy(level);
        StartCoroutine(DelayedReset());
    }

    public void WinGame()
    {
        hasWon = true;
        bunkerCeiling.SetActive(true);
    }

    public void ExplosionEffect()
    {
        playedSoundEffect = true;
        timer = 0;
        explosion.Play();
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public IEnumerator DelayedReset()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("EscapeRoom", LoadSceneMode.Single);
    }
}
