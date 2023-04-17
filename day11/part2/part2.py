from game import Game

input = open("input", "r")
data = input.readlines()
game = Game.fromData(data)
#print(str(game))
game.run(10000)
#print(str(game))
print("Monkey business: " + str(game.monkeyBusiness()))