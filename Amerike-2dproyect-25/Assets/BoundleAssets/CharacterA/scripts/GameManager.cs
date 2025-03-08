using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager instance = null;
    private GameApp gameApp;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            gameApp = new GameApp();
            gameApp.StartApp();
        }
        else {
            Destroy(gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        gameApp.Dispose();
    }
}
