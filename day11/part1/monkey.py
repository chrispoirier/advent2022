from operation import Operation
import re
import math

class Monkey:
	itemWorries = []
	operation = None
	testDivisible = None
	trueMonkey = None
	falseMonkey = None
	numInspected = 0

	def __init__(self, data):
		worriesMatch = re.search("items: (.*)", data[0])
		if worriesMatch != None:
			self.itemWorries = list(map(int, worriesMatch.groups()[0].split(",")))

		opMatch = re.search("Operation: (.*)", data[1])
		if opMatch != None:
			self.operation = Operation(opMatch.groups()[0])

		testMatch = re.search("by (\\d+)", data[2])
		if testMatch != None:
			self.testDivisible = int(testMatch.groups()[0])

		trueMatch = re.search("monkey (\\d+)", data[3])
		if trueMatch != None:
			self.trueMonkey = int(trueMatch.groups()[0])

		falseMatch = re.search("monkey (\\d+)", data[4])
		if falseMatch != None:
			self.falseMonkey = int(falseMatch.groups()[0])

	def __str__(self):
		monkeyStr = "Items: " + str(self.itemWorries) + "\n"
		monkeyStr += "Operation: " + str(self.operation) + "\n"
		monkeyStr += "If div by " + str(self.testDivisible) + " then " + str(self.trueMonkey) + " else " + str(self.falseMonkey) + "\n"
		return monkeyStr

	def inspectItem(self):
		self.numInspected += 1
		itemWorry = self.operation.perform(self.itemWorries.pop(0))
		itemWorry = math.floor(itemWorry / 3)
		if itemWorry % self.testDivisible == 0:
			return (self.trueMonkey, itemWorry)
		else:
			return (self.falseMonkey, itemWorry)