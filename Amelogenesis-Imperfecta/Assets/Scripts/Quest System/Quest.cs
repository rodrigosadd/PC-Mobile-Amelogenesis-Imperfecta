using UnityEngine;

namespace Quest_System
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Quest", fileName = "New Quest")]
    public class Quest : ScriptableObject
    {
        public string questName;
        public string questDescription;
        public bool isCompleted;
    }
}