using System;

[Serializable]
public class Combination
{
    public Item.Type targetType;
    public Item.Type partnerType;
    public Item.Type synthesisedType;
    public Combination(Item.Type targetType, Item.Type partnerType, Item.Type synthesisedType)
    {
        this.targetType = targetType;
        this.partnerType = partnerType;
        this.synthesisedType = synthesisedType;
    }
}