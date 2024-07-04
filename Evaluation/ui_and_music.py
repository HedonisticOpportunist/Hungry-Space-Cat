from wordcloud import WordCloud, STOPWORDS
import matplotlib.pyplot as plt

# create an array of adjectives and other descriptive words 
ui_and_music = ["great", "nice", "good", "nice"]

# join the array with any empty spaces
ui_and_music = " ".join(ui_and_music)

# set stopwords
stopwords = set(STOPWORDS)

# set up the word cloud
wordcloud = WordCloud(background_color="cyan", stopwords=stopwords).generate(
    ui_and_music
)

# plot the WordCloud image
plt.figure(figsize=(4, 4), facecolor=None)
plt.imshow(wordcloud, interpolation="bilinear")
plt.axis("off")
plt.tight_layout(pad=0)

plt.show()
