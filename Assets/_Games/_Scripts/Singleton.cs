using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public bool IsValid()
    {
        return instance != null;
    }
}