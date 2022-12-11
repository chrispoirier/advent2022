from tree import Tree

class Forest:
    trees = []

    def setVisibility(self):
        for rowNum, treeRow in enumerate(self.trees):
            for colNum, tree in enumerate(treeRow):
                tree.visible = self.isTreeVisible(tree.height, rowNum, colNum)

    def isTreeVisible(self, height, row, col):
        if row == 0 or col == 0 or row == len(self.trees)-1 or col == len(self.trees[0])-1:
            return True
        else:
            leftVis = True
            rightVis = True
            for tCol, tree in enumerate(self.trees[row]):
                if tree.height >= height and tCol < col:
                    leftVis = False
                if tree.height >= height and tCol > col:
                    rightVis = False

            upVis = True
            downVis = True
            for tRow, treeRow in enumerate(self.trees):
                if treeRow[col].height >= height and tRow < row:
                    upVis = False
                if treeRow[col].height >= height and tRow > row:
                    downVis = False

            return leftVis or rightVis or upVis or downVis

    def countVisibility(self):
        count = 0
        for treeRow in self.trees:
            for tree in treeRow:
                if tree.visible:
                    count += 1
        return count

    def printForest(self):
        output = ""
        for treeRow in self.trees:
            for tree in treeRow:
                vis = "N"
                if tree.visible: vis = "V"
                output += str(tree.height) + vis + " "
            output += "\n"
        print(output)


    @staticmethod
    def fromData(data):
        forest = Forest()
        for dline in data:
            forest.trees.append([Tree(int(char)) for char in dline.strip()])
        return forest