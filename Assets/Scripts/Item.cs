using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class Item
{
    public enum Type
    {
        Sponge,
        Sorp,
        SpongeWithSorp,
        Magnet,
        Thread,
        MagnetAndThread,
        BottleAndMagnet,
        Remocon,
        Battery,
        Driver,
        Note,
        Pencil,
        Triangle,
        Square,
        Cylinder,
        Key,
    }
    public enum Status
    {
        NotObtain,
        Obtain,
        Used,
    }
    public Type type;
    public Sprite sprite;
    public GameObject zoomObj;
    public Status status;
    public Item(Type _type, Sprite _sprite, GameObject _zoomObj, Status _status)
    {
        this.type = _type;
        this.sprite = _sprite;
        this.zoomObj = _zoomObj;
        this.status = _status;
    }
}
