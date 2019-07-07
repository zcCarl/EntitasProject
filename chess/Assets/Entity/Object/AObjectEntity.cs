using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal abstract class AObjectEntity : IEntity
{
    ObjectEntityManager manager;
    public void DestroyEntity()
    {
        //命令管理器销毁对象，实际上是让其回收对象
        manager.DestoryEntity(this);
    }

    public IEntityManager GetManager()
    {
        return manager;
    }

    public abstract void Init();

    public abstract void OnDestroyed();

    public void SetManager(IEntityManager manager)
    {
        if (manager is ObjectEntityManager)
        {
            this.manager = (ObjectEntityManager)manager;
        }
    }
}
