using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelComponent : MonoBehaviour
{
    public void Reload()
    {
        var session = FindObjectOfType<GameSession>();
        Destroy(session);

        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
