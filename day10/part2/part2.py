from crt import Crt

input = open("input", "r")
data = input.readlines()
crt = Crt.fromData(data)
crt.run()
crt.render()