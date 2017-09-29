using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Space {
    class Region {
        private readonly State _default;
        private readonly int _size;
        private Dimension _progenerator;

        public Region(int dimensionSize) {
            _default = State.Dark;
            _size = dimensionSize;
        }

        public void ChangeCoordinateState(int[] coordinates, State state) {
            
        }

        //private void AddDimension()
    }
}
