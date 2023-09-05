using UnityEngine;
/// <summary>
/// This class is responsible for creating mono singleton classes
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingelton<T> : MonoBehaviour where T : class 
{
    public static T Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
        }
        else 
        {
            Debug.LogError($"MonoSingelton: There is already singelton of type {typeof(T)} - Error");
        }
    }
}
