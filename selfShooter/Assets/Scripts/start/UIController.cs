using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    public RectTransform targetUI;
    public RectTransform nowUI;

    public Scrollbar scrollBar;
    public Text hardlevelText;
    private Image image;

    private bool tempBool;
    private Slider _slider;

    // Use this for initialization
    private void Start()
    {
        _slider = slider.GetComponent<Slider>();
        image = hardlevelText.gameObject.transform.parent.GetComponent<Image>();
        tempBool = false;
        _slider.value = GlobalData.voice;
        scrollBar.value = 0;
        ChangeHardLevel();

        targetUI.gameObject.SetActive(false);
    }

    /*--------------------------------------------------*/

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ChangePanel()
    {
        nowUI.gameObject.SetActive(tempBool);
        targetUI.gameObject.SetActive(!tempBool);
        tempBool = !tempBool;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeHardLevel()
    {
        if (scrollBar.value < 0.3333 && scrollBar.value >= 0)
        {
            hardlevelText.text = "Easy";
            image.color = Color.green;
            GlobalData.hardLevel = 0;
        }
        else if (scrollBar.value >= 0.3333 && scrollBar.value < 0.6666)
        {
            hardlevelText.text = "Normal";
            image.color = Color.yellow;
            GlobalData.hardLevel = 1;
        }
        else { hardlevelText.text = "hard"; image.color = Color.red; GlobalData.hardLevel = 2; }
    }

    public void ChangeVoice()
    {
        GlobalData.voice = _slider.value;
    }
}