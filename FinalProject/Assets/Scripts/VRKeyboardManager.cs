using UnityEngine;
using UnityEngine.UI;

public class VRKeyboardManager : MonoBehaviour
{
    public GameObject keyboard;
    public AudioManager audioManager;
    private GameManager gameManager;
    public Text inputDisplay;
    private string currentText = "";
    public int maxLength = 20;
    
    void Start()
    {
        inputDisplay.text = "_";
        HideKeyboard();
    }
   
    public void AddCharacter(string character)
    {
        if (currentText.Length < maxLength)
        {
            currentText += character;
            UpdateDisplay();
            audioManager.PlayClickSound();
        }
    }
    
    public void Backspace()
    {
        if (currentText.Length > 0)
        {
            currentText = currentText.Substring(0, currentText.Length - 1);
            UpdateDisplay();
        }
    }
    
    public void Submit()
    {
        if (string.IsNullOrWhiteSpace(currentText)) return;

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.SubmitRecord(currentText.Trim());
        }
        
        ClearInput();
        HideKeyboard();
    }

    private void UpdateDisplay()
    {
        inputDisplay.text = currentText + "_";
    }

    private void ClearInput()
    {
        currentText = "";
        UpdateDisplay();
    }
    
    public void ShowKeyboard()
    {
        keyboard.SetActive(true);
    }
    
    public void HideKeyboard()
    {
        keyboard.SetActive(false);
    }
}