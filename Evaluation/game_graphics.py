from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives and other descriptive words
graphics = ["lovely", "palette feels like velvet", "good", "cartoony", "nice", "cute"]

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
