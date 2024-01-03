using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton <T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance { get { return instance ; } }

    protected virtual void Awake() // protected demek ;bu y�ntemin sadece s�n�fa ve do�rudan miras alan di�er s�n�flara g�r�n�r olaca�� anlam�na gelir.
    {
        if(instance != null && this.gameObject != null)
        {
            Destroy(this.gameObject);  
        }
        else
        {
            instance = (T)this;
        }

        if (!gameObject.transform.parent)
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
}
