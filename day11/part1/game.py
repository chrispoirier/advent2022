from monkey import Monkey
import re
import math

class Game:
    monkeys = []

    def run(self, rounds):
        for _ in range(rounds):
            for monkey in self.monkeys:
                while len(monkey.itemWorries) > 0:
                    (throwTo, itemWorry) = monkey.inspectItem()
                    self.monkeys[throwTo].itemWorries.append(itemWorry)

    def monkeyBusiness(self):
        first = 0
        second = 0
        for monkey in self.monkeys:
            if monkey.numInspected > first:
                second = first
                first = monkey.numInspected
                continue
            if monkey.numInspected > second:
                second = monkey.numInspected
        return first * second
        
    def __str__(self):
        gameStr = ""
        for i, monkey in enumerate(self.monkeys):
            gameStr += "Monkey " + str(i) + ":\n" + str(monkey) + "\n"
        return gameStr

    @staticmethod
    def fromData(data):
        game = Game()
        for i, dline in enumerate(data):
            if re.search("Monkey \\d", dline) != None:
                game.monkeys.append(Monkey(Game.getMonkeyBlock(i, data)))
        return game

    @staticmethod
    def getMonkeyBlock(index, data):
        monkeyLines = []
        for i in range(index+1, index+6):
            monkeyLines.append(data[i].strip())
        return list(monkeyLines)