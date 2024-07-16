from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives
graphics = [
    "lovely",
    "velvety",
    "good",
    "cartoony",
    "nice",
    "cute",
    "nice",
    "great",
    "nice",
    "good",
    "awesome",
    "straightforward",
    "customisable",
    "nice",
]

# join the array with any empty spaces
graphics = " ".join(graphics)

# set stopwords
stopwords = set(STOPWORDS)

# set up the word cloud
wordcloud = WordCloud(background_color="lightblue", stopwords=stopwords).generate(
    graphics
)

# plot the WordCloud image
plt.figure(figsize=(6, 6), facecolor=None)
plt.imshow(wordcloud, interpolation="bilinear")
plt.axis("off")
plt.tight_layout(pad=0)

plt.show()
