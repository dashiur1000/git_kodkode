import  pandas as pd
a = [1, 7, 2]
data = {
  "speed": [50, 40, 45],
  "heading": [100, 359, 164.5]
}

my = pd.DataFrame(data, index= [11, 12, 13],)
my["speed_kmh"] = my["speed"] * 2
print(my)