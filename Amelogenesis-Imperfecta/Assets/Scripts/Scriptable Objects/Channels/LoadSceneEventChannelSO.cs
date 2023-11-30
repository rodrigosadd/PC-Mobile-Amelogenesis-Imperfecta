using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Event Channels/Load Scene", fileName = "Load Scene Event Channel")]
public class LoadSceneEventChannelSO : ScriptableObject
{
    public UnityAction<GameSceneSO> OnLoadSceneRequested;

    public void RaiseLoadSceneEvent(GameSceneSO gameScene)
    {
        if (OnLoadSceneRequested != null)
        {
            OnLoadSceneRequested.Invoke(gameScene);
        }
        else
        {
            Debug.Log("Load Scene Event is null!!!");
        }
    }
}