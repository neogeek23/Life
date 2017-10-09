using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Space {
    public class Region {
        private readonly State _default;
        private readonly int _size;
        private readonly int _dimensionCount;
        private readonly Dimension _deviantTree;

        public Region(int dimensionSize, int maxSize) {
            _default = State.Default;
            _dimensionCount = dimensionSize;
            _size = maxSize;
            _deviantTree = new Dimension(0, null);
        }

        public int GetSize() {
            return _size;
        }

        public int GetDimensionCount() {
            return _dimensionCount;
        }

        public State GetDefaultState() {
            return _default;
        }

        public Dimension GetDeviantTree() {
            return _deviantTree;
        }

        public void AddInitialCoordinate(int[] coordinate, State state) {
            Dimension currentDimension = _deviantTree;
            for (int i = 0; i < coordinate.Length; i++) {
                List<Dimension> currentChildren = currentDimension.GetChildList();

                if (currentChildren == null) {
                    currentDimension = AddNewChild(i, coordinate, currentDimension, state);
                }
                else {
                    bool wasIndexFound = false;
                    foreach (Dimension dim in currentChildren) {
                        wasIndexFound |= dim.GetIndex() == coordinate[i];
                        if (dim.GetIndex() == coordinate[i]) {
                            currentDimension = dim;
                            break;
                        }
                    }
                    if (!wasIndexFound) {
                        currentDimension = AddNewChild(i, coordinate, currentDimension, state);
                    }
                }
            }
        }

        private Dimension AddNewChild(int n, int[] coordinate, Dimension currentDimension, State state) {
            Location newLocation;
            if (n == coordinate.Length - 1) {
                newLocation = new Location(state, null, coordinate, _size);
            } else {
                newLocation = null;
            }
            Dimension newChild = new Dimension(coordinate[n], newLocation);
            newChild.SetParent(currentDimension);
            currentDimension.AddChild(newChild);
            return currentDimension.GetChildList()[Convert.ToInt32(currentDimension.GetChildIndexOf(coordinate[n]))];
        }

        public void RemoveCoordinate(int[] coordinate) {
            Dimension currentDimension = _deviantTree;
            for (int i = 0; i < coordinate.Length; i++) {
                int? currentIndex = currentDimension.GetChildIndexOf(coordinate[i]);
            }
        }

        public void PrintSpace() {
            PrintFromDimension(_dimensionCount, _deviantTree);
        }

        private string DimensionalAnchor(int n, int index) {
            int dimensionStringSpace = System.Convert.ToInt32(Math.Log10(System.Convert.ToDouble(n)));
            int indexStringSpace = System.Convert.ToInt32(Math.Log10(System.Convert.ToDouble(index)));
            int remainingOpenSpace = (_size - dimensionStringSpace - indexStringSpace) / 2;
            int oddDivision = (_size - dimensionStringSpace - indexStringSpace) % 2;
            const string filler = "-";
            string result = n.ToString();

            for (int i = 0; i < remainingOpenSpace; i++) {
                result += filler;
            }

            result += index.ToString();

            for (int i = 0; i < remainingOpenSpace + oddDivision; i++) {
                result += filler;
            }

            return result;
        }

        private void Print2DSpace(Dimension deviants) {
            string result = "";
            for (int i = 0; i < _size; i++) {
                int? ParentIndex = deviants.GetChildIndexOf(i);
                if (ParentIndex != null) {
                    for (int j = 0; j < _size; j++) {
                        int? ChildIndex = deviants.GetChild(ParentIndex).GetChildIndexOf(j);
                        if (ChildIndex != null) {
                            result += Convert.ToInt32(deviants.GetChild(ParentIndex).GetChild(ChildIndex).GetLocation()
                                .GetPresentState()) + " ";
                        }
                        else {
                            result += Convert.ToInt32(_default) + " ";
                        }
                    }
                }
                else {
                    for (int j = 0; j < _size; j++) {
                        result += Convert.ToInt32(_default) + " ";
                    }
                }
                if (i < _size - 1) {
                    result += "\n";
                }
            }
            Console.WriteLine(result);
        }

        private void PrintFromDimension(int n, Dimension deviants) {
            if (n > 2) {
                PrintFromDimension(n - 1, deviants);
            }
            else {
                Print2DSpace(deviants);
            }
        }
    }
}
