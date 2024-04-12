using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ItemManager :MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<ItemManager>();
            }
            return instance;
        }
    }
    ItemListEntity itemListEntity;
    private void Start()
    {
        LoadItemListEntity();
    }
    void LoadItemListEntity()
    {
        itemListEntity = DictionaryToList(DataManager.Instance.Flag.itemStatusDictionary);
    }
    void SaveItemStatusDictionary()
    {
        DataManager.Instance.Flag.itemStatusDictionary = ListToDictionary(itemListEntity);
    }
    public void SetItemListEntitiy(ItemListEntity _itemListEntity)
    {
        itemListEntity = _itemListEntity;
    }
    public Item Spawn(Item.Type _type)
    {
        foreach (var item in itemListEntity.itemList)
        {
            if (item.type == _type)
            {
                return new Item(item.type, item.sprite, item.zoomObj, item.status);
            }
        }
        return null;
    }
    public void ItemObtained(Item.Type type)
    {
        ChangeStatus(type, Item.Status.Obtain);
    }
    public void ItemUsed(Item.Type type)
    {
        ChangeStatus(type, Item.Status.Used);
    }
    void ChangeStatus(Item.Type type, Item.Status status)
    {
        foreach (var item in itemListEntity.itemList)
        {
            if (item.type == type)
            {
                item.status = status;
            }
        }
        SaveItemStatusDictionary();
    }
    public Item.Status GetItemStatus(Item.Type type)
    {
        foreach (var item in itemListEntity.itemList)
        {
            if (item.type == type)
            {
                return item.status;
            }
        }
        print("type is null");
        return Item.Status.Obtain;
    }
    public Item.Type[] GetObtainedItems()
    {
        var obtainedItems = new List<Item.Type>();
        foreach (var item in itemListEntity.itemList)
        {
            if (item.status == Item.Status.Obtain)
            {
                obtainedItems.Add(item.type);
            }
        }
        return obtainedItems.ToArray();
    }
    public void ResetItemListEntity()
    {
        itemListEntity = Resources.Load<ItemListEntity>("ItemListEntity");
        foreach (var item in itemListEntity.itemList)
        {
            item.status = Item.Status.NotObtain;
        }
        DataManager.Instance.Flag.itemStatusDictionary = ListToDictionary(itemListEntity);
    }
    public bool IsUsed(Item.Type type)
    {
        foreach (var item in itemListEntity.itemList)
        {
            if (item.type == type)
            {
                if (item.status == Item.Status.Used)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        print("item is null");
        return true;
    }
    ItemListEntity DictionaryToList(Dictionary<Item.Type, Item.Status> dic)
    {
        var itemListEntity = Resources.Load<ItemListEntity>("ItemListEntity");
        foreach (var item in dic)
        {
            foreach (var itemList in itemListEntity.itemList)
            {
                if (itemList.type == item.Key)
                {
                    itemList.status = item.Value;
                }
            }
        }
        return itemListEntity;
    }
    public Dictionary<Item.Type, Item.Status> ListToDictionary(ItemListEntity list)
    {
        var itemStatusDictionary = new Dictionary<Item.Type, Item.Status>();
        foreach (var item in itemListEntity.itemList)
        {
            itemStatusDictionary.Add(item.type, item.status);
        }
        return itemStatusDictionary;
    }
    public GameObject GetZoomItem(Item.Type type)
    {
        foreach (var item in itemListEntity.itemList)
        {
            if (item.type == type)
            {
                return item.zoomObj;
            }
        }
        return null;
    }
    void FitObject(GameObject targetObj, GameObject fitObj)
    {
        //リサイズするオブジェクトのサイズを取得
        var targetCol = targetObj.GetComponent<BoxCollider>();
        Vector3 objectSize = targetCol.bounds.size;
        //FitObjをカメラのY軸を回転軸として正面を向かせる。
        var mainCamera = Camera.main;
        var cameraYAxis = mainCamera.transform.up;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.right, cameraYAxis);
        fitObj.transform.rotation = targetRotation;
        //立方体のサイズを取得
        var fitCol = fitObj.GetComponent<BoxCollider>();
        fitCol.enabled = true;
        Vector3 boxSize = fitCol.bounds.size;
        fitCol.enabled = false;
        //取得したサイズをもとに倍率を計算
        int scaleFactor = 100;
        float minScale = Mathf.Min(
            boxSize.x / objectSize.x,
            boxSize.y / objectSize.y,
            boxSize.z / objectSize.z) * scaleFactor;
        Vector3 newScale = new Vector3(minScale, minScale, minScale);
        targetObj.transform.localScale = newScale;
    }
    public GameObject GenerateZoomItem(Item.Type type)
    {
        GameObject zoomObjPrefab = GetZoomItem(type);
        var zoomCanvasTransform = GameObject.Find("ZoomCanvas").transform;
        GameObject zoomItem = Instantiate(zoomObjPrefab, zoomCanvasTransform);
        zoomItem.AddComponent<BoxCollider>();
        var fitObj = zoomCanvasTransform.Find("FitBox").gameObject;
        FitObject(zoomItem, fitObj);
        return zoomItem;
    }
}
