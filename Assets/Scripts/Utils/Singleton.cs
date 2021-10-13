using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;
    private static object _lock = new object();


    void Awake()
    {
        if (instance == null)
        {
            instance = (T)FindObjectOfType(typeof(T));
        }
        else
        {
            Destroy(this.gameObject);
        }

        gameObject.name = gameObject.name + "(Singleton)";

        DontDestroyOnLoad(instance.gameObject);

        OnInitialize();
    }

    public static T GetInstance()
    {
        if(instance == null)
        {
            Init();
        }

        return instance;
    }

    private static void Init()
    {
        lock (_lock)
        {
            GameObject singleton = new GameObject();
            singleton.name = typeof(T).ToString();
            instance = singleton.AddComponent<T>();
        }
    }

    protected virtual void OnInitialize() { }

    protected virtual void OnDestroy() { }
}
