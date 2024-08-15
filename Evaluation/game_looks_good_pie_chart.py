import sys
import matplotlib

matplotlib.use("Agg")


import matplotlib.pyplot as plt
import numpy as np

# Credit: https://www.w3schools.com/python/matplotlib_pie_charts.asp

# y = np.array([8, 2, 1]) # week 14; laste category denotes "Neither agree or disagree"
y = np.array([5, 2]) # week 18 
mylabels = ["Looks Good", "Partially Looks Good"]

plt.pie(y, labels=mylabels, startangle=90)
plt.show()

plt.savefig(sys.stdout.buffer)
sys.stdout.flush()
