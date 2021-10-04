using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFunction : MonoBehaviour
{
    public GameObject Enemy;
    public float time;

    public Text ScoreText;
    public int Score = 0;
    public static GameFunction Instance;

    public GameObject GameTitle;
    public GameObject GameOverTitle;
    public GameObject PlayButton;
    public bool IsPlaying = false;

    public GameObject RestartButton;
    public GameObject QuitButton;

    public float BulletTime;
    public GameObject Ship;
    public GameObject Bullet;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        GameTitle.SetActive(true);
        GameOverTitle.SetActive(false);
        RestartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>0.5f && IsPlaying == true)
        {
            Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), 4.5f, 0);
            Instantiate(Enemy, pos, transform.rotation);
            time = 0f;
        }

        BulletTime += Time.deltaTime;
        if(BulletTime > 0.15f && IsPlaying == true)
        {
            Vector3 Bullet_pos = Ship.transform.position + new Vector3(0, 0.6f, 0);
            Instantiate(Bullet, Bullet_pos, Ship.transform.rotation);
            BulletTime = 0f;
        }
        
    }
    public void AddScore()
    {
        Score += 10;
        ScoreText.text = "Score : " + Score;
    }
    public void GameStart()
    {
        IsPlaying = true;
        GameTitle.SetActive(false);
        PlayButton.SetActive(false);
        QuitButton.SetActive(false);
    }
    public void GameOver()
    {
        IsPlaying = false;
        GameOverTitle.SetActive(true);
        RestartButton.SetActive(true);
        QuitButton.SetActive(true);
    }
    public void GameRestart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
