using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int scoreNow = 0;
    public int time = 30;
    public bool takingaway = false; 
    public Text scoreText;
    public Text timer;
    public GameObject endScreen;
    public pausingscript pausescr;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator TimerTake()
    {
        takingaway = true;
        yield return new WaitForSeconds(1);
        time -= 1;
        timer.text = time.ToString() + " Seconds";
        takingaway = false;
    }

    public void addScore(){
        scoreNow = scoreNow + 1;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreNow.ToString();

         if (takingaway == false && time > 0)
        {
            StartCoroutine(TimerTake());
        }
        if (time <= 0)
        {
            //end game, give results
            //turn off uis, show aim results (missed shots / accracy, amount hit, targets per min, etc) then press space quit
            endScreen.SetActive(true);
            pausescr.endgamepause();

        }
    }
    public void restartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void closegame()
    {
        Application.Quit();
    }
}
