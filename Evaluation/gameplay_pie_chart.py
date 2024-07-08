import sys
import matplotlib

matplotlib.use("Agg")


import matplotlib.pyplot as plt
import numpy as np

# Credit: https://www.w3schools.com/python/matplotlib_pie_charts.asp

y = np.array([4])
mylabels = ["Game is playable"]

plt.pie(y, labels=mylabels, startangle=90)
plt.show()

plt.savefig(sys.stdout.buffer)
sys.stdout.flush()
