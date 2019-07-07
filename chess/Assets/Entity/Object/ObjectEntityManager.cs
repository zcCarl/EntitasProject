using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ObjectEntityManager : AObjectManager<AObjectEntity>, IEntityManager
{
    /// <summary>
    /// 被作为模板的对象
    /// </summary>
    protected Type type;

    public ObjectEntityManager(Type type)
    {
        this.type = type;
    }

    public void Init()
    {
        DestryAllObject();
    }

    protected override AObjectEntity CreatNew()
    {
        AObjectEntity entityObject = (AObjectEntity)Activator.CreateInstance(type, true);
        entityObject.SetManager(this);
        return entityObject;
    }

    protected override void OnCreatObject(AObjectEntity obj)
    {
        obj.Init();
    }

    protected override void OnDestoryObject(AObjectEntity obj)
    {
        obj.OnDestroyed();
    }

    IEntity IEntityManager.Creat()
    {
        IEntity result = null;
        result = CreatObject();
        return result;
    }

    public void DestoryEntity(IEntity obj)
    {
        if (obj is AObjectEntity)
        {
            DestoryObject((AObjectEntity)obj);
        }
    }
}
