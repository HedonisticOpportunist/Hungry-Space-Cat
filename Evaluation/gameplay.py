from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives and other descriptive words
gameplay = [
    "accessible",
    "fun",
    "playable",
    "challenging",
    "good",
    "mature",
    "fun",
    "better gameplay experience and challenge",
    "nice variety of enemies to face",
    "feels like a prototype",
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
]

# join the array with any empty spaces
gameplay = " ".join(gameplay)

# set stopwords
stopwords = set(STOPWORDS)

# set up the word cloud
wordcloud = WordCloud(background_color="white", stopwords=stopwords).generate(gameplay)

# plot the WordCloud image
plt.figure(figsize=(7, 7), facecolor=None)
plt.imshow(wordcloud, interpolation="bilinear")
plt.axis("off")
plt.tight_layout(pad=0)

plt.show()
