using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    public Animator StartBT;
    public GameObject[] roomPrefabs;

    private int selectedRoomNumber = 0; // 存储当前选择的关卡编号，默认为 0 表示未选择

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 保持对象在场景切换时不被销毁
        SceneManager.sceneLoaded += OnSceneLoaded; // 注册场景加载完成的事件
    }

    // private void Update()
    // {
    //     GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
    //     foreach (GameObject room in rooms)
    //     {
    //         Destroy(room);
    //     }
    // }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 在新场景加载后，检查是否有所选关卡编号，如果有，则加载对应的预制体房间
        if (scene.name == "SampleScene" && selectedRoomNumber != 0)
        {
            LoadRoom(selectedRoomNumber);
        }
    }

    public void ReturnStart()
    {
        StartBT.SetBool("isdisplay", true);
        Invoke("ReturnScene", 1.7f);
    }

    public void StartGame()
    {
        StartBT.SetBool("isdisplay", true);
        Invoke("LoadNewScene", 0f);
    }

    public void LoadNewScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene("StartMune");
    }

    public void LoadRoom(int roomNumber)
    {
        selectedRoomNumber = roomNumber; // 保存所选关卡的编号
        Invoke("InstantiateRoom", 0f); // 1.5秒延迟后执行 InstantiateRoom 方法
    }

    private void InstantiateRoom()
    {
        if (selectedRoomNumber >= 1 && selectedRoomNumber <= roomPrefabs.Length)
        {
            Instantiate(roomPrefabs[selectedRoomNumber - 1]); // 从数组中选择对应预制件，索引从0开始，而关卡编号从1开始
        }
        else
        {
            Debug.LogWarning("Invalid room number");
        }
    }
}