using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/// <summary>
/// 对象的管理器，对不同的IEntity需要不同的IEntityManager来管理
/// </summary>
internal interface IEntityManager
{
    /// <summary>
    /// 初始化管理器
    /// </summary>
    void Init();
    IEntity Creat();
    void DestoryEntity(IEntity obj);
}
