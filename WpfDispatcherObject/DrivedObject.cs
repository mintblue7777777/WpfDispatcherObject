using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfDispatcherObject {
    class DrivedObject :  DispatcherObject{
        public void DoSomething() {
            this.VerifyAccess();
            Debug.WriteLine("DoSomething");
        }
    }
}
