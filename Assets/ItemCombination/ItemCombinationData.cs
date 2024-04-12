using UnityEngine;


public class ItemCombinationData :MonoBehaviour
{
    public static ItemCombinationData instance;
    [SerializeField] CombinationListEntity combinationListEntity;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public Item.Type GetPartnerType(Item.Type targetType)
    {
        foreach (var combi in combinationListEntity.combinationList)
        {
            if (targetType == combi.targetType)
            {
                return combi.partnerType;
            }
            if (targetType == combi.partnerType)
            {
                return combi.targetType;
            }
        }
        Debug.Log("bug");
        return Item.Type.Triangle;
    }
    public Item.Type GetSynthesisedType(Item.Type targetType)
    {
        foreach (var combi in combinationListEntity.combinationList)
        {
            if (targetType == combi.targetType)
            {
                return combi.synthesisedType;
            }
            if (targetType == combi.partnerType)
            {
                return combi.synthesisedType;
            }
        }
        Debug.Log("bug");
        return Item.Type.Triangle;
    }
}