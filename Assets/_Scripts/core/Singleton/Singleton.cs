using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace core.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance;
        public static bool HasInstance => Instance != null;

        private void Awake()
        {
            if (Instance == null)
                Instance = GetComponent<T>();

            else
                Destroy(gameObject);
        }
    }
}
