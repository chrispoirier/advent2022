from forest import Forest
from tree import Tree

input = open("input", "r")
data = input.readlines()
forest = Forest.fromData(data)
forest.setViews()
forest.printForest()
print("Largest view distance: " + str(forest.maxViewDistance()))