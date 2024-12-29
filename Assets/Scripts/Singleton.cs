using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 인스턴스를 저장할 private static 변수
    private static T m_instance;
    private static readonly object m_Lock = new();

    // 객체 접근을 위한 public static 프로퍼티
    public static T Instance 
    {
        get 
        {
            lock (m_Lock)
            {
                if (m_instance == null)
                {
                    m_instance = (T)FindAnyObjectByType(typeof(T));

                    if (m_instance == null)
                    {
                        GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                        m_instance = obj.GetComponent<T>();
                    }
                }
                return m_instance; 
            } 
        }
    }

    private void Awake()
    {
        // 현 오브젝트가 부모를 가지고 있으면 부모를 DontDestroyOnLoad 처리리
        if (transform.parent != null && transform.root != null)
        {
            DontDestroyOnLoad(this.transform.root.gameObject); 
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
