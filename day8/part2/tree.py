class Tree:
    height = 0
    leftView = 0
    rightView = 0
    upView = 0
    downView = 0

    def __init__(self, height = 0):
        self.height = int(height)

    def setViews(self, left, right, up, down):
        self.leftView = left
        self.rightView = right
        self.upView = up
        self.downView = down

    def getViewDistance(self):
        return self.leftView * self.rightView * self.upView * self.downView

    def getViewsStr(self):
        return "(" + str(self.leftView) + "," + str(self.rightView) + "," + str(self.upView) + "," + str(self.downView) + ")"