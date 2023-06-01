using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagmentt : MonoBehaviour
{
    public void NextScene()
    {
        Invoke("ChangeScene", 1);

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
