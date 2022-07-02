using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    /**
    A class (and object) purely to just store all unique prefabs, so for a case where a prefab may need to refer to another prefab, it can just refer to this
    */

    [SerializeField]
    private List<GameObject> prefabList;

    /**
    Getter is based on index
    */
    public GameObject prefabListGetter(int index)
    {
        return prefabList[index];
    }

}
