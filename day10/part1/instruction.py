from enum import Enum
import re

class Operation(Enum):
    NOOP=1,
    ADDX=2

class Instruction:
    operation=0
    signal=0

    def __init__(self, inst):
        noopMatch = re.match("noop", inst)
        addxMatch = re.match("addx (-?\d+)", inst)

        if noopMatch != None:
            self.operation = Operation.NOOP
        else:
            if addxMatch != None:
                self.operation = Operation.ADDX
                self.signal = int(addxMatch.groups()[0])

    def __str__(self):
        if self.operation == Operation.NOOP: return "noop"
        else: return "addx " + str(self.signal)