using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
    public void LocalLevel()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    public void AILevel()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
        
    public void ExitGame()
    {
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
