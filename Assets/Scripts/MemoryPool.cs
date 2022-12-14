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
    //[SerializeField] ObjectInfo[] objectInfo = null;

    //public Queue<GameObject> effectQueue = new Queue<GameObject>();

    public static MemoryPool instance;

    Stack<ParticleSystem> effectPool = new Stack<ParticleSystem>();

    private void Start()
    {
        instance = this;
        //effectQueue = InsertQueue(objectInfo[0]);
    }

    public void InitEffectPool(int size)  //Stack
    {
        for (int i = 0; i < size; i++)
        {
            var effect = ObjectManager.GetInstance().CreateHitEffect();
            effect.gameObject.SetActive(false);
            effectPool.Push(effect);
        }
    }

    public void ReleasePool()  //Stack
    {
        effectPool.Clear();
    }

    public void UseEffect()  //Stack
    {
        ParticleSystem effect = null;

        if(effectPool.Count > 0)
        {
            effect = effectPool.Pop();
            effect.gameObject.SetActive(true);
        }
        else
        {
            effect = ObjectManager.GetInstance().CreateHitEffect();
        }

        effect.Play();

        float randX = Random.Range(-1.2f, 1.2f);
        float randY = Random.Range(-1.2f, 1.2f);

        effect.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        effect.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);
    }

    public void ReturnEffect(ParticleSystem particle)  //Stack
    {
        particle.gameObject.SetActive(false);
        effectPool.Push(particle);
    }

    /*Queue<GameObject> InsertQueue(ObjectInfo p_objectInfo)
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

   public void RemoveEffect(ObjectInfo p_objectInfo, GameObject effect)
    {
        effect.SetActive(false);
        effect.transform.SetParent(p_objectInfo.tfPoolParent);
    }*/
}
