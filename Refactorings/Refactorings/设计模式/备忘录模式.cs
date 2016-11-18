using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings.设计模式
{
    public class 备忘录模式
    {
        //备忘录模式又叫快照模式（Snapshot Pattern）或ToKen 模式，
        //属于行为模式
        #region  涉及角色
         //Originator(发起人);负责创建一个备忘录（Memento）用以记录当前时刻自身的内部状态,
        //并可使用备忘录恢复内部状态.Orginator 可以根据需要决定Memento存储自己的哪些内部状态。
        
        //Memento(备忘录)：负责存储Originator对象的内部状态，并可以防止Originator以外的其他对象访问备忘录。
        //备忘录有两个接口：Caretake只能看到备忘录的窄接口，他之鞥你将备忘录传递给其他对象。
        //Originator却可看到备忘录额宽接口，允许它访问返回到先前状态所需要的所有数据。

        //Caretaker(管理者）：负责备忘录Memento,不能对Memento的内容进行访问或者操作。
        #endregion


    }
}
