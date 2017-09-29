using System.Collections.Generic;

namespace N_Space {
    class Dimension {
        private readonly int _index;
        private Dimension _parent;      //These are the dimensional parents so in (1,2) the dimension that has the index=1 would be the parent of the dimention that has the index=2
        private List<Dimension> _child;
        private readonly Location _location;

        public Dimension(int n, Location location) {
            _index = n;
            _parent = null;
            _child = null;
            _location = location;
        }

        public void SetParent(Dimension parent) {
            _parent = parent;
        }

        public void AddChild(Dimension child) {
            if (_child == null) {
                _child = new List<Dimension>();
            }

            _child.Add(child);
            _child.Sort((x, y) => x._index.CompareTo(y._index));
        }

        public int GetIndex() {
            return _index;
        }

        public Dimension GetParent() {
            return _parent;
        }

        public List<Dimension> GetChildList() {
            return _child;
        }

        public Location GetLocation() {
            return _location;
        }
    }
}