# Life
Conway's Game of Life

This is an attempt to make a multidimentional multistate game of life.  The game's space is held in a region which has a tree of dimensions (each level of the tree is a dimensional freedom, i.e. level 1 may be x and level 2 y and level 3 z and so forth) of the Locations that are deviant from the space's default state (dead).  Each location is only present as a leaf in the tree and the tree is always full and jagged.  Each location knows its neighbors and has a state for its present state and its calculate future state.  Only locations that are not in the default state or will not be in the default state are stored in the tree, all other locations are assumed to be in the default state.
