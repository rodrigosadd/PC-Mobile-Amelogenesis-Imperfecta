using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Cursor Lock Mode", fileName = "Cursor Lock Mode")]
    public class CursorLockModeSO : ScriptableObject
    {
        public CursorLockMode cursorLockMode;
    }
}