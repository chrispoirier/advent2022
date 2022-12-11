from tree import Tree

class Forest:
    trees = []

    def setViews(self):
        for rowNum, treeRow in enumerate(self.trees):
            for colNum, tree in enumerate(treeRow):
                self.setTreeViews(tree, rowNum, colNum)

    def setTreeViews(self, tree, row, col):
        if row == 0 or col == 0 or row == len(self.trees)-1 or col == len(self.trees[0])-1:
            tree.setViews(0, 0, 0, 0)
        else:
            for tCol in range(col-1, 0, -1):
                iTree = self.trees[row][tCol]
                if iTree.height >= tree.height:
                    tree.leftView = col - tCol
                    break
            for tCol in range(col+1, len(self.trees[0])-1, 1):
                iTree = self.trees[row][tCol]
                if iTree.height >= tree.height and tCol > col:
                    tree.rightView = tCol - col
                    break
            if tree.leftView == 0: tree.leftView = col
            if tree.rightView == 0: tree.rightView = len(self.trees[0]) - col - 1

            for tRow in range(row-1, 0, -1):
                treeRow = self.trees[tRow]
                if treeRow[col].height >= tree.height:
                    tree.upView = row - tRow
                    break
            for tRow in range(row+1, len(self.trees)-1, 1):
                treeRow = self.trees[tRow]
                if treeRow[col].height >= tree.height and tRow > row:
                    tree.downView = tRow - row
                    break
            if tree.upView == 0: tree.upView = row
            if tree.downView == 0: tree.downView = len(self.trees) - row - 1

    def maxViewDistance(self):
        max = 0
        for treeRow in self.trees:
            for tree in treeRow:
                vd = tree.getViewDistance()
                if vd > max: max = vd
        return max

    def printForest(self):
        output = ""
        for treeRow in self.trees:
            for tree in treeRow:
                output += str(tree.height) + str(tree.getViewsStr()) + " "
            output += "\n"
        print(output)


    @staticmethod
    def fromData(data):
        forest = Forest()
        for dline in data:
            forest.trees.append([Tree(int(char)) for char in dline.strip()])
        return forest