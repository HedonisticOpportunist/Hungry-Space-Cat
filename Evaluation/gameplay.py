from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives
gameplay = [
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
    "good",
    "easy",
    "understandable",
    "good",
    "simple",
    "functional",
    "well-developed",
    "interactive",
    "enjoyable",
    "fun",
    "complete",
    "fun"
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

