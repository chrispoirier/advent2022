from enum import Enum
import re

class OperationType(Enum):
    ADD = 1
    MULT = 2
    SQUARE = 3

class Operation:
    type = None
    operand = None

    def __init__(self, opStr):
        match = re.search("new = old (.) (.+)", opStr)
        if match != None:
            self.type = Operation.getOpType(match.groups()[0], match.groups()[1])
            if self.type != OperationType.SQUARE:
                self.operand = int(match.groups()[1])

    @staticmethod
    def getOpType(op, val):
        if op == "+":
            return OperationType.ADD
        if val == "old":
            return OperationType.SQUARE
        return OperationType.MULT

    @staticmethod
    def getOpStr(type, val):
        if type == OperationType.ADD: return "+ " + str(val)
        if type == OperationType.MULT: return "* " + str(val)
        return "* old"

    def perform(self, val):
        if self.type == OperationType.ADD:
            return val + self.operand
        if self.type == OperationType.MULT:
            return val * self.operand
        return val * val

    def __str__(self):
        return "new = old " + Operation.getOpStr(self.type, self.operand)