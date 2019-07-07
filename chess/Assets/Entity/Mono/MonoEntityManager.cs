using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

internal class MonoEntityManager : AObjectManager<AMonoEntity>, IEntityManager
{
    AMonoEntity template;

    public MonoEntityManager(AMonoEntity template)
    {
        this.template = template;
    }

    public IEntity Creat()
    {
        IEntity result = null;
        result = CreatObject();
        return result;
    }


    public void DestoryEntity(IEntity obj)
    {
        if (obj is AMonoEntity)
        {
            DestoryObject((AMonoEntity)obj);
        }
    }

    public void Init()
    {
        DestryAllObject();
    }

    protected override AMonoEntity CreatNew()
    {
        AMonoEntity entityObject = AMonoEntity.Instantiate<AMonoEntity>(template);
        entityObject.SetManager(this);
        return entityObject;
    }

    protected override void OnCreatObject(AMonoEntity obj)
    {
        obj.Init();
        obj.gameObject.SetActive(true);
    }

    internal AMonoEntity Creat(Transform parent)
    {
        AMonoEntity result = (AMonoEntity)Creat();
        result.transform.SetParent(parent);
        return result;


    }

    protected override void OnDestoryObject(AMonoEntity obj)
    {
        obj.OnDestroyed();
        obj.gameObject.SetActive(false);
    }
}
