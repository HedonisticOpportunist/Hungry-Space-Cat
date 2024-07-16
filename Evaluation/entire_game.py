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
    "nice",
    "accessible",
    "fun",
    "playable",
    "challenging",
    "good",
    "mature",
    "fun",
    "better gameplay experience and challenge",
    "nice variety of enemies to face",
    "alright",
    "excellent job showing damage",
    "game idea itself is excellent",
    "unique",
    "good",
    "playable",
    "good",
    "fast-paced",
    "good",
    "responsive",
    "challenging",
    "right",
    "fine",
    "good",
    "good",
    "simple",
    "fun",
    "good variety of enemy types",
    "fun game to play",
    "good",
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
