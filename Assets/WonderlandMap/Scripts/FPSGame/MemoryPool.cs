using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool : MonoBehaviour
{

    private class PoolItem
    {
        public bool isActive;//gameobject�� Ȱ��ȭ.��Ȱ��ȭ
        public GameObject gameObject; // ȭ�鿡 ���̴� ���� ���� ������Ʈ
    }

    private int increaseCount = 5;      //������Ʈ�� ������ �� Instantiate()�� �߰� �����Ǵ� ������Ʈ ����
    private int maxCount;       //���� ����Ʈ�� ��ϵǾ� �ִ� ������Ʈ ����
    private int activeCount;        //���� ���ӿ��� Ȱ��ȭ�� ������Ʈ ����

    private GameObject poolObject;  //������Ʈ �������� �����ϴ� ���� ������Ʈ ������
    private List<PoolItem> poolItemList;    //�����Ǵ� ��� ������Ʈ�� �����ϴ� ����Ʈ

    public int MaxCount => maxCount;    //�ܺο��� ���� ����Ʈ�� ��ϵǾ� �ִ� ������Ʈ ���� Ȯ���� ���� ������Ƽ
    public int ActiveCount => activeCount;      //�ܺο��� ���� Ȱ��ȭ �Ǿ� �ִ� ������Ʈ ���� Ȯ���� ���� ������Ƽ

    public MemoryPool(GameObject poolObject)
    {
        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;

        poolItemList = new List<PoolItem>();

        InstantiateObjects();
    }

    public void InstantiateObjects()
    {
        maxCount += increaseCount;

        for(int i = 0; i<increaseCount; ++i)
        {
            PoolItem poolItem = new PoolItem();
            poolItem.isActive = false;
            poolItem.gameObject = GameObject.Instantiate(poolObject);
            poolItem.gameObject.SetActive(false);

            poolItemList.Add(poolItem);

        }
    }

    public void DestroyObjects()//���� �ٲ�ų� ��������� �ѹ������Ͽ� ��� ���� ������Ʈ�� �ѹ��� �����Ѵ�.
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for(int i =0; i<count; ++i)
        {
            GameObject.Destroy(poolItemList[i].gameObject);
        }

        poolItemList.Clear();
    }

    public GameObject ActivePoolItem()//��Ȱ��ȭ ������Ʈ �� �ϳ��� Ȱ��ȭ�� ����� ��� ��Ȱ��������Ʈ ������ instantiateobjects() ȣ���� �߰�����
    {
        if (poolItemList == null) return null;

        if(maxCount == activeCount)
        {
            InstantiateObjects();
        }

        int count = poolItemList.Count;
        for(int i =0;   i < count;   ++ i)
        {
            PoolItem poolItem = poolItemList[i];

            if(poolItem.isActive == false)
            {
                activeCount++;

                poolItem.isActive = true;
                poolItem.gameObject.SetActive(true);

                return poolItem.gameObject;
            }
        }

        return null;
    }

    public void DeactivePoolItem(GameObject removeObject)//���� Ȱ��ȭ ������ ������Ʈ removeobject�� ��Ȱ��ȭ   
    {
        if (poolItemList == null || removeObject == null) return;

        int count = poolItemList.Count;
        for(int i =0; i<count;++i)
        {
            PoolItem poolItem = poolItemList[i];

            if(poolItem.gameObject==removeObject)
            {
                activeCount--;

                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }

    public void DeactiveAllPoolItems()//Ȱ��ȭ���� ��� ������Ʈ�� �������ʰ���.
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for(int i=0;i<count;++i)
        {
            PoolItem poolItem = poolItemList[i];

            if( poolItem.gameObject != null && poolItem.isActive == true)
            {
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

            }
        }
        activeCount = 0;
    }



    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
