using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIView : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button backbtn;
    [SerializeField] private RectTransform settingPanel;
    [SerializeField] private Slider slider;
    [SerializeField] private Slider sliderSound;
    [SerializeField] private TextMeshProUGUI textSens;
    [SerializeField] private TextMeshProUGUI textSound;
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    private void Awake()
    {
        settingPanel.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingBtn.onClick.AddListener(OnSettingButtonClicked);
        backbtn.onClick.AddListener(OnBAckButton);

    }

    private void OnSlidervalueChangedSound(float arg0)
    {
        int value = (int)arg0;
        textSound.text = value.ToString();
    }

    private void OnSliderValueChanged(float arg0)
    {
        int value = (int)arg0;
        textSens.text = value.ToString();
        playerScriptableObject.sensitivity = value;
    }

    private void OnBAckButton()
    {
        settingPanel.gameObject.SetActive(false);
    }

    private void OnSettingButtonClicked()
    {
        settingPanel.gameObject.SetActive(true);
        sliderSound.onValueChanged.AddListener(OnSlidervalueChangedSound);
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        textSens.text = slider.value.ToString();
        textSound.text = sliderSound.value.ToString();
    }

    private void SaveMouseSetting()
    {

        textSens.text = slider.value.ToString();
        playerScriptableObject.sensitivity = slider.value;
    }
    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
