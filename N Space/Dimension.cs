using System;
using System.Collections.Generic;

namespace N_Space {
    public class Dimension {
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

        public Dimension GetChild(int? n) {
            if (n == null) {
                return null;
            }
            return _child[System.Convert.ToInt32(n)];
        }

        public Location GetLocation() {
            return _location;
        }

        public int? GetChildIndexOf(int n) {
            if (_child.Count > 0) {
                return FindChildIndexOf(n, _child, 0);
            }
            return null;
        }

        private int? FindChildIndexOf(int n, List<Dimension> list, int indexHoldOver) {
            int breakpoint = list.Count / 2;
            List<Dimension> part = new List<Dimension>();
            if (n > list[breakpoint].GetIndex() && list.Count > 1) {
                for (int i = breakpoint; i < list.Count; i++) {
                    part.Add(list[i]);
                }
                return FindChildIndexOf(n, part, breakpoint + indexHoldOver);
            } else if (n < list[breakpoint].GetIndex() && list.Count > 1) {
                for (int i = 0; i < breakpoint; i++) {
                    part.Add(list[i]);
                }
                return FindChildIndexOf(n, part, indexHoldOver);
            } else if (n == list[breakpoint].GetIndex()) {
                return breakpoint + indexHoldOver;
            }
            else {
                return null;
            }
        }
    }
}
