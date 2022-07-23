from random import random

N = 1000_000
x = 0
for i in range(0, N):
    y = random() * 8
    y = 16 - (y - 4) * (y - 4)
    x += y 

x /= N
x *= 8
print("integral: ", x)
