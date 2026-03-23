using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    void Start()
    {
        
    }

    public void Restart(){
        SceneManager.LoadScene("Game");
    }

    public void Exit(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // В собранной игре
        Application.Quit();
        #endif
    }
}
