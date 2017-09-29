using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Space{
    public class Region_Test{
        public void CreateRegionTestObject() {
            Region regionCheck = new Region(0);

            if (regionCheck == null) {
                throw new System.ArgumentException("Region created cannot be null");
            }
        }
    }
}
