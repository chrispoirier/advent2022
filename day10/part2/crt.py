from instruction import Instruction, Operation
import math

class Crt:
    instructions = []
    spritePos = 1
    cycle = 0
    pixels = []

    def __init__(self):
        for i in range(6):
            self.pixels.append(['.' for j in range(40)])

    def run(self):
        for inst in self.instructions:
            if inst.operation == Operation.NOOP:
                #print("noop")
                self.cycle += 1
                self.setPixel()
            if inst.operation == Operation.ADDX:
                #print("addx")
                self.cycle += 1
                self.setPixel()
                self.cycle += 1
                self.setPixel()
                self.spritePos += inst.signal

    def setPixel(self):
        horiz = (self.cycle-1) % 40
        vert = math.floor(self.cycle/40) % 6
        if horiz == self.spritePos or horiz-1 == self.spritePos or horiz+1 == self.spritePos:
            self.pixels[vert][horiz] = '#'
            #print("set (" + str(horiz) + "," + str(vert) + "): sprint = " + str(self.spritePos))

    def render(self):
        for pixLine in self.pixels:
            print("".join(str(pixel) for pixel in pixLine))


    @staticmethod
    def fromData(data):
        crt = Crt()
        for dline in data:
            crt.instructions.append(Instruction(dline))
        return crt