using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausingscript : MonoBehaviour
{
    public  bool GameIsPaused = false;
    public GameObject pausemenu;
    public GameObject startmenu;
    public GameObject gameui;
    public FirstPersonController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        startmenu.SetActive(true);
        gameui.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerScript.cameraCanMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void startGame()
    {
        startmenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerScript.cameraCanMove = true;
        gameui.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
            }else{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
            }
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused){
                Resume();
                        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
            }else{
                Pause();
                        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void Resume(){
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        playerScript.cameraCanMove = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameui.SetActive(true);
    }
    void Pause(){
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerScript.cameraCanMove = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameui.SetActive(false);
    }
    public void endgamepause()
    {
        startmenu.SetActive(false);
        pausemenu.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerScript.cameraCanMove = false;
        gameui.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameui.SetActive(false);
    }
}
