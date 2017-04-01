using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text timeText;

    [SerializeField]
    private GameObject optionPanel;

    [SerializeField]
    private Text hardText;

    [SerializeField]
    private Slider bloodSlider;

    public Scrollbar scrollBar;
    public Text hardlevelText;
    private Image image;
    private Slider slider;

    // Use this for initialization
    private void Start()
    {
        slider = bloodSlider.GetComponent<Slider>();

        scoreText.text = 0.ToString();
        GlobalData.playerScore = 0;
        timeText.text = 0.ToString();
        image = hardlevelText.gameObject.transform.parent.GetComponent<Image>();
        optionPanel.SetActive(false);

        scrollBar.value = GlobalData.hardLevel * 0.5f;
        ChangeHardLevel();
        //ChangeUIState(false);
    }

    // Update is called once per frame
    private void Update()
    {
        float totalScore = GlobalData.playerScore;
        scoreText.text = totalScore.ToString();
        timeText.text = Time.timeSinceLevelLoad.ToString();
        scrollBar.value = GlobalData.hardLevel * 0.5f;
        hardText.text = "Hard:" + GlobalData.hardLevel.ToString();
        slider.value = GlobalData.playerBlood;
    }

    /*-----------------------------------------*/

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

    public void ChangeUIState(bool uiState)
    {
        optionPanel.SetActive(uiState);
        GlobalData.isUI = uiState;
    }
}