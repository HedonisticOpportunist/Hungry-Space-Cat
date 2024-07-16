from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives to describe the game
words = [
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
    "accessible",
    "fun",
    "playable",
    "challenging",
    "good",
    "mature",
    "fun",
    "alright",
    "unique",
    "charming",
    "good",
    "playable",
    "good",
    "fast-paced",
    "good",
    "responsive",
    "challenging",
    "fine",
    "good",
    "purposeful",
    "simple",
    "fun",
    "fun",
    "easy",
    "understandable",
    "good",
    "simple",
    "functional",
    "well-developed",
    "interactive"
    "enjoyable"
]

# join the array with any empty spaces
words = " ".join(words)
# print(words)

# set stopwords
stopwords = set(STOPWORDS)

# set up the word cloud
wordcloud = WordCloud(background_color="beige", stopwords=stopwords).generate(words)

# plot the word cloud image
plt.figure(figsize=(8, 8), facecolor=None)
plt.imshow(wordcloud, interpolation="bilinear")
plt.axis("off")
plt.tight_layout(pad=0)

plt.show()
