using UnityEngine;

public class SingletonInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = (T)FindObjectOfType(typeof(T));

            gameObject.name = gameObject.name;
            OnInitialize();
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

	public static T GetInstance()
    {
        return instance;
    }

    protected virtual void OnInitialize() { }

    protected virtual void OnDestroy() { }
}