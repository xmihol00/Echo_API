from random import random
import math

N = 1_000_000
inside = 0

for i in range(0, N):
    x = random()
    y = random()
    if x*x + y*y < 1:
        inside += 1

print("pi: ", inside / N * 4)

res = 0
for i in range(0, N):
    x = random()
    res += math.sqrt(1 - x*x) * 4

print("pi: ", res / N)


