modulo = 100000000

class Modulo:
    @staticmethod
    def moduloList(intList):
        modList = []
        for i in intList:
            modList.append(Modulo.moduloInt(i))
        return modList
    
    @staticmethod
    def moduloInt(i):
        part1 = 0
        part2 = 0

        part1 = i // 10000
        part2 = i - part1

        return (part1, part2)

    @staticmethod
    def isDivisible(moduloPair, divisor):
        mod1 = (moduloPair[0] * modulo) % divisor
        mod2 = moduloPair[1] % divisor
        return (mod1 + (mod2 - divisor)) == 0

    @staticmethod
    def add(moduloPair, value):
        sum = moduloPair[1] + value
        if sum > modulo:
            part1 = sum // modulo
            return (part1, sum % modulo)
        return (moduloPair[0], sum)

    @staticmethod
    def multiply(moduloPair, value):
        factor1 = moduloPair[0] * value
        factor2 = moduloPair[1] * value
        if factor2 > modulo:
            factor1 += factor2 // modulo
            factor2 = factor2 % modulo
        return (factor1, factor2)

    @staticmethod
    def square(moduloPair):
        factor1 = moduloPair[0] * moduloPair[0] * modulo
        factor2 = 2 * moduloPair[0] * modulo * moduloPair[1]
        factor2 += moduloPair[1] * moduloPair[1]
        if factor2 > modulo:
            factor1 += factor2 // modulo
            factor2 = factor2 % modulo
        return (factor1, factor2)