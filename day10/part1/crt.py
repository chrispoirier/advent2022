from instruction import Instruction, Operation

class Crt:
    instructions = []
    x = 1
    cycle = 0

    def run(self):
        interesting = []
        for inst in self.instructions:
            if inst.operation == Operation.NOOP:
                self.cycle += 1
                if (self.cycle - 20) % 40 == 0: interesting.append(self.x * self.cycle)
            if inst.operation == Operation.ADDX:
                self.cycle += 2
                if (self.cycle - 20) % 40 == 0: interesting.append(self.x * self.cycle)
                if (self.cycle - 21) % 40 == 0: interesting.append(self.x * (self.cycle-1))
                self.x += inst.signal
        return sum(interesting)


    @staticmethod
    def fromData(data):
        crt = Crt()
        for dline in data:
            crt.instructions.append(Instruction(dline))
        return crt