using UnityEngine;

///<summary>
/// Base class for a singleton script. By extending this you are invoking the simple rule
/// that there can ONLY BE ONE of this class. Use with care. The singleton pattern can quickly 
/// couple your code and make certain aspects of the program harder to debug. You might also end up with
/// nasty race conditions making life a nightmare. This class is perfect for managers and gameobjects we only 
/// ever need 1 instance of, but be warned. Any change in this class could impose problems in multiple classes
/// that have a reference to it. You have been warned.
///</summary>
public class Singleton<T> : MonoBehaviour where T:Singleton<T>
{
    // There should only be one instance of this class. This is a static variable that
    // is global to the whole program. The variable itself is private since we do not want other
    // parts of the program to accidentaly modify it.
    private static T instance;

    ///<summary>
    /// The Getter method is where other programs can get access to the singleton and vice versa.
    /// This is important so we have type safety. There is no set method here because we don't want 
    /// other programs to touch the global value.
    ///<summary>
    public static T Instance
    {
        get{return instance;}
    }

    // Check if this gameobject with class is instantiated.
    public bool IsInstantiated
    {
        get{return instance != null;}
    }

    ///<summary>
    /// In the awake method of the singleton, we make sure there is no other singletons already in the
    /// game by checking the instance variable. The method logs the error if this is the case. If not,
    /// we set the instance to this class.
    ///</summary>
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Debug.LogError("[SINGLETON] An second instance of a singleton class was attempted to be instantiated. Please check your code");
            Destroy(this);
        }
        else
        {
            instance = (T)this;
        }
    }

    ///<summary>
    /// When destroyed, the instance is set to null so that a new instance can be created if needed.
    ///</summary>
    protected virtual void OnDestroy()
    {
        if(instance == this)
        {
            instance = null;
        }
    }
}
