import sys
import matplotlib

matplotlib.use("Agg")


import matplotlib.pyplot as plt
import numpy as np

y = np.array([3, 1])
mylabels = ["Looks good", "Partially looks good"]

plt.pie(y, labels=mylabels, startangle=90)
plt.show()

plt.savefig(sys.stdout.buffer)
sys.stdout.flush()
