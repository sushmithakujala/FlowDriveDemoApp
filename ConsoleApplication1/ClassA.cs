using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ClassA
    {

        SuperClass[] listOfSuperClass = new SuperClass[4];
        public SuperClass SuperCls { get {
                return listOfSuperClass.FirstOrDefault();
            } }
    }
}
