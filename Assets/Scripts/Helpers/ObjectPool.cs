using UnityEngine;

/* Based on the below, with modifications: 
// @Credit: https://gitlab.com/GameDevTV/CompleteUnity3D/realmrush/-/blob/master/Assets/Enemy/ObjectPool.cs
// @Credit: https://learn.unity.com/tutorial/introduction-to-object-pooling 
*/

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool objectPool;
    GameObject[] _objectPool;
    readonly int _poolSize = 10;
    [SerializeField] GameObject objectPrefab;


    void Awake()
    {
        objectPool = this;
        CreatePoolOfObjects();
    }

    public GameObject GetPooledObjects()
    {
        for (int i = 0; i < _objectPool.Length; i++)
        {
            if (_objectPool[i].activeInHierarchy == false)
            {
                _objectPool[i].SetActive(true);
                return _objectPool[i];
            }
        }

        return null;

    }


    void CreatePoolOfObjects()
    {
        _objectPool = new GameObject[_poolSize];
        for (int i = 0; i < _objectPool.Length; i++)
        {
            _objectPool[i] = Instantiate(objectPrefab, transform);
            _objectPool[i].SetActive(false);

        }
    }
}

   
