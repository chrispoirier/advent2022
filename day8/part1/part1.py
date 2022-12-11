from forest import Forest
from tree import Tree

input = open("input", "r")
data = input.readlines()
forest = Forest.fromData(data)
forest.setVisibility()
forest.printForest()
print("Visible trees: " + str(forest.countVisibility()))