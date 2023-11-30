using UnityEngine;
using UnityEngine.SceneManagement;
using Scriptable_Objects.Channels;

public class SceneManager : MonoBehaviour
{
    [Header("Game Scene")]
    [SerializeField] private GameSceneSO _sceneAfterInitialization;

    [Header("Channels")]
    [SerializeField] private LoadSceneEventChannelSO _loadSceneEventChannel;
    [SerializeField] private VoidEventChannelSO _startTransitionVoidChannel;
    [SerializeField] private VoidEventChannelSO _endTransitionVoidChannel;

    private bool _isLoading;
    private GameSceneSO _sceneToLoad;
    private GameSceneSO _currentlyLoadedScene;

    private void OnEnable()
    {
        _loadSceneEventChannel.OnLoadSceneRequested += LoadScene;      
        _endTransitionVoidChannel.OnVoidRequested += UnloadPreviousScene;
    }

    private void OnDisable()
    {
        _loadSceneEventChannel.OnLoadSceneRequested -= LoadScene;
        _endTransitionVoidChannel.OnVoidRequested -= UnloadPreviousScene;
    }

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        _currentlyLoadedScene = _sceneAfterInitialization;
    }

    void LoadScene(GameSceneSO scene)
    {
        if (_isLoading)
            return;

        _sceneToLoad = scene;
        _isLoading = true;

        _startTransitionVoidChannel.RaiseVoidEvent();        
    }

    void UnloadPreviousScene()
    {
        if (_currentlyLoadedScene.ToString() != null)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(_currentlyLoadedScene.sceneName);
        }

        LoadNewScene();
    }

    void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_sceneToLoad.sceneName, LoadSceneMode.Additive).completed += OnNewSceneLoaded;
    }
     
    void OnNewSceneLoaded(AsyncOperation obj)
    {
        _currentlyLoadedScene = _sceneToLoad;
        _isLoading = false;
    }
}