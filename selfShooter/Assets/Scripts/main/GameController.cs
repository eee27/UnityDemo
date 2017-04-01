using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        buttonController();
    }

    public void buttonController()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GamePause(true);
        }
        if (Input.GetButtonDown("Restart"))
        {
            GlobalFunction.LoadScene("main");
        }
    }

    public void LoadScene(string scene)
    {
        GlobalFunction.LoadScene(scene);
    }

    public void ExitGame()
    {
        GlobalFunction.ExitGame();
    }

    public void GamePause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
        }
        else { Time.timeScale = 1; }
    }
}