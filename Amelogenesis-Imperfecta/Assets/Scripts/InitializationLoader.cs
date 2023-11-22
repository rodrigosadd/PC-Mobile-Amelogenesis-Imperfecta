using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializationLoader : MonoBehaviour
{
    [Header("Game Scenes")]
    [SerializeField] private GameSceneSO _managersScene;
    [SerializeField] private GameSceneSO _mainMenuScene;

    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_managersScene.sceneName, LoadSceneMode.Additive).completed += LoadMainMenu;
    }

    void LoadMainMenu(AsyncOperation obj)
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_mainMenuScene.sceneName, LoadSceneMode.Additive).completed += UnloadInitializationScene;
    }

    void UnloadInitializationScene(AsyncOperation obj)
    {
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(0);
    }
}