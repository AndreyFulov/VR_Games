using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void LevelLoadOne(){
        SceneManager.LoadScene("Level1Scene");
    }

    public void LevelLoadTwo(){
        SceneManager.LoadScene("Level2Scene");
    }

    public void MenuLoadScene(){
        SceneManager.LoadScene("MenuScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
