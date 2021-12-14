#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Game.Mechanics
{
    public static class ExitHelper
    {
        public static void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}
