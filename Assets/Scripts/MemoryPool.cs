using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectInfo
{
    public GameObject effectPre;
    public int count;
    public Transform tfPoolParent;
}
public class MemoryPool : MonoBehaviour
{
    [SerializeField] ObjectInfo[] objectInfo = null;

    public Queue<GameObject> effectQueue = new Queue<GameObject>();

    public static MemoryPool instance;

    private void Start()
    {
        instance = this;
        effectQueue = InsertQueue(objectInfo[0]);
    }

    Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
    {
        Queue<GameObject> t_queue = new Queue<GameObject>();
        for (int i = 0; i < p_objectInfo.count; i++)
        {
            GameObject t_clone = Instantiate(p_objectInfo.effectPre, transform.position, Quaternion.identity);
            t_clone.SetActive(false);

            if (p_objectInfo.tfPoolParent != null)
                t_clone.transform.SetParent(p_objectInfo.tfPoolParent);

            else
                t_clone.transform.SetParent(this.transform);

            t_queue.Enqueue(t_clone);
        }

        return t_queue;
    }

/*   public void RemoveEffect(ObjectInfo p_objectInfo, GameObject effect)
    {
        effect.SetActive(false);
        effect.transform.SetParent(p_objectInfo.tfPoolParent);
    }*/
}
