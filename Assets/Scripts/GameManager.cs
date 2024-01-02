using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator BackBT;
    
    
    public void PauseTime()
    {
        BackBT.SetBool("isdisplay", true);
        Invoke("PauseGame", 1.8f); // 增加一些时间间隔
    }
    
    public void ReturnTime()
    {
        Invoke("ResumeGame", 0f);
        BackBT.SetBool("isdisplay", false);
    }
    
    public void ReturnStart()
    {
        Time.timeScale = 1f;
        Invoke("ReturnScene", 1f);
    }
    
    void PauseGame()
    {
        Time.timeScale = 0f; // 暂停游戏时间
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // 恢复游戏时间
    }
    
    public void ReturnScene()
    {
        SceneManager.LoadScene("StartMune");
    }
}